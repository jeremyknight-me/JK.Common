using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications;

public sealed class AlphanumericSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsAlphanumeric(candidate);
}
