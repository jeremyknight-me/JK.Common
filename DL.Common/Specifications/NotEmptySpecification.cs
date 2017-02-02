using DL.Common.Patterns.Specification;

namespace DL.Common.Specifications
{
    public class NotEmptySpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return !string.IsNullOrWhiteSpace(candidate);
        }
    }
}
