using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public sealed class NumericSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate)
        => !string.IsNullOrWhiteSpace(candidate) && double.TryParse(candidate, out _);
}
