using System;
using System.Text;
using System.Text.RegularExpressions;

namespace JK.Common.TypeHelpers;

public static class StringHelper
{
    public static decimal? GetNullableDecimal(in string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return !decimal.TryParse(value, out var number) ? null : number;
    }

    public static int? GetNullableInteger(in string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return !int.TryParse(value, out var number) ? null : number;
    }

    /// <summary>Returns the specified number of characters from a string. Same as Right()</summary>
    /// <param name="value">The given string</param>
    /// <param name="length">Number of characters to get from end of string.</param>
    /// <returns>Returns the last X characters of the string.</returns>
    public static string Last(in string value, in int length) => Right(value, length);

    public static string RemoveUnitedStatesCurrencyFormat(in string valueToFormat)
    {
        if (string.IsNullOrEmpty(valueToFormat))
        {
            throw new ArgumentNullException(nameof(valueToFormat));
        }

        var returnValue = valueToFormat.Trim("$".ToCharArray());
        returnValue = returnValue.Replace(",", string.Empty);
        return string.IsNullOrEmpty(returnValue) ? "0" : returnValue;
    }

    /// <summary>
    /// Reverses the characters within a string.
    /// </summary>
    /// <param name="valueToReverse">Current string object from extension method.</param>
    /// <returns>The original string in reverse.</returns>
    public static string Reverse(in string valueToReverse)
    {
        if (string.IsNullOrEmpty(valueToReverse))
        {
            throw new ArgumentNullException(nameof(valueToReverse));
        }

        var c = valueToReverse.ToCharArray();
        Array.Reverse(c);
        return new string(c);
    }

    /// <summary>Returns the specified number of characters from a string. Same as Last()</summary>
    /// <param name="value">The given string</param>
    /// <param name="length">Number of characters to get from end of string.</param>
    /// <returns>Returns the last X characters of the string.</returns>
    public static string Right(in string value, in int length)
        => value switch
        {
            var v when string.IsNullOrEmpty(v) => string.Empty,
            var v when v.Length > length => v[^length..],
            _ => value,
        };

    /// <summary>
    /// Removes XML/HTML from given text block.
    /// </summary>
    /// <param name="valueToStrip">Current string object from extension method.</param>
    /// <returns>Clean string with no XML/HTML.</returns>
    public static string StripXml(in string valueToStrip) => Regex.Replace(valueToStrip, @"<(.|\n)*?>", string.Empty);

    #region Base64 Conversion

    /// <summary>Converts a string from base 64.</summary>
    /// <param name="base64Text">Text to convert from base 64.</param>
    /// <returns>String converted from base 64.</returns>
    public static string FromBase64(in string base64Text)
    {
        if (string.IsNullOrEmpty(base64Text))
        {
            return base64Text;
        }

        var encoding = new ASCIIEncoding();
        return encoding.GetString(Convert.FromBase64String(base64Text));
    }

    /// <summary>Converts a string to base 64.</summary>
    /// <param name="text">Text to convert to base 64.</param>
    /// <returns>String converted to base 64.</returns>
    public static string ToBase64(in string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        var encoding = new ASCIIEncoding();
        return Convert.ToBase64String(encoding.GetBytes(text));
    }

    #endregion

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER

    public static ReadOnlySpan<char> Slice(in string text, int start)
    {
        ReadOnlySpan<char> textAsSpan = text;
        return textAsSpan.Slice(start);
    }

    public static ReadOnlySpan<char> Slice(in string text, int start, int length)
    {
        ReadOnlySpan<char> textAsSpan = text;
        return textAsSpan.Slice(start, length);
    }

#endif
}
