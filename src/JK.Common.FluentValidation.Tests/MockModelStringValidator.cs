using JK.Common.FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests
{
    internal class MockModelStringValidator : AbstractValidator<MockModel>
    {
        public MockModelStringValidator(StringValidatorBase<MockModel, string> validator)
        {
            this.RuleFor(x => x.StringValue).SetValidator(validator);
        }
    }
}
