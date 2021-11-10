using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public class LatitudeSpecification : Specification<double>
{
    public override bool IsSatisfiedBy(double candidate) => candidate >= -90 && candidate <= 90;
}
