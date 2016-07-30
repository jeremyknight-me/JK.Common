using System;
using System.Globalization;

namespace DL.Core.TypeExtensions
{
    /// <summary>Extension methods for the DateTime object.</summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Calculates age of an individual.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <param name="birthday">Date of birth.</param>
        /// <returns>Age from birth date to given date.</returns>
        public static int CalculateAge(this DateTime dt, DateTime birthday)
        {
            var utility = new DateTimeUtility();
            return utility.CalculateAge(dt, birthday);
        }

        /// <summary>
        /// Gets the abbreviated day name.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <returns>Abbreviated day name.</returns>
        public static string GetAbbreviatedDayName(this DateTime dt)
        {
            var utility = new DateTimeUtility();
            return utility.GetAbbreviatedDayName(dt);
        }

        /// <summary>
        /// Gets the abbreviated day name.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <param name="currentCulture">Culture to use when getting day name.</param>
        /// <returns>Abbreviated day name.</returns>
        public static string GetAbbreviatedDayName(this DateTime dt, CultureInfo currentCulture)
        {
            var utility = new DateTimeUtility();
            return utility.GetAbbreviatedDayName(dt, currentCulture);
        }

        /// <summary>
        /// Gets the abbreviated month name.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <returns>Abbreviated month name.</returns>
        public static string GetAbbreviatedMonthName(this DateTime dt)
        {
            var utility = new DateTimeUtility();
            return utility.GetAbbreviatedMonthName(dt);
        }

        /// <summary>
        /// Gets the abbreviated month name.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <param name="currentCulture">Culture to use when getting month name.</param>
        /// <returns>Abbreviated month name.</returns>
        public static string GetAbbreviatedMonthName(this DateTime dt, CultureInfo currentCulture)
        {
            var utility = new DateTimeUtility();
            return utility.GetAbbreviatedMonthName(dt, currentCulture);
        }

        /// <summary>
        /// Gets the full name of a given day.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <returns>Full day name.</returns>
        public static string GetDayName(this DateTime dt)
        {
            var utility = new DateTimeUtility();
            return utility.GetDayName(dt);
        }

        /// <summary>
        /// Gets the full name of a given day.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <param name="currentCulture">Culture to use when getting day name.</param>
        /// <returns>Full day name.</returns>
        public static string GetDayName(this DateTime dt, CultureInfo currentCulture)
        {
            var utility = new DateTimeUtility();
            return utility.GetDayName(dt, currentCulture);
        }

        /// <summary>
        /// Gets the full name of a month.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <returns>Full month name.</returns>
        public static string GetMonthName(this DateTime dt)
        {
            var utility = new DateTimeUtility();
            return utility.GetMonthName(dt);
        }

        /// <summary>
        /// Gets the full name of a month.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <param name="currentCulture">Culture to use when getting month name.</param>
        /// <returns>Full month name.</returns>
        public static string GetMonthName(this DateTime dt, CultureInfo currentCulture)
        {
            var utility = new DateTimeUtility();
            return utility.GetMonthName(dt, currentCulture);
        }

        /// <summary>
        /// Determines if given date is a weekday.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <returns>True if is a weekday, otherwise false.</returns>
        public static bool IsWeekday(this DateTime dt)
        {
            var utility = new DateTimeUtility();
            return utility.IsWeekday(dt);
        }

        /// <summary>
        /// Determines if given date is a weekday.
        /// </summary>
        /// <param name="dt">Current DateTime object from extension method.</param>
        /// <returns>True if is a weekend, otherwise false.</returns>
        public static bool IsWeekend(this DateTime dt)
        {
            var utility = new DateTimeUtility();
            return utility.IsWeekend(dt);
        }
    }
}
