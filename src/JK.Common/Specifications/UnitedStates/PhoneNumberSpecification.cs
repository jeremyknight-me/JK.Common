using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications.UnitedStates;

/// <summary>
/// Specification to determine if a string is a valid United States phone number.
/// </summary>
public sealed class PhoneNumberSpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is a valid United States phone number.
    /// </summary>
    /// <param name="candidate">The string to evaluate as a phone number.</param>
    /// <returns>
    /// <c>true</c> if the candidate is a valid United States phone number; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsUnitedStatesPhoneNumber(candidate);
}
