using System;
using DL.Core.Specifications;
using FluentValidation.Validators;

namespace DL.Core.Validation.Fluent
{
    /// <summary>
    /// Validator that validates that a date property is a valid SQL date.
    /// </summary>
    public class SqlDateValidator : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDateValidator"/> class.
        /// </summary>
        public SqlDateValidator()
            : base("Year must be greater than 1753")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var date = context.PropertyValue as DateTime?;

            if (!date.HasValue)
            {
                return true;
            }

            var specification = new SqlDateSpecification();
            return specification.IsSatisfiedBy(date.Value);
        }
    }
}
