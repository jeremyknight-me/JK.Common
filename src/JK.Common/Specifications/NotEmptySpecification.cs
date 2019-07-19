using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications
{
    public class NotEmptySpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return !string.IsNullOrWhiteSpace(candidate);
        }
    }
}
