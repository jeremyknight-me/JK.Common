using JK.Common.FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests.Validators;

public class LatitudeValidatorTests
{
    internal AbstractValidator<MockModel> MockValidator
    {
        get
        {
            var validator = new LatitudeValidator<MockModel, double>();
            return new MockModelDoubleValidator(validator);
        }
    }

    [Theory]
    [InlineData(-90)]
    [InlineData(0)]
    [InlineData(90)]
    public void IsValid_TrueTheories(double value)
    {
        var result = value.GetTestValidationResult(this.MockValidator);
        result.ShouldNotHaveValidationErrorFor(x => x.DoubleValue);
    }

    [Theory]
    [InlineData(-91)]
    [InlineData(91)]
    public void IsValid_FalseTheories(double value)
    {
        var result = value.GetTestValidationResult(this.MockValidator);
        result.ShouldHaveValidationErrorFor(x => x.DoubleValue);
    }
}
