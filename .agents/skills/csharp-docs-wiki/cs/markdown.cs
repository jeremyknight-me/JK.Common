
public class MarkdownGenerator(Template typeTemplate, Template memberTemplate, ProjectInfo project)
{
    private readonly Template _typeTemplate = typeTemplate;
    private readonly Template _memberTemplate = memberTemplate;
    private readonly ProjectInfo _project = project;

    public (int membersProcessed, int filesGenerated, Dictionary<string, List<NamespaceTypeEntry>> namespaceTypes) Generate(Dictionary<string, TypeDoc> typesByGroup, string outputPath)
    {
        int membersProcessed = 0;
        int filesGenerated = 0;
        var nsTypes = new Dictionary<string, List<NamespaceTypeEntry>>();

        foreach (var (key, typeDoc) in typesByGroup)
        {
            var ns = typeDoc.Namespace;
            var nsFolder = SimplifyNamespace(ns);
            var folder = Path.Combine(outputPath, nsFolder);
            Directory.CreateDirectory(folder);

            var propertyBodies = typeDoc.Properties.Select(p => { membersProcessed++; return _memberTemplate.Render(BuildMemberContext(p)); }).ToList();
            var eventBodies = typeDoc.Events.Select(e => { membersProcessed++; return _memberTemplate.Render(BuildMemberContext(e)); }).ToList();
            var fieldBodies = typeDoc.Fields.Select(f => { membersProcessed++; return _memberTemplate.Render(BuildMemberContext(f)); }).ToList();
            var methodOverloadCounts = typeDoc.Methods.GroupBy(m => m.DisplayName).ToDictionary(g => g.Key, g => g.Count());
            var methodHeadings = typeDoc.Methods.Select(m =>
            {
                var count = methodOverloadCounts.GetValueOrDefault(m.DisplayName, 1);
                if (count <= 1)
                {
                    return m.DisplayName;
                }

                return m.Signature;
            }).ToList();

            var methodBodies2 = typeDoc.Methods.Select((m, i) =>
            {
                membersProcessed++;
                m.Heading = methodHeadings[i];
                return _memberTemplate.Render(BuildMemberContext(m));
            }).ToList();

            var nestedBodies = typeDoc.NestedTypes.Select(n => $"### {n.TypeName}\n\n{n.Summary}").ToList();
            var ctorBodies = typeDoc.Constructors.Select(c => { membersProcessed++; return _memberTemplate.Render(BuildMemberContext(c)); }).ToList();
            Dictionary<string, object?> context = new() 
            {
                ["TypeName"] = typeDoc.GenericDisplayName,
                ["Namespace"] = ns,
                ["Summary"] = typeDoc.Summary,
                ["Remarks"] = typeDoc.Remarks,
                ["TypeParams"] = typeDoc.TypeParams,
                ["Constructors"] = ctorBodies.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
                ["Methods"] = methodBodies2.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
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
            var breadcrumb = nsFolder.Contains('/')
                ? $"[Docs]({up}/README.md) > [{projectFolder}]({string.Join("/", Enumerable.Repeat("..", depth - 1))}/README.md) > {typeName}\n\n"
                : $"[Docs]({up}/README.md) > [{projectFolder}](README.md) > {typeName}\n\n";
            rendered = breadcrumb + rendered;
            rendered = CleanUpMarkdownWhitespace(rendered);
            var safeName = typeDoc.GenericDisplayName
                .Replace("<", "_")
                .Replace(">", "")
                .Replace(", ", "_");
            safeName = Helpers.SanitizeFileName(safeName);
            var mdFile = Path.Combine(folder, $"{safeName}.md");
            File.WriteAllText(mdFile, rendered);
            Console.WriteLine($"Generated: {mdFile}");
            filesGenerated++;

            if (!nsTypes.ContainsKey(ns))
            {
                nsTypes[ns] = new();
            }

            nsTypes[ns].Add(new NamespaceTypeEntry(typeDoc.GenericDisplayName, safeName, typeDoc.Summary));
        }

        // Generate per-namespace README.md files
        foreach (var (ns, typeEntries) in nsTypes)
        {
            var nsFolder = SimplifyNamespace(ns);
            var folder = Path.Combine(outputPath, nsFolder);
            Directory.CreateDirectory(folder);

            Helpers.DeleteLegacyNamespaceFile(Path.Combine(folder, "README.md"), outputPath);

            System.Text.StringBuilder readme = new();
            var projectFolder = nsFolder.Split('/')[0];
            readme.Append(nsFolder.Contains('/')
                ? $"[← {projectFolder}]({string.Join("/", Enumerable.Repeat("..", nsFolder.Split('/').Length - 1))}/README.md)\n\n"
                : $"[← Documentation](../README.md)\n\n");
            readme.Append($"# {ns}\n\n");
            readme.Append("## Types\n");
            foreach (var entry in typeEntries.OrderBy(x => x.DisplayName))
            {
                readme.Append($"### [{Esc(entry.DisplayName)}]({entry.FileName}.md)\n\n");
                if (!string.IsNullOrWhiteSpace(entry.Summary))
                {
                    readme.Append($"{entry.Summary}\n\n");
                }
            }

            var readmePath = Path.Combine(folder, "README.md");
            File.WriteAllText(readmePath, readme.ToString());
            Console.WriteLine($"Generated: {readmePath}");
            filesGenerated++;
        }

        return (membersProcessed, filesGenerated, nsTypes);
    }

    internal static string Esc(string s) => s.Replace("<", "\\<").Replace(">", "\\>").Replace("`", "\\`");

    internal static string CleanUpMarkdownWhitespace(string markdown)
    {
        var lines = markdown.Split('\n');
        List<string> result = [];
        bool lastWasBlank = false;
        bool inFence = false;
        foreach (var raw in lines)
        {
            var line = raw.TrimEnd('\r');
            var trimmed = line.TrimStart();
            if (trimmed.StartsWith("```"))
            {
                inFence = !inFence;
            }

            bool isBlank = string.IsNullOrWhiteSpace(line);
            if (!inFence && isBlank && lastWasBlank)
            {
                continue;
            }

            result.Add(line);
            if (!inFence)
            {
                lastWasBlank = isBlank;
            }
        }
        
        while (result.Count > 0 && string.IsNullOrWhiteSpace(result[^1]))
        {
            result.RemoveAt(result.Count - 1);
        }

        return string.Join('\n', result);
    }

    public string SimplifyNamespace(string ns)
    {
        var roots = new[] { _project.AssemblyName, _project.RootNamespace, _project.ProjectName }
            .Where(r => r != null)
            .Select(r => r!)
            .Distinct()
            .OrderByDescending(r => r.Length);
        return roots.FirstOrDefault(r => ns == r || ns.StartsWith(r + "."))
            is { } root
                ? ns == root ? root : $"{root}/{ns[(root.Length + 1)..].Replace(".", "/")}"
                : ns.Replace(".", "/");
    }

    private static object BuildMemberContext(MemberDoc member)
    {
        if (string.IsNullOrEmpty(member.Heading))
        {
            member.Heading = member.DisplayName;
        }

        return member;
    }
}