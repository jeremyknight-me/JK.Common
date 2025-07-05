using System;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public sealed class WeekdaySpecification : Specification<DateTime>
{
    public override bool IsSatisfiedBy(in DateTime candidate)
    {
        DayOfWeek dayOfWeek = candidate.DayOfWeek;
        return dayOfWeek != DayOfWeek.Saturday
            && dayOfWeek != DayOfWeek.Sunday;
    }
}
