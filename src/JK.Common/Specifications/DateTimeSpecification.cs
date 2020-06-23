using System;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications
{
    public class DateTimeSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(candidate))
            {
                DateTime dateTime;
                result = DateTime.TryParse(candidate, out dateTime);
            }

            return result;
        }
    }
}
