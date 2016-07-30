using System.Web.UI;

namespace DL.Core.Web.TypeExtensions
{
    public static class TextControlExtensions
    {
        /// <summary>Gets a nullable decimal from the Text property of an ITextControl.</summary>
        /// <param name="control">Control of type ITextControl to use.</param>
        /// <returns>Null if empty or invalid, otherwise an decimal.</returns>
        public static decimal? GetNullableDecimal(this ITextControl control)
        {
            return (new NullableValueParser()).GetNullableDecimal(control.Text);
        }

        /// <summary>Get a nullable integer from the Text property of an ITextControl.</summary>
        /// <param name="control">Control of type ITextControl to use.</param>
        /// <returns>Null if empty or invalid, otherwise an integer.</returns>
        public static int? GetNullableInteger(this ITextControl control)
        {
            return (new NullableValueParser()).GetNullableInteger(control.Text);
        }

        /// <summary>Gets the trimmed text of a control inheriting from ITextControl.</summary>
        /// <param name="textControl">Control which inherits from ITextControl. Ex: TextBox, Literal, etc.</param>
        /// <returns>Text from the control or empty string if selected item is null.</returns>
        public static string GetValue(this ITextControl textControl)
        {
            return textControl.Text.Trim();
        }

        /// <summary>Extension method which inserts any value into the Text property of an ITextControl.</summary>
        /// <param name="control">Current ITextControl.</param>
        /// <param name="value">Value to insert into the Text property.</param>
        public static void LoadValue(this ITextControl control, object value)
        {
            control.Text = value.ToString();
        }
    }
}
