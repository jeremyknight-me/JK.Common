using System;

namespace DL.Core.TypeExtensions
{
    /// <summary>
    /// Class which contains methods which formats a DateTime into a string.
    /// </summary>
    public class DateTimeFormatter
    {
        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// full date and long time string representation.
        /// </summary>
        /// <param name="dateTime">DateTime to convert to a string.</param>
        /// <returns>Date and time string in the format: Sunday, January 31, 2010 12:45:30 PM</returns>
        public static string FormatAsFullDateLongTimeString(DateTime dateTime)
        {
            return string.Format("{0:f}", dateTime);
        }

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// full date and short time string representation.
        /// </summary>
        /// <param name="dateTime">DateTime to convert to a string.</param>
        /// <returns>Date and time string in the format: Sunday, January 31, 2010 12:45 PM</returns>
        public static string FormatAsFullDateShortTimeString(DateTime dateTime)
        {
            return string.Format("{0:f}", dateTime);
        }

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// general date and short time string representation.
        /// </summary>
        /// <param name="dateTime">DateTime to convert to a string.</param>
        /// <returns>Date and time string in the format: 1/31/2010 12:45 PM</returns>
        public static string FormatAsGeneralDateShortTimeString(DateTime dateTime)
        {
            return string.Format("{0:g}", dateTime);
        }

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// month and day string representation.
        /// </summary>
        /// <param name="dateTime">DateTime to convert to a string.</param>
        /// <returns>Date and time string in the format: January 31</returns>
        public static string FormatAsMonthDayString(DateTime dateTime)
        {
            return string.Format("{0:M}", dateTime);
        }

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// RFC1123 string representation.
        /// </summary>
        /// <param name="dateTime">DateTime to convert to a string.</param>
        /// <returns>Date and time string in the format: Sun, 31 Jan 2010 12:45:30 GMT</returns>
        public static string FormatAsRfc1123String(DateTime dateTime)
        {
            return string.Format("{0:R}", dateTime);
        }

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// sortable date and time string representation.
        /// </summary>
        /// <param name="dateTime">DateTime to convert to a string.</param>
        /// <returns>Date and time string in the format: 2010-01-31T12:45:30</returns>
        public static string FormatAsSortableDateTimeString(DateTime dateTime)
        {
            return string.Format("{0:s}", dateTime);
        }

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// universal sortable date and time string representation.
        /// </summary>
        /// <param name="dateTime">DateTime to convert to a string.</param>
        /// <returns>Date and time string in the format: 2010-01-31 12:45:30Z</returns>
        public static string FormatAsUniversalSortableString(DateTime dateTime)
        {
            return string.Format("{0:u}", dateTime);
        }

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// Coordinated Universal Time (UTC) string representation.
        /// </summary>
        /// <param name="dateTime">DateTime to convert to a string.</param>
        /// <returns>Date and time string in the format: Sunday, January 31, 2010 6:45:30 PM
        /// (This takes into account time zone and returns UTC time)</returns>
        public static string FormatAsUniversalString(DateTime dateTime)
        {
            return string.Format("{0:U}", dateTime);
        }

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// year and month string representation.
        /// </summary>
        /// <param name="dateTime">DateTime to convert to a string.</param>
        /// <returns>Date and time string in the format: January, 2010</returns>
        public static string FormatAsYearMonthString(DateTime dateTime)
        {
            return string.Format("{0:Y}", dateTime);
        }
    }
}
