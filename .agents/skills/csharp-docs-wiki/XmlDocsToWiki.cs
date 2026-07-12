#:property PublishAot=false
#:property PackAsTool=false
#:property TargetFramework=net10.0
#:property ImplicitUsings=enable

using System.Xml.Linq;
using System.Text.RegularExpressions;

// ── Entry Point ──

if (args.Length == 0 || (!File.Exists(args[0]) && !args[0].EndsWith(".xml", StringComparison.OrdinalIgnoreCase)))
{
    Console.WriteLine("Usage: dotnet run --file XmlDocsToWiki.cs -- <xml-file> [xml-file2 ...] [output-path]");
    Console.WriteLine();
    Console.WriteLine("  xml-file   Path(s) to XML documentation files (one or more)");
    Console.WriteLine("  output-path  Output directory (default: ./docs)");
    Console.WriteLine();
    Console.WriteLine("The agent should build projects first, then pass the resulting XML files here.");
    return;
}

var xmlPaths = new List<string>();
var outputPath = "./docs";

for (int i = 0; i < args.Length; i++)
{
    if (File.Exists(args[i]) || args[i].EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
        xmlPaths.Add(args[i]);
    else
        outputPath = args[i];
}

var templatesDir = FindTemplates(null)
    ?? throw new DirectoryNotFoundException("Could not find templates/ folder. Run from the repo root or next to the skill folder.");
var typeTemplate = Template.Load(Path.Combine(templatesDir, "type.md"));
var memberTemplate = Template.Load(Path.Combine(templatesDir, "member.md"));

Console.WriteLine($"Templates: {templatesDir}");
Console.WriteLine($"XML files: {xmlPaths.Count}");
Console.WriteLine($"Output: {outputPath}");

int membersProcessed = 0;
int filesCreated = 0;
var allNsEntries = new List<(string Ns, string Folder, List<(string displayName, string fileName)> Types)>();

void AccumulateNs(Dictionary<string, List<(string displayName, string fileName)>> nsTypes, MarkdownGenerator gen)
{
    foreach (var (ns, types) in nsTypes)
    {
        var existing = allNsEntries.FirstOrDefault(e => e.Ns == ns);
        if (existing.Folder != null)
        {
            existing.Types.AddRange(types);
        }
        else
        {
            allNsEntries.Add((ns, gen.SimplifyNamespace(ns), new List<(string, string)>(types)));
        }
    }
    allNsEntries.Sort((a, b) => string.Compare(a.Ns, b.Ns, StringComparison.Ordinal));
}

string Esc(string s) => s.Replace("<", "\\<").Replace(">", "\\>");

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
    var projectRoot = FindProjectRoot(rootNamespace);

    var generator = new MarkdownGenerator(typeTemplate, memberTemplate, projectRoot);
    var (m, f, nsTypes) = generator.Generate(typesByGroup, outputPath);
    membersProcessed += m;
    filesCreated += f;
    AccumulateNs(nsTypes, generator);
}

// Generate root README.md grouped by project
var projectGroups = allNsEntries
    .GroupBy(e => e.Folder.Split('/')[0])
    .OrderBy(g => g.Key);

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
Console.WriteLine($"Generated: {rootPath}");
filesCreated++;

Console.WriteLine($"\nDone. Members: {membersProcessed}, Files: {filesCreated}");
Console.WriteLine($"README: {Path.GetFullPath(rootPath)}");

string? FindTemplates(string? startDir)
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

// ── Model ──

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
    public List<Dictionary<string, string>> TypeParams { get; set; } = new();
    public List<string> TypeParamNames { get; set; } = new();
    public string GenericDisplayName
    {
        get
        {
            var baseName = Regex.Replace(TypeName, @"_\d+$", "");
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
    public string InheritedSuffix { get; set; } = "";
    public string Signature { get; set; } = "";
    public string Summary { get; set; } = "";
    public string Remarks { get; set; } = "";
    public string Returns { get; set; } = "";
    public List<Dictionary<string, string>> Params { get; set; } = new();
    public List<Dictionary<string, string>> Exceptions { get; set; } = new();
    public string Example { get; set; } = "";
    public List<string> SeeAlso { get; set; } = new();
    public bool HasParams => Params.Count > 0;
    public bool HasReturns => !string.IsNullOrWhiteSpace(Returns);
    public bool HasExceptions => Exceptions.Count > 0;
    public bool HasExample => !string.IsNullOrWhiteSpace(Example);
}

// ── Template Engine ──

class Template
{
    private readonly string _raw;

    private Template(string raw) => _raw = raw;

    public static Template Load(string path) => new(File.ReadAllText(path));

    public string Render(Dictionary<string, object?> context)
    {
        var result = _raw;

        while (Regex.IsMatch(result, @"\{#each\s+(\w+)\}"))
        {
            var match = Regex.Match(result, @"\{#each\s+(\w+)\}");
            var key = match.Groups[1].Value;
            var openEnd = match.Index + match.Length;
            var closeTag = FindClosingTag(result, openEnd, "{#each", "{/each}");
            if (closeTag < 0) break;

            var inner = result.Substring(openEnd, closeTag - openEnd);
            var items = GetListValue(context, key);
            var replacement = items.Count > 0
                ? string.Join("\n", items.Select(item => RenderSingle(inner, item)))
                : "";
            result = result.Substring(0, match.Index) + replacement + result.Substring(closeTag + "{/each}".Length);
        }

        while (Regex.IsMatch(result, @"\{#if\s+(\w+)\}"))
        {
            var match = Regex.Match(result, @"\{#if\s+(\w+)\}");
            var key = match.Groups[1].Value;
            var openEnd = match.Index + match.Length;
            var closeTag = FindClosingTag(result, openEnd, "{#if", "{/if}");
            if (closeTag < 0) break;

            var inner = result.Substring(openEnd, closeTag - openEnd);
            var truthy = IsTruthy(context, key);
            var replacement = truthy ? inner : "";
            result = result.Substring(0, match.Index) + replacement + result.Substring(closeTag + "{/if}".Length);
        }

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
        return Regex.Replace(text, @"\n{3,}", "\n\n").Trim();
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
        if (val is List<Dictionary<string, string>> stringDicts)
            return stringDicts.Select(s => s.ToDictionary(kv => kv.Key, kv => (object?)kv.Value)).ToList();
        if (val is List<string> strings) return strings.Select(s => new Dictionary<string, object?> { ["."] = s }).ToList();
        return new();
    }
}

// ── XML Parser ──

class XmlDocParser
{
    private readonly Dictionary<string, bool> _typeMap = new();
    private readonly Dictionary<string, XElement> _generatedMembers = new();

    public (Dictionary<string, TypeDoc> types, string rootNamespace) Parse(string xmlPath)
    {
        var doc = XDocument.Load(xmlPath);
        var types = new Dictionary<string, TypeDoc>();
        string rootNamespace = doc.Root?.Element("assembly")?.Element("name")?.Value ?? "";

        // First pass: collect <G>$ members for inheritdoc resolution
        foreach (var member in doc.Descendants("member"))
        {
            var name = member.Attribute("name")?.Value;
            if (name != null && name.Contains("<G>$"))
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

            if (ns.StartsWith("System")) continue;

            var displayTypeName = Regex.Replace(typeName, @"`(\d+)", "_$1");
            var nestedDot = typeName.IndexOf('.');
            string rootType = nestedDot >= 0 ? typeName.Substring(0, nestedDot) : typeName;
            var key = $"{ns}/{rootType}";

            if (!types.ContainsKey(key))
                types[key] = new TypeDoc { Namespace = ns, TypeName = Regex.Replace(rootType, @"`(\d+)", "_$1") };

            if (kind == "T:")
            {
                _typeMap[$"{ns}.{displayTypeName}"] = true;
                var typeDoc = types[key];

                foreach (var tp in member.Elements("typeparam"))
                    typeDoc.TypeParams.Add(new() { ["Name"] = tp.Attribute("name")?.Value ?? "", ["Description"] = ConvertXmlToMarkdown(tp) ?? "" });

                typeDoc.TypeParamNames = typeDoc.TypeParams.Select(tp => tp["Name"]).ToList();

                typeDoc.Summary = ConvertXmlToMarkdown(member.Element("summary"), typeDoc.TypeParamNames) ?? typeDoc.Summary;
                typeDoc.Remarks = ConvertXmlToMarkdown(member.Element("remarks"), typeDoc.TypeParamNames) ?? typeDoc.Remarks;

                if (nestedDot >= 0)
                {
                    var parentKey = $"{ns}/{typeName.Substring(0, nestedDot)}";
                    if (!types.ContainsKey(parentKey))
                        types[parentKey] = new TypeDoc { Namespace = ns, TypeName = Regex.Replace(typeName.Substring(0, nestedDot), @"`\d+", "") };
                    types[parentKey].NestedTypes.Add(new TypeDoc { TypeName = displayTypeName, Summary = typeDoc.Summary, Namespace = ns });
                }
            }
            else
            {
                var typeDoc = types[key];
                var memberDoc = ParseMember(member, name, kind, typeDoc.TypeParamNames);
                switch (kind)
                {
                    case "M:":
                        if (memberDoc.DisplayName == ".ctor" || memberDoc.DisplayName == ".cctor")
                        {
                            memberDoc.DisplayName = typeDoc.TypeName;
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

        var displayName = Regex.Replace(memberPart, @"`\d+", "");
        var signature = BuildSignature(full, displayName, kind, typeParamNames);
        var isInherited = member.Element("inheritdoc") != null;

        XElement? source = member;
        if (isInherited)
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

        signature = AppendParamNames(signature, paramList);

        var exceptionList = source.Elements("exception")
            .Select(e =>
            {
                var cref = e.Attribute("cref")?.Value ?? "";
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
                return p;
            })
            .ToList();

        return $"{displayName}({string.Join(", ", displayParams)})";
    }

    private string AppendParamNames(string signature, List<Dictionary<string, string>> paramList)
    {
        if (paramList.Count == 0) return signature;

        var open = signature.IndexOf('(');
        var close = signature.LastIndexOf(')');
        if (open < 0 || close < 0) return signature;

        var paramStr = signature.Substring(open + 1, close - open - 1);
        if (string.IsNullOrWhiteSpace(paramStr)) return signature;

        var types = paramStr.Split(',').Select(t => t.Trim()).ToList();
        var offset = types.Count - paramList.Count;
        if (offset < 0) return signature;

        var enhanced = types.Select((type, i) =>
        {
            var idx = i - offset;
            if (idx >= 0 && idx < paramList.Count)
            {
                var name = paramList[idx]["Name"];
                if (!string.IsNullOrEmpty(name))
                    return $"{type} {name}";
            }
            return type;
        }).ToList();

        return $"{signature.Substring(0, open + 1)}{string.Join(", ", enhanced)}{signature.Substring(close)}";
    }

    private string? ConvertXmlToMarkdown(XElement? node, List<string>? typeParamNames = null)
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
                        parts.Add($"**{ConvertXmlToMarkdown(el, typeParamNames)}**");
                        break;
                    case "code":
                        var lang = el.Attribute("language")?.Value ?? "";
                        parts.Add($"```{lang}\n{el.Value.TrimEnd()}\n```");
                        break;
                    case "b":
                        parts.Add($"**{ConvertXmlToMarkdown(el, typeParamNames)}**");
                        break;
                    case "i":
                        parts.Add($"*{ConvertXmlToMarkdown(el, typeParamNames)}*");
                        break;
                    case "u":
                        parts.Add($"<u>{ConvertXmlToMarkdown(el, typeParamNames)}</u>");
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
                        parts.Add($"\n{ConvertXmlToMarkdown(el, typeParamNames)}\n");
                        break;
                    case "list":
                        var listType = el.Attribute("type")?.Value ?? "bullet";
                        var listParts = el.Elements("item")
                            .Select((item, idx) =>
                            {
                                var term = ConvertXmlToMarkdown(item.Element("term"), typeParamNames) ?? "";
                                var desc = ConvertXmlToMarkdown(item.Element("description"), typeParamNames) ?? "";
                                return listType == "number"
                                    ? $"{idx + 1}. **{term}** — {desc}"
                                    : $"- **{term}** — {desc}";
                            }).ToList();
                        parts.Add(string.Join("\n", listParts));
                        break;
                    case "exception":
                        var exCref = el.Attribute("cref")?.Value ?? "";
                        exCref = Regex.Replace(exCref, @"^[TMPFE]:", "");
                        exCref = Regex.Replace(exCref, @"\(.*$", "");
                        parts.Add($"- **{exCref}**: {ConvertXmlToMarkdown(el, typeParamNames)}");
                        break;
                    default:
                        parts.Add(ConvertXmlToMarkdown(el, typeParamNames) ?? "");
                        break;
                }
            }
        }
        return string.Join(" ", parts).Trim();
    }
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
            var nestedBodies = typeDoc.NestedTypes.Select(n => $"### {n.TypeName}\n\n{n.Summary}").ToList();

            var context = new Dictionary<string, object?>
            {
                ["TypeName"] = typeDoc.GenericDisplayName,
                ["Namespace"] = ns,
                ["Summary"] = typeDoc.Summary,
                ["Remarks"] = typeDoc.Remarks,
                ["TypeParams"] = typeDoc.TypeParams,
                ["Constructors"] = constructorBodies.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
                ["Methods"] = methodBodies.Select(b => new Dictionary<string, object?> { ["Body"] = b }).ToList(),
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
            safeName = Regex.Replace(safeName, @"[:""|?*]", "_");
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

            var readme = "";
            var projectFolder = nsFolder.Split('/')[0];
            if (nsFolder.Contains('/'))
            {
                var projUp = string.Join("/", Enumerable.Repeat("..", nsFolder.Split('/').Length - 1));
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
            Console.WriteLine($"Generated: {readmePath}");
            filesGenerated++;
        }

        return (membersProcessed, filesGenerated, nsTypes);
    }

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
            ["InheritedSuffix"] = member.InheritedSuffix,
            ["Signature"] = $"`{member.Signature}`",
            ["Summary"] = member.Summary,
            ["Remarks"] = member.Remarks,
            ["Returns"] = member.Returns,
            ["Params"] = member.Params,
            ["Exceptions"] = member.Exceptions,
            ["Example"] = member.Example,
            ["SeeAlso"] = member.SeeAlso,
            ["HasParams"] = member.HasParams,
            ["HasReturns"] = member.HasReturns,
            ["HasExceptions"] = member.HasExceptions,
            ["HasExample"] = member.HasExample
        };
    }
}
