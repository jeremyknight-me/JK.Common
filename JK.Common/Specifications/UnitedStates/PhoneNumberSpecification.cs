using System.Text.RegularExpressions;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications.UnitedStates
{
    public class PhoneNumberSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return Regex.IsMatch(
                    candidate,
                    @"^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})$");
        }
    }
}
