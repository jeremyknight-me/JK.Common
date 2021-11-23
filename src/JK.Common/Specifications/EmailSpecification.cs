using System.Text.RegularExpressions;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public class EmailSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate)
        => Regex.IsMatch(
            candidate,
            @"^[a-zA-Z0-9.!#$%&’'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
}
