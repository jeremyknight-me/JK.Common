namespace JK.Common.Extensions;

public static class DayOfWeekExtensions
{
    extension(DayOfWeek dayOfWeek)
    {
        /// <summary>Determines whether or not the given day of week is a weekday.</summary>
        /// <returns>True if weekday, otherwise false.</returns>
        public bool IsWeekday => dayOfWeek != DayOfWeek.Saturday && dayOfWeek != DayOfWeek.Sunday;
    }
}
