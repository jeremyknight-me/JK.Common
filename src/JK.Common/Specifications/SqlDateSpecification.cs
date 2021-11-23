using System;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public class SqlDateSpecification : Specification<DateTime>
{
    public override bool IsSatisfiedBy(in DateTime candidate) => candidate.Year >= 1753;
}
