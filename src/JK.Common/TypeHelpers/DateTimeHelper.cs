using System;
using System.Globalization;

namespace JK.Common.TypeHelpers
{
    /// <summary>
    /// Class which contains methods for DateTime manipulation
    /// </summary>
    public class DateTimeHelper
    {
        /// <summary>
        /// Adds given number of business days to a date.
        /// </summary>
        /// <param name="date">Start date</param>
        /// <param name="days">Number of days to add (can be negative).</param>
        /// <returns>The date the given amount of business days from the start date.</returns>
        public DateTime AddWorkDays(DateTime date, int days)
        {
            var direction = days < 0 ? -1 : 1;
            var completeWeeks = days / 5;
            var newDate = date.AddDays(completeWeeks * 7);
            days %= 5;
            for (var i = 0; i < Math.Abs(days); i++)
            {
                newDate = newDate.AddDays(direction);
                while (!this.IsWeekday(newDate))
                {
                    newDate = newDate.AddDays(direction);
                }
            }
            return newDate;
        }

        /// <summary>
        /// Calculates age of an individual.
        /// </summary>
        /// <param name="currentDate">Date to calculate age from.</param>
        /// <param name="birthday">Date of birth.</param>
        /// <returns>Age from birth date to given date.</returns>
        public int CalculateAge(DateTime currentDate, DateTime birthday)
        {
            var now = currentDate.Date;
            var age = now.Year - birthday.Year;

            if (birthday > now.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// Calculates age of an individual.
        /// </summary>
        /// <param name="birthday">Date of birth.</param>
        /// <returns>Age from birth date to date today.</returns>
        public int CalculateAge(DateTime birthday) => this.CalculateAge(DateTime.Today, birthday);

        /// <summary>
        /// Determines whether or not two date ranges overlap.
        /// </summary>
        /// <param name="startOne">Start date of range one</param>
        /// <param name="endOne">End date of range one</param>
        /// <param name="startTwo">Start date of range two</param>
        /// <param name="endTwo">End date of range two</param>
        /// <returns>True if overlap, otherwise false</returns>
        public bool DoesOverlap(DateTime startOne, DateTime endOne, DateTime startTwo, DateTime endTwo) => startOne < endTwo && startTwo < endOne;

        /// <summary>
        /// Gets the abbreviated day name.
        /// </summary>
        /// <param name="date">Date of day.</param>
        /// <returns>Abbreviated day name.</returns>
        public string GetAbbreviatedDayName(DateTime date) => this.GetAbbreviatedDayName(date, CultureInfo.CurrentCulture);

        /// <summary>
        /// Gets the abbreviated day name.
        /// </summary>
        /// <param name="date">Date of day.</param>
        /// <param name="currentCulture">Culture to use when getting day name.</param>
        /// <returns>Abbreviated day name.</returns>
        public string GetAbbreviatedDayName(DateTime date, CultureInfo currentCulture) => currentCulture.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek);

        /// <summary>
        /// Gets the abbreviated month name.
        /// </summary>
        /// <param name="date">Date within the month to abbreviate.</param>
        /// <returns>Abbreviated month name.</returns>
        public string GetAbbreviatedMonthName(DateTime date) => this.GetAbbreviatedMonthName(date, CultureInfo.CurrentCulture);

        /// <summary>
        /// Gets the abbreviated month name.
        /// </summary>
        /// <param name="date">Date within the month to abbreviate.</param>
        /// <param name="currentCulture">Culture to use when getting month name.</param>
        /// <returns>Abbreviated month name.</returns>
        public string GetAbbreviatedMonthName(DateTime date, CultureInfo currentCulture) => currentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);

        /// <summary>
        /// Gets the full name of a given day.
        /// </summary>
        /// <param name="date">Date of day.</param>
        /// <returns>Full day name.</returns>
        public string GetDayName(DateTime date) => this.GetDayName(date, CultureInfo.CurrentCulture);

        /// <summary>
        /// Gets the full name of a given day.
        /// </summary>
        /// <param name="date">Date of day.</param>
        /// <param name="currentCulture">Culture to use when getting day name.</param>
        /// <returns>Full day name.</returns>
        public string GetDayName(DateTime date, CultureInfo currentCulture) => currentCulture.DateTimeFormat.GetDayName(date.DayOfWeek);

        /// <summary>
        /// Gets the full name of a month.
        /// </summary>
        /// <param name="date">Date within the month.</param>
        /// <returns>Full month name.</returns>
        public string GetMonthName(DateTime date) => this.GetMonthName(date, CultureInfo.CurrentCulture);

        /// <summary>
        /// Gets the full name of a month.
        /// </summary>
        /// <param name="date">Date within the month.</param>
        /// <param name="currentCulture">Culture to use when getting month name.</param>
        /// <returns>Full month name.</returns>
        public string GetMonthName(DateTime date, CultureInfo currentCulture) => currentCulture.DateTimeFormat.GetMonthName(date.Month);

        /// <summary>
        /// Determines whether or not a given date is between (inclusive) the given start and end dates.
        /// </summary>
        /// <param name="date">Date to check</param>
        /// <param name="start">Start of date range to check</param>
        /// <param name="end">End of date range to check</param>
        /// <returns>True if date falls within range, otherwise false</returns>
        public bool IsBetween(DateTime date, DateTime start, DateTime end) => start <= date && end >= date;

        /// <summary>
        /// Determines whether or not a given date is valid to place in a
        /// SQL date time column.
        /// </summary>
        /// <param name="date">Date to check against SQL date.</param>
        /// <returns>True if valid SQL date, otherwise false.</returns>
        public bool IsSqlDate(DateTime date) => date.Year > 1753;

        /// <summary>
        /// Determines whether or not the given date is a weekday.
        /// </summary>
        /// <param name="date">Date to check.</param>
        /// <returns>True if weekday, otherwise false.</returns>
        public bool IsWeekday(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;
            return dayOfWeek != DayOfWeek.Saturday
                && dayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Determines whether or not the given date is a weekend.
        /// </summary>
        /// <param name="date">Date to check.</param>
        /// <returns>True if weekend, otherwise false.</returns>
        public bool IsWeekend(DateTime date) => !this.IsWeekday(date);
    }
}
