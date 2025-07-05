using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public sealed class MaximumLengthSpecification : Specification<string>
{
    public MaximumLengthSpecification(int maximumLengthToUse)
    {
        MaximumLength = maximumLengthToUse;
    }

    public int MaximumLength { get; }

    public override bool IsSatisfiedBy(in string candidate) => candidate.Length <= MaximumLength;
}
