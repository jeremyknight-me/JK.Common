#:property PublishAot=false
#:property PackAsTool=false
#:property TargetFramework=net10.0
#:property ImplicitUsings=enable

using System.Xml.Linq;
using System.Text.RegularExpressions;

// ── Entry Point ──

var outputPath = args.Length > 1 ? args[1] : "./docs";
var templatesDir = FindTemplates(null)
    ?? throw new DirectoryNotFoundException("Could not find templates/ folder. Run from the repo root or next to the skill folder.");
var typeTemplate = Template.Load(Path.Combine(templatesDir, "type.md"));
var memberTemplate = Template.Load(Path.Combine(templatesDir, "member.md"));

Console.WriteLine($"Templates: {templatesDir}");

int membersProcessed = 0;
int filesCreated = 0;

if (args.Length > 0 && File.Exists(args[0]))
{
    var xmlPath = Path.GetFullPath(args[0]);
    Console.WriteLine($"Processing: {xmlPath}");

    var parser = new XmlDocParser();
    var (typesByGroup, rootNamespace) = parser.Parse(xmlPath);
    var projectRoot = FindProjectRoot(rootNamespace);

    var generator = new MarkdownGenerator(typeTemplate, memberTemplate, projectRoot);
    var (m, f) = generator.Generate(typesByGroup, outputPath);
    membersProcessed += m;
    filesCreated += f;

    Console.WriteLine($"\nDone. Members: {membersProcessed}, Files: {filesCreated}");
}
else
{
    var projects = DiscoverProjects();
    if (projects.Count == 0)
    {
        Console.WriteLine("No qualifying projects found.");
        return;
    }

    foreach (var project in projects)
    {
        Console.WriteLine($"\nBuilding: {project.CsprojPath}");
        var buildResult = RunBuild(project.CsprojPath);
        if (buildResult != 0)
        {
            Console.WriteLine($"  Build failed, skipping.");
            continue;
        }

        var xmlPath = Path.Combine(project.ProjectDir, "bin", "Debug", "net10.0", $"{project.AssemblyName}.xml");
        if (!File.Exists(xmlPath))
        {
            Console.WriteLine($"  XML not found: {xmlPath}");
            continue;
        }

        Console.WriteLine($"  Parsing: {xmlPath}");
        var parser = new XmlDocParser();
        var (typesByGroup, _) = parser.Parse(xmlPath);

        var generator = new MarkdownGenerator(typeTemplate, memberTemplate, project);
        var (m, f) = generator.Generate(typesByGroup, outputPath);
        membersProcessed += m;
        filesCreated += f;
    }

    Console.WriteLine($"\nDone. Members: {membersProcessed}, Files: {filesCreated}");
}

Console.WriteLine($"README: {Path.GetFullPath(Path.Combine(outputPath, "README.md"))}");

// ── Helpers ──

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

List<ProjectInfo> DiscoverProjects()
{
    var dir = Directory.GetCurrentDirectory();
    string? repoRoot = null;
    for (int i = 0; i < 10; i++)
    {
        var hasSln = Directory.GetFiles(dir, "*.sln").Length > 0
            || Directory.GetFiles(dir, "*.slnx").Length > 0
            || Directory.Exists(Path.Combine(dir, "src")) && (
                Directory.GetFiles(Path.Combine(dir, "src"), "*.sln").Length > 0
                || Directory.GetFiles(Path.Combine(dir, "src"), "*.slnx").Length > 0);

        if (hasSln)
        {
            repoRoot = dir;
            break;
        }
        var parent = Directory.GetParent(dir);
        if (parent == null) break;
        dir = parent.FullName;
    }
    if (repoRoot == null)
    {
        Console.WriteLine("Could not find repo root (no .sln or .slnx found).");
        return new();
    }

    Console.WriteLine($"Repo root: {repoRoot}");
    var projects = new List<ProjectInfo>();
    foreach (var csproj in Directory.GetFiles(Path.Combine(repoRoot, "src"), "*.csproj", SearchOption.AllDirectories))
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
        if (val is List<string> strings) return strings.Select(s => new Dictionary<string, object?> { ["."] = s }).ToList();
        return new();
    }
}

// ── XML Parser ──

class XmlDocParser
{
    private readonly Dictionary<string, bool> _typeMap = new();

    public (Dictionary<string, TypeDoc> types, string rootNamespace) Parse(string xmlPath)
    {
        var doc = XDocument.Load(xmlPath);
        var types = new Dictionary<string, TypeDoc>();
        string rootNamespace = doc.Root?.Element("assembly")?.Element("name")?.Value ?? "";

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
                typeDoc.Summary = ConvertXmlToMarkdown(member.Element("summary")) ?? typeDoc.Summary;
                typeDoc.Remarks = ConvertXmlToMarkdown(member.Element("remarks")) ?? typeDoc.Remarks;

                foreach (var tp in member.Elements("typeparam"))
                    typeDoc.TypeParams.Add(new() { ["Name"] = tp.Attribute("name")?.Value ?? "", ["Description"] = ConvertXmlToMarkdown(tp) ?? "" });

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
                var memberDoc = ParseMember(member, name, kind);
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

    private MemberDoc ParseMember(XElement member, string name, string kind)
    {
        var full = name.Substring(2);
        var parenIdx = full.IndexOf('(');
        var beforeParams = parenIdx >= 0 ? full.Substring(0, parenIdx) : full;
        var lastDot = beforeParams.LastIndexOf('.');
        var memberPart = lastDot >= 0 ? beforeParams.Substring(lastDot + 1) : beforeParams;

        var displayName = Regex.Replace(memberPart, @"`\d+", "");
        var signature = BuildSignature(full, displayName, kind);
        var summary = ConvertXmlToMarkdown(member.Element("summary")) ?? "";
        var remarks = ConvertXmlToMarkdown(member.Element("remarks")) ?? "";
        var returns = ConvertXmlToMarkdown(member.Element("returns")) ?? "";
        var isInherited = member.Element("inheritdoc") != null;

        var paramList = member.Elements("param")
            .Select(p => new Dictionary<string, string>
            {
                ["Name"] = p.Attribute("name")?.Value ?? "",
                ["Description"] = ConvertXmlToMarkdown(p) ?? ""
            }).ToList();

        var exceptionList = member.Elements("exception")
            .Select(e =>
            {
                var cref = e.Attribute("cref")?.Value ?? "";
                cref = Regex.Replace(cref, @"^[TMPFE]:", "");
                cref = Regex.Replace(cref, @"\(.*$", "");
                return new Dictionary<string, string>
                {
                    ["Type"] = cref,
                    ["Description"] = ConvertXmlToMarkdown(e) ?? ""
                };
            }).ToList();

        var example = ConvertXmlToMarkdown(member.Element("example")) ?? "";
        var seeAlso = member.Elements("seealso")
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

    private string BuildSignature(string full, string displayName, string kind)
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
                return p;
            })
            .ToList();

        return $"{displayName}({string.Join(", ", displayParams)})";
    }

    private string? ConvertXmlToMarkdown(XElement? node)
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
                        parts.Add($"**{ConvertXmlToMarkdown(el)}**");
                        break;
                    case "code":
                        var lang = el.Attribute("language")?.Value ?? "";
                        parts.Add($"```{lang}\n{el.Value.TrimEnd()}\n```");
                        break;
                    case "b":
                        parts.Add($"**{ConvertXmlToMarkdown(el)}**");
                        break;
                    case "i":
                        parts.Add($"*{ConvertXmlToMarkdown(el)}*");
                        break;
                    case "u":
                        parts.Add($"<u>{ConvertXmlToMarkdown(el)}</u>");
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
                        parts.Add($"\n{ConvertXmlToMarkdown(el)}\n");
                        break;
                    case "list":
                        var listType = el.Attribute("type")?.Value ?? "bullet";
                        var listParts = el.Elements("item")
                            .Select((item, idx) =>
                            {
                                var term = ConvertXmlToMarkdown(item.Element("term")) ?? "";
                                var desc = ConvertXmlToMarkdown(item.Element("description")) ?? "";
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
                        parts.Add($"- **{exCref}**: {ConvertXmlToMarkdown(el)}");
                        break;
                    default:
                        parts.Add(ConvertXmlToMarkdown(el) ?? "");
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

    public (int membersProcessed, int filesGenerated) Generate(Dictionary<string, TypeDoc> typesByGroup, string outputPath)
    {
        int membersProcessed = 0;
        int filesGenerated = 0;
        var nsTypes = new Dictionary<string, List<string>>();

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
                ["TypeName"] = typeDoc.TypeName,
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
            var safeName = Regex.Replace(typeDoc.TypeName, @"[<>:""|?*]", "_");
            var mdFile = Path.Combine(folder, $"{safeName}.md");
            File.WriteAllText(mdFile, rendered);
            Console.WriteLine($"Generated: {mdFile}");
            filesGenerated++;

            if (!nsTypes.ContainsKey(ns)) nsTypes[ns] = new();
            nsTypes[ns].Add(typeDoc.TypeName);
        }

        // Generate per-namespace README.md files
        foreach (var (ns, typeNames) in nsTypes)
        {
            var nsFolder = SimplifyNamespace(ns);
            var folder = Path.Combine(outputPath, nsFolder);
            Directory.CreateDirectory(folder);
            var readme = $"# {ns}\n\n## Types\n";
            foreach (var t in typeNames.OrderBy(x => x))
                readme += $"- [{t}]({t}.md)\n";
            var readmePath = Path.Combine(folder, "README.md");
            File.WriteAllText(readmePath, readme);
            Console.WriteLine($"Generated: {readmePath}");
            filesGenerated++;
        }

        // Generate root README.md
        var rootReadme = $"# {_project.ProjectName} Documentation\n\nThis documentation is automatically generated from XML documentation.\n\n## Namespaces\n";
        foreach (var ns in nsTypes.Keys.OrderBy(x => x))
        {
            var nsFolder = SimplifyNamespace(ns);
            rootReadme += $"\n### [{ns}]({nsFolder}/README.md)\n";
            foreach (var t in nsTypes[ns].OrderBy(x => x))
                rootReadme += $"- [{t}]({nsFolder}/{t}.md)\n";
        }
        var rootPath = Path.Combine(outputPath, "README.md");
        File.WriteAllText(rootPath, rootReadme);
        Console.WriteLine($"Generated: {rootPath}");
        filesGenerated++;

        return (membersProcessed, filesGenerated);
    }

    private string SimplifyNamespace(string ns)
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
