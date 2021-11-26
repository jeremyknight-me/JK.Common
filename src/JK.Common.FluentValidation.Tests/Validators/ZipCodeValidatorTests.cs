using JK.Common.FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests.Validators
{
    public class ZipCodeValidatorTests
    {
        internal MockModelStringValidator MockValidator
        {
            get
            {
                var validator = new ZipCodeValidator();
                return new MockModelStringValidator(validator);
            }
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("12345-6789")]
        public void IsValid_TrueTheories(string value)
        {
            var result = value.GetTestValidationResult(this.MockValidator);
            result.ShouldNotHaveValidationErrorFor(x => x.StringValue);
        }

        [Theory]
        [InlineData("12X45")]
        [InlineData("12X45-6789")]
        [InlineData("12345-67X9")]
        public void IsValid_FalseTheories(string value)
        {
            var result = value.GetTestValidationResult(this.MockValidator);
            result.ShouldHaveValidationErrorFor(x => x.StringValue);
        }
    }
}
