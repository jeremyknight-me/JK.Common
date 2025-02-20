using System;
using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public sealed class DateTimeSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(in string candidate)
        => !string.IsNullOrEmpty(candidate) && DateTime.TryParse(candidate, out _);
}
