using System.Text.RegularExpressions;

internal static partial class Regexes
{
    [GeneratedRegex(@"_\d+$")] public static partial Regex TrailingGeneric();
    [GeneratedRegex(@"`+(\d+)")] public static partial Regex GenericArg();
    [GeneratedRegex(@"`{2,}(\d+)")] public static partial Regex MethodGenericArg();
    [GeneratedRegex(@"`+\d+")] public static partial Regex GenericTick();
    [GeneratedRegex(@"\((.+)\)$")] public static partial Regex MethodParams();
    [GeneratedRegex(@"\[\]$")] public static partial Regex TrailingArray();
    [GeneratedRegex(@".*\.(\w+)`?\d*\[")] public static partial Regex GenericArray();
    [GeneratedRegex(@"\]$")] public static partial Regex TrailingBracket();
}