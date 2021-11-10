using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications;

public class NumericSpecification : Specification<string>
{
    public override bool IsSatisfiedBy(string candidate)
    {
        var result = false;
        if (!string.IsNullOrWhiteSpace(candidate))
        {
            result = double.TryParse(candidate, out var value);
        }

        return result;
    }
}
