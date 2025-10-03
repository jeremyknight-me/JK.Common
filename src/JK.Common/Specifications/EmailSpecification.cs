using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a string is a valid email address.
/// </summary>
public sealed class EmailSpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is a valid email address.
    /// </summary>
    /// <param name="candidate">The string to evaluate as an email address.</param>
    /// <returns>
    /// <c>true</c> if the candidate is a valid email address; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsEmailAddress(candidate);
}
