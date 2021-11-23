using System.Text.RegularExpressions;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications.UnitedStates;

public class SocialSecurityNumberSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate)
        => Regex.IsMatch(candidate, @"^(?!000)(?!666)(?!9)\d{3}([- ]?)(?!00)\d{2}\1(?!0000)\d{4}$");
}
