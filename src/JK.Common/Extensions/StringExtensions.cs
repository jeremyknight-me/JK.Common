using System.Text;
using System.Text.RegularExpressions;
using JK.Common.Specifications;
using JK.Common.Specifications.UnitedStates;
using JK.Common.Text;

namespace JK.Common.Extensions;

/// <summary>
/// Extension methods for the <see cref="string"/> object.
/// </summary>
public static class StringExtensions
{
    /// <summary>Converts a string from base 64.</summary>
    /// <param name="base64Text">Text to convert from base 64.</param>
    /// <returns>String converted from base 64.</returns>
    public static string ConvertFromBase64(in string base64Text)
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
    public static string ConvertToBase64(in string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        var encoding = new ASCIIEncoding();
        return Convert.ToBase64String(encoding.GetBytes(text));
    }

    /// <summary>
    /// Determines if the given string is a date/time. 
    /// Relies on <see cref="DateTimeSpecification"/>
    /// </summary>
    /// <param name="valueToValidate">Current string object from extension method.</param>
    /// <returns>True if a date, otherwise false.</returns>
    public static bool IsDateTime(this string valueToValidate) => new DateTimeSpecification().IsSatisfiedBy(valueToValidate);

    /// <summary>
    /// Determines if the given string is a number.
    /// Relies on <see cref="NumericSpecification"/>
    /// </summary>
    /// <param name="valueToValidate">Current string object from extension method.</param>
    /// <returns>True if a number, otherwise false.</returns>
    public static bool IsNumeric(this string valueToValidate) => new NumericSpecification().IsSatisfiedBy(valueToValidate);

    /// <summary>
    /// Validates that a string is a valid email address.
    /// Relies on <see cref="EmailSpecification"/>
    /// </summary>
    /// <param name="valueToValidate">Current string object from extension method.</param>
    /// <returns>True if valid email otherwise false.</returns>
    public static bool IsValidEmailAddress(this string valueToValidate) => new EmailSpecification().IsSatisfiedBy(valueToValidate);

    /// <summary>
    /// Validates that a string is a valid IP v4 address.
    /// Relies on <see cref="InternetProtocolAddressSpecification"/>
    /// </summary>
    /// <param name="valueToValidate">Current string object from extension method.</param>
    /// <returns>True if valid IP v4 address otherwise false.</returns>
    public static bool IsValidIpAddress(this string valueToValidate) => new InternetProtocolAddressSpecification().IsSatisfiedBy(valueToValidate);

    /// <summary>
    /// Validates that a string is a valid United States phone number.
    /// Relies on <see cref="PhoneNumberSpecification"/>
    /// </summary>
    /// <param name="valueToValidate">Current string object from extension method.</param>
    /// <returns>True if valid US phone number otherwise false.</returns>
    public static bool IsValidUnitedStatesPhoneNumber(this string valueToValidate) => new PhoneNumberSpecification().IsSatisfiedBy(valueToValidate);

    /// <summary>
    /// Validates that a string is a valid zip code.
    /// Relies on <see cref="ZipCodeSpecification"/>
    /// </summary>
    /// <param name="valueToValidate">Current string object from extension method.</param>
    /// <returns>True if valid zip code otherwise false.</returns>
    public static bool IsValidZip(this string valueToValidate) => new ZipCodeSpecification().IsSatisfiedBy(valueToValidate);

    /// <summary>
    /// Returns the specified number of characters from a string. Same as <see cref="Last"/>.
    /// </summary>
    /// <param name="value">Current string object from extension method.</param>
    /// <param name="length">Number of characters to get from end of string.</param>
    /// <returns>Returns the last X characters of the string.</returns>
    public static string Last(this string value, in int length) => value.Right(length);

    /// <summary>
    /// Removes US (dollar) currency format characters from a string.
    /// </summary>
    /// <param name="valueToFormat">Current string object from extension method.</param>
    /// <returns>String that can be parsed into a number.</returns>
    public static string RemoveUnitedStatesCurrencyFormat(this string valueToFormat)
    {
        if (string.IsNullOrWhiteSpace(valueToFormat))
        {
            throw new ArgumentNullException(nameof(valueToFormat));
        }

        var returnValue = valueToFormat.Trim("$".ToCharArray());
        returnValue = returnValue.Replace(",", string.Empty);
        return string.IsNullOrWhiteSpace(returnValue) ? "0" : returnValue;
    }

    /// <summary>
    /// Removes XML/HTML from given text block.
    /// </summary>
    /// <param name="valueToStrip">Current string object from extension method.</param>
    /// <returns>Clean string with no XML/HTML.</returns>
    public static string RemoveXml(this string valueToStrip)
        => Regex.Replace(valueToStrip, @"<(.|\n)*?>", string.Empty);

    /// <summary>
    /// Reverses the characters within a string.
    /// </summary>
    /// <param name="valueToReverse">Current string object from extension method.</param>
    /// <returns>The original string in reverse.</returns>
    public static string Reverse(this string valueToReverse)
    {
        if (string.IsNullOrEmpty(valueToReverse))
        {
            throw new ArgumentNullException(nameof(valueToReverse));
        }

        var c = valueToReverse.ToCharArray();
        Array.Reverse(c);
        return new string(c);
    }

    /// <summary>
    /// Returns the specified number of characters from a string. Same as <see cref="Last"/>.
    /// </summary>
    /// <param name="value">Current string object from extension method.</param>
    /// <param name="length">Number of characters to get from end of string.</param>
    /// <returns>Returns the last X characters of the string.</returns>
    public static string Right(this string value, in int length)
        => value switch
        {
            var v when string.IsNullOrEmpty(v) => string.Empty,
            var v when v.Length > length => v[^length..],
            _ => value,
        };

    /// <summary>
    /// Attempts to parse the string as a decimal value. Returns null if the string is null, whitespace, or not a valid decimal.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <returns>The parsed decimal value, or null if parsing fails.</returns>
    public static decimal? ToNullableDecimal(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return !decimal.TryParse(value, out var number)
            ? null
            : number;
    }

    /// <summary>
    /// Attempts to parse the string as an integer value. Returns null if the string is null, whitespace, or not a valid integer.
    /// </summary>
    /// <param name="value">The string to parse.</param>
    /// <returns>The parsed integer value, or null if parsing fails.</returns>
    public static int? ToNullableInteger(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return !int.TryParse(value, out var number)
            ? null
            : number;
    }

    /// <summary>
    /// Converts a null string to an empty string.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <returns>An empty string if <paramref name="value"/> is null; otherwise, the original string.</returns>
    public static string ToNullIfEmpty(this string value) => value ?? string.Empty;

    /// <summary>
    /// Trims a block of text to a specified length. The string will be trimmed to 
    /// the previous space coming before the length position passed.
    /// Relies on <see cref="StringTruncater"/>
    /// </summary>
    /// <param name="valueToTruncate">Current string object from extension method.</param>
    /// <param name="length">Number of characters to keep from the original string.</param>
    /// <returns>Truncated, or shortened, text.</returns>
    public static string Truncate(this string valueToTruncate, in int length) => new StringTruncater(valueToTruncate).TruncateToLength(length);

    /// <summary>
    /// Trims a block of text to a specified length. The string will be trimmed to 
    /// the previous space coming before the length position passed.
    /// Relies on <see cref="StringTruncater"/>
    /// </summary>
    /// <param name="valueToTruncate">Current string object from extension method.</param>
    /// <param name="length">Number of characters to keep from the original string.</param>
    /// <param name="indicator">String of characters to indicate that a truncation has occurred.</param>
    /// <returns>Truncated, or shortened, text with an indicator marking where the truncation occurred.</returns>
    public static string Truncate(this string valueToTruncate, in int length, in string indicator)
    {
        var truncater = new StringTruncater(valueToTruncate) { Indicator = indicator };
        return truncater.TruncateToLength(length);
    }

#if NET7_0_OR_GREATER

    /// <summary>
    /// Parses a string into a specified type. 
    /// </summary>
    /// <typeparam name="T">Type to parse string value to which must implement <see cref="System.IParsable{T}"/></typeparam>
    /// <param name="input">Current string object from extension method.</param>
    /// <param name="formatProvider">Format provider to pass down to the <see cref="IParsable{T}.Parse"/> method.</param>
    /// <returns>Parsed value of type T.</returns>
    public static T Parse<T>(this string input, IFormatProvider formatProvider = null)
        where T : IParsable<T>
        => T.Parse(input, formatProvider);

#endif
}
