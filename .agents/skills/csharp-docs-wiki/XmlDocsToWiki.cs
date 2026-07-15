#:property PublishAot=false
#:property PackAsTool=false
#:property TargetFramework=net10.0
#:property ImplicitUsings=enable

using System.Xml.Linq;
using System.Text.RegularExpressions;

// ── Entry Point ──

<<<<<<< HEAD
<<<<<<< HEAD
if (args.Length == 0 || args[0] == "--help" || args[0] == "-h")
{
    Console.WriteLine("Usage: dotnet run --file XmlDocsToWiki.cs -- --files <xml-file> [xml-file ...] [--output <path>]");
    Console.WriteLine();
    Console.WriteLine("  --files    One or more paths to XML documentation files (required)");
    Console.WriteLine("  --output   Output directory (default: ./docs)");
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
if (args.Length == 0 || (!File.Exists(args[0]) && !args[0].EndsWith(".xml", StringComparison.OrdinalIgnoreCase)))
{
    Console.WriteLine("Usage: dotnet run --file XmlDocsToWiki.cs -- <xml-file> [xml-file2 ...] [output-path]");
    Console.WriteLine();
    Console.WriteLine("  xml-file   Path(s) to XML documentation files (one or more)");
    Console.WriteLine("  output-path  Output directory (default: ./docs)");
<<<<<<< HEAD
>>>>>>> updated skill
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    Console.WriteLine();
    Console.WriteLine("The agent should build projects first, then pass the resulting XML files here.");
    return;
}

var xmlPaths = new List<string>();
var outputPath = "./docs";

for (int i = 0; i < args.Length; i++)
{
<<<<<<< HEAD
<<<<<<< HEAD
    if (args[i] == "--files")
    {
        while (i + 1 < args.Length && !args[i + 1].StartsWith("--"))
        {
            i++;
            xmlPaths.Add(args[i]);
        }
    }
    else if (args[i] == "--output")
    {
        if (i + 1 < args.Length)
        {
            i++;
            outputPath = args[i];
        }
        else
        {
            Console.WriteLine("Error: --output requires a value.");
            return;
        }
    }
    else
    {
        Console.WriteLine($"Warning: ignoring unrecognized argument '{args[i]}'.");
    }
}

if (xmlPaths.Count == 0)
{
    Console.WriteLine("Error: no XML files specified. Use --files <file> [file ...].");
    return;
}

var templatesDir = FindTemplates()
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    if (File.Exists(args[i]) || args[i].EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
        xmlPaths.Add(args[i]);
    else
        outputPath = args[i];
}

var templatesDir = FindTemplates(null)
<<<<<<< HEAD
>>>>>>> updated skill
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    ?? throw new DirectoryNotFoundException("Could not find templates/ folder. Run from the repo root or next to the skill folder.");
var typeTemplate = Template.Load(Path.Combine(templatesDir, "type.md"));
var memberTemplate = Template.Load(Path.Combine(templatesDir, "member.md"));

Console.WriteLine($"Templates: {templatesDir}");
Console.WriteLine($"XML files: {xmlPaths.Count}");
Console.WriteLine($"Output: {outputPath}");

int membersProcessed = 0;
int filesCreated = 0;
var allNsEntries = new List<(string Ns, string Folder, List<(string displayName, string fileName)> Types)>();
<<<<<<< HEAD
<<<<<<< HEAD
var cachedCsprojs = Directory.GetFiles(".", "*.csproj", SearchOption.AllDirectories);
=======
>>>>>>> updated skill
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

void AccumulateNs(Dictionary<string, List<(string displayName, string fileName)>> nsTypes, MarkdownGenerator gen)
{
    foreach (var (ns, types) in nsTypes)
    {
        var existing = allNsEntries.FirstOrDefault(e => e.Ns == ns);
        if (existing.Folder != null)
        {
            existing.Types.AddRange(types);
<<<<<<< HEAD
}
else
{
            allNsEntries.Add((ns, gen.SimplifyNamespace(ns), new List<(string, string)>(types)));
    }
=======
        }
        else
        {
            allNsEntries.Add((ns, gen.SimplifyNamespace(ns), new List<(string, string)>(types)));
        }
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    }
    allNsEntries.Sort((a, b) => string.Compare(a.Ns, b.Ns, StringComparison.Ordinal));
}

<<<<<<< HEAD

foreach (var xmlArg in xmlPaths)
<<<<<<< HEAD
    {
    var xmlPath = Path.GetFullPath(xmlArg);
    if (!File.Exists(xmlPath))
        {
        Console.WriteLine($"Skipping (not found): {xmlPath}");
            continue;
        }

    Console.WriteLine($"\nProcessing: {xmlPath}");

        Console.WriteLine($"  Parsing: {xmlPath}");
        var parser = new XmlDocParser();
    var (typesByGroup, rootNamespace) = parser.Parse(xmlPath);
    var projectRoot = FindProjectRoot(rootNamespace, cachedCsprojs);

    var generator = new MarkdownGenerator(typeTemplate, memberTemplate, projectRoot);
    var (m, f, nsTypes) = generator.Generate(typesByGroup, outputPath);
        membersProcessed += m;
        filesCreated += f;
    AccumulateNs(nsTypes, generator);
    }
=======
=======
string Esc(string s) => s.Replace("<", "\\<").Replace(">", "\\>");

foreach (var xmlArg in xmlPaths)
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
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
    var projectRoot = FindProjectRoot(rootNamespace);

    var generator = new MarkdownGenerator(typeTemplate, memberTemplate, projectRoot);
    var (m, f, nsTypes) = generator.Generate(typesByGroup, outputPath);
    membersProcessed += m;
    filesCreated += f;
    AccumulateNs(nsTypes, generator);
<<<<<<< HEAD
>>>>>>> updated skill
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
}

// Generate root README.md grouped by project
var projectGroups = allNsEntries
    .GroupBy(e => e.Folder.Split('/')[0])
    .OrderBy(g => g.Key);

<<<<<<< HEAD
var rootReadme = new System.Text.StringBuilder("# Documentation\n\nThis documentation is automatically generated from XML documentation.\n");
foreach (var group in projectGroups)
{
    rootReadme.Append($"\n## {group.Key}\n");
    foreach (var entry in group.OrderBy(e => e.Ns))
    {
        rootReadme.Append($"\n### [{entry.Ns}]({entry.Folder}/README.md)\n");
        foreach (var entry2 in entry.Types.OrderBy(x => x.displayName))
            rootReadme.Append($"- [{MarkdownGenerator.Esc(entry2.displayName)}]({entry.Folder}/{entry2.fileName}.md)\n");
    }
}
var rootPath = Path.Combine(outputPath, "README.md");
File.WriteAllText(rootPath, rootReadme.ToString());
=======
var rootReadme = "# Documentation\n\nThis documentation is automatically generated from XML documentation.\n";
foreach (var group in projectGroups)
{
    rootReadme += $"\n## {group.Key}\n";
    foreach (var entry in group.OrderBy(e => e.Ns))
    {
        rootReadme += $"\n### [{entry.Ns}]({entry.Folder}/README.md)\n";
        foreach (var entry2 in entry.Types.OrderBy(x => x.displayName))
            rootReadme += $"- [{Esc(entry2.displayName)}]({entry.Folder}/{entry2.fileName}.md)\n";
    }
}
var rootPath = Path.Combine(outputPath, "README.md");
File.WriteAllText(rootPath, rootReadme);
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
Console.WriteLine($"Generated: {rootPath}");
filesCreated++;

Console.WriteLine($"\nDone. Members: {membersProcessed}, Files: {filesCreated}");
Console.WriteLine($"README: {Path.GetFullPath(rootPath)}");

<<<<<<< HEAD
string? FindTemplates()
=======
string? FindTemplates(string? startDir)
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
{
    var dir = Directory.GetCurrentDirectory();
    for (int i = 0; i < 10; i++)
    {
        // Check current dir and src/ subdirectory for solution file
        var hasSln = Directory.GetFiles(dir, "*.sln").Length > 0
            || Directory.GetFiles(dir, "*.slnx").Length > 0
            || Directory.Exists(Path.Combine(dir, "src")) && (
                Directory.GetFiles(Path.Combine(dir, "src"), "*.sln").Length > 0
                || Directory.GetFiles(Path.Combine(dir, "src"), "*.slnx").Length > 0);

        if (hasSln)
        {
            var candidate = Path.Combine(dir, ".agents", "skills", "csharp-docs-wiki", "templates", "type.md");
            if (File.Exists(candidate)) return Path.Combine(dir, ".agents", "skills", "csharp-docs-wiki", "templates");
            break;
        }
        var parent = Directory.GetParent(dir);
        if (parent == null) break;
        dir = parent.FullName;
    }
    return null;
}

<<<<<<< HEAD
<<<<<<< HEAD
static int RunBuild(string csprojPath)
{
    var psi = new System.Diagnostics.ProcessStartInfo("dotnet", $"build \"{csprojPath}\" -f net10.0 -c Debug --nologo -v q")
    {
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };
    using var process = System.Diagnostics.Process.Start(psi)!;
    process.WaitForExit();
    return process.ExitCode;
}

ProjectInfo FindProjectRoot(string rootNamespace, string[] csprojFiles)
    {
    foreach (var csproj in csprojFiles)
    {
        if (csproj.Contains(".Tests.")) continue;
        var doc = XDocument.Load(csproj);
        var root = doc.Root!;
        var ns = root.Name.Namespace;
        var genDoc = root.Descendants(ns + "GenerateDocumentationFile")
            .FirstOrDefault()?.Value;
        if (!string.Equals(genDoc, "true", StringComparison.OrdinalIgnoreCase)) continue;

        var rootNamespace = root.Descendants(ns + "RootNamespace").FirstOrDefault()?.Value;
        var assemblyName = root.Descendants(ns + "AssemblyName").FirstOrDefault()?.Value;
        var projectName = Path.GetFileNameWithoutExtension(csproj);
        var projectDir = Path.GetDirectoryName(csproj)!;

        projects.Add(new ProjectInfo
        {
            CsprojPath = csproj,
            ProjectDir = projectDir,
            AssemblyName = assemblyName ?? projectName,
            RootNamespace = rootNamespace,
            ProjectName = projectName
        });
    }
    return projects;
}

=======
>>>>>>> updated skill
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
ProjectInfo FindProjectRoot(string rootNamespace)
{
    foreach (var csproj in Directory.GetFiles(".", "*.csproj", SearchOption.AllDirectories))
    {
        var doc = XDocument.Load(csproj);
        var root = doc.Root!;
        var ns = root.Name.Namespace;
        var rn = root.Descendants(ns + "RootNamespace").FirstOrDefault()?.Value;
        var an = root.Descendants(ns + "AssemblyName").FirstOrDefault()?.Value;
        var pn = Path.GetFileNameWithoutExtension(csproj);
        if (string.Equals(rn ?? an ?? pn, rootNamespace, StringComparison.Ordinal))
        {
            return new ProjectInfo
            {
                CsprojPath = csproj,
                ProjectDir = Path.GetDirectoryName(csproj)!,
                AssemblyName = an ?? pn,
                RootNamespace = rn,
                ProjectName = pn
            };
        }
    }
    return new ProjectInfo { ProjectName = rootNamespace, AssemblyName = rootNamespace, RootNamespace = null, ProjectDir = ".", CsprojPath = "" };
}

<<<<<<< HEAD
static partial class Regexes
{
    [GeneratedRegex(@"\{#each\s+(\w+)\}")]
    public static partial Regex Each();
    [GeneratedRegex(@"\{#if\s+(\w+)\}")]
    public static partial Regex If();
    [GeneratedRegex(@"\{(\w+(?:\.\w+)*)\}")]
    public static partial Regex Var();
    [GeneratedRegex(@"\n{3,}")]
    public static partial Regex Newlines();
    [GeneratedRegex(@"_\d+$")]
    public static partial Regex TrailingGeneric();
    [GeneratedRegex(@"`+(\d+)")]
    public static partial Regex GenericArg();
    [GeneratedRegex(@"`{2,}(\d+)")]
    public static partial Regex MethodGenericArg();
    [GeneratedRegex(@"`+\d+")]
    public static partial Regex GenericTick();
    [GeneratedRegex(@"^[TMPFE]:")]
    public static partial Regex CrefPrefix();
    [GeneratedRegex(@"\(.*$")]
    public static partial Regex CrefParams();
    [GeneratedRegex(@"[:""|?*]")]
    public static partial Regex UnsafeChars();
    [GeneratedRegex(@"\((.+)\)$")]
    public static partial Regex MethodParams();
    [GeneratedRegex(@"\[\]$")]
    public static partial Regex TrailingArray();
    [GeneratedRegex(@".*\.(\w+)`?\d*\[")]
    public static partial Regex GenericArray();
    [GeneratedRegex(@"\]$")]
    public static partial Regex TrailingBracket();
}

// ── Model ──

record ParamInfo(string Name, string Description);
record ExceptionInfo(string Type, string Description);

=======
// ── Model ──

>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
class ProjectInfo
{
    public required string CsprojPath { get; set; }
    public required string ProjectDir { get; set; }
    public required string AssemblyName { get; set; }
    public string? RootNamespace { get; set; }
    public required string ProjectName { get; set; }
    public string TopLevelFolder => RootNamespace ?? ProjectName;
}

class TypeDoc
{
    public string Namespace { get; set; } = "";
    public string TypeName { get; set; } = "";
    public string Summary { get; set; } = "";
    public string Remarks { get; set; } = "";
<<<<<<< HEAD
    public List<ParamInfo> TypeParams { get; set; } = new();
=======
    public List<Dictionary<string, string>> TypeParams { get; set; } = new();
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    public List<string> TypeParamNames { get; set; } = new();
    public string GenericDisplayName
    {
        get
        {
<<<<<<< HEAD
            var baseName = Regexes.TrailingGeneric().Replace(TypeName, "");
=======
            var baseName = Regex.Replace(TypeName, @"_\d+$", "");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            return TypeParamNames.Count > 0
                ? $"{baseName}<{string.Join(", ", TypeParamNames)}>"
                : baseName;
        }
    }
    public List<MemberDoc> Constructors { get; set; } = new();
    public List<MemberDoc> Methods { get; set; } = new();
    public List<MemberDoc> Properties { get; set; } = new();
    public List<MemberDoc> Events { get; set; } = new();
    public List<MemberDoc> Fields { get; set; } = new();
    public List<TypeDoc> NestedTypes { get; set; } = new();
}

class MemberDoc
{
    public string DisplayName { get; set; } = "";
<<<<<<< HEAD
    public string Heading { get; set; } = "";
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    public string InheritedSuffix { get; set; } = "";
    public string Signature { get; set; } = "";
    public string Summary { get; set; } = "";
    public string Remarks { get; set; } = "";
    public string Returns { get; set; } = "";
<<<<<<< HEAD
    public List<ParamInfo> Params { get; set; } = new();
    public List<ExceptionInfo> Exceptions { get; set; } = new();
=======
    public List<Dictionary<string, string>> Params { get; set; } = new();
    public List<Dictionary<string, string>> Exceptions { get; set; } = new();
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    public string Example { get; set; } = "";
    public List<string> SeeAlso { get; set; } = new();
    public bool HasParams => Params.Count > 0;
    public bool HasReturns => !string.IsNullOrWhiteSpace(Returns);
<<<<<<< HEAD
    public bool HasRemarks => !string.IsNullOrWhiteSpace(Remarks);
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    public bool HasExceptions => Exceptions.Count > 0;
    public bool HasExample => !string.IsNullOrWhiteSpace(Example);
}

// ── Template Engine ──

class Template
{
    private readonly string _raw;

    private Template(string raw) => _raw = raw;

    public static Template Load(string path) => new(File.ReadAllText(path));

<<<<<<< HEAD
    public string Render(Dictionary<string, object?> context) => RenderTemplate(_raw, context, clean: true);

    private static string RenderTemplate(string template, Dictionary<string, object?> context, bool clean)
    {
        var result = template;

        while (Regexes.Each().IsMatch(result))
        {
            var match = Regexes.Each().Match(result);
=======
    public string Render(Dictionary<string, object?> context)
    {
        var result = _raw;

        while (Regex.IsMatch(result, @"\{#each\s+(\w+)\}"))
        {
            var match = Regex.Match(result, @"\{#each\s+(\w+)\}");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            var key = match.Groups[1].Value;
            var openEnd = match.Index + match.Length;
            var closeTag = FindClosingTag(result, openEnd, "{#each", "{/each}");
            if (closeTag < 0) break;

            var inner = result.Substring(openEnd, closeTag - openEnd);
            var items = GetListValue(context, key);
            var replacement = items.Count > 0
<<<<<<< HEAD
                ? string.Join("\n", items.Select(item => RenderTemplate(inner, item, clean: false)))
=======
                ? string.Join("\n", items.Select(item => RenderSingle(inner, item)))
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                : "";
            result = result.Substring(0, match.Index) + replacement + result.Substring(closeTag + "{/each}".Length);
        }

<<<<<<< HEAD
        while (Regexes.If().IsMatch(result))
        {
            var match = Regexes.If().Match(result);
=======
        while (Regex.IsMatch(result, @"\{#if\s+(\w+)\}"))
        {
            var match = Regex.Match(result, @"\{#if\s+(\w+)\}");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            var key = match.Groups[1].Value;
            var openEnd = match.Index + match.Length;
            var closeTag = FindClosingTag(result, openEnd, "{#if", "{/if}");
            if (closeTag < 0) break;

            var inner = result.Substring(openEnd, closeTag - openEnd);
            var truthy = IsTruthy(context, key);
            var replacement = truthy ? inner : "";
            result = result.Substring(0, match.Index) + replacement + result.Substring(closeTag + "{/if}".Length);
        }

<<<<<<< HEAD
        result = Regexes.Var().Replace(result, m =>
        {
            var key = m.Groups[1].Value;
            if (key.All(char.IsDigit)) return m.Value;
            var val = GetNestedValue(context, key);
            return val ?? "";
        });

        return clean ? CleanOutput(result) : result;
=======
        result = Regex.Replace(result, @"\{(\w+(?:\.\w+)*)\}", m =>
        {
            var val = GetNestedValue(context, m.Groups[1].Value);
            return val ?? "";
        });

        return CleanOutput(result);
    }

    private string RenderSingle(string template, Dictionary<string, object?> item)
    {
        var result = template;

        while (Regex.IsMatch(result, @"\{#each\s+(\w+)\}"))
        {
            var match = Regex.Match(result, @"\{#each\s+(\w+)\}");
            var key = match.Groups[1].Value;
            var openEnd = match.Index + match.Length;
            var closeTag = FindClosingTag(result, openEnd, "{#each", "{/each}");
            if (closeTag < 0) break;

            var inner = result.Substring(openEnd, closeTag - openEnd);
            var items = GetListValue(item, key);
            var replacement = items.Count > 0
                ? string.Join("\n", items.Select(child => RenderSingle(inner, child)))
                : "";
            result = result.Substring(0, match.Index) + replacement + result.Substring(closeTag + "{/each}".Length);
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
        }

        while (Regex.IsMatch(result, @"\{#if\s+(\w+)\}"))
        {
            var match = Regex.Match(result, @"\{#if\s+(\w+)\}");
            var key = match.Groups[1].Value;
            var openEnd = match.Index + match.Length;
            var closeTag = FindClosingTag(result, openEnd, "{#if", "{/if}");
            if (closeTag < 0) break;

            var inner = result.Substring(openEnd, closeTag - openEnd);
            var truthy = IsTruthy(item, key);
            var replacement = truthy ? inner : "";
            result = result.Substring(0, match.Index) + replacement + result.Substring(closeTag + "{/if}".Length);
        }

        result = Regex.Replace(result, @"\{(\w+(?:\.\w+)*)\}", m =>
        {
            var val = GetNestedValue(item, m.Groups[1].Value);
            return val ?? "";
        });

        return CleanOutput(result);
    }

    private static string CleanOutput(string text)
    {
<<<<<<< HEAD
        text = text.Replace("\r\n", "\n");
        return Regexes.Newlines().Replace(text, "\n\n").Trim();
=======
        return Regex.Replace(text, @"\n{3,}", "\n\n").Trim();
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    }

    private static int FindClosingTag(string text, int start, string openTag, string closeTag)
    {
        int depth = 1;
        int pos = start;
        while (depth > 0 && pos < text.Length)
        {
            var nextOpen = text.IndexOf(openTag, pos);
            var nextClose = text.IndexOf(closeTag, pos);
            if (nextClose < 0) return -1;
            if (nextOpen >= 0 && nextOpen < nextClose)
            {
                depth++;
                pos = nextOpen + openTag.Length;
            }
            else
            {
                depth--;
                if (depth == 0) return nextClose;
                pos = nextClose + closeTag.Length;
            }
        }
        return -1;
    }

    private static bool IsTruthy(Dictionary<string, object?> ctx, string key)
    {
        if (!ctx.TryGetValue(key, out var val) || val == null) return false;
        if (val is bool b) return b;
        if (val is string s) return s.Length > 0;
        if (val is System.Collections.IList list) return list.Count > 0;
        return true;
    }

    private static string? GetNestedValue(Dictionary<string, object?> ctx, string path)
    {
        var parts = path.Split('.');
        object? current = ctx;
        foreach (var part in parts)
        {
            if (current is Dictionary<string, object?> dict && dict.TryGetValue(part, out var next))
                current = next;
            else
                return null;
        }
        return current?.ToString() ?? "";
    }

    private static List<Dictionary<string, object?>> GetListValue(Dictionary<string, object?> ctx, string key)
    {
        if (!ctx.TryGetValue(key, out var val)) return new();
        if (val is List<Dictionary<string, object?>> list) return list;
<<<<<<< HEAD
        if (val is List<string> strings) return strings.Select(s => new Dictionary<string, object?> { ["Value"] = s }).ToList();
=======
        if (val is List<Dictionary<string, string>> stringDicts)
            return stringDicts.Select(s => s.ToDictionary(kv => kv.Key, kv => (object?)kv.Value)).ToList();
        if (val is List<string> strings) return strings.Select(s => new Dictionary<string, object?> { ["."] = s }).ToList();
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
        return new();
    }
}

// ── XML Parser ──

class XmlDocParser
{
<<<<<<< HEAD
=======
    private readonly Dictionary<string, bool> _typeMap = new();
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    private readonly Dictionary<string, XElement> _generatedMembers = new();

    public (Dictionary<string, TypeDoc> types, string rootNamespace) Parse(string xmlPath)
    {
        var doc = XDocument.Load(xmlPath);
        var types = new Dictionary<string, TypeDoc>();
        string rootNamespace = doc.Root?.Element("assembly")?.Element("name")?.Value ?? "";

<<<<<<< HEAD
        // First pass: collect members for inheritdoc resolution
        foreach (var member in doc.Descendants("member"))
        {
            var name = member.Attribute("name")?.Value;
            if (name != null)
=======
        // First pass: collect <G>$ members for inheritdoc resolution
        foreach (var member in doc.Descendants("member"))
        {
            var name = member.Attribute("name")?.Value;
            if (name != null && name.Contains("<G>$"))
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                _generatedMembers[name] = member;
        }

        // Second pass: process all members
        foreach (var member in doc.Descendants("member"))
        {
            var name = member.Attribute("name")?.Value;
            if (name == null) continue;

            var kind = name.Length >= 2 ? name.Substring(0, 2) : "";
            var full = name.Length >= 2 ? name.Substring(2) : "";

            if (kind == "N:") { if (string.IsNullOrEmpty(rootNamespace)) rootNamespace = full; continue; }
            if (full.Contains("<G>$")) continue;

            var parenIdx = full.IndexOf('(');
            var beforeParams = parenIdx >= 0 ? full.Substring(0, parenIdx) : full;

            string ns, typeName;
            if (kind == "T:")
            {
                var lastDot = beforeParams.LastIndexOf('.');
                if (lastDot < 0) continue;
                ns = beforeParams.Substring(0, lastDot);
                typeName = beforeParams.Substring(lastDot + 1);
            }
            else
            {
                var lastDot = beforeParams.LastIndexOf('.');
                if (lastDot < 0) continue;
                var secondLastDot = beforeParams.LastIndexOf('.', lastDot - 1);
                if (secondLastDot < 0) continue;
                ns = beforeParams.Substring(0, secondLastDot);
                typeName = beforeParams.Substring(secondLastDot + 1, lastDot - secondLastDot - 1);
            }

<<<<<<< HEAD
            if (ns == "System" || ns.StartsWith("System.")) continue;

            var displayTypeName = Regexes.GenericArg().Replace(typeName, "_$1");
=======
            if (ns.StartsWith("System")) continue;

            var displayTypeName = Regex.Replace(typeName, @"`(\d+)", "_$1");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            var nestedDot = typeName.IndexOf('.');
            string rootType = nestedDot >= 0 ? typeName.Substring(0, nestedDot) : typeName;
            var key = $"{ns}/{rootType}";

            if (!types.ContainsKey(key))
<<<<<<< HEAD
                types[key] = new TypeDoc { Namespace = ns, TypeName = Regexes.GenericArg().Replace(rootType, "_$1") };
=======
                types[key] = new TypeDoc { Namespace = ns, TypeName = Regex.Replace(rootType, @"`(\d+)", "_$1") };
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

            if (kind == "T:")
            {
                _typeMap[$"{ns}.{displayTypeName}"] = true;
                var typeDoc = types[key];

                foreach (var tp in member.Elements("typeparam"))
<<<<<<< HEAD
                    typeDoc.TypeParams.Add(new ParamInfo(tp.Attribute("name")?.Value ?? "", ConvertXmlToMarkdown(tp) ?? ""));

                typeDoc.TypeParamNames = typeDoc.TypeParams.Select(tp => tp.Name).ToList();
=======
                    typeDoc.TypeParams.Add(new() { ["Name"] = tp.Attribute("name")?.Value ?? "", ["Description"] = ConvertXmlToMarkdown(tp) ?? "" });

                typeDoc.TypeParamNames = typeDoc.TypeParams.Select(tp => tp["Name"]).ToList();
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

                typeDoc.Summary = ConvertXmlToMarkdown(member.Element("summary"), typeDoc.TypeParamNames) ?? typeDoc.Summary;
                typeDoc.Remarks = ConvertXmlToMarkdown(member.Element("remarks"), typeDoc.TypeParamNames) ?? typeDoc.Remarks;

                if (nestedDot >= 0)
                {
                    var parentKey = $"{ns}/{typeName.Substring(0, nestedDot)}";
                    if (!types.ContainsKey(parentKey))
<<<<<<< HEAD
                        types[parentKey] = new TypeDoc { Namespace = ns, TypeName = Regexes.GenericTick().Replace(typeName.Substring(0, nestedDot), "") };
=======
                        types[parentKey] = new TypeDoc { Namespace = ns, TypeName = Regex.Replace(typeName.Substring(0, nestedDot), @"`\d+", "") };
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                    types[parentKey].NestedTypes.Add(new TypeDoc { TypeName = displayTypeName, Summary = typeDoc.Summary, Namespace = ns });
                }
            }
            else
            {
                var typeDoc = types[key];
<<<<<<< HEAD

                // Extract method-level type params (appended after type-level params)
                var methodTypeParamNames = new List<string>(typeDoc.TypeParamNames);
                var methodGenericTypeParams = new List<string>();
                if (kind == "M:")
                {
                    var methodGenericMatch = Regexes.GenericArg().Match(beforeParams);
                    if (methodGenericMatch.Success)
                    {
                        var count = int.Parse(methodGenericMatch.Groups[1].Value);
                        for (int i = 0; i < count; i++)
                        {
                            var tpName = i == 0 ? "T" : $"T{i + 1}";
                            methodTypeParamNames.Add(tpName);
                            methodGenericTypeParams.Add(tpName);
                        }
                    }
                }

                var memberDoc = ParseMember(member, name, kind, methodTypeParamNames);
                switch (kind)
                {
                    case "M:":
                        if (memberDoc.DisplayName.StartsWith("get_") || memberDoc.DisplayName.StartsWith("set_"))
                        {
                            memberDoc.DisplayName = memberDoc.DisplayName.Substring(4);
                            memberDoc.Signature = memberDoc.DisplayName;
                            typeDoc.Properties.Add(memberDoc);
                        }
                        else if (memberDoc.DisplayName == "#ctor" || memberDoc.DisplayName == "#cctor")
                        {
                            memberDoc.DisplayName = typeDoc.GenericDisplayName;
=======
                var memberDoc = ParseMember(member, name, kind, typeDoc.TypeParamNames);
                switch (kind)
                {
                    case "M:":
                        if (memberDoc.DisplayName == ".ctor" || memberDoc.DisplayName == ".cctor")
                        {
                            memberDoc.DisplayName = typeDoc.TypeName;
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                            typeDoc.Constructors.Add(memberDoc);
                        }
                        else typeDoc.Methods.Add(memberDoc);
                        break;
                    case "P:":
                        typeDoc.Properties.Add(memberDoc);
                        break;
                    case "E:":
                        typeDoc.Events.Add(memberDoc);
                        break;
                    case "F:":
                        typeDoc.Fields.Add(memberDoc);
                        break;
                }
            }
        }

        return (types, rootNamespace);
    }

    private MemberDoc ParseMember(XElement member, string name, string kind, List<string> typeParamNames)
    {
        var full = name.Substring(2);
        var parenIdx = full.IndexOf('(');
        var beforeParams = parenIdx >= 0 ? full.Substring(0, parenIdx) : full;
        var lastDot = beforeParams.LastIndexOf('.');
        var memberPart = lastDot >= 0 ? beforeParams.Substring(lastDot + 1) : beforeParams;

<<<<<<< HEAD
        var displayName = Regexes.GenericTick().Replace(memberPart, "");

        var methodGenericArity = 0;
        var arityMatch = Regexes.GenericArg().Match(memberPart);
        if (arityMatch.Success)
            methodGenericArity = int.Parse(arityMatch.Groups[1].Value);

        var methodGenericTypeParams = new List<string>();
        if (methodGenericArity > 0)
        {
            for (int i = 0; i < methodGenericArity; i++)
                methodGenericTypeParams.Add(i == 0 ? "T" : $"T{i + 1}");
        }

        var signature = BuildSignature(full, displayName, kind, typeParamNames, methodGenericTypeParams);
=======
        var displayName = Regex.Replace(memberPart, @"`\d+", "");
        var signature = BuildSignature(full, displayName, kind, typeParamNames);
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
        var isInherited = member.Element("inheritdoc") != null;

        XElement? source = member;
        if (isInherited)
<<<<<<< HEAD
            {
            var cref = member.Element("inheritdoc")!.Attribute("cref")?.Value;
            if (cref != null && _generatedMembers.TryGetValue(cref, out var target))
            {
                source = target;
            }
            else if (cref == null)
            {
                var currentMethodName = name.Contains('.') ? name.Substring(name.LastIndexOf('.') + 1) : name;
                var inheritedMatch = _generatedMembers
                    .Where(kvp => kvp.Key != name &&
                                  kvp.Key.EndsWith($".{currentMethodName}") &&
                                  !kvp.Key.Contains("<G>$"))
                    .Select(kvp => kvp.Value)
                    .FirstOrDefault();
                if (inheritedMatch != null)
                    source = inheritedMatch;
            }
        }

        var summary = ConvertXmlToMarkdown(source.Element("summary"), typeParamNames, methodGenericTypeParams) ?? "";
        var remarks = ConvertXmlToMarkdown(source.Element("remarks"), typeParamNames, methodGenericTypeParams) ?? "";
        var returns = ConvertXmlToMarkdown(source.Element("returns"), typeParamNames, methodGenericTypeParams) ?? "";

        var paramList = source.Elements("param")
            .Select(p => new ParamInfo(
                p.Attribute("name")?.Value ?? "",
                ConvertXmlToMarkdown(p, typeParamNames, methodGenericTypeParams) ?? ""
            )).ToList();
=======
        {
            var cref = member.Element("inheritdoc")!.Attribute("cref")?.Value;
            if (cref != null && _generatedMembers.TryGetValue(cref, out var target))
                source = target;
        }

        var summary = ConvertXmlToMarkdown(source.Element("summary"), typeParamNames) ?? "";
        var remarks = ConvertXmlToMarkdown(source.Element("remarks"), typeParamNames) ?? "";
        var returns = ConvertXmlToMarkdown(source.Element("returns"), typeParamNames) ?? "";

        var paramList = source.Elements("param")
            .Select(p => new Dictionary<string, string>
            {
                ["Name"] = p.Attribute("name")?.Value ?? "",
                ["Description"] = ConvertXmlToMarkdown(p, typeParamNames) ?? ""
            }).ToList();
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

        signature = AppendParamNames(signature, paramList);

        var exceptionList = source.Elements("exception")
            .Select(e =>
            {
                var cref = e.Attribute("cref")?.Value ?? "";
<<<<<<< HEAD
                cref = Regexes.CrefPrefix().Replace(cref, "");
                cref = Regexes.CrefParams().Replace(cref, "");
                return new ExceptionInfo(cref, ConvertXmlToMarkdown(e, typeParamNames, methodGenericTypeParams) ?? "");
            }).ToList();

        var example = ConvertXmlToMarkdown(source.Element("example"), typeParamNames, methodGenericTypeParams) ?? "";
        var seeAlso = source.Elements("seealso")
            .Select(sa => sa.Attribute("cref")?.Value ?? "")
            .Where(c => c.Length > 0)
            .Select(c => Regexes.CrefParams().Replace(Regexes.CrefPrefix().Replace(c, ""), ""))
=======
                cref = Regex.Replace(cref, @"^[TMPFE]:", "");
                cref = Regex.Replace(cref, @"\(.*$", "");
                return new Dictionary<string, string>
                {
                    ["Type"] = cref,
                    ["Description"] = ConvertXmlToMarkdown(e, typeParamNames) ?? ""
                };
            }).ToList();

        var example = ConvertXmlToMarkdown(source.Element("example"), typeParamNames) ?? "";
        var seeAlso = source.Elements("seealso")
            .Select(sa => sa.Attribute("cref")?.Value ?? "")
            .Where(c => c.Length > 0)
            .Select(c => Regex.Replace(Regex.Replace(c, @"^[TMPFE]:", ""), @"\(.*$", ""))
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            .ToList();

        return new MemberDoc
        {
            DisplayName = displayName,
            Signature = signature,
            Summary = summary,
            Remarks = remarks,
            Returns = returns,
            InheritedSuffix = isInherited ? " *(Inherited)*" : "",
            Params = paramList,
            Exceptions = exceptionList,
            Example = example,
            SeeAlso = seeAlso
        };
    }

<<<<<<< HEAD
    private string BuildSignature(string full, string displayName, string kind, List<string> typeParamNames, List<string> methodGenericTypeParams)
    {
        if (kind != "M:") return displayName;

        var genericDisplay = methodGenericTypeParams.Count > 0
            ? $"<{string.Join(", ", methodGenericTypeParams)}>"
            : "";

        var match = Regexes.MethodParams().Match(full);
        if (!match.Success)
        {
            return $"{displayName}{genericDisplay}()";
        }

        var paramStr = match.Groups[1].Value;
        var typeParamCount = typeParamNames.Count - methodGenericTypeParams.Count;
        var converted = paramStr.Replace("{", "<").Replace("}", ">");
        var displayParams = SplitParams(converted)
            .Select(p =>
            {
                p = p.Trim();
                p = StripNamespace(p);
                p = Regexes.MethodGenericArg().Replace(p, m =>
                {
                    var idx = int.Parse(m.Groups[1].Value);
                    var adjustedIdx = typeParamCount + idx;
                    return adjustedIdx < typeParamNames.Count ? typeParamNames[adjustedIdx] : m.Value;
                });
                p = Regexes.GenericArg().Replace(p, m =>
                {
                    var idx = int.Parse(m.Groups[1].Value);
                    return idx < typeParamCount ? typeParamNames[idx] : m.Value;
                });
                p = Regexes.GenericTick().Replace(p, "");
                p = p.Replace("@", "");
                p = Regexes.TrailingArray().Replace(p, "[]");
                p = Regexes.GenericArray().Replace(p, "$1<");
                p = Regexes.TrailingBracket().Replace(p, ">");
                p = NormalizeGenericSpacing(p);
=======
    private string BuildSignature(string full, string displayName, string kind, List<string> typeParamNames)
    {
        if (kind != "M:") return displayName;

        var match = Regex.Match(full, @"\((.+)\)$");
        if (!match.Success) return $"{displayName}()";

        var paramStr = match.Groups[1].Value;
        var displayParams = paramStr.Split(',')
            .Select(p =>
            {
                p = p.Trim();
                p = Regex.Replace(p, @".*\.", "");
                p = Regex.Replace(p, @"\[\]$", "[]");
                p = Regex.Replace(p, @".*\.(\w+)`?\d*\[", "$1<");
                p = Regex.Replace(p, @"\]$", ">");
                p = Regex.Replace(p, @"`(\d+)", m =>
                {
                    var idx = int.Parse(m.Groups[1].Value);
                    return idx < typeParamNames.Count ? typeParamNames[idx] : m.Value;
                });
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                return p;
            })
            .ToList();

<<<<<<< HEAD
        return $"{displayName}{genericDisplay}({string.Join(", ", displayParams)})";
    }

    private string AppendParamNames(string signature, List<ParamInfo> paramList)
=======
        return $"{displayName}({string.Join(", ", displayParams)})";
    }

    private string AppendParamNames(string signature, List<Dictionary<string, string>> paramList)
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    {
        if (paramList.Count == 0) return signature;

        var open = signature.IndexOf('(');
        var close = signature.LastIndexOf(')');
        if (open < 0 || close < 0) return signature;

        var paramStr = signature.Substring(open + 1, close - open - 1);
        if (string.IsNullOrWhiteSpace(paramStr)) return signature;

<<<<<<< HEAD
        var types = SplitParams(paramStr);
=======
        var types = paramStr.Split(',').Select(t => t.Trim()).ToList();
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
        var offset = types.Count - paramList.Count;
        if (offset < 0) return signature;

        var enhanced = types.Select((type, i) =>
        {
            var idx = i - offset;
            if (idx >= 0 && idx < paramList.Count)
            {
<<<<<<< HEAD
                var name = paramList[idx].Name;
=======
                var name = paramList[idx]["Name"];
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                if (!string.IsNullOrEmpty(name))
                    return $"{type} {name}";
            }
            return type;
        }).ToList();

        return $"{signature.Substring(0, open + 1)}{string.Join(", ", enhanced)}{signature.Substring(close)}";
    }

<<<<<<< HEAD
    private static string StripNamespace(string type)
    {
        var sb = new System.Text.StringBuilder(type.Length);
        int depth = 0;
        int segStart = 0;
        for (int i = 0; i <= type.Length; i++)
        {
            bool atEnd = i == type.Length;
            char c = atEnd ? '\0' : type[i];
            if (c == '<' || c == ',' || c == '>' || atEnd)
            {
                var segment = sb.ToString(segStart, sb.Length - segStart);
                var lastDot = segment.LastIndexOf('.');
                if (lastDot >= 0)
                    sb.Remove(segStart, lastDot + 1);
                if (!atEnd) sb.Append(c);
                if (c == '<') depth++;
                else if (c == '>') depth--;
                segStart = sb.Length;
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    private static List<string> SplitParams(string paramStr)
    {
        var result = new List<string>();
        int depth = 0, start = 0;
        for (int i = 0; i <= paramStr.Length; i++)
        {
            if (i == paramStr.Length || (paramStr[i] == ',' && depth == 0))
            {
                result.Add(paramStr.Substring(start, i - start).Trim());
                start = i + 1;
            }
            else if (i < paramStr.Length && paramStr[i] == '<') depth++;
            else if (i < paramStr.Length && paramStr[i] == '>') depth--;
        }
        return result;
    }

    private static string FormatGenericArity(string aritySuffix)
    {
        var digits = System.Text.RegularExpressions.Regex.Match(aritySuffix, @"\d+");
        if (!digits.Success) return "";
        var n = int.Parse(digits.Value);
        if (n <= 0) return "";
        var names = new System.Collections.Generic.List<string>(n);
        for (int i = 0; i < n; i++)
            names.Add(i == 0 ? "T" : $"T{i + 1}");
        return $"&lt;{string.Join(", ", names)}&gt;";
    }

    private static string NormalizeGenericSpacing(string type)
    {
        int depth = 0;
        var sb = new System.Text.StringBuilder(type.Length + 4);
        for (int i = 0; i < type.Length; i++)
        {
            if (type[i] == '<') depth++;
            else if (type[i] == '>') depth--;
            if (type[i] == ',' && depth > 0)
            {
                sb.Append(',');
                if (i + 1 < type.Length && type[i + 1] != ' ')
                    sb.Append(' ');
    }
            else
            {
                sb.Append(type[i]);
            }
        }
        return sb.ToString();
    }

    private string? ConvertXmlToMarkdown(XElement? node, List<string>? typeParamNames = null, List<string>? methodGenericTypeParams = null)
=======
    private string? ConvertXmlToMarkdown(XElement? node, List<string>? typeParamNames = null)
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
    {
        if (node == null) return null;

        var parts = new List<string>();
        foreach (var child in node.Nodes())
        {
            if (child is XText text)
            {
                parts.Add(text.Value.Trim());
            }
            else if (child is XElement el)
            {
                switch (el.Name.LocalName)
                {
                    case "see" when el.Attribute("cref") != null:
                        var cref = el.Attribute("cref")!.Value;
<<<<<<< HEAD
                        var crName = Regexes.CrefPrefix().Replace(cref, "");
                        crName = Regexes.CrefParams().Replace(crName, "");
                        if (typeParamNames != null && typeParamNames.Count > 0)
                        {
                            var typeParamCount = typeParamNames.Count - (methodGenericTypeParams?.Count ?? 0);
                            crName = Regexes.MethodGenericArg().Replace(crName, m =>
                            {
                                var idx = int.Parse(m.Groups[1].Value);
                                var adjustedIdx = typeParamCount + idx;
                                return adjustedIdx < typeParamNames.Count ? typeParamNames[adjustedIdx] : m.Value;
                            });
                            crName = Regexes.GenericArg().Replace(crName, m =>
                            {
                                var idx = int.Parse(m.Groups[1].Value);
                                return idx < typeParamCount ? typeParamNames[idx] : m.Value;
                            });
                        }
                        crName = Regexes.GenericTick().Replace(crName, m => FormatGenericArity(m.Value));
=======
                        var crName = Regex.Replace(cref, @"^[TMPFE]:", "");
                        crName = Regex.Replace(crName, @"\(.*$", "");
                        if (typeParamNames != null && typeParamNames.Count > 0)
                            crName = Regex.Replace(crName, @"`(\d+)", m =>
                            {
                                var idx = int.Parse(m.Groups[1].Value);
                                return idx < typeParamNames.Count ? typeParamNames[idx] : m.Value;
                            });
                        else
                            crName = Regex.Replace(crName, @"`\d+", "");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                        var crDisplay = el.Value.Length > 0 ? el.Value : crName.Split('.').Last();
                        parts.Add($"**{crDisplay}**");
                        break;
                    case "see" when el.Attribute("langword") != null:
                        parts.Add($"**{el.Attribute("langword")!.Value}**");
                        break;
                    case "see" when el.Attribute("href") != null:
                        var href = el.Attribute("href")!.Value;
                        var hrefText = el.Value.Length > 0 ? el.Value : href;
                        parts.Add($"[{hrefText}]({href})");
                        break;
                    case "paramref":
                        parts.Add($"**{el.Attribute("name")?.Value ?? ""}**");
                        break;
                    case "typeparamref":
                        parts.Add($"**{el.Attribute("name")?.Value ?? ""}**");
                        break;
                    case "c":
<<<<<<< HEAD
                        parts.Add($"**{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}**");
=======
                        parts.Add($"**{ConvertXmlToMarkdown(el, typeParamNames)}**");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                        break;
                    case "code":
                        var lang = el.Attribute("language")?.Value ?? "";
                        parts.Add($"```{lang}\n{el.Value.TrimEnd()}\n```");
                        break;
                    case "b":
<<<<<<< HEAD
                        parts.Add($"**{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}**");
                        break;
                    case "i":
                        parts.Add($"*{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}*");
                        break;
                    case "u":
                        parts.Add($"<u>{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}</u>");
=======
                        parts.Add($"**{ConvertXmlToMarkdown(el, typeParamNames)}**");
                        break;
                    case "i":
                        parts.Add($"*{ConvertXmlToMarkdown(el, typeParamNames)}*");
                        break;
                    case "u":
                        parts.Add($"<u>{ConvertXmlToMarkdown(el, typeParamNames)}</u>");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                        break;
                    case "br":
                        parts.Add("\n");
                        break;
                    case "a":
                        var aHref = el.Attribute("href")?.Value ?? "";
                        var aText = el.Value.Length > 0 ? el.Value : aHref;
                        parts.Add($"[{aText}]({aHref})");
                        break;
                    case "para":
<<<<<<< HEAD
                        parts.Add($"\n{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}\n");
=======
                        parts.Add($"\n{ConvertXmlToMarkdown(el, typeParamNames)}\n");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                        break;
                    case "list":
                        var listType = el.Attribute("type")?.Value ?? "bullet";
                        var listParts = el.Elements("item")
                            .Select((item, idx) =>
                            {
<<<<<<< HEAD
                                var term = ConvertXmlToMarkdown(item.Element("term"), typeParamNames, methodGenericTypeParams) ?? "";
                                var desc = ConvertXmlToMarkdown(item.Element("description"), typeParamNames, methodGenericTypeParams) ?? "";
=======
                                var term = ConvertXmlToMarkdown(item.Element("term"), typeParamNames) ?? "";
                                var desc = ConvertXmlToMarkdown(item.Element("description"), typeParamNames) ?? "";
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                                return listType == "number"
                                    ? $"{idx + 1}. **{term}** — {desc}"
                                    : $"- **{term}** — {desc}";
                            }).ToList();
                        parts.Add(string.Join("\n", listParts));
                        break;
                    case "exception":
                        var exCref = el.Attribute("cref")?.Value ?? "";
<<<<<<< HEAD
                        exCref = Regexes.CrefPrefix().Replace(exCref, "");
                        exCref = Regexes.CrefParams().Replace(exCref, "");
                        parts.Add($"- **{exCref}**: {ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}");
                        break;
                    default:
                        parts.Add(ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams) ?? "");
=======
                        exCref = Regex.Replace(exCref, @"^[TMPFE]:", "");
                        exCref = Regex.Replace(exCref, @"\(.*$", "");
                        parts.Add($"- **{exCref}**: {ConvertXmlToMarkdown(el, typeParamNames)}");
                        break;
                    default:
                        parts.Add(ConvertXmlToMarkdown(el, typeParamNames) ?? "");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                        break;
                }
            }
        }
<<<<<<< HEAD
        var result = string.Join(" ", parts).Trim();
        if (typeParamNames != null && typeParamNames.Count > 0)
        {
            var typeParamCount = typeParamNames.Count - (methodGenericTypeParams?.Count ?? 0);
            result = Regexes.MethodGenericArg().Replace(result, m =>
            {
                var idx = int.Parse(m.Groups[1].Value);
                var adjustedIdx = typeParamCount + idx;
                return adjustedIdx < typeParamNames.Count ? typeParamNames[adjustedIdx] : m.Value;
            });
            result = Regexes.GenericArg().Replace(result, m =>
            {
                var idx = int.Parse(m.Groups[1].Value);
                return idx < typeParamCount ? typeParamNames[idx] : m.Value;
            });
    }
        result = Regexes.GenericTick().Replace(result, m => FormatGenericArity(m.Value));
        return result;
}
=======
        return string.Join(" ", parts).Trim();
    }
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
}

// ── Markdown Generator ──

class MarkdownGenerator
{
    private readonly Template _typeTemplate;
    private readonly Template _memberTemplate;
    private readonly ProjectInfo _project;

    public MarkdownGenerator(Template typeTemplate, Template memberTemplate, ProjectInfo project)
    {
        _typeTemplate = typeTemplate;
        _memberTemplate = memberTemplate;
        _project = project;
    }

    public (int membersProcessed, int filesGenerated, Dictionary<string, List<(string displayName, string fileName)>> namespaceTypes) Generate(Dictionary<string, TypeDoc> typesByGroup, string outputPath)
    {
        int membersProcessed = 0;
        int filesGenerated = 0;
        var nsTypes = new Dictionary<string, List<(string displayName, string fileName)>>();

        foreach (var (key, typeDoc) in typesByGroup)
        {
            var ns = typeDoc.Namespace;
            var nsFolder = SimplifyNamespace(ns);
            var folder = Path.Combine(outputPath, nsFolder);
            Directory.CreateDirectory(folder);

            var constructorBodies = typeDoc.Constructors.Select(c => { membersProcessed++; return _memberTemplate.Render(BuildMemberContext(c)); }).ToList();
            var methodBodies = typeDoc.Methods.Select(m => { membersProcessed++; return _memberTemplate.Render(BuildMemberContext(m)); }).ToList();
            var propertyBodies = typeDoc.Properties.Select(p => { membersProcessed++; return _memberTemplate.Render(BuildMemberContext(p)); }).ToList();
            var eventBodies = typeDoc.Events.Select(e => { membersProcessed++; return _memberTemplate.Render(BuildMemberContext(e)); }).ToList();
            var fieldBodies = typeDoc.Fields.Select(f => { membersProcessed++; return _memberTemplate.Render(BuildMemberContext(f)); }).ToList();
<<<<<<< HEAD

            var methodOverloadCounts = typeDoc.Methods.GroupBy(m => m.DisplayName).ToDictionary(g => g.Key, g => g.Count());
            var methodHeadings = typeDoc.Methods.Select(m =>
            {
                var count = methodOverloadCounts.GetValueOrDefault(m.DisplayName, 1);
                if (count <= 1) return m.DisplayName;
                var sigParts = m.Signature;
                var parenIndex = sigParts.IndexOf('(');
                return parenIndex >= 0 ? $"{m.DisplayName}{sigParts.Substring(parenIndex)}" : m.DisplayName;
            }).ToList();

            var methodBodies2 = typeDoc.Methods.Select((m, i) =>
            {
                membersProcessed++;
                m.Heading = methodHeadings[i];
                return _memberTemplate.Render(BuildMemberContext(m));
            }).ToList();

=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            var nestedBodies = typeDoc.NestedTypes.Select(n => $"### {n.TypeName}\n\n{n.Summary}").ToList();

            var context = new Dictionary<string, object?>
            {
                ["TypeName"] = typeDoc.GenericDisplayName,
                ["Namespace"] = ns,
                ["Summary"] = typeDoc.Summary,
                ["Remarks"] = typeDoc.Remarks,
<<<<<<< HEAD
                ["TypeParams"] = typeDoc.TypeParams.Select(tp => new Dictionary<string, object?> { ["Name"] = tp.Name, ["Description"] = tp.Description }).ToList<Dictionary<string, object?>>(),
                ["Constructors"] = typeDoc.Constructors.Select(c =>
                {
                    membersProcessed++;
                    return new Dictionary<string, object?>
                    {
                        ["DisplayName"] = c.DisplayName,
                        ["Summary"] = c.Summary,
                        ["HasParams"] = c.HasParams,
                        ["Params"] = c.Params.Select(p => new Dictionary<string, object?> { ["Name"] = p.Name, ["Description"] = p.Description }).ToList<Dictionary<string, object?>>(),
                        ["HasRemarks"] = c.HasRemarks,
                        ["Remarks"] = c.Remarks
                    };
                }).ToList(),
                ["Methods"] = methodBodies2.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
=======
                ["TypeParams"] = typeDoc.TypeParams,
                ["Constructors"] = constructorBodies.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
                ["Methods"] = methodBodies.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
                ["Properties"] = propertyBodies.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
                ["Events"] = eventBodies.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
                ["Fields"] = fieldBodies.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
                ["NestedTypes"] = nestedBodies.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList()
            };

            var rendered = _typeTemplate.Render(context);

            var depth = nsFolder.Split('/').Length;
            var up = string.Join("/", Enumerable.Repeat("..", depth));
            var projectFolder = nsFolder.Split('/')[0];
            var typeName = typeDoc.GenericDisplayName;
            string breadcrumb;
            if (nsFolder.Contains('/'))
            {
                var projectUp = string.Join("/", Enumerable.Repeat("..", depth - 1));
                breadcrumb = $"[Docs]({up}/README.md) > [{projectFolder}]({projectUp}/README.md) > {typeName}\n\n";
            }
            else
            {
                breadcrumb = $"[Docs]({up}/README.md) > [{projectFolder}](README.md) > {typeName}\n\n";
            }
            rendered = breadcrumb + rendered;
            var safeName = typeDoc.GenericDisplayName
                .Replace("<", "_")
                .Replace(">", "")
                .Replace(", ", "_");
<<<<<<< HEAD
            safeName = Regexes.UnsafeChars().Replace(safeName, "_");
=======
            safeName = Regex.Replace(safeName, @"[:""|?*]", "_");
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            var mdFile = Path.Combine(folder, $"{safeName}.md");
            File.WriteAllText(mdFile, rendered);
            Console.WriteLine($"Generated: {mdFile}");
            filesGenerated++;

            if (!nsTypes.ContainsKey(ns)) nsTypes[ns] = new();
            nsTypes[ns].Add((typeDoc.GenericDisplayName, safeName));
        }

        // Generate per-namespace README.md files
        foreach (var (ns, typeEntries) in nsTypes)
        {
            var nsFolder = SimplifyNamespace(ns);
            var folder = Path.Combine(outputPath, nsFolder);
            Directory.CreateDirectory(folder);

<<<<<<< HEAD
            var readme = new System.Text.StringBuilder();
=======
            var readme = "";
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            var projectFolder = nsFolder.Split('/')[0];
            if (nsFolder.Contains('/'))
            {
                var projUp = string.Join("/", Enumerable.Repeat("..", nsFolder.Split('/').Length - 1));
<<<<<<< HEAD
                readme.Append($"[← {projectFolder}]({projUp}/README.md)\n\n");
            }
            else
            {
                readme.Append($"[← Documentation](../README.md)\n\n");
            }
            readme.Append($"# {ns}\n\n## Types\n");
            foreach (var entry in typeEntries.OrderBy(x => x.displayName))
                readme.Append($"- [{Esc(entry.displayName)}]({entry.fileName}.md)\n");
            var readmePath = Path.Combine(folder, "README.md");
            File.WriteAllText(readmePath, readme.ToString());
=======
                readme += $"[← {projectFolder}]({projUp}/README.md)\n\n";
            }
            else
            {
                readme += $"[← Documentation](../README.md)\n\n";
            }
            readme += $"# {ns}\n\n## Types\n";
            foreach (var entry in typeEntries.OrderBy(x => x.displayName))
                readme += $"- [{Esc(entry.displayName)}]({entry.fileName}.md)\n";
            var readmePath = Path.Combine(folder, "README.md");
            File.WriteAllText(readmePath, readme);
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            Console.WriteLine($"Generated: {readmePath}");
            filesGenerated++;
        }

        return (membersProcessed, filesGenerated, nsTypes);
<<<<<<< HEAD
        }
        var rootPath = Path.Combine(outputPath, "README.md");
        File.WriteAllText(rootPath, rootReadme);
        Console.WriteLine($"Generated: {rootPath}");
        filesGenerated++;

    internal static string Esc(string s) => s.Replace("<", "\\<").Replace(">", "\\>").Replace("`", "\\`");
=======
    }
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

    private static string Esc(string s) => s.Replace("<", "\\<").Replace(">", "\\>");

    public string SimplifyNamespace(string ns)
    {
        var roots = new[] { _project.AssemblyName, _project.RootNamespace, _project.ProjectName }
            .Where(r => r != null)
            .Select(r => r!)
            .Distinct()
            .OrderByDescending(r => r.Length)
            .ToList();

        foreach (var root in roots)
        {
            if (ns == root) return root;
            if (ns.StartsWith(root + "."))
                return root + "/" + ns.Substring(root.Length + 1).Replace(".", "/");
        }
        return ns.Replace(".", "/");
    }

    private Dictionary<string, object?> BuildMemberContext(MemberDoc member)
    {
        return new Dictionary<string, object?>
        {
            ["DisplayName"] = member.DisplayName,
<<<<<<< HEAD
            ["Heading"] = string.IsNullOrEmpty(member.Heading) ? member.DisplayName : member.Heading,
            ["InheritedSuffix"] = member.InheritedSuffix,
            ["Signature"] = member.Signature,
            ["Summary"] = member.Summary,
            ["Remarks"] = member.Remarks,
            ["Returns"] = member.Returns,
            ["Params"] = member.Params.Select(p => new Dictionary<string, object?> { ["Name"] = p.Name, ["Description"] = p.Description }).ToList<Dictionary<string, object?>>(),
            ["Exceptions"] = member.Exceptions.Select(e => new Dictionary<string, object?> { ["Type"] = e.Type, ["Description"] = e.Description }).ToList<Dictionary<string, object?>>(),
=======
            ["InheritedSuffix"] = member.InheritedSuffix,
            ["Signature"] = $"`{member.Signature}`",
            ["Summary"] = member.Summary,
            ["Remarks"] = member.Remarks,
            ["Returns"] = member.Returns,
            ["Params"] = member.Params,
            ["Exceptions"] = member.Exceptions,
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            ["Example"] = member.Example,
            ["SeeAlso"] = member.SeeAlso,
            ["HasParams"] = member.HasParams,
            ["HasReturns"] = member.HasReturns,
<<<<<<< HEAD
            ["HasRemarks"] = member.HasRemarks,
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
            ["HasExceptions"] = member.HasExceptions,
            ["HasExample"] = member.HasExample
        };
    }
}
