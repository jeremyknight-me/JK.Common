using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications.UnitedStates;

public sealed class PhoneNumberSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsUnitedStatesPhoneNumber(candidate);
}
