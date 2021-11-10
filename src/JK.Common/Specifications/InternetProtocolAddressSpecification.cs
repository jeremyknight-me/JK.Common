using System.Text.RegularExpressions;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public class InternetProtocolAddressSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(string candidate)
        => Regex.IsMatch(
            candidate,
            @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
}
