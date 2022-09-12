using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public sealed class NotEmptySpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate) => !string.IsNullOrWhiteSpace(candidate);
}
