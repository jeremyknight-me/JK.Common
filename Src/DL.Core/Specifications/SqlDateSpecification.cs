using System;
using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
{
    public class SqlDateSpecification : Specification<DateTime>
    {
        public override bool IsSatisfiedBy(DateTime candidate)
        {
            return candidate.Year >= 1753;
        }
    }
}
