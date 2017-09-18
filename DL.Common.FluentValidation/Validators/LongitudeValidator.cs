using System;
using DL.Common.Specifications;
using FluentValidation.Validators;

namespace DL.Common.FluentValidation.Validators
{
    /// <summary>
    /// Validator that validates that a double property is a valid longitude.
    /// </summary>
    public class LongitudeValidator : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LongitudeValidator"/> class.
        /// </summary>
        public LongitudeValidator()
            : base("Longitude must be between -180 and 180.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            decimal longitude = Convert.ToDecimal(context.PropertyValue);

            var specification = new LongitudeSpecification();
            return specification.IsSatisfiedBy(longitude);
        }
    }
}
