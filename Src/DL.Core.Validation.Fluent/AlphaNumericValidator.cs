using DL.Core.Specifications;
using FluentValidation.Validators;

namespace DL.Core.Validation.Fluent
{
    /// <summary>
    /// Validator that validates that a string property contains alphanumeric characters.
    /// </summary>
    public class AlphaNumericValidator : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlphaNumericValidator"/> class.
        /// </summary>
        public AlphaNumericValidator()
            : base("String must only contain uppercase letters, lowercase letters, or numbers.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var stringToValidate = context.PropertyValue as string;

            if (string.IsNullOrEmpty(stringToValidate))
            {
                return true;
            }

            var specification = new AlphanumericSpecification();
            return specification.IsSatisfiedBy(stringToValidate);
        }
    }
}
