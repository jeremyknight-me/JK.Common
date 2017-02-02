using System.Text.RegularExpressions;
using DL.Common.Patterns.Specification;

namespace DL.Common.Specifications
{
    public class ZipCodeSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return Regex.IsMatch(candidate, @"^\d{5}(\-\d{4})?$");
        }
    }
}
