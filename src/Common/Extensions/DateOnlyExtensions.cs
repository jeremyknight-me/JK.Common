#if NET6_0_OR_GREATER

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="DateOnly"/>.
/// </summary>
public static class DateOnlyExtensions
{
    extension(DateOnly date)
    {
        /// <summary>
        /// Calculates the number of days between two DateOnly instances.
        /// </summary>
        /// <remarks>
        /// This operator enables direct subtraction of two DateOnly values to determine the
        /// interval in days.
        /// </remarks>
        /// <param name="left">The first date in the subtraction operation.</param>
        /// <param name="right">The date to subtract from the left operand.</param>
        /// <returns>
        /// The number of days between the left and right dates. The result is positive if the left
        /// date is later than the right date, negative if earlier, or zero if they are the same.
        /// </returns>
        public static int operator -(DateOnly left, DateOnly right)
            => left.DayNumber - right.DayNumber;

        /// <summary>Adds given number of business days to a date.</summary>
        /// <param name="days">Number of days to add (can be negative).</param>
        /// <returns>The date the given amount of business days from the start date.</returns>
        public DateOnly AddWorkDays(in int days)
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
        public bool IsBetween(in DateOnly start, in DateOnly end)
            => start <= date && end >= date;

        /// <summary>Determines whether or not a given date is valid to place in a SQL datetime column.</summary>
        /// <returns>True if valid SQL date, otherwise false.</returns>
        /// <remarks>The minimum date a 'datetime' date type in SQL can hold is January 1, 1753</remarks>
        public bool IsSqlDate => date >= DateOnly.Parse(Constants.SqlDateTimeStart);

        /// <summary>Determines if given date is a weekday.</summary>
        /// <returns>True if is a weekday, otherwise false.</returns>
        public bool IsWeekday => date.DayOfWeek.IsWeekday;

        /// <summary>Determines if given date is a weekday.</summary>
        /// <returns>True if is a weekend, otherwise false.</returns>
        public bool IsWeekend => !date.IsWeekday;
    }
}

#endif
