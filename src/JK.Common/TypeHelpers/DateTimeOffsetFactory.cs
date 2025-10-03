using System;

namespace JK.Common.TypeHelpers;

/// <summary>
/// Provides factory methods for creating <see cref="DateTimeOffset"/> instances with specific time zones.
/// </summary>
public static class DateTimeOffsetFactory
{
    /// <summary>
    /// Creates a <see cref="DateTimeOffset"/> from a <see cref="DateTime"/> and a time zone ID.
    /// </summary>
    /// <param name="date">The date and time to use.</param>
    /// <param name="timeZoneId">The time zone identifier (e.g., "Central Standard Time").</param>
    /// <returns>A <see cref="DateTimeOffset"/> representing the specified date and time in the given time zone.</returns>
    public static DateTimeOffset Make(in DateTime date, in string timeZoneId)
    {
        TimeSpan offset = GetOffsetForDate(date, timeZoneId);
        return DateTimeOffset.Parse($"{date:yyyy-MM-ddTHH:mm:ss}{offset.Hours:+00;-00}:00");
    }

    /// <summary>
    /// Creates a <see cref="DateTimeOffset"/> from year, month, day, and a time zone ID.
    /// </summary>
    /// <param name="year">The year component.</param>
    /// <param name="month">The month component.</param>
    /// <param name="day">The day component.</param>
    /// <param name="timeZoneId">The time zone identifier (e.g., "Central Standard Time").</param>
    /// <returns>A <see cref="DateTimeOffset"/> representing the specified date in the given time zone.</returns>
    public static DateTimeOffset Make(in int year, in int month, in int day, in string timeZoneId)
    {
        var date = new DateTime(year, month, day);
        return Make(date, timeZoneId);
    }

    /// <summary>
    /// Creates a <see cref="DateTimeOffset"/> from year, month, day, hour, minute, second, and a time zone ID.
    /// </summary>
    /// <param name="year">The year component.</param>
    /// <param name="month">The month component.</param>
    /// <param name="day">The day component.</param>
    /// <param name="hour">The hour component.</param>
    /// <param name="minute">The minute component.</param>
    /// <param name="second">The second component.</param>
    /// <param name="timeZoneId">The time zone identifier (e.g., "Central Standard Time").</param>
    /// <returns>A <see cref="DateTimeOffset"/> representing the specified date and time in the given time zone.</returns>
    public static DateTimeOffset Make(in int year, in int month, in int day,
        in int hour, in int minute, in int second, in string timeZoneId)
    {
        var date = new DateTime(year, month, day, hour, minute, second);
        return Make(date, timeZoneId);
    }

    private static TimeSpan GetOffsetForDate(in DateTime date, in string timeZoneId)
    {
        DateTimeOffset dateOffset = DateTimeOffset.Parse($"{date:yyyy-MM-dd} 12:00:00");
        DateTimeOffset centralDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateOffset, timeZoneId);
        return centralDate.Offset;
    }
}
