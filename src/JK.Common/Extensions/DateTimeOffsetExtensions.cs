using System;
using JK.Common.TypeHelpers;

namespace JK.Common.Extensions;

/// <summary>Extension methods for the DateTimeOffset object.</summary>
public static class DateTimeOffsetExtensions
{
    /// <summary>Adds given number of business days to a date.</summary>
    /// <param name="dt">Current DateTimeOffset object from extension method.</param>
    /// <param name="days">Number of days to add (can be negative).</param>
    /// <returns>The date the given amount of business days from the start date.</returns>
    public static DateTimeOffset AddWorkDays(this DateTimeOffset dt, int days) => DateHelper.AddWorkDays(dt, days);

    /// <summary>Gets the abbreviated day name.</summary>
    /// <param name="dt">Current DateTimeOffset object from extension method.</param>
    /// <returns>Abbreviated day name.</returns>
    public static string GetAbbreviatedDayName(this DateTimeOffset dt) => DateHelper.GetAbbreviatedDayName(dt);

    /// <summary>Gets the abbreviated month name.</summary>
    /// <param name="dt">Current DateTimeOffset object from extension method.</param>
    /// <returns>Abbreviated month name.</returns>
    public static string GetAbbreviatedMonthName(this DateTimeOffset dt) => DateHelper.GetAbbreviatedMonthName(dt);

    /// <summary>Gets the full name of a given day.</summary>
    /// <param name="dt">Current DateTimeOffset object from extension method.</param>
    /// <returns>Full day name.</returns>
    public static string GetDayName(this DateTimeOffset dt) => DateHelper.GetDayName(dt);

    /// <summary>Gets the full name of a month.</summary>
    /// <param name="dt">Current DateTimeOffset object from extension method.</param>
    /// <returns>Full month name.</returns>
    public static string GetMonthName(this DateTimeOffset dt) => DateHelper.GetMonthName(dt);

    /// <summary>Determines whether or not a given date is between (inclusive) the given start and end dates.</summary>
    /// <param name="dt">Current DateTimeOffset object from extension method.</param>
    /// <param name="start">Start of date range to check</param>
    /// <param name="end">End of date range to check</param>
    /// <returns>True if date falls within range, otherwise false</returns>
    public static bool IsBetween(this DateTimeOffset dt, DateTimeOffset start, DateTimeOffset end) => DateHelper.IsBetween(dt, start, end);

    /// <summary>Determines if given date is a weekday.</summary>
    /// <param name="dt">Current DateTimeOffset object from extension method.</param>
    /// <returns>True if is a weekday, otherwise false.</returns>
    public static bool IsWeekday(this DateTimeOffset dt) => DateHelper.IsWeekday(dt);

    /// <summary>Determines if given date is a weekday.</summary>
    /// <param name="dt">Current DateTimeOffset object from extension method.</param>
    /// <returns>True if is a weekend, otherwise false.</returns>
    public static bool IsWeekend(this DateTimeOffset dt) => DateHelper.IsWeekend(dt);
}
