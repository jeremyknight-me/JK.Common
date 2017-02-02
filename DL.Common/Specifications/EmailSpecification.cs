using System.Text.RegularExpressions;
using DL.Common.Patterns.Specification;

namespace DL.Common.Specifications
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
