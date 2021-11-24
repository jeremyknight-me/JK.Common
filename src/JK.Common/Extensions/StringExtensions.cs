﻿using JK.Common.Specifications;
using JK.Common.Specifications.UnitedStates;
using JK.Common.Text;
using JK.Common.TypeHelpers;

namespace JK.Common.Extensions;

/// <summary>Extension methods for the String object.</summary>
public static class StringExtensions
{
    public static string ConvertNullToEmptyString(this string value) => value ?? string.Empty;

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

    /// <summary>Returns the specified number of characters from a string. Same as Last()</summary>
    /// <param name="value">Current string object from extension method.</param>
    /// <param name="length">Number of characters to get from end of string.</param>
    /// <returns>Returns the last X characters of the string.</returns>
    public static string Last(this string value, in int length) => StringHelper.Last(value, length);

    /// <summary>
    /// Removes US (dollar) currency format characters from a string.
    /// </summary>
    /// <param name="valueToFormat">Current string object from extension method.</param>
    /// <returns>String that can be parsed into a number.</returns>
    public static string RemoveUnitedStatesCurrencyFormat(this string valueToFormat) => StringHelper.RemoveUnitedStatesCurrencyFormat(valueToFormat);

    /// <summary>
    /// Reverses the characters within a string.
    /// </summary>
    /// <param name="valueToReverse">Current string object from extension method.</param>
    /// <returns>The original string in reverse.</returns>
    public static string Reverse(this string valueToReverse) => StringHelper.Reverse(valueToReverse);

    /// <summary>Returns the specified number of characters from a string. Same as Last()</summary>
    /// <param name="value">Current string object from extension method.</param>
    /// <param name="length">Number of characters to get from end of string.</param>
    /// <returns>Returns the last X characters of the string.</returns>
    public static string Right(this string value, in int length) => StringHelper.Right(value, length);

    /// <summary>
    /// Removes XML/HTML from given text block.
    /// </summary>
    /// <param name="valueToStrip">Current string object from extension method.</param>
    /// <returns>Clean string with no XML/HTML.</returns>
    public static string StripXml(this string valueToStrip) => StringHelper.StripXml(valueToStrip);

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
}
