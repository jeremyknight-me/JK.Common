using System;
using System.Globalization;

namespace JK.Common.TypeHelpers
{
    public class DateTimeHelper
    {
        /// <summary>
        /// Calculates age of an individual.
        /// </summary>
        /// <param name="currentDate">Date to calculate age from.</param>
        /// <param name="birthday">Date of birth.</param>
        /// <returns>Age from birth date to given date.</returns>
        public int CalculateAge(DateTime currentDate, DateTime birthday)
        {
            DateTime now = currentDate.Date;
            int age = now.Year - birthday.Year;

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
        public int CalculateAge(DateTime birthday)
        {
            return this.CalculateAge(DateTime.Today, birthday);
        }

        /// <summary>
        /// Gets the abbreviated day name.
        /// </summary>
        /// <param name="date">Date of day.</param>
        /// <returns>Abbreviated day name.</returns>
        public string GetAbbreviatedDayName(DateTime date)
        {
            return this.GetAbbreviatedDayName(date, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the abbreviated day name.
        /// </summary>
        /// <param name="date">Date of day.</param>
        /// <param name="currentCulture">Culture to use when getting day name.</param>
        /// <returns>Abbreviated day name.</returns>
        public string GetAbbreviatedDayName(DateTime date, CultureInfo currentCulture)
        {
            return currentCulture.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Gets the abbreviated month name.
        /// </summary>
        /// <param name="date">Date within the month to abbreviate.</param>
        /// <returns>Abbreviated month name.</returns>
        public string GetAbbreviatedMonthName(DateTime date)
        {
            return this.GetAbbreviatedMonthName(date, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the abbreviated month name.
        /// </summary>
        /// <param name="date">Date within the month to abbreviate.</param>
        /// <param name="currentCulture">Culture to use when getting month name.</param>
        /// <returns>Abbreviated month name.</returns>
        public string GetAbbreviatedMonthName(DateTime date, CultureInfo currentCulture)
        {
            return currentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
        }

        /// <summary>
        /// Gets the full name of a given day.
        /// </summary>
        /// <param name="date">Date of day.</param>
        /// <returns>Full day name.</returns>
        public string GetDayName(DateTime date)
        {
            return this.GetDayName(date, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the full name of a given day.
        /// </summary>
        /// <param name="date">Date of day.</param>
        /// <param name="currentCulture">Culture to use when getting day name.</param>
        /// <returns>Full day name.</returns>
        public string GetDayName(DateTime date, CultureInfo currentCulture)
        {
            return currentCulture.DateTimeFormat.GetDayName(date.DayOfWeek);
        }

        /// <summary>
        /// Gets the full name of a month.
        /// </summary>
        /// <param name="date">Date within the month.</param>
        /// <returns>Full month name.</returns>
        public string GetMonthName(DateTime date)
        {
            return this.GetMonthName(date, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the full name of a month.
        /// </summary>
        /// <param name="date">Date within the month.</param>
        /// <param name="currentCulture">Culture to use when getting month name.</param>
        /// <returns>Full month name.</returns>
        public string GetMonthName(DateTime date, CultureInfo currentCulture)
        {
            return currentCulture.DateTimeFormat.GetMonthName(date.Month);
        }

        /// <summary>
        /// Determines whether or not a given date is valid to place in a
        /// SQL date time column.
        /// </summary>
        /// <param name="date">Date to check against SQL date.</param>
        /// <returns>True if valid SQL date, otherwise false.</returns>
        public bool IsSqlDate(DateTime date)
        {
            return date.Year > 1753;
        }

        /// <summary>
        /// Determines whether or not the given date is a weekday.
        /// </summary>
        /// <param name="date">Date to check.</param>
        /// <returns>True if weekday, otherwise false.</returns>
        public bool IsWeekday(DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            return dayOfWeek != DayOfWeek.Saturday
                && dayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Determines whether or not the given date is a weekend.
        /// </summary>
        /// <param name="date">Date to check.</param>
        /// <returns>True if weekend, otherwise false.</returns>
        public bool IsWeekend(DateTime date)
        {
            return !this.IsWeekday(date);
        }
    }
}
