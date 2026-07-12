using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a string is not null, empty, or whitespace.
/// </summary>
public sealed class NotEmptySpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is not null, empty, or whitespace.
    /// </summary>
    /// <param name="candidate">The string to evaluate.</param>
    /// <returns>
    /// <c>true</c> if the candidate is not null, not empty, and not whitespace; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate) => !string.IsNullOrWhiteSpace(candidate);
}
