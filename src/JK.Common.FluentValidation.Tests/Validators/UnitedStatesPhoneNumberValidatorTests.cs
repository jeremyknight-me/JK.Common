using JK.Common.FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests.Validators;

public class UnitedStatesPhoneNumberValidatorTests
{
    internal MockModelStringValidator MockValidator
    {
        get
        {
            var validator = new UnitedStatesPhoneNumberValidator<MockModel, string>();
            return new MockModelStringValidator(validator);
        }       
    }

    [Theory]
    [InlineData("5555551234")]
    [InlineData("(555) 555-1234")]
    [InlineData("555-555-1234")]
    [InlineData("5551234")]
    [InlineData("555-1234")]
    public void IsValid_TrueTheories(string value)
    {
        var result = value.GetTestValidationResult(this.MockValidator);
        result.ShouldNotHaveValidationErrorFor(x => x.StringValue);
    }
}
