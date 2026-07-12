namespace JK.Common.Extensions;

/// <summary>
/// Class which contains methods which formats a DateTime into a string.
/// </summary>
public static class DateFormatExtensions
{
    extension(in DateTime date)
    {
        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// full date and long time string representation.
        /// </summary>
        /// <returns>Date and time string in the format: Sunday, January 31, 2010 12:45:30 PM</returns>
        public string ToFullDateLongTimeFormat() => $"{date:F}";

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// full date and short time string representation.
        /// </summary>
        /// <returns>Date and time string in the format: Sunday, January 31, 2010 12:45 PM</returns>
        public string ToFullDateShortTimeFormat() => $"{date:f}";

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// general date and short time string representation.
        /// </summary>
        /// <returns>Date and time string in the format: 1/31/2010 12:45 PM</returns>
        public string ToGeneralDateShortTimeFormat() => $"{date:g}";

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// month and day string representation.
        /// </summary>
        /// <returns>Date and time string in the format: January 31</returns>
        public string ToMonthDayFormat() => $"{date:M}";

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// RFC1123 string representation.
        /// </summary>
        /// <returns>Date and time string in the format: Sun, 31 Jan 2010 12:45:30 GMT</returns>
        public string ToRfc1123Format() => $"{date:R}";

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// sortable date and time string representation.
        /// </summary>
        /// <returns>Date and time string in the format: 2010-01-31T12:45:30</returns>
        public string ToSortableFormat() => $"{date:s}";

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// universal sortable date and time string representation.
        /// </summary>
        /// <returns>Date and time string in the format: 2010-01-31 12:45:30Z</returns>
        public string ToUniversalSortableFormat() => $"{date:u}";

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// Coordinated Universal Time (UTC) string representation.
        /// </summary>
        /// <returns>Date and time string in the format: Sunday, January 31, 2010 6:45:30 PM
        /// (This takes into account time zone and returns UTC time)</returns>
        public string ToUniversalFormat() => $"{date:U}";

        /// <summary>
        /// Formats the value of the current DateTime object to its equivalent 
        /// year and month string representation.
        /// </summary>
        /// <returns>Date and time string in the format: January, 2010</returns>
        public string ToYearMonthFormat() => $"{date:Y}";
    }
}
