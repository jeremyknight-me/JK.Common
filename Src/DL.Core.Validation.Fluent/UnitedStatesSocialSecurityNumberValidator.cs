using DL.Core.Specifications;
using FluentValidation.Validators;

namespace DL.Core.Validation.Fluent
{
    public class UnitedStatesSocialSecurityNumberValidator : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitedStatesSocialSecurityNumberValidator"/> class.
        /// </summary>
        public UnitedStatesSocialSecurityNumberValidator()
            : base("String must only contain valid United States social security numbers.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var stringToValidate = context.PropertyValue as string;

            if (string.IsNullOrEmpty(stringToValidate))
            {
                return true;
            }

            var specification = new USSocialSecurityNumberSpecification();
            return specification.IsSatisfiedBy(stringToValidate);
        }
    }
}
