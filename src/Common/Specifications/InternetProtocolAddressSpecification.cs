using JK.Common.Patterns.Specification;
using JK.Common.TypeHelpers;

namespace JK.Common.Specifications;

/// <summary>
/// Specification to determine if a string is a valid IPv4 address.
/// </summary>
public sealed class InternetProtocolAddressSpecification : Specification<string>
{
    /// <summary>
    /// Determines whether the specified candidate string is a valid IPv4 address.
    /// </summary>
    /// <param name="candidate">The string to evaluate as an IPv4 address.</param>
    /// <returns>
    /// <c>true</c> if the candidate is a valid IPv4 address; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsSatisfiedBy(in string candidate)
        => RegexHelper.IsIPv4(candidate);
}
