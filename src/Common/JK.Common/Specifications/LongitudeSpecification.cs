using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications
{
    public class LongitudeSpecification : Specification<double>
    {
        public override bool IsSatisfiedBy(double candidate)
        {
            return candidate >= -180 && candidate <= 180;
        }
    }
}
