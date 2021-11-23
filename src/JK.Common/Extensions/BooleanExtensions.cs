namespace JK.Common.Extensions;

public static class BooleanExtensions
{
    public static string ConvertToText(this bool value, in string trueText = "Yes", in string falseText = "No")
        => value ? trueText : falseText;
}
