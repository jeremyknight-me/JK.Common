using JK.Common.Patterns.Specification;

namespace JK.Common.Specifications
{
    public class NumericSpecification : Specification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            bool result = false;

            if (!string.IsNullOrWhiteSpace(candidate))
            {
                double value;
                result = double.TryParse(candidate, out value);
            }

            return result;
        }
    }
}
