using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications.UnitedStates;

public sealed class SocialSecurityNumberSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsSocialSecurityNumber(candidate);
}
