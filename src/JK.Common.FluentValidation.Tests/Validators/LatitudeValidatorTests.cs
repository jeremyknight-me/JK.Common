namespace JK.Common.FluentValidation.Tests.Validators;

public class LatitudeValidatorTests : DecimalValidatorTestsBase
{
    public override PropertyValidator<MockModel, decimal> Validator => new LatitudeValidator<MockModel, decimal>();

    [Theory]
    [InlineData(-90)]
    [InlineData(0)]
    [InlineData(90)]
    public void IsValid_TrueTheories(decimal value)
    {
        var result = this.MakeAndTestValidator(value);
        result.ShouldNotHaveValidationErrorFor(x => x.DecimalValue);
    }

    [Theory]
    [InlineData(-91)]
    [InlineData(91)]
    public void IsValid_FalseTheories(decimal value)
    {
        var result = this.MakeAndTestValidator(value);
        result.ShouldHaveValidationErrorFor(x => x.DecimalValue);
    }
}
