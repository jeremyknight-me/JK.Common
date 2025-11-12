using JK.Common.DateTimeProviders;

namespace JK.Common.Extensions;

/// <summary>Extension methods for the DateTime object.</summary>
public static class DateTimeExtensions
{
    /// <summary>Adds given number of business days to a date.</summary>
    /// <param name="date">Current DateTime object from extension method.</param>
    /// <param name="days">Number of days to add (can be negative).</param>
    /// <returns>The date the given amount of business days from the start date.</returns>
    public static DateTime AddWorkDays(this DateTime date, in int days)
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

    /// <summary>Calculates age of an individual.</summary>
    /// <param name="currentDate">Date to calculate age from.</param>
    /// <param name="birthday">Date of birth.</param>
    /// <returns>Age from birth date to given date.</returns>
    public static int CalculateAge(this DateTime currentDate, in DateTime birthday)
    {
        DateTime now = currentDate.Date;
        var age = now.Year - birthday.Year;
        if (birthday > now.AddYears(-age))
        {
            age--;
        }

        return age;
    }

    /// <summary>Calculates age of an individual.</summary>
    /// <param name="birthday">Date of birth.</param>
    /// <param name="dateTimeProvider">Provider for the current date. If null, uses the default provider.</param>
    /// <returns>Age from birth date to date today.</returns>
    public static int CalculateAge(this DateTime birthday, IDateTimeProvider dateTimeProvider = null)
    {
        dateTimeProvider ??= new DefaultDateTimeProvider();
        return CalculateAge(dateTimeProvider.Today, birthday);
    }

    /// <summary>Determines whether or not a given date is between (inclusive) the given start and end dates.</summary>
    /// <param name="date">Current DateTime object from extension method.</param>
    /// <param name="start">Start of date range to check</param>
    /// <param name="end">End of date range to check</param>
    /// <returns>True if date falls within range, otherwise false</returns>
    public static bool IsBetween(this DateTime date, in DateTime start, in DateTime end) => start <= date && end >= date;

    /// <summary>Determines whether or not a given date is valid to place in a SQL datetime column.</summary>
    /// <param name="date">Date to check against SQL datetime.</param>
    /// <returns>True if valid SQL date, otherwise false.</returns>
    /// <remarks>The minimum date a 'datetime' date type in SQL can hold is January 1, 1753</remarks>
    public static bool IsSqlDate(this DateTime date) => date >= DateTime.Parse(Constants.SqlDateTimeStart);

    /// <summary>Determines if given date is a weekday.</summary>
    /// <param name="date">Current DateTime object from extension method.</param>
    /// <returns>True if is a weekday, otherwise false.</returns>
    public static bool IsWeekday(this DateTime date) => date.DayOfWeek.IsWeekday();

    /// <summary>Determines if given date is a weekday.</summary>
    /// <param name="date">Current DateTime object from extension method.</param>
    /// <returns>True if is a weekend, otherwise false.</returns>
    public static bool IsWeekend(this DateTime date) => !date.DayOfWeek.IsWeekday();
}
