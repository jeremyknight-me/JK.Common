using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a string is a valid date and time.
/// </summary>
public sealed class DateTimeSpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is a valid date and time.
    /// </summary>
    /// <param name="candidate">The string to evaluate as a date and time.</param>
    /// <returns>
    /// <c>true</c> if the candidate is not null or empty and can be parsed as a <see cref="DateTime"/>; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate)
        => !string.IsNullOrEmpty(candidate) && DateTime.TryParse(candidate, out _);
}
