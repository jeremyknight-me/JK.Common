using System;
using System.Text;
using System.Text.RegularExpressions;

namespace JK.Common.TypeHelpers;

public class StringHelper
{
    public decimal? GetNullableDecimal(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return !decimal.TryParse(value, out var number) ? null : number;
    }

    public int? GetNullableInteger(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return !int.TryParse(value, out var number) ? null : number;
    }

    public string RemoveUnitedStatesCurrencyFormat(string valueToFormat)
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
    public string Reverse(string valueToReverse)
    {
        if (string.IsNullOrEmpty(valueToReverse))
        {
            throw new ArgumentNullException(nameof(valueToReverse));
        }

        var c = valueToReverse.ToCharArray();
        Array.Reverse(c);
        return new string(c);
    }

    public string Right(string value, int length)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        return value.Length <= length
            ? value
            : value.Substring(value.Length - length);
    }

    /// <summary>
    /// Removes XML/HTML from given text block.
    /// </summary>
    /// <param name="valueToStrip">Current string object from extension method.</param>
    /// <returns>Clean string with no XML/HTML.</returns>
    public string StripXml(string valueToStrip) => Regex.Replace(valueToStrip, @"<(.|\n)*?>", string.Empty);

    #region Base64 Conversion

    /// <summary>Converts a string from base 64.</summary>
    /// <param name="base64Text">Text to convert from base 64.</param>
    /// <returns>String converted from base 64.</returns>
    public static string FromBase64(string base64Text)
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
    public static string ToBase64(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        var encoding = new ASCIIEncoding();
        return Convert.ToBase64String(encoding.GetBytes(text));
    }

    #endregion
}
