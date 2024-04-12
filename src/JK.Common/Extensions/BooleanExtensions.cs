namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="bool"/>.
/// </summary>
public static class BooleanExtensions
{
    public static string ConvertToText(this bool value, in string trueText = "Yes", in string falseText = "No")
        => value ? trueText : falseText;
}
