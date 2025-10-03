using System;

namespace JK.Common.Extensions;

/// <summary>Extension methods for the DateTimeOffset object.</summary>
public static class DateTimeOffsetExtensions
{
    /// <summary>Adds given number of business days to a date.</summary>
    /// <param name="date">Current DateTimeOffset object from extension method.</param>
    /// <param name="days">Number of days to add (can be negative).</param>
    /// <returns>The date the given amount of business days from the start date.</returns>
    public static DateTimeOffset AddWorkDays(this DateTimeOffset date, in int days)
    {
        var direction = days < 0 ? -1 : 1;
        var daysToAdd = Math.Abs(days);
        var count = 0;
        while (count < daysToAdd)
        {
            date = date.AddDays(direction);
            if (IsWeekday(date))
            {
                count++;
            }
        }

        return date;
    }

    /// <summary>Determines whether or not a given date is between (inclusive) the given start and end dates.</summary>
    /// <param name="date">Date to check</param>
    /// <param name="start">Start of date range to check</param>
    /// <param name="end">End of date range to check</param>
    /// <returns>True if date falls within range, otherwise false</returns>
    public static bool IsBetween(this DateTimeOffset date, in DateTimeOffset start, in DateTimeOffset end) => start <= date && end >= date;

    /// <summary>Determines if given date is a weekday.</summary>
    /// <param name="date">Current DateTimeOffset object from extension method.</param>
    /// <returns>True if is a weekday, otherwise false.</returns>
    public static bool IsWeekday(this DateTimeOffset date) => date.DayOfWeek.IsWeekday();

    /// <summary>Determines if given date is a weekday.</summary>
    /// <param name="date">Current DateTimeOffset object from extension method.</param>
    /// <returns>True if is a weekend, otherwise false.</returns>
    public static bool IsWeekend(this DateTimeOffset date) => !date.DayOfWeek.IsWeekday();
}
