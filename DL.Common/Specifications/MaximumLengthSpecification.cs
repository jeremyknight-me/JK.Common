using DL.Common.Patterns.Specification;

namespace DL.Common.Specifications
{
    public class MaximumLengthSpecification : Specification<string>
    {
        public MaximumLengthSpecification(int maximumLengthToUse)
        {
            this.MaximumLength = maximumLengthToUse;
        }

        public int MaximumLength { get; }

        public override bool IsSatisfiedBy(string candidate)
        {
            return candidate.Length <= this.MaximumLength;
        }
    }
}
