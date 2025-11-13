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
    extension(string text)
    {
        
        /// <summary>
        /// Converts a Base64-encoded string to its decoded string representation using the specified encoding.
        /// </summary>
        /// <param name="encoding">The encoding to use for decoding. If null, ASCII encoding is used.</param>
        /// <returns>The decoded string, or the original string if it is null or empty.</returns>
        public string ConvertFromBase64(Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            encoding ??= new ASCIIEncoding();
            return encoding.GetString(Convert.FromBase64String(text));
        }

        /// <summary>
        /// Converts the current string to its Base64-encoded representation using the specified encoding.
        /// </summary>
        /// <param name="encoding">The encoding to use for encoding. If null, ASCII encoding is used.</param>
        /// <returns>The Base64-encoded string, or the original string if it is null or empty.</returns>
        public string ConvertToBase64(Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            encoding ??= new ASCIIEncoding();
            return Convert.ToBase64String(encoding.GetBytes(text));
        }

        /// <summary>
        /// Determines if the given string is a date/time. 
        /// Relies on <see cref="DateTimeSpecification"/>
        /// </summary>
        /// <returns>True if a date, otherwise false.</returns>
        public bool IsDateTime => new DateTimeSpecification().IsSatisfiedBy(text);

        /// <summary>
        /// Determines whether the string is <c>null</c>.
        /// </summary>
        /// <remarks>
        /// Returns <c>true</c> if the string is <c>null</c>; otherwise, <c>false</c>.
        /// </remarks>
        public bool IsNull() => text is null;

        /// <summary>
        /// Determines whether the string is <c>null</c> or an empty string.
        /// </summary>
        /// <remarks>
        /// Returns <c>true</c> if the string is <c>null</c> or an empty string; otherwise, <c>false</c>.
        /// </remarks>
        public bool IsNullOrEmpty() => string.IsNullOrEmpty(text);

        /// <summary>
        /// Determines whether the string is <c>null</c>, empty, or consists only of white-space characters.
        /// </summary>
        /// <remarks>
        /// Returns <c>true</c> if the string is <c>null</c>, empty, or consists only of white-space characters; otherwise, <c>false</c>.
        /// </remarks>
        public bool IsNullOrWhiteSpace() => string.IsNullOrWhiteSpace(text);

        /// <summary>
        /// Determines if the given string is a number.
        /// Relies on <see cref="NumericSpecification"/>
        /// </summary>
        /// <returns>True if a number, otherwise false.</returns>
        public bool IsNumeric => new NumericSpecification().IsSatisfiedBy(text);

        /// <summary>
        /// Validates that a string is a valid email address.
        /// Relies on <see cref="EmailSpecification"/>
        /// </summary>
        /// <returns>True if valid email otherwise false.</returns>
        public bool IsValidEmailAddress => new EmailSpecification().IsSatisfiedBy(text);

        /// <summary>
        /// Validates that a string is a valid IP v4 address.
        /// Relies on <see cref="InternetProtocolAddressSpecification"/>
        /// </summary>
        /// <returns>True if valid IP v4 address otherwise false.</returns>
        public bool IsValidIpAddress => new InternetProtocolAddressSpecification().IsSatisfiedBy(text);

        /// <summary>
        /// Validates that a string is a valid United States phone number.
        /// Relies on <see cref="PhoneNumberSpecification"/>
        /// </summary>
        /// <returns>True if valid US phone number otherwise false.</returns>
        public bool IsValidUnitedStatesPhoneNumber => new PhoneNumberSpecification().IsSatisfiedBy(text);

        /// <summary>
        /// Validates that a string is a valid zip code.
        /// Relies on <see cref="ZipCodeSpecification"/>
        /// </summary>
        /// <returns>True if valid zip code otherwise false.</returns>
        public bool IsValidZip => new ZipCodeSpecification().IsSatisfiedBy(text);

        /// <summary>
        /// Removes US (dollar) currency format characters from a string.
        /// </summary>
        /// <returns>String that can be parsed into a number.</returns>
        public string RemoveUnitedStatesCurrencyFormat()
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            var returnValue = text.Trim("$".ToCharArray());
            returnValue = returnValue.Replace(",", string.Empty);
            return string.IsNullOrWhiteSpace(returnValue) ? "0" : returnValue;
        }

        /// <summary>
        /// Removes XML/HTML from given text block.
        /// </summary>
        /// <returns>Clean string with no XML/HTML.</returns>
        public string RemoveXml() => Regex.Replace(text, @"<(.|\n)*?>", string.Empty);

        /// <summary>
        /// Reverses the characters within a string.
        /// </summary>
        /// <returns>The original string in reverse.</returns>
        public string Reverse()
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            var c = text.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        /// <summary>
        /// Returns the specified number of characters from the end of string. Same as <see cref="Last"/>.
        /// </summary>
        /// <param name="length">Number of characters to get from end of string.</param>
        /// <returns>Returns the last X characters of the string.</returns>
        public string Right(in int length)
            => text switch
            {
                var t when string.IsNullOrEmpty(t) => string.Empty,
                var t when t.Length > length => t[^length..],
                _ => text,
            };

        /// <summary>
        /// Attempts to parse the string as a decimal value. Returns null if the string is null, whitespace, or not a valid decimal.
        /// </summary>
        /// <returns>The parsed decimal value, or null if parsing fails.</returns>
        public decimal? ToNullableDecimal()
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return !decimal.TryParse(text, out var number)
                ? null
                : number;
        }

        /// <summary>
        /// Attempts to parse the string as an integer value. Returns null if the string is null, whitespace, or not a valid integer.
        /// </summary>
        /// <returns>The parsed integer value, or null if parsing fails.</returns>
        public int? ToNullableInteger()
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return !int.TryParse(text, out var number)
                ? null
                : number;
        }

        /// <summary>
        /// Converts a null string to an empty string.
        /// </summary>
        /// <returns>An empty string if null; otherwise, the original string.</returns>
        public string ToNullIfEmpty() => text ?? string.Empty;

        /// <summary>
        /// Trims a block of text to a specified length. The string will be trimmed to 
        /// the previous space coming before the length position passed.
        /// Relies on <see cref="StringTruncater"/>
        /// </summary>
        /// <param name="length">Number of characters to keep from the original string.</param>
        /// <returns>Truncated, or shortened, text.</returns>
        public string Truncate(in int length) => new StringTruncater(text).TruncateToLength(length);

        /// <summary>
        /// Trims a block of text to a specified length. The string will be trimmed to 
        /// the previous space coming before the length position passed.
        /// Relies on <see cref="StringTruncater"/>
        /// </summary>
        /// <param name="length">Number of characters to keep from the original string.</param>
        /// <param name="indicator">String of characters to indicate that a truncation has occurred.</param>
        /// <returns>Truncated, or shortened, text with an indicator marking where the truncation occurred.</returns>
        public string Truncate(in int length, in string indicator)
        {
            var truncater = new StringTruncater(text) { Indicator = indicator };
            return truncater.TruncateToLength(length);
        }

#if NET7_0_OR_GREATER

        /// <summary>
        /// Parses a string into a specified type. 
        /// </summary>
        /// <typeparam name="T">Type to parse string value to which must implement <see cref="System.IParsable{T}"/></typeparam>
        /// <param name="formatProvider">Format provider to pass down to the <see cref="IParsable{T}.Parse"/> method.</param>
        /// <returns>Parsed value of type T.</returns>
        public T Parse<T>(IFormatProvider formatProvider = null)
            where T : IParsable<T>
            => T.Parse(text, formatProvider);

#endif
    }
}
