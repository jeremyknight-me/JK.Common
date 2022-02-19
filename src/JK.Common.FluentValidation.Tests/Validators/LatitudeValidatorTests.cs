namespace JK.Common.FluentValidation.Tests.Validators;

public class LatitudeValidatorTests : DoubleValidatorTestsBase
{
    public override PropertyValidator<MockModel, double> Validator => new LatitudeValidator<MockModel, double>();

    [Theory]
    [InlineData(-90)]
    [InlineData(0)]
    [InlineData(90)]
    public void IsValid_TrueTheories(double value)
    {
        var result = this.MakeAndTestValidator(value);
        result.ShouldNotHaveValidationErrorFor(x => x.DoubleValue);
    }

    [Theory]
    [InlineData(-91)]
    [InlineData(91)]
    public void IsValid_FalseTheories(double value)
    {
        var result = this.MakeAndTestValidator(value);
        result.ShouldHaveValidationErrorFor(x => x.DoubleValue);
    }
}
