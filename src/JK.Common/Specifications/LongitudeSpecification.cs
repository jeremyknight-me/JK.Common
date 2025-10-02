using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a decimal value is a valid longitude.
/// </summary>
public sealed class LongitudeSpecification : Specification<decimal>
{
    /// <summary>
    /// Determines whether the specified candidate value is a valid longitude.
    /// </summary>
    /// <param name="candidate">The longitude value to evaluate.</param>
    /// <returns>
    /// <c>true</c> if the candidate is between -180 and 180 (inclusive); otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in decimal candidate) => candidate >= -180 && candidate <= 180;
}
