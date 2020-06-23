using System;
using JK.Common.Specifications;
using FluentValidation.Validators;

namespace JK.Common.FluentValidation.Validators
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
            var date = this.GetDateTime(context.PropertyValue);

            if (!date.HasValue)
            {
                return true;
            }

            var specification = new SqlDateSpecification();
            return specification.IsSatisfiedBy(date.Value);
        }

        protected DateTime? GetDateTime(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is DateTimeOffset)
            {
                return ((DateTimeOffset)value).DateTime;
            }

            return (DateTime)value;
        }
    }
}
