using JK.Common.Specifications.UnitedStates;

namespace JK.Common.FluentValidation.Validators
{
    /// <summary>
    /// Validator that validates that a string property is a valid zip code.
    /// </summary>
    public class ZipCodeValidator : StringValidatorBase
    {
        private readonly ZipCodeSpecification specification;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipCodeValidator"/> class.
        /// </summary>
        public ZipCodeValidator() : base("Property must contain a valid zip code.")
        {
            this.specification = new ZipCodeSpecification();
        }

        protected override bool IsStringValid(string value) => this.specification.IsSatisfiedBy(value);
    }
}
