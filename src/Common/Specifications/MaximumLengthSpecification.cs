using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a string's length does not exceed a maximum value.
/// </summary>
public sealed class MaximumLengthSpecification : Specification<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MaximumLengthSpecification"/> class.
    /// </summary>
    /// <param name="maximumLengthToUse">The maximum allowed length for the string.</param>
    public MaximumLengthSpecification(int maximumLengthToUse)
    {
        MaximumLength = maximumLengthToUse;
    }

    /// <summary>
    /// Gets the maximum allowed length for the string.
    /// </summary>
    public int MaximumLength { get; }

    /// <summary>
    /// Determines whether the specified candidate string's length is less than or equal to the maximum length.
    /// </summary>
    /// <param name="candidate">The string to evaluate.</param>
    /// <returns>
    /// <c>true</c> if the candidate's length is less than or equal to <see cref="MaximumLength"/>; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate) => candidate.Length <= MaximumLength;
}
