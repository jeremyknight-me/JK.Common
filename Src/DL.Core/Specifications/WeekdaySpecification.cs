using System;
using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
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
