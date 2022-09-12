using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public sealed class LongitudeSpecification : Specification<decimal>
{
    public override bool IsSatisfiedBy(in decimal candidate) => candidate >= -180 && candidate <= 180;
}
