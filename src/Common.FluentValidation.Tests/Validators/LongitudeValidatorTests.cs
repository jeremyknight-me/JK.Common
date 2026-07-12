namespace JK.Common.FluentValidation.Tests.Validators;

public class LongitudeValidatorTests : DecimalValidatorTestsBase
{
    public override PropertyValidator<MockModel, decimal> Validator => new LongitudeValidator<MockModel>();

    [Theory]
    [InlineData(-180)]
    [InlineData(0)]
    [InlineData(180)]
    public void IsValid_TrueTheories(decimal value)
    {
        TestValidationResult<MockModel> result = MakeAndTestValidator(value);
        result.ShouldNotHaveValidationErrorFor(x => x.DecimalValue);
    }

    [Theory]
    [InlineData(-181)]
    [InlineData(181)]
    public void IsValid_FalseTheories(decimal value)
    {
        TestValidationResult<MockModel> result = MakeAndTestValidator(value);
        result.ShouldHaveValidationErrorFor(x => x.DecimalValue);
    }
}
