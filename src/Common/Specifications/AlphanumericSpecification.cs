using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a string is alphanumeric.
/// </summary>
public sealed class AlphanumericSpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is alphanumeric.
    /// </summary>
    /// <param name="candidate">The string to evaluate as alphanumeric.</param>
    /// <returns>
    /// <c>true</c> if the candidate is alphanumeric; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsAlphanumeric(candidate);
}
