using System.Text.RegularExpressions;
using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
{
    public class AlphabeticalSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return Regex.IsMatch(candidate, @"^[a-zA-Z]+$");
        }
    }
}
