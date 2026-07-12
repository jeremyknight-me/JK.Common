using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a decimal value is a valid latitude.
/// </summary>
public sealed class LatitudeSpecification : Specification<decimal>
{
    /// <summary>
    /// Determines whether the specified candidate value is a valid latitude.
    /// </summary>
    /// <param name="candidate">The latitude value to evaluate.</param>
    /// <returns>
    /// <c>true</c> if the candidate is between -90 and 90 (inclusive); otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in decimal candidate) => candidate >= -90 && candidate <= 90;
}
