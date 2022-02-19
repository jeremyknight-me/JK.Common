using JK.Common.FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests.Validators;

public class AlphabeticalValidatorTests
{
    internal MockModelStringValidator MockValidator
    {
        get
        {
            var validator = new AlphabeticalValidator<MockModel, string>();
            return new MockModelStringValidator(validator);
        }
    }

    [Theory]
    [InlineData("abcdefghijklmnopqrstuvwxyz")]
    public void IsValid_TrueTheories(string value)
    {
        var result = value.GetTestValidationResult(this.MockValidator);
        result.ShouldNotHaveValidationErrorFor(x => x.StringValue);
    }

    [Theory]
    [InlineData("1234567890")]
    [InlineData("abc123")]
    public void IsValid_FalseTheories(string value)
    {
        var result = value.GetTestValidationResult(this.MockValidator);
        result.ShouldHaveValidationErrorFor(x => x.StringValue);
    }
}
