using System;
using System.Text.RegularExpressions;

namespace DL.Core.TypeExtensions
{
    public class StringUtility
    {
        public string RemoveUnitedStatesCurrencyFormat(string valueToFormat)
        {
            if (string.IsNullOrEmpty(valueToFormat))
            {
                throw new ArgumentNullException("valueToFormat");
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
                throw new ArgumentNullException("valueToReverse");
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
