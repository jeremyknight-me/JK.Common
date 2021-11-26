using JK.Common.Specifications;

namespace JK.Common.FluentValidation.Validators
{
    public class AlphabeticalValidator : StringValidatorBase
    {
        private readonly AlphabeticalSpecification specification;

        public AlphabeticalValidator() : base("String must only contain uppercase letters or lowercase letters.")
        {
            this.specification = new AlphabeticalSpecification();
        }

        protected override bool IsStringValid(string value) => this.specification.IsSatisfiedBy(value);
    }
}
