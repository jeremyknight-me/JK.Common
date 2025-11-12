using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

/// <summary>
/// Specification that determines if a <see cref="DateTime"/> value falls on a weekday (Monday through Friday).
/// </summary>
public sealed class WeekdaySpecification : Specification<DateTime>
{
    /// <summary>
    /// Determines whether the specified <see cref="DateTime"/> is a weekday (not Saturday or Sunday).
    /// </summary>
    /// <param name="candidate">The date to evaluate.</param>
    /// <returns><c>true</c> if the date is a weekday; otherwise, <c>false</c>.</returns>
    public override bool IsSatisfiedBy(in DateTime candidate)
    {
        DayOfWeek dayOfWeek = candidate.DayOfWeek;
        return dayOfWeek != DayOfWeek.Saturday
            && dayOfWeek != DayOfWeek.Sunday;
    }
}
