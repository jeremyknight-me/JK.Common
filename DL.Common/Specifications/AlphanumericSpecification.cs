using System.Text.RegularExpressions;
using DL.Common.Patterns.Specification;

namespace DL.Common.Specifications
{
    public class AlphanumericSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return Regex.IsMatch(candidate, @"^[a-zA-Z0-9]+$");
        }
    }
}
