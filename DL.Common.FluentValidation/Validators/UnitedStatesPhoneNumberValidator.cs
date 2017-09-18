using DL.Common.Specifications.UnitedStates;
using FluentValidation.Validators;

namespace DL.Common.FluentValidation.Validators
{
    public class UnitedStatesPhoneNumberValidator : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitedStatesPhoneNumberValidator"/> class.
        /// </summary>
        public UnitedStatesPhoneNumberValidator()
            : base("String must only contain valid United States phone numbers.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var stringToValidate = context.PropertyValue as string;

            if (string.IsNullOrEmpty(stringToValidate))
            {
                return true;
            }

            var specification = new PhoneNumberSpecification();
            return specification.IsSatisfiedBy(stringToValidate);
        }
    }
}
