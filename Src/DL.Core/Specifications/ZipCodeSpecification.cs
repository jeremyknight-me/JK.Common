using System.Text.RegularExpressions;
using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
{
    public class ZipCodeSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return Regex.IsMatch(candidate, @"^\d{5}(\-\d{4})?$");
        }
    }
}
