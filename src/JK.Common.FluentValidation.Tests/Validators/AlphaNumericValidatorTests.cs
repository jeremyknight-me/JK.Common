namespace JK.Common.FluentValidation.Tests.Validators;

public class AlphaNumericValidatorTests : StringValidatorTestsBase
{
    public override StringValidatorBase<MockModel> Validator => new AlphaNumericValidator<MockModel>();

    [Theory]
    [InlineData("abcdefghijklmnopqrstuvwxyz")]
    [InlineData("1234567890")]
    [InlineData("abc123")]
    public void IsValid_TrueTheories(string value)
    {
        var result = this.MakeAndTestValidator(value);
        result.ShouldNotHaveValidationErrorFor(x => x.StringValue);
    }

    [Theory]
    [InlineData("asdf234*@#asdf")]
    public void IsValid_FalseTheories(string value)
    {
        var result = this.MakeAndTestValidator(value);
        result.ShouldHaveValidationErrorFor(x => x.StringValue);
    }
}
