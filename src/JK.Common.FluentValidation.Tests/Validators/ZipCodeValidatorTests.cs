namespace JK.Common.FluentValidation.Tests.Validators;

public class ZipCodeValidatorTests : StringValidatorTestsBase
{
    public override StringValidatorBase<MockModel> Validator => new ZipCodeValidator<MockModel>();

    [Theory]
    [InlineData("12345")]
    [InlineData("12345-6789")]
    public void IsValid_TrueTheories(string value)
    {
        TestValidationResult<MockModel> result = MakeAndTestValidator(value);
        result.ShouldNotHaveValidationErrorFor(x => x.StringValue);
    }

    [Theory]
    [InlineData("12X45")]
    [InlineData("12X45-6789")]
    [InlineData("12345-67X9")]
    public void IsValid_FalseTheories(string value)
    {
        TestValidationResult<MockModel> result = MakeAndTestValidator(value);
        result.ShouldHaveValidationErrorFor(x => x.StringValue);
    }
}
