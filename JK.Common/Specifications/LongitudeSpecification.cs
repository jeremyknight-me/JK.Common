using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications
{
    public class LongitudeSpecification : Specification<decimal>
    {
        public override bool IsSatisfiedBy(decimal candidate)
        {
            return candidate >= -180 && candidate <= 180;
        }
    }
}
