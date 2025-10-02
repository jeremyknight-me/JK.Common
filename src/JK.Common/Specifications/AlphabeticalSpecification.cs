using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a string is alphabetical.
/// </summary>
public sealed class AlphabeticalSpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is alphabetical.
    /// </summary>
    /// <param name="candidate">The string to evaluate as alphabetical.</param>
    /// <returns>
    /// <c>true</c> if the candidate is alphabetical; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsAlphabetical(candidate);
}
