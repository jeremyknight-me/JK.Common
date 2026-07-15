#:property PublishAot=false
#:property PackAsTool=false
#:property TargetFramework=net10.0
#:property ImplicitUsings=enable
#:package Fluid.Core@2.*

using System.Xml.Linq;
using System.Text.RegularExpressions;
using Fluid;
using Fluid.Parser;

// ── Entry Point ──

if (args.Length == 0 || args[0] == "--help" || args[0] == "-h")
{
    Console.WriteLine("Usage: dotnet run --file XmlDocsToWiki.cs -- --files <xml-file> [xml-file ...] [--output <path>]");
    Console.WriteLine();
    Console.WriteLine("  --files    One or more paths to XML documentation files (required)");
    Console.WriteLine("  --output   Output directory (default: ./docs)");
    Console.WriteLine();
    Console.WriteLine("The agent should build projects first, then pass the resulting XML files here.");
    return;
}

List<string> xmlPaths = [];
var outputPath = "./docs";

for (int i = 0; i < args.Length; i++)
{
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
    ?? throw new DirectoryNotFoundException("Could not find templates/ folder. Run from the repo root or next to the skill folder.");
var typeTemplate = Template.Load(Path.Combine(templatesDir, "type.md"));
var memberTemplate = Template.Load(Path.Combine(templatesDir, "member.md"));

Console.WriteLine($"Templates: {templatesDir}");
Console.WriteLine($"XML files: {xmlPaths.Count}");
Console.WriteLine($"Output: {outputPath}");

int membersProcessed = 0;
int filesCreated = 0;
List<(string Ns, string Folder, List<(string displayName, string fileName)> Types)> allNsEntries = [];
var cachedCsprojs = Directory.GetFiles(".", "*.csproj", SearchOption.AllDirectories);

void AccumulateNs(Dictionary<string, List<(string displayName, string fileName)>> nsTypes, MarkdownGenerator gen)
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

// Generate root README.md grouped by project
var projectGroups = allNsEntries
    .GroupBy(e => e.Folder.Split('/')[0])
    .OrderBy(g => g.Key);

var rootReadme = new System.Text.StringBuilder("# Documentation\n\nThis documentation is automatically generated from XML documentation.\n");
foreach (var group in projectGroups)
{
    rootReadme.Append($"\n## {group.Key}\n");
    foreach (var entry in group.OrderBy(e => e.Ns))
    {
        rootReadme.Append($"\n### [{entry.Ns}]({entry.Folder}/README.md)\n");
        foreach (var entry2 in entry.Types.OrderBy(x => x.displayName))
        {
            rootReadme.Append($"- [{MarkdownGenerator.Esc(entry2.displayName)}]({entry.Folder}/{entry2.fileName}.md)\n");
        }
    }
}
var rootPath = Path.Combine(outputPath, "README.md");
File.WriteAllText(rootPath, rootReadme.ToString());
Console.WriteLine($"Generated: {rootPath}");
filesCreated++;

Console.WriteLine($"\nDone. Members: {membersProcessed}, Files: {filesCreated}");
Console.WriteLine($"README: {Path.GetFullPath(rootPath)}");

string? FindTemplates()
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
            if (File.Exists(candidate))
            {
                return Path.Combine(dir, ".agents", "skills", "csharp-docs-wiki", "templates");
            }
            break;
        }

        var parent = Directory.GetParent(dir);
        if (parent == null)
        {
            break;
        }

        dir = parent.FullName;
    }
    return null;
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

internal static partial class Regexes
{
    [GeneratedRegex(@"_\d+$")]
    public static partial Regex TrailingGeneric();
    [GeneratedRegex(@"`+(\d+)")]
    public static partial Regex GenericArg();
    [GeneratedRegex(@"`{2,}(\d+)")]
    public static partial Regex MethodGenericArg();
    [GeneratedRegex(@"`+\d+")]
    public static partial Regex GenericTick();
    [GeneratedRegex(@"\((.+)\)$")]
    public static partial Regex MethodParams();
    [GeneratedRegex(@"\[\]$")]
    public static partial Regex TrailingArray();
    [GeneratedRegex(@".*\.(\w+)`?\d*\[")]
    public static partial Regex GenericArray();
    [GeneratedRegex(@"\]$")]
    public static partial Regex TrailingBracket();
}

internal static partial class Helpers
{
    [GeneratedRegex(@"\s+")]
    public static partial Regex MultipleWhitespace();

    public static string CollapseWhitespace(string s) =>
        MultipleWhitespace().Replace(s.Trim(), " ");

    public static string StripCref(string cref)
    {
        cref = cref.Length > 2 && cref[1] == ':' ? cref[2..] : cref;
        var paren = cref.IndexOf('(');
        return paren >= 0 ? cref[..paren] : cref;
    }

    public static string SanitizeFileName(string name)
    {
        Span<char> buf = stackalloc char[name.Length];
        int j = 0;
        foreach (var c in name)
        {
            if (c is ':' or '"' or '|' or '?' or '*')
            {
                buf[j++] = '_';
            }
            else
            {
                buf[j++] = c;
            }
        }
        return new string(buf[..j]);
    }

    public static string ResolveGenericArgs(string text, List<string> typeParamNames, int methodGenericCount)
    {
        if (typeParamNames.Count == 0)
        {
            return text;
        }

        var typeParamCount = typeParamNames.Count - methodGenericCount;
        text = Regexes.MethodGenericArg().Replace(text, m =>
        {
            var idx = int.Parse(m.Groups[1].Value);
            var adjustedIdx = typeParamCount + idx;
            return adjustedIdx < typeParamNames.Count ? typeParamNames[adjustedIdx] : m.Value;
        });
        text = Regexes.GenericArg().Replace(text, m =>
        {
            var idx = int.Parse(m.Groups[1].Value);
            return idx < typeParamCount ? typeParamNames[idx] : m.Value;
        });
        return text;
    }
}

// ── Model ──

file record ParamInfo(string Name, string Description);
file record ExceptionInfo(string Type, string Description);
file record ProjectInfo(string CsprojPath, string ProjectDir, string AssemblyName, string? RootNamespace, string ProjectName);

file class TypeDoc
{
    public string Namespace { get; set; } = "";
    public string TypeName { get; set; } = "";
    public string Summary { get; set; } = "";
    public string Remarks { get; set; } = "";
    public List<ParamInfo> TypeParams { get; set; } = [];
    public List<string> TypeParamNames { get; set; } = [];
    public string GenericDisplayName
    {
        get
        {
            var baseName = Regexes.TrailingGeneric().Replace(TypeName, "");
            return TypeParamNames.Count > 0
                ? $"{baseName}<{string.Join(", ", TypeParamNames)}>"
                : baseName;
        }
    }
    public List<MemberDoc> Constructors { get; set; } = [];
    public List<MemberDoc> Methods { get; set; } = [];
    public List<MemberDoc> Properties { get; set; } = [];
    public List<MemberDoc> Events { get; set; } = [];
    public List<MemberDoc> Fields { get; set; } = [];
    public List<TypeDoc> NestedTypes { get; set; } = [];
}

file class MemberDoc
{
    public string DisplayName { get; set; } = "";
    public string Heading { get; set; } = "";
    public string InheritedSuffix { get; set; } = "";
    public string Signature { get; set; } = "";
    public string Summary { get; set; } = "";
    public string Remarks { get; set; } = "";
    public string Returns { get; set; } = "";
    public List<ParamInfo> Params { get; set; } = [];
    public List<ExceptionInfo> Exceptions { get; set; } = [];
    public string Example { get; set; } = "";
    public List<string> SeeAlso { get; set; } = [];
    public bool HasParams => Params.Count > 0;
    public bool HasReturns => !string.IsNullOrWhiteSpace(Returns);
    public bool HasRemarks => !string.IsNullOrWhiteSpace(Remarks);
    public bool HasExceptions => Exceptions.Count > 0;
    public bool HasExample => !string.IsNullOrWhiteSpace(Example);
}

// ── Template Engine (Fluid) ──

file class Template
{
    private static readonly FluidParser _parser = new();
    private static readonly TemplateOptions _options;

    static Template()
    {
        _options = new TemplateOptions();
        _options.Trimming = TrimmingFlags.None;
        _options.Greedy = false;
        _options.MemberAccessStrategy.Register<MemberDoc>();
        _options.MemberAccessStrategy.Register<ParamInfo>();
        _options.MemberAccessStrategy.Register<ExceptionInfo>();
    }

    private readonly IFluidTemplate _template;

    private Template(IFluidTemplate template) => _template = template;

    public static Template Load(string path)
    {
        var source = File.ReadAllText(path);
        if (!_parser.TryParse(source, out var template, out var error))
        {
            throw new InvalidOperationException($"Template parse error: {error}");
        }

        return new Template(template);
    }

    public string Render(object model)
    {
        var ctx = new TemplateContext(_options);
        if (model is IDictionary<string, object?> dict)
        {
            foreach (var (key, value) in dict)
            {
                ctx.SetValue(key, value);
            }
        }
        else
        {
            ctx = new TemplateContext(model, _options);
        }
        return _template.Render(ctx);
    }
}

// ── XML Parser ──

file class XmlDocParser
{
    private readonly Dictionary<string, XElement> _generatedMembers = new();

    public (Dictionary<string, TypeDoc> types, string rootNamespace) Parse(string xmlPath)
    {
        var doc = XDocument.Load(xmlPath);
        var types = new Dictionary<string, TypeDoc>();
        string rootNamespace = doc.Root?.Element("assembly")?.Element("name")?.Value ?? "";

        // First pass: collect members for inheritdoc resolution
        foreach (var member in doc.Descendants("member"))
        {
            var name = member.Attribute("name")?.Value;
            if (name != null)
            {
                _generatedMembers[name] = member;
            }
        }

        // Second pass: process all members
        foreach (var member in doc.Descendants("member"))
        {
            var name = member.Attribute("name")?.Value;
            if (name == null)
            {
                continue;
            }

            var (kind, full) = name.Length >= 2 ? (name[..2], name[2..]) : ("", "");

            if (kind == "N:")
            {
                if (string.IsNullOrEmpty(rootNamespace))
                {
                    rootNamespace = full;
                }

                continue;
            }

            if (full.Contains("<G>$"))
            {
                continue;
            }

            var parenIdx = full.IndexOf('(');
            var beforeParams = parenIdx >= 0 ? full[..parenIdx] : full;

            string ns, typeName;
            if (kind == "T:")
            {
                var lastDot = beforeParams.LastIndexOf('.');
                if (lastDot < 0)
                {
                    continue;
                }

                ns = beforeParams[..lastDot];
                typeName = beforeParams[(lastDot + 1)..];
            }
            else
            {
                var lastDot = beforeParams.LastIndexOf('.');
                if (lastDot < 0)
                {
                    continue;
                }

                var secondLastDot = beforeParams.LastIndexOf('.', lastDot - 1);
                if (secondLastDot < 0)
                {
                    continue;
                }

                ns = beforeParams[..secondLastDot];
                typeName = beforeParams[(secondLastDot + 1)..lastDot];
            }

            if (ns == "System" || ns.StartsWith("System."))
            {
                continue;
            }

            var displayTypeName = Regexes.GenericArg().Replace(typeName, "_$1");
            var nestedDot = typeName.IndexOf('.');
            string rootType = nestedDot >= 0 ? typeName[..nestedDot] : typeName;
            var key = $"{ns}/{rootType}";

            if (!types.ContainsKey(key))
            {
                types[key] = new TypeDoc { Namespace = ns, TypeName = Regexes.GenericArg().Replace(rootType, "_$1") };
            }

            if (kind == "T:")
            {
                var typeDoc = types[key];

                foreach (var tp in member.Elements("typeparam"))
                {
                    typeDoc.TypeParams.Add(new ParamInfo(tp.Attribute("name")?.Value ?? "", ConvertXmlToMarkdown(tp) ?? ""));
                }

                typeDoc.TypeParamNames = typeDoc.TypeParams.Select(tp => tp.Name).ToList();

                typeDoc.Summary = ConvertXmlToMarkdown(member.Element("summary"), typeDoc.TypeParamNames) ?? typeDoc.Summary;
                typeDoc.Remarks = ConvertXmlToMarkdown(member.Element("remarks"), typeDoc.TypeParamNames) ?? typeDoc.Remarks;

                if (nestedDot >= 0)
                {
                    var parentKey = $"{ns}/{typeName[..nestedDot]}";
                    if (!types.ContainsKey(parentKey))
                    {
                        types[parentKey] = new TypeDoc { Namespace = ns, TypeName = Regexes.GenericTick().Replace(typeName[..nestedDot], "") };
                    }
                    types[parentKey].NestedTypes.Add(new TypeDoc { TypeName = displayTypeName, Summary = typeDoc.Summary, Namespace = ns });
                }
            }
            else
            {
                var typeDoc = types[key];

                // Extract method-level type params (appended after type-level params)
                var methodTypeParamNames = new List<string>(typeDoc.TypeParamNames);
                List<string> methodGenericTypeParams = [];
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
                            memberDoc.DisplayName = memberDoc.DisplayName[4..];
                            memberDoc.Signature = memberDoc.DisplayName;
                            typeDoc.Properties.Add(memberDoc);
                        }
                        else if (memberDoc.DisplayName == "#ctor" || memberDoc.DisplayName == "#cctor")
                        {
                            memberDoc.DisplayName = typeDoc.GenericDisplayName;
                            typeDoc.Constructors.Add(memberDoc);
                        }
                        else
                        {
                            typeDoc.Methods.Add(memberDoc);
                        }
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
        var full = name[2..];
        var parenIdx = full.IndexOf('(');
        var beforeParams = parenIdx >= 0 ? full[..parenIdx] : full;
        var lastDot = beforeParams.LastIndexOf('.');
        var memberPart = lastDot >= 0 ? beforeParams[(lastDot + 1)..] : beforeParams;

        var displayName = Regexes.GenericTick().Replace(memberPart, "");

        var methodGenericArity = 0;
        var arityMatch = Regexes.GenericArg().Match(memberPart);
                    if (arityMatch.Success)
                    {
                        methodGenericArity = int.Parse(arityMatch.Groups[1].Value);
                    }

        List<string> methodGenericTypeParams = [];
        if (methodGenericArity > 0)
        {
            for (int i = 0; i < methodGenericArity; i++)
            {
                methodGenericTypeParams.Add(i == 0 ? "T" : $"T{i + 1}");
            }
        }

        var signature = BuildSignature(full, displayName, kind, typeParamNames, methodGenericTypeParams);
        var isInherited = member.Element("inheritdoc") != null;

        XElement? source = member;
        if (isInherited && member.Element("inheritdoc") is { } inheritdoc)
        {
            var cref = inheritdoc.Attribute("cref")?.Value;
            if (cref != null && _generatedMembers.TryGetValue(cref, out var target))
            {
                source = target;
            }
            else if (cref == null)
            {
                var currentMethodName = name.Contains('.') ? name[(name.LastIndexOf('.') + 1)..] : name;
                var inheritedMatch = _generatedMembers
                    .Where(kvp => kvp.Key != name &&
                                  kvp.Key.EndsWith($".{currentMethodName}") &&
                                  !kvp.Key.Contains("<G>$"))
                    .Select(kvp => kvp.Value)
                    .FirstOrDefault();
                if (inheritedMatch != null)
                {
                    source = inheritedMatch;
                }
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

        signature = AppendParamNames(signature, paramList);

        var exceptionList = source.Elements("exception")
            .Select(e =>
            {
                var cref = Helpers.StripCref(e.Attribute("cref")?.Value ?? "");
                return new ExceptionInfo(cref, ConvertXmlToMarkdown(e, typeParamNames, methodGenericTypeParams) ?? "");
            }).ToList();

        var example = ConvertXmlToMarkdown(source.Element("example"), typeParamNames, methodGenericTypeParams) ?? "";
        var seeAlso = source.Elements("seealso")
            .Select(sa => sa.Attribute("cref")?.Value ?? "")
            .Where(c => c.Length > 0)
            .Select(c => Helpers.StripCref(c))
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

    private string BuildSignature(string full, string displayName, string kind, List<string> typeParamNames, List<string> methodGenericTypeParams)
    {
        if (kind != "M:")
        {
            return displayName;
        }

        var genericDisplay = methodGenericTypeParams.Count > 0
            ? $"<{string.Join(", ", methodGenericTypeParams)}>"
            : "";

        var match = Regexes.MethodParams().Match(full);
        if (!match.Success)
        {
            return $"{displayName}{genericDisplay}()";
        }

        var paramStr = match.Groups[1].Value;
        var converted = paramStr.Replace("{", "<").Replace("}", ">");
        var displayParams = SplitParams(converted)
            .Select(p =>
            {
                p = p.Trim();
                p = StripNamespace(p);
                p = Helpers.ResolveGenericArgs(p, typeParamNames, methodGenericTypeParams.Count);
                p = Regexes.GenericTick().Replace(p, "");
                p = p.Replace("@", "");
                p = Regexes.TrailingArray().Replace(p, "[]");
                p = Regexes.GenericArray().Replace(p, "$1<");
                p = Regexes.TrailingBracket().Replace(p, ">");
                p = NormalizeGenericSpacing(p);
                return p;
            })
            .ToList();

        return $"{displayName}{genericDisplay}({string.Join(", ", displayParams)})";
    }

    private string AppendParamNames(string signature, List<ParamInfo> paramList)
    {
        if (paramList.Count == 0)
        {
            return signature;
        }

        var open = signature.IndexOf('(');
        var close = signature.LastIndexOf(')');
        if (open < 0 || close < 0)
        {
            return signature;
        }

        var paramStr = signature[(open + 1)..close];
        if (string.IsNullOrWhiteSpace(paramStr))
        {
            return signature;
        }

        var types = SplitParams(paramStr);
        var offset = types.Count - paramList.Count;
        if (offset < 0)
        {
            return signature;
        }

        var enhanced = types.Select((type, i) =>
        {
            var idx = i - offset;
            if (idx >= 0 && idx < paramList.Count)
            {
                var name = paramList[idx].Name;
                if (!string.IsNullOrEmpty(name))
                {
                    return $"{type} {name}";
                }
            }
            return type;
        }).ToList();

        return $"{signature[..(open + 1)]}{string.Join(", ", enhanced)}{signature[close..]}";
    }

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
                {
                    sb.Remove(segStart, lastDot + 1);
                }

                if (!atEnd)
                {
                    sb.Append(c);
                }

                if (c == '<')
                {
                    depth++;
                }
                else if (c == '>')
                {
                    depth--;
                }
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
        List<string> result = [];
        int depth = 0, start = 0;
        for (int i = 0; i <= paramStr.Length; i++)
        {
            if (i == paramStr.Length || (paramStr[i] == ',' && depth == 0))
            {
                result.Add(paramStr[start..i].Trim());
                start = i + 1;
            }
            else if (i < paramStr.Length && paramStr[i] == '<')
            {
                depth++;
            }
            else if (i < paramStr.Length && paramStr[i] == '>')
            {
                depth--;
            }
        }
        return result;
    }

    private static string FormatGenericArity(string aritySuffix)
    {
        var digits = Regex.Match(aritySuffix, @"\d+");
        if (!digits.Success)
        {
            return "";
        }

        var n = int.Parse(digits.Value);
        if (n <= 0)
        {
            return "";
        }

        var names = new List<string>(n);
        for (int i = 0; i < n; i++)
        {
            names.Add(i == 0 ? "T" : $"T{i + 1}");
        }

        return $"&lt;{string.Join(", ", names)}&gt;";
    }

    private static string NormalizeGenericSpacing(string type)
    {
        int depth = 0;
        var sb = new System.Text.StringBuilder(type.Length + 4);
        for (int i = 0; i < type.Length; i++)
        {
            if (type[i] == '<')
            {
                depth++;
            }
            else if (type[i] == '>')
            {
                depth--;
            }

            if (type[i] == ',' && depth > 0)
            {
                sb.Append(',');
                if (i + 1 < type.Length && type[i + 1] != ' ')
                {
                    sb.Append(' ');
                }
            }
            else
            {
                sb.Append(type[i]);
            }
        }
        return sb.ToString();
    }

    private static string CollapseWhitespace(string s) => Helpers.CollapseWhitespace(s);

    private string? ConvertXmlToMarkdown(XElement? node, List<string>? typeParamNames = null, List<string>? methodGenericTypeParams = null)
    {
        if (node == null)
        {
            return null;
        }

        List<string> parts = [];
        foreach (var child in node.Nodes())
        {
            if (child is XText text)
            {
                parts.Add(CollapseWhitespace(text.Value));
            }
            else if (child is XElement el)
            {
                switch (el.Name.LocalName)
                {
                    case "see" when el.Attribute("cref") != null:
                        var crName = Helpers.StripCref(el.Attribute("cref")!.Value);
                        if (typeParamNames != null && typeParamNames.Count > 0)
                        {
                            crName = Helpers.ResolveGenericArgs(crName, typeParamNames, methodGenericTypeParams?.Count ?? 0);
                        }

                        crName = Regexes.GenericTick().Replace(crName, m => FormatGenericArity(m.Value));
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
                        parts.Add($"**{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}**");
                        break;
                    case "code":
                        var lang = el.Attribute("language")?.Value ?? "";
                        parts.Add($"```{lang}\n{el.Value.TrimEnd()}\n```");
                        break;
                    case "b":
                        parts.Add($"**{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}**");
                        break;
                    case "i":
                        parts.Add($"*{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}*");
                        break;
                    case "u":
                        parts.Add($"<u>{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}</u>");
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
                        parts.Add($"\n{ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}\n");
                        break;
                    case "list":
                        var listType = el.Attribute("type")?.Value ?? "bullet";
                        var listParts = el.Elements("item")
                            .Select((item, idx) =>
                            {
                                var term = ConvertXmlToMarkdown(item.Element("term"), typeParamNames, methodGenericTypeParams) ?? "";
                                var desc = ConvertXmlToMarkdown(item.Element("description"), typeParamNames, methodGenericTypeParams) ?? "";
                                return listType == "number"
                                    ? $"{idx + 1}. **{term}** — {desc}"
                                    : $"- **{term}** — {desc}";
                            }).ToList();
                        parts.Add(string.Join("\n", listParts));
                        break;
                    case "exception":
                        var exCref = Helpers.StripCref(el.Attribute("cref")?.Value ?? "");
                        parts.Add($"- **{exCref}**: {ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams)}");
                        break;
                    default:
                        parts.Add(ConvertXmlToMarkdown(el, typeParamNames, methodGenericTypeParams) ?? "");
                        break;
                }
            }
        }
        
        var result = string.Join(" ", parts).Trim();
        if (typeParamNames != null && typeParamNames.Count > 0)
        {
            result = Helpers.ResolveGenericArgs(result, typeParamNames, methodGenericTypeParams?.Count ?? 0);
        }

        result = Regexes.GenericTick().Replace(result, m => FormatGenericArity(m.Value));
        return result;
    }
}

// ── Markdown Generator ──

file class MarkdownGenerator
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

                var sigParts = m.Signature;
                var parenIndex = sigParts.IndexOf('(');
                return parenIndex >= 0 ? $"{m.DisplayName}{sigParts[parenIndex..]}" : m.DisplayName;
            }).ToList();

            var methodBodies2 = typeDoc.Methods.Select((m, i) =>
            {
                membersProcessed++;
                m.Heading = methodHeadings[i];
                return _memberTemplate.Render(BuildMemberContext(m));
            }).ToList();

            var nestedBodies = typeDoc.NestedTypes.Select(n => $"### {n.TypeName}\n\n{n.Summary}").ToList();

            membersProcessed += typeDoc.Constructors.Count;

            var context = new Dictionary<string, object?>
            {
                ["TypeName"] = typeDoc.GenericDisplayName,
                ["Namespace"] = ns,
                ["Summary"] = typeDoc.Summary,
                ["Remarks"] = typeDoc.Remarks,
                ["TypeParams"] = typeDoc.TypeParams,
                ["Constructors"] = typeDoc.Constructors,
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

            nsTypes[ns].Add((typeDoc.GenericDisplayName, safeName));
        }

        // Generate per-namespace README.md files
        foreach (var (ns, typeEntries) in nsTypes)
        {
            var nsFolder = SimplifyNamespace(ns);
            var folder = Path.Combine(outputPath, nsFolder);
            Directory.CreateDirectory(folder);

            var readme = new System.Text.StringBuilder();
            var projectFolder = nsFolder.Split('/')[0];
            readme.Append(nsFolder.Contains('/')
                ? $"[← {projectFolder}]({string.Join("/", Enumerable.Repeat("..", nsFolder.Split('/').Length - 1))}/README.md)\n\n"
                : $"[← Documentation](../README.md)\n\n");
            readme.Append($"# {ns}\n\n## Types\n");
            foreach (var entry in typeEntries.OrderBy(x => x.displayName))
            {
                readme.Append($"- [{Esc(entry.displayName)}]({entry.fileName}.md)\n");
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
        foreach (var raw in lines)
        {
            var line = raw.TrimEnd('\r');
            bool isBlank = string.IsNullOrWhiteSpace(line);
            if (isBlank && lastWasBlank)
            {
                continue;
            }

            result.Add(line);
            lastWasBlank = isBlank;
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
