using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
{
    public class LongitudeSpecification : Specification<decimal>
    {
        public override bool IsSatisfiedBy(decimal candidate)
        {
            return candidate >= -180 && candidate <= 180;
        }
    }
}
