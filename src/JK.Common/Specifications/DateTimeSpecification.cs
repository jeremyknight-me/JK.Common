using System;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public class DateTimeSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(string candidate)
    {
        var result = false;
        if (!string.IsNullOrEmpty(candidate))
        {
            result = DateTime.TryParse(candidate, out var dateTime);
        }

        return result;
    }
}
