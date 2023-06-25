namespace JK.Common.FluentValidation.Tests.Validators;

public abstract class DecimalValidatorTestsBase
{
    public abstract PropertyValidator<MockModel, decimal> Validator { get; }

    public TestValidationResult<MockModel> MakeAndTestValidator(decimal value)
    {
        var model = new MockModel { DecimalValue = value };
        var validator = new MockModelDecimalValidator(this.Validator);
        return validator.TestValidate(model);
    }

    private class MockModelDecimalValidator : AbstractValidator<MockModel>
    {
        public MockModelDecimalValidator(PropertyValidator<MockModel, decimal> validator)
        {
            this.RuleFor(x => x.DecimalValue).SetValidator(validator);
        }
    }
}
