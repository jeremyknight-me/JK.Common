using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
{
    public class LatitudeSpecification : Specification<decimal>
    {
        public override bool IsSatisfiedBy(decimal candidate)
        {
            return candidate >= -90 && candidate <= 90;
        }
    }
}
