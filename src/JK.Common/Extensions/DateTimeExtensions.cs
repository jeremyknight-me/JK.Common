namespace JK.Common.Extensions;

/// <summary>Extension methods for the DateTime object.</summary>
public static class DateTimeExtensions
{
    extension(DateTime date)
    {
        /// <summary>Adds given number of business days to a date.</summary>
        /// <param name="days">Number of days to add (can be negative).</param>
        /// <returns>The date the given amount of business days from the start date.</returns>
        public DateTime AddWorkDays(in int days)
        {
            var direction = days < 0 ? -1 : 1;
            var daysToAdd = Math.Abs(days);
            var count = 0;
            while (count < daysToAdd)
            {
                date = date.AddDays(direction);
                if (date.IsWeekday)
                {
                    count++;
                }
            }

            return date;
        }

        /// <summary>Determines whether or not a given date is between (inclusive) the given start and end dates.</summary>
        /// <param name="start">Start of date range to check</param>
        /// <param name="end">End of date range to check</param>
        /// <returns>True if date falls within range, otherwise false</returns>
        public bool IsBetween(in DateTime start, in DateTime end) => start <= date && end >= date;

        /// <summary>Determines whether or not a given date is valid to place in a SQL datetime column.</summary>
        /// <returns>True if valid SQL date, otherwise false.</returns>
        /// <remarks>The minimum date a 'datetime' date type in SQL can hold is January 1, 1753</remarks>
        public bool IsSqlDate => date >= DateTime.Parse(Constants.SqlDateTimeStart);

        /// <summary>Determines if given date is a weekday.</summary>
        /// <returns>True if is a weekday, otherwise false.</returns>
        public bool IsWeekday => date.DayOfWeek.IsWeekday;

        /// <summary>Determines if given date is a weekday.</summary>
        /// <returns>True if is a weekend, otherwise false.</returns>
        public bool IsWeekend => !date.DayOfWeek.IsWeekday;
    }
}
