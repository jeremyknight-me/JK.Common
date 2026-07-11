using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications.UnitedStates;

/// <summary>
/// Specification to determine if a string is a valid United States Social Security Number (SSN).
/// </summary>
public sealed class SocialSecurityNumberSpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is a valid United States Social Security Number (SSN).
    /// </summary>
    /// <param name="candidate">The string to evaluate as a Social Security Number.</param>
    /// <returns>
    /// <c>true</c> if the candidate is a valid SSN; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsSocialSecurityNumber(candidate);
}
