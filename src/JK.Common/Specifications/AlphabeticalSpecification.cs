using System.Text.RegularExpressions;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public class AlphabeticalSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate)
        => Regex.IsMatch(candidate, @"^[a-zA-Z]+$");
}
