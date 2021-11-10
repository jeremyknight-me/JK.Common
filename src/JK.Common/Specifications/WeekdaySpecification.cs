using System;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public class WeekdaySpecification : Specification<DateTime>
{
    public override bool IsSatisfiedBy(DateTime candidate)
    {
        var dayOfWeek = candidate.DayOfWeek;
        return dayOfWeek != DayOfWeek.Saturday
            && dayOfWeek != DayOfWeek.Sunday;
    }
}
