using System;
using DL.Core.Specifications;
using FluentValidation.Validators;

namespace DL.Core.Validation.Fluent
{
    /// <summary>
    /// Validator that validates that a double property is a valid latitude.
    /// </summary>
    public class LatitudeValidator : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LatitudeValidator"/> class.
        /// </summary>
        public LatitudeValidator()
            : base("Latitude must be between -90 and 90.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            decimal latitude = Convert.ToDecimal(context.PropertyValue);

            var specification = new LatitudeSpecification();
            return specification.IsSatisfiedBy(latitude);
        }
    }
}
