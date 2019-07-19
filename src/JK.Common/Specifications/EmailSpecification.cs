using System.Text.RegularExpressions;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications
{
    public class EmailSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return Regex.IsMatch(
                    candidate,
                    @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");  
        }
    }
}
