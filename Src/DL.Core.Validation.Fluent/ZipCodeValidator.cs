using DL.Core.Specifications;
using FluentValidation.Validators;

namespace DL.Core.Validation.Fluent
{
    /// <summary>
    /// Validator that validates that a string property is a valid zip code.
    /// </summary>
    public class ZipCodeValidator : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZipCodeValidator"/> class.
        /// </summary>
        public ZipCodeValidator()
            : base("Property must contain a valid zip code.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var stringToValidate = context.PropertyValue as string;

            if (string.IsNullOrEmpty(stringToValidate))
            {
                return true;
            }

            var specification = new ZipCodeSpecification();
            return specification.IsSatisfiedBy(stringToValidate);
        }
    }
}
