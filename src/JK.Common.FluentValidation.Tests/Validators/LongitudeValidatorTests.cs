using JK.Common.FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests.Validators;

public class LongitudeValidatorTests
{
    internal AbstractValidator<MockModel> MockValidator
    {
        get
        {
            var validator = new LongitudeValidator<MockModel, double>();
            return new MockModelDoubleValidator(validator);
        }
    }

    [Theory]
    [InlineData(-180)]
    [InlineData(0)]
    [InlineData(180)]
    public void IsValid_TrueTheories(double value)
    {
        var result = value.GetTestValidationResult(this.MockValidator);
        result.ShouldNotHaveValidationErrorFor(x => x.DoubleValue);
    }

    [Theory]
    [InlineData(-181)]
    [InlineData(181)]
    public void IsValid_FalseTheories(double value)
    {
        var result = value.GetTestValidationResult(this.MockValidator);
        result.ShouldHaveValidationErrorFor(x => x.DoubleValue);
    }
}
