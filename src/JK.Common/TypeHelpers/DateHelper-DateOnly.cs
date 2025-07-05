#if NET6_0_OR_GREATER

using System;
using System.Globalization;

namespace JK.Common.TypeHelpers;

public static partial class DateHelper
{
    /// <summary>Adds given number of business days to a date.</summary>
    /// <param name="date">Start date</param>
    /// <param name="days">Number of days to add (can be negative).</param>
    /// <returns>The date the given amount of business days from the start date.</returns>
    public static DateOnly AddWorkDays(DateOnly date, in int days)
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

    #region CalculateAge

    /// <summary>Calculates age of an individual.</summary>
    /// <param name="currentDate">Date to calculate age from.</param>
    /// <param name="birthday">Date of birth.</param>
    /// <returns>Age from birth date to given date.</returns>
    public static int CalculateAge(in DateOnly currentDate, in DateOnly birthday)
    {
        DateOnly now = currentDate;
        var age = now.Year - birthday.Year;
        if (birthday > now.AddYears(-age))
        {
            age--;
        }

        return age;
    }

    /// <summary>Calculates age of an individual.</summary>
    /// <param name="birthday">Date of birth.</param>
    /// <returns>Age from birth date to date today.</returns>
    public static int CalculateAge(in DateOnly birthday) => CalculateAge(DateOnly.FromDateTime(DateTime.Today), birthday);

    #endregion

    /// <summary>Determines whether or not two date ranges overlap.</summary>
    /// <param name="startOne">Start date of range one</param>
    /// <param name="endOne">End date of range one</param>
    /// <param name="startTwo">Start date of range two</param>
    /// <param name="endTwo">End date of range two</param>
    /// <returns>True if overlap, otherwise false</returns>
    public static bool DoesOverlap(in DateOnly startOne, in DateOnly endOne, in DateOnly startTwo, in DateOnly endTwo) => startOne < endTwo && startTwo < endOne;

    /// <summary>Gets the abbreviated day name.</summary>
    /// <param name="date">Date of day.</param>
    /// <returns>Abbreviated day name.</returns>
    public static string GetAbbreviatedDayName(in DateOnly date) => GetAbbreviatedDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

    /// <summary>Gets the abbreviated month name.</summary>
    /// <param name="date">Date within the month to abbreviate.</param>
    /// <returns>Abbreviated month name.</returns>
    public static string GetAbbreviatedMonthName(in DateOnly date) => GetAbbreviatedMonthName(date.Month, CultureInfo.CurrentCulture);

    /// <summary>Gets the full name of a given day.</summary>
    /// <param name="date">Date of day.</param>
    /// <returns>Full day name.</returns>
    public static string GetDayName(in DateOnly date) => GetDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

    /// <summary>Gets the full name of a month.</summary>
    /// <param name="date">Date within the month.</param>
    /// <returns>Full month name.</returns>
    public static string GetMonthName(in DateOnly date) => GetMonthName(date.Month, CultureInfo.CurrentCulture);

    /// <summary>Determines whether or not a given date is between (inclusive) the given start and end dates.</summary>
    /// <param name="date">Date to check</param>
    /// <param name="start">Start of date range to check</param>
    /// <param name="end">End of date range to check</param>
    /// <returns>True if date falls within range, otherwise false</returns>
    public static bool IsBetween(in DateOnly date, in DateOnly start, in DateOnly end) => start <= date && end >= date;

    /// <summary>Determines whether or not a given date is valid to place in a SQL datetime column.</summary>
    /// <param name="date">Date to check against SQL datetime.</param>
    /// <returns>True if valid SQL date, otherwise false.</returns>
    /// <remarks>The minimum date a 'datetime' date type in SQL can hold is January 1, 1753</remarks>
    public static bool IsSqlDate(in DateOnly date) => date >= DateOnly.Parse("1753-01-01");

    /// <summary>Determines whether or not the given date is a weekday.</summary>
    /// <param name="date">DateTime to check.</param>
    /// <returns>True if weekday, otherwise false.</returns>
    public static bool IsWeekday(in DateOnly date) => IsWeekday(date.DayOfWeek);

    /// <summary>Determines whether or not the given date is a weekend.</summary>
    /// <param name="date">DateTime to check.</param>
    /// <returns>True if weekend, otherwise false.</returns>
    public static bool IsWeekend(in DateOnly date) => !IsWeekday(date);
}

#endif
