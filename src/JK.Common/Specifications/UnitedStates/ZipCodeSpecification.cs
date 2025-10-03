using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications.UnitedStates;

/// <summary>
/// Specification to determine if a string is a valid United States ZIP code.
/// </summary>
public sealed class ZipCodeSpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is a valid United States ZIP code.
    /// </summary>
    /// <param name="candidate">The string to evaluate as a ZIP code.</param>
    /// <returns>
    /// <c>true</c> if the candidate is a valid ZIP code; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsZipCode(candidate);
}
