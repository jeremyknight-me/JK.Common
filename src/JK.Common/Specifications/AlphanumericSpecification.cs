using System.Text.RegularExpressions;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public class AlphanumericSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(string candidate)
        => Regex.IsMatch(candidate, @"^[a-zA-Z0-9]+$");
}
