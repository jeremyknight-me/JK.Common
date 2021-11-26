using JK.Common.Specifications.UnitedStates;

namespace JK.Common.FluentValidation.Validators
{
    public class SocialSecurityNumberValidator : StringValidatorBase
    {
        private readonly SocialSecurityNumberSpecification specification;

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialSecurityNumberValidator"/> class.
        /// </summary>
        public SocialSecurityNumberValidator() : base("String must only contain valid United States social security numbers.")
        {
            this.specification = new SocialSecurityNumberSpecification();
        }

        protected override bool IsStringValid(string value) => this.specification.IsSatisfiedBy(value);
    }
}
