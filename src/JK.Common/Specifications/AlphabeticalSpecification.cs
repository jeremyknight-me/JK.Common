using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications;

public sealed class AlphabeticalSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsAlphabetical(candidate);
}
