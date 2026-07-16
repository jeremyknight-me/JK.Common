using System.Xml.Linq;
using System.Text.RegularExpressions;

public class XmlDocParser
{
    private readonly Dictionary<string, XElement> _generatedMembers = [];

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
                if (typeDoc.TypeParamNames.Count == 0)
                {
                    var arityMatch = Regexes.GenericArg().Match(rootType);
                    if (arityMatch.Success)
                    {
                        var n = int.Parse(arityMatch.Groups[1].Value);
                        typeDoc.TypeParamNames = Enumerable.Range(0, n)
                            .Select(i => i == 0 ? "T" : $"T{i + 1}")
                            .ToList();
                    }
                }

                typeDoc.Summary = ConvertXmlToMarkdown(member.Element("summary"), typeDoc.TypeParamNames) ?? typeDoc.Summary;
                typeDoc.Remarks = ConvertXmlToMarkdown(member.Element("remarks"), typeDoc.TypeParamNames) ?? typeDoc.Remarks;

                var nsLastDot = ns.LastIndexOf('.');
                if (nsLastDot >= 0)
                {
                    var parentNs = ns[..nsLastDot];
                    var parentTypeLeaf = ns[(nsLastDot + 1)..];
                    var parentKey = $"{parentNs}/{parentTypeLeaf}";
                    if (types.TryGetValue(parentKey, out var parentDoc))
                    {
                        parentDoc.NestedTypes.Add(new TypeDoc { TypeName = displayTypeName, Summary = typeDoc.Summary, Namespace = ns });
                    }
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
                    var methodLastDot = beforeParams.LastIndexOf('.');
                    var methodPart = methodLastDot >= 0 ? beforeParams[(methodLastDot + 1)..] : beforeParams;
                    var methodGenericMatch = Regexes.GenericArg().Match(methodPart);
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
                            var ctorParen = memberDoc.Signature.IndexOf('(');
                            memberDoc.Signature = ctorParen >= 0
                                ? $"{typeDoc.GenericDisplayName}{memberDoc.Signature[ctorParen..]}"
                                : typeDoc.GenericDisplayName;
                            memberDoc.Heading = typeDoc.GenericDisplayName;
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
        if (types.Count != paramList.Count)
        {
            return signature;
        }

        var enhanced = types
            .Select((type, i) =>
            {
                var name = paramList[i].Name;
                if (!string.IsNullOrEmpty(name))
                {
                    return $"{type} {name}";
                }
                return type;
            })
            .ToList();
        return $"{signature[..(open + 1)]}{string.Join(", ", enhanced)}{signature[close..]}";
    }

    private static string StripNamespace(string type)
    {
        System.Text.StringBuilder sb = new(type.Length);
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
        int depth = 0, bracketDepth = 0, start = 0;
        for (int i = 0; i <= paramStr.Length; i++)
        {
            if (i == paramStr.Length || (paramStr[i] == ',' && depth == 0 && bracketDepth == 0))
            {
                result.Add(paramStr.AsSpan(start, i - start).Trim().ToString());
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
            else if (i < paramStr.Length && paramStr[i] == '[')
            {
                bracketDepth++;
            }
            else if (i < paramStr.Length && paramStr[i] == ']')
            {
                bracketDepth--;
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
        System.Text.StringBuilder sb = new(type.Length + 4);
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
                            })
                            .ToList();
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
        result = Regex.Replace(result, " (?=[.,;:!?](?:\\s|$))", "");
        if (typeParamNames != null && typeParamNames.Count > 0)
        {
            result = Helpers.ResolveGenericArgs(result, typeParamNames, methodGenericTypeParams?.Count ?? 0);
        }

        result = Regexes.GenericTick().Replace(result, m => FormatGenericArity(m.Value));
        return result;
    }
}
