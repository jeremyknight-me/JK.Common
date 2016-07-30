using System.Text.RegularExpressions;
using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
{
    public class IPv4Specification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return Regex.IsMatch(
                    candidate,
                    @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
        }
    }
}
