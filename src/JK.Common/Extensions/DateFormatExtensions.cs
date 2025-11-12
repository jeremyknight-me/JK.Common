namespace JK.Common.Extensions;

/// <summary>
/// Class which contains methods which formats a DateTime into a string.
/// </summary>
public static class DateFormatExtensions
{
    /// <summary>
    /// Formats the value of the current DateTime object to its equivalent 
    /// full date and long time string representation.
    /// </summary>
    /// <param name="date">DateTime to convert to a string.</param>
    /// <returns>Date and time string in the format: Sunday, January 31, 2010 12:45:30 PM</returns>
    public static string ToFormatFullDateLongTime(this DateTime date) => $"{date:f}";

    /// <summary>
    /// Formats the value of the current DateTime object to its equivalent 
    /// full date and short time string representation.
    /// </summary>
    /// <param name="date">DateTime to convert to a string.</param>
    /// <returns>Date and time string in the format: Sunday, January 31, 2010 12:45 PM</returns>
    public static string ToFormatFullDateShortTime(this DateTime date) => $"{date:f}";

    /// <summary>
    /// Formats the value of the current DateTime object to its equivalent 
    /// general date and short time string representation.
    /// </summary>
    /// <param name="date">DateTime to convert to a string.</param>
    /// <returns>Date and time string in the format: 1/31/2010 12:45 PM</returns>
    public static string ToFormatGeneralDateShortTime(this DateTime date) => $"{date:g}";

    /// <summary>
    /// Formats the value of the current DateTime object to its equivalent 
    /// month and day string representation.
    /// </summary>
    /// <param name="date">DateTime to convert to a string.</param>
    /// <returns>Date and time string in the format: January 31</returns>
    public static string ToFormatMonthDay(this DateTime date) => $"{date:M}";

    /// <summary>
    /// Formats the value of the current DateTime object to its equivalent 
    /// RFC1123 string representation.
    /// </summary>
    /// <param name="date">DateTime to convert to a string.</param>
    /// <returns>Date and time string in the format: Sun, 31 Jan 2010 12:45:30 GMT</returns>
    public static string ToFormatRfc1123(this DateTime date) => $"{date:R}";

    /// <summary>
    /// Formats the value of the current DateTime object to its equivalent 
    /// sortable date and time string representation.
    /// </summary>
    /// <param name="date">DateTime to convert to a string.</param>
    /// <returns>Date and time string in the format: 2010-01-31T12:45:30</returns>
    public static string ToFormatSortableDateTime(this DateTime date) => $"{date:s}";

    /// <summary>
    /// Formats the value of the current DateTime object to its equivalent 
    /// universal sortable date and time string representation.
    /// </summary>
    /// <param name="date">DateTime to convert to a string.</param>
    /// <returns>Date and time string in the format: 2010-01-31 12:45:30Z</returns>
    public static string ToFormatUniversalSortable(this DateTime date) => $"{date:u}";

    /// <summary>
    /// Formats the value of the current DateTime object to its equivalent 
    /// Coordinated Universal Time (UTC) string representation.
    /// </summary>
    /// <param name="date">DateTime to convert to a string.</param>
    /// <returns>Date and time string in the format: Sunday, January 31, 2010 6:45:30 PM
    /// (This takes into account time zone and returns UTC time)</returns>
    public static string ToFormatUniversal(this DateTime date) => $"{date:U}";

    /// <summary>
    /// Formats the value of the current DateTime object to its equivalent 
    /// year and month string representation.
    /// </summary>
    /// <param name="date">DateTime to convert to a string.</param>
    /// <returns>Date and time string in the format: January, 2010</returns>
    public static string ToFormatYearMonth(this DateTime date) => $"{date:Y}";
}
