using JK.Common.Specifications;

namespace JK.Common.FluentValidation.Validators
{
    /// <summary>
    /// Validator that validates that a string property contains alphanumeric characters.
    /// </summary>
    public class AlphaNumericValidator : StringValidatorBase
    {
        private readonly AlphanumericSpecification specification;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphaNumericValidator"/> class.
        /// </summary>
        public AlphaNumericValidator() : base("String must only contain uppercase letters, lowercase letters, or numbers.")
        {
            this.specification = new AlphanumericSpecification();
        }

        protected override bool IsStringValid(string value) => this.specification.IsSatisfiedBy(value);
    }
}
