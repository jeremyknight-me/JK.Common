using System;
using DL.Common.Patterns.Specification;

namespace DL.Common.Specifications
{
    public class WeekdaySpecification : Specification<DateTime>
    {
        public override bool IsSatisfiedBy(DateTime candidate)
        {
            DayOfWeek dayOfWeek = candidate.DayOfWeek;
            return dayOfWeek != DayOfWeek.Saturday
                && dayOfWeek != DayOfWeek.Sunday;
        }
    }
}
