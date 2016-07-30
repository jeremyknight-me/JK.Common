using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
{
    public class NotEmptySpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return !string.IsNullOrWhiteSpace(candidate);
        }
    }
}
