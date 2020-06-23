using JK.Common.Specifications;
using FluentValidation.Validators;

namespace JK.Common.FluentValidation.Validators
{
    public class AlphabeticalValidator : PropertyValidator
    {
        public AlphabeticalValidator()
            : base("String must only contain uppercase letters or lowercase letters.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var stringToValidate = context.PropertyValue as string;

            if (string.IsNullOrEmpty(stringToValidate))
            {
                return true;
            }

            var specification = new AlphabeticalSpecification();
            return specification.IsSatisfiedBy(stringToValidate);
        }
    }
}
