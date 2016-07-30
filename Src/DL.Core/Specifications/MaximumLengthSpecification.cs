using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
{
    public class MaximumLengthSpecification : Specification<string>
    {
        public MaximumLengthSpecification(int maximumLengthToUse)
        {
            this.MaximumLength = maximumLengthToUse;
        }

        public int MaximumLength { get; private set; }

        public override bool IsSatisfiedBy(string candidate)
        {
            return candidate.Length <= this.MaximumLength;
        }
    }
}
