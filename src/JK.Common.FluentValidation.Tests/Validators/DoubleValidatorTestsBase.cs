namespace JK.Common.FluentValidation.Tests.Validators;

public abstract class DoubleValidatorTestsBase
{
    public abstract PropertyValidator<MockModel, double> Validator { get; }

    public TestValidationResult<MockModel> MakeAndTestValidator(double value)
    {
        var model = new MockModel { DoubleValue = value };
        var validator = new MockModelDoubleValidator(this.Validator);
        return validator.TestValidate(model);
    }

    private class MockModelDoubleValidator : AbstractValidator<MockModel>
    {
        public MockModelDoubleValidator(PropertyValidator<MockModel, double> validator)
        {
            this.RuleFor(x => x.DoubleValue).SetValidator(validator);
        }
    }
}
