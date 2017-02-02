using System;
using DL.Common.Patterns.Specification;

namespace DL.Common.Specifications
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
