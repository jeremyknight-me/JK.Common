using System.Text.RegularExpressions;
using DL.Core.SpecificationPattern;

namespace DL.Core.Specifications
{
    public class USSocialSecurityNumberSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return Regex.IsMatch(
                    candidate,
                    @"^(?!000)([0-6]\d{2}|7([0-6]\d|7[012]))([ -]?)(?!00)\d\d\3(?!0000)\d{4}$");
        }
    }
}
