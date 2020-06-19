using System;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications
{
    public class SqlDateSpecification : Specification<DateTime>
    {
        public override bool IsSatisfiedBy(DateTime candidate)
        {
            return candidate.Year >= 1753;
        }
    }
}
