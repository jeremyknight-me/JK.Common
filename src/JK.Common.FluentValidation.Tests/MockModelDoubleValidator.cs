using FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests
{
    internal class MockModelDoubleValidator : AbstractValidator<MockModel>
    {
        public MockModelDoubleValidator(PropertyValidator validator)
        {
            this.RuleFor(x => x.DoubleValue).SetValidator(validator);
        }
    }
}
