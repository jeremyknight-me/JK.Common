using System;
using System.Globalization;

namespace JK.Common.Extensions;

public static class DateNameExtensions
{
    /// <summary>Gets the abbreviated day name.</summary>
    /// <param name="date">Date of day.</param>
    /// <returns>Abbreviated day name.</returns>
    public static string GetAbbreviatedDayName(in DateTime date) => GetAbbreviatedDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

    /// <summary>Gets the abbreviated day name.</summary>
    /// <param name="date">Date of day.</param>
    /// <returns>Abbreviated day name.</returns>
    public static string GetAbbreviatedDayName(in DateTimeOffset date) => GetAbbreviatedDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

    /// <summary>Gets the abbreviated month name.</summary>
    /// <param name="date">Date within the month to abbreviate.</param>
    /// <returns>Abbreviated month name.</returns>
    public static string GetAbbreviatedMonthName(in DateTime date) => GetAbbreviatedMonthName(date.Month, CultureInfo.CurrentCulture);

    /// <summary>Gets the abbreviated month name.</summary>
    /// <param name="date">Date within the month to abbreviate.</param>
    /// <returns>Abbreviated month name.</returns>
    public static string GetAbbreviatedMonthName(in DateTimeOffset date) => GetAbbreviatedMonthName(date.Month, CultureInfo.CurrentCulture);

    /// <summary>Gets the full name of a given day.</summary>
    /// <param name="date">Date of day.</param>
    /// <returns>Full day name.</returns>
    public static string GetDayName(in DateTime date) => GetDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

    /// <summary>Gets the full name of a given day.</summary>
    /// <param name="date">Date of day.</param>
    /// <returns>Full day name.</returns>
    public static string GetDayName(in DateTimeOffset date) => GetDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

    /// <summary>Gets the full name of a month.</summary>
    /// <param name="date">Date within the month.</param>
    /// <returns>Full month name.</returns>
    public static string GetMonthName(in DateTime date) => GetMonthName(date.Month, CultureInfo.CurrentCulture);

    /// <summary>Gets the full name of a month.</summary>
    /// <param name="date">Date within the month.</param>
    /// <returns>Full month name.</returns>
    public static string GetMonthName(in DateTimeOffset date) => GetMonthName(date.Month, CultureInfo.CurrentCulture);


#if NET6_0_OR_GREATER

    /// <summary>Gets the abbreviated day name.</summary>
    /// <param name="date">Current DateOnly object from extension method.</param>
    /// <returns>Abbreviated day name.</returns>
    public static string GetAbbreviatedDayName(this DateOnly date) => GetAbbreviatedDayName(date.DayOfWeek);

    /// <summary>Gets the abbreviated month name.</summary>
    /// <param name="date">Current DateOnly object from extension method.</param>
    /// <returns>Abbreviated month name.</returns>
    public static string GetAbbreviatedMonthName(this DateOnly date) => GetAbbreviatedMonthName(date.Month);

    /// <summary>Gets the full name of a given day.</summary>
    /// <param name="date">Current DateOnly object from extension method.</param>
    /// <returns>Full day name.</returns>
    public static string GetDayName(this DateOnly date) => GetDayName(date.DayOfWeek);

    /// <summary>Gets the full name of a month.</summary>
    /// <param name="date">Current DateOnly object from extension method.</param>
    /// <returns>Full month name.</returns>
    public static string GetMonthName(this DateOnly date) => GetMonthName(date.Month);

#endif

    private static string GetAbbreviatedDayName(this DayOfWeek dayOfWeek, CultureInfo cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        return cultureInfo.DateTimeFormat.GetAbbreviatedDayName(dayOfWeek);
    }

    private static string GetAbbreviatedMonthName(int month, CultureInfo cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        return cultureInfo.DateTimeFormat.GetAbbreviatedMonthName(month);
    }

    private static string GetDayName(DayOfWeek dayOfWeek, CultureInfo cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        return cultureInfo.DateTimeFormat.GetDayName(dayOfWeek);
    }

    private static string GetMonthName(int month, CultureInfo cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        return cultureInfo.DateTimeFormat.GetMonthName(month);
    }
}
