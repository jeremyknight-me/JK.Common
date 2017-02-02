using System;
using DL.Common.Patterns.Specification;

namespace DL.Common.Specifications
{
    public class SqlDateSpecification : Specification<DateTime>
    {
        public override bool IsSatisfiedBy(DateTime candidate)
        {
            return candidate.Year >= 1753;
        }
    }
}
