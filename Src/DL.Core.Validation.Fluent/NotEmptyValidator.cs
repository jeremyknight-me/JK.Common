using DL.Core.Specifications;
using FluentValidation.Validators;

namespace DL.Core.Validation.Fluent
{
    /// <summary>
    /// Validator that validates that a string property contains valid characters.
    /// </summary>
    public class NotEmptyValidator : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotEmptyValidator"/> class.
        /// </summary>
        public NotEmptyValidator() 
            : base("Property must contain valid characters.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var stringToValidate = context.PropertyValue as string;

            var specification = new NotEmptySpecification();
            return specification.IsSatisfiedBy(stringToValidate);
        }
    }
}
