namespace JK.Common.FluentValidation.Tests.Validators;

public abstract class StringValidatorTestsBase
{
    public abstract StringValidatorBase<MockModel, string> Validator { get; }

    public TestValidationResult<MockModel> MakeAndTestValidator(string value)
    {
        var model = new MockModel { StringValue = value };
        var validator = new MockModelStringValidator(this.Validator);
        return validator.TestValidate(model);
    }

    private class MockModelStringValidator : AbstractValidator<MockModel>
    {
        public MockModelStringValidator(StringValidatorBase<MockModel, string> validator)
        {
            this.RuleFor(x => x.StringValue).SetValidator(validator);
        }
    }
}
