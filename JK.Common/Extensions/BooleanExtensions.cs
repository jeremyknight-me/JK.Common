namespace JK.Common.Extensions
{
    public static class BooleanExtensions
    {
        public static string ConvertToText(this bool value, string trueText = "Yes", string falseText = "No")
        {
            return value ? trueText : falseText;
        }
    }
}
