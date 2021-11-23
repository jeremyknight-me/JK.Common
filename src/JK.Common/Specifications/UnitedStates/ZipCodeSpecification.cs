using System.Text.RegularExpressions;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications.UnitedStates;

public class ZipCodeSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate) => Regex.IsMatch(candidate, @"^\d{5}(\-\d{4})?$");
}
