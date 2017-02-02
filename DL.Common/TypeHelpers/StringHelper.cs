using System;
using System.Text.RegularExpressions;

namespace DL.Common.TypeHelpers
{
    public class StringHelper
    {
        public decimal? GetNullableDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            decimal number;
            if (!decimal.TryParse(value, out number))
            {
                return null;
            }

            return number;
        }

        public int? GetNullableInteger(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            int number;
            if (!int.TryParse(value, out number))
            {
                return null;
            }

            return number;
        }

        public string RemoveUnitedStatesCurrencyFormat(string valueToFormat)
        {
            if (string.IsNullOrEmpty(valueToFormat))
            {
                throw new ArgumentNullException(nameof(valueToFormat));
            }

            string returnValue = valueToFormat.Trim("$".ToCharArray());
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

            char[] c = valueToReverse.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }

        /// <summary>
        /// Removes XML/HTML from given text block.
        /// </summary>
        /// <param name="valueToStrip">Current string object from extension method.</param>
        /// <returns>Clean string with no XML/HTML.</returns>
        public string StripXml(string valueToStrip)
        {
            return Regex.Replace(valueToStrip, @"<(.|\n)*?>", string.Empty);
        }
    }
}
