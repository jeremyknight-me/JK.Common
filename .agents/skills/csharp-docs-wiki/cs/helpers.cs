using System.Text.RegularExpressions;

public static partial class Helpers
{
    [GeneratedRegex(@"\s+")] public static partial Regex MultipleWhitespace();

    public static string CollapseWhitespace(string s) => MultipleWhitespace().Replace(s.Trim(), " ");

    public static string StripCref(string cref)
    {
        cref = cref.Length > 2 && cref[1] == ':' ? cref[2..] : cref;
        var paren = cref.IndexOf('(');
        return paren >= 0 ? cref[..paren] : cref;
    }

    public static void DeleteLegacyNamespaceFile(string readmePath, string outputPath)
    {
        var resolvedReadmePath = Path.GetFullPath(readmePath);
        var resolvedOutputPath = Path.GetFullPath(outputPath);
        var readmeFolder = Path.GetDirectoryName(resolvedReadmePath);
        if (string.IsNullOrWhiteSpace(readmeFolder) || string.Equals(readmeFolder, resolvedOutputPath, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        var parentFolder = Path.GetDirectoryName(readmeFolder);
        if (string.IsNullOrWhiteSpace(parentFolder))
        {
            return;
        }

        var legacyPath = Path.Combine(parentFolder, Path.GetFileName(readmeFolder) + ".md");
        if (File.Exists(legacyPath))
        {
            File.Delete(legacyPath);
            Console.WriteLine($"Deleted: {legacyPath}");
        }
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