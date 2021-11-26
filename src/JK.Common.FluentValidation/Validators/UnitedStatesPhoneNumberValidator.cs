using JK.Common.Specifications.UnitedStates;

namespace JK.Common.FluentValidation.Validators
{
    public class UnitedStatesPhoneNumberValidator : StringValidatorBase
    {
        private readonly PhoneNumberSpecification specification;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitedStatesPhoneNumberValidator"/> class.
        /// </summary>
        public UnitedStatesPhoneNumberValidator() : base("String must only contain valid United States phone numbers.")
        {
            this.specification = new PhoneNumberSpecification();
        }

        protected override bool IsStringValid(string value) => specification.IsSatisfiedBy(value);
    }
}
