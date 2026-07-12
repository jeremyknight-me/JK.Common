using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a string represents a numeric value.
/// </summary>
public sealed class NumericSpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is a valid numeric value.
    /// </summary>
    /// <param name="candidate">The string to evaluate.</param>
    /// <returns>
    /// <c>true</c> if the candidate is not null, not whitespace, and can be parsed as a double; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate)
        => !string.IsNullOrWhiteSpace(candidate) && double.TryParse(candidate, out _);
}
