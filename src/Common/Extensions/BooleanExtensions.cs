namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="bool"/>.
/// </summary>
public static class BooleanExtensions
{
    extension(bool value)
    {
        /// <summary>
        /// Converts a boolean value to its corresponding text representation.
        /// </summary>
        /// <param name="trueText">The text to return if the value is true. Defaults to "Yes".</param>
        /// <param name="falseText">The text to return if the value is false. Defaults to "No".</param>
        /// <returns>The corresponding text for the boolean value.</returns>
        public string ConvertToText(in string trueText = "Yes", in string falseText = "No")
            => value ? trueText : falseText;
    }
}
