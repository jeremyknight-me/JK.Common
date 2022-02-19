namespace JK.Common.FluentValidation.Tests.Validators;

public class LongitudeValidatorTests : DoubleValidatorTestsBase
{
    public override PropertyValidator<MockModel, double> Validator => new LongitudeValidator<MockModel, double>();

    [Theory]
    [InlineData(-180)]
    [InlineData(0)]
    [InlineData(180)]
    public void IsValid_TrueTheories(double value)
    {
        var result = this.MakeAndTestValidator(value);
        result.ShouldNotHaveValidationErrorFor(x => x.DoubleValue);
    }

    [Theory]
    [InlineData(-181)]
    [InlineData(181)]
    public void IsValid_FalseTheories(double value)
    {
        var result = this.MakeAndTestValidator(value);
        result.ShouldHaveValidationErrorFor(x => x.DoubleValue);
    }
}
