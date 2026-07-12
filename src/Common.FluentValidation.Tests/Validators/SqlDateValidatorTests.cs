namespace JK.Common.FluentValidation.Tests.Validators;

public class SqlDateValidatorTests
{
    [Theory]
    [InlineData(1753, 1, 1)] // = 1753
    [InlineData(1754, 1, 1)] // > 1753
    public void IsValid_TrueTheories(int year, int month, int day)
    {
        TestValidationResult<MockModel> result = MakeAndTestValidator(year, month, day);
        result.ShouldNotHaveValidationErrorFor(x => x.DateValue);
    }

    [Theory]
    [InlineData(1752, 12, 31)] // < 1753
    public void IsValid_FalseTheories(int year, int month, int day)
    {
        TestValidationResult<MockModel> result = MakeAndTestValidator(year, month, day);
        result.ShouldHaveValidationErrorFor(x => x.DateValue);
    }

    private static TestValidationResult<MockModel> MakeAndTestValidator(int year, int month, int day)
    {
        var date = new DateTime(year, month, day);
        var model = new MockModel { DateValue = date };
        var validator = new SqlDateValidator<MockModel, DateTime>();
        var mock = new MockModelDateValidator(validator);
        return mock.TestValidate(model);
    }

    private class MockModelDateValidator : AbstractValidator<MockModel>
    {
        public MockModelDateValidator(PropertyValidator<MockModel, DateTime> validator)
        {
            RuleFor(x => x.DateValue).SetValidator(validator);
        }
    }
}
