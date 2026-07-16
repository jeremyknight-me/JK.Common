#!/usr/bin/env -S dotnet --

#:property PublishAot=false
#:property PackAsTool=false
#:property TargetFramework=net10.0
#:property ImplicitUsings=enable

#:include cs/*.cs

#:package System.CommandLine@2.*
#:package Fluid.Core@2.*

using System.CommandLine;
using System.Xml.Linq;
using System.Text;


RootCommand rootCommand = new("Generate Markdown wiki from XML documentation.");
Option<string[]> filesOption = new("--files")
{
    Description = "One or more paths to XML documentation files (required)",
    Required = true,
    Arity = ArgumentArity.OneOrMore,
    AllowMultipleArgumentsPerToken = true
};
Option<string> outputOption = new("--output")
{
    Description = "Output directory (default: ./docs)"
};
Option<string> templatePathOption = new("--templatePath")
{
    Description = "Path to the templates directory containing type.md and member.md",
    Required = true
};

rootCommand.Add(filesOption);
rootCommand.Add(outputOption);
rootCommand.Add(templatePathOption);
rootCommand.SetAction(parseResult =>
{
    var files = parseResult.GetValue(filesOption) ?? [];
    var output = parseResult.GetValue(outputOption) ?? "./docs";
    var templatePath = parseResult.GetValue(templatePathOption)!;
    Process(files, output, templatePath);
});

var parseResult = rootCommand.Parse(args);
return parseResult.Invoke();

void Process(string[] xmlPaths, string outputPath, string templatePath)
{
    if (!Directory.Exists(templatePath))
    {
        throw new DirectoryNotFoundException($"Templates directory not found: {templatePath}");
    }

    Console.WriteLine($"Templates: {templatePath}");
    Console.WriteLine($"XML files: {xmlPaths.Length}");
    Console.WriteLine($"Output: {outputPath}");

    var typeTemplate = Template.Load(Path.Combine(templatePath, "type.md"));
    var memberTemplate = Template.Load(Path.Combine(templatePath, "member.md"));
    int membersProcessed = 0;
    int filesCreated = 0;
    List<(string Ns, string Folder, List<NamespaceTypeEntry> Types)> allNsEntries = [];
    var cachedCsprojs = Directory.GetFiles(".", "*.csproj", SearchOption.AllDirectories);

    void AccumulateNs(Dictionary<string, List<NamespaceTypeEntry>> nsTypes, MarkdownGenerator gen)
    {
        foreach (var (ns, types) in nsTypes)
        {
            if (allNsEntries.FirstOrDefault(e => e.Ns == ns) is { Folder: not null } existing)
            {
                existing.Types.AddRange(types);
            }
            else
            {
                allNsEntries.Add((ns, gen.SimplifyNamespace(ns), [.. types]));
            }
        }
        allNsEntries.Sort((a, b) => string.Compare(a.Ns, b.Ns, StringComparison.Ordinal));
    }

    foreach (var xmlArg in xmlPaths)
    {
        var xmlPath = Path.GetFullPath(xmlArg);
        if (!File.Exists(xmlPath))
        {
            Console.WriteLine($"Skipping (not found): {xmlPath}");
            continue;
        }

        Console.WriteLine($"\nProcessing: {xmlPath}");

        var parser = new XmlDocParser();
        var (typesByGroup, rootNamespace) = parser.Parse(xmlPath);
        var projectRoot = FindProjectRoot(rootNamespace, cachedCsprojs);
        var generator = new MarkdownGenerator(typeTemplate, memberTemplate, projectRoot);
        var (m, f, nsTypes) = generator.Generate(typesByGroup, outputPath);
        membersProcessed += m;
        filesCreated += f;
        AccumulateNs(nsTypes, generator);
    }

    // Generate project-level README.md files that link to namespace folder READMEs
    var projectGroups = allNsEntries
        .GroupBy(e => e.Folder.Split('/')[0])
        .OrderBy(g => g.Key);

    foreach (var group in projectGroups)
    {
        var projectReadmePath = Path.Combine(outputPath, group.Key, "README.md");
        var projectDir = Path.GetDirectoryName(projectReadmePath)!;
        Directory.CreateDirectory(projectDir);

        StringBuilder projectReadme = new();
        projectReadme.Append($"[← Documentation](../README.md)\n\n# {group.Key}\n\n");
        var childNamespaces = group
            .Where(e => e.Folder != group.Key && e.Folder.StartsWith(group.Key + "/", StringComparison.Ordinal))
            .OrderBy(e => e.Ns)
            .ToList();

        if (childNamespaces.Count > 0)
        {
            projectReadme.Append("## Namespaces\n");
            foreach (var entry in childNamespaces)
            {
                projectReadme.Append($"- [{MarkdownGenerator.Esc(entry.Ns)}]({entry.Folder}/README.md)\n");
            }
        }

        Helpers.DeleteLegacyNamespaceFile(projectReadmePath, outputPath);
        File.WriteAllText(projectReadmePath, projectReadme.ToString());
        Console.WriteLine($"Generated: {projectReadmePath}");
        filesCreated++;
    }

    StringBuilder rootReadme = new("# Documentation\n\nThis documentation is automatically generated from XML documentation.\n");
    foreach (var group in projectGroups)
    {
        rootReadme.Append($"\n## {group.Key}\n");
        foreach (var entry in group.OrderBy(e => e.Ns))
        {
            rootReadme.Append($"\n### [{entry.Ns}]({entry.Folder}/README.md)\n");
            foreach (var entry2 in entry.Types.OrderBy(x => x.DisplayName))
            {
                rootReadme.Append($"- [{MarkdownGenerator.Esc(entry2.DisplayName)}]({entry.Folder}/{entry2.FileName}.md)\n");
            }
        }
    }
    var rootPath = Path.Combine(outputPath, "README.md");
    File.WriteAllText(rootPath, rootReadme.ToString());
    Console.WriteLine($"Generated: {rootPath}");
    filesCreated++;

    Console.WriteLine($"\nDone. Members: {membersProcessed}, Files: {filesCreated}");
    Console.WriteLine($"README: {Path.GetFullPath(rootPath)}");
}

ProjectInfo FindProjectRoot(string rootNamespace, string[] csprojFiles)
{
    foreach (var csproj in csprojFiles)
    {
        var doc = XDocument.Load(csproj);
        var root = doc.Root!;
        var ns = root.Name.Namespace;
        var rn = root.Descendants(ns + "RootNamespace").FirstOrDefault()?.Value;
        var an = root.Descendants(ns + "AssemblyName").FirstOrDefault()?.Value;
        var pn = Path.GetFileNameWithoutExtension(csproj);
        if (string.Equals(rn ?? an ?? pn, rootNamespace, StringComparison.Ordinal))
        {
            return new ProjectInfo(csproj, Path.GetDirectoryName(csproj)!, an ?? pn, rn, pn);
        }
    }
    return new ProjectInfo("", ".", rootNamespace, null, rootNamespace);
}
