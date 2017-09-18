using DL.Common.Specifications.UnitedStates;
using FluentValidation.Validators;

namespace DL.Common.FluentValidation.Validators
{
    public class SocialSecurityNumberValidator : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SocialSecurityNumberValidator"/> class.
        /// </summary>
        public SocialSecurityNumberValidator()
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

            var specification = new SocialSecurityNumberSpecification();
            return specification.IsSatisfiedBy(stringToValidate);
        }
    }
}
