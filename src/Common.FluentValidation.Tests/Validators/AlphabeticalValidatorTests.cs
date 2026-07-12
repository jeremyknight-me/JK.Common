namespace JK.Common.FluentValidation.Tests.Validators;

public class AlphabeticalValidatorTests : StringValidatorTestsBase
{
    public override StringValidatorBase<MockModel> Validator => new AlphabeticalValidator<MockModel>();

    [Theory]
    [InlineData("abcdefghijklmnopqrstuvwxyz")]
    public void IsValid_TrueTheories(string value)
    {
        TestValidationResult<MockModel> result = MakeAndTestValidator(value);
        result.ShouldNotHaveValidationErrorFor(x => x.StringValue);
    }

    [Theory]
    [InlineData("1234567890")]
    [InlineData("abc123")]
    public void IsValid_FalseTheories(string value)
    {
        TestValidationResult<MockModel> result = MakeAndTestValidator(value);
        result.ShouldHaveValidationErrorFor(x => x.StringValue);
    }
}
