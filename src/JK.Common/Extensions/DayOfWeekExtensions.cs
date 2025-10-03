using System;

namespace JK.Common.Extensions;

public static class DayOfWeekExtensions
{
    /// <summary>Determines whether or not the given day of week is a weekday.</summary>
    /// <param name="dayOfWeek">DayOfWeek to check</param>
    /// <returns>True if weekday, otherwise false.</returns>
    public static bool IsWeekday(this DayOfWeek dayOfWeek)
        => dayOfWeek != DayOfWeek.Saturday && dayOfWeek != DayOfWeek.Sunday;
}
