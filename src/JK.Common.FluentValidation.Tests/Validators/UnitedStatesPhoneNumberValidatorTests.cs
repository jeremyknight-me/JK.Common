namespace JK.Common.FluentValidation.Tests.Validators;

public class UnitedStatesPhoneNumberValidatorTests : StringValidatorTestsBase
{
    public override StringValidatorBase<MockModel> Validator => new UnitedStatesPhoneNumberValidator<MockModel>();

    [Theory]
    [InlineData("5555551234")]
    [InlineData("(555) 555-1234")]
    [InlineData("555-555-1234")]
    [InlineData("5551234")]
    [InlineData("555-1234")]
    public void IsValid_TrueTheories(string value)
    {
        var result = this.MakeAndTestValidator(value);
        result.ShouldNotHaveValidationErrorFor(x => x.StringValue);
    }
}
