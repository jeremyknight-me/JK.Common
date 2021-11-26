using JK.Common.FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests.Validators
{
    public class AlphaNumericValidatorTests
    {
        internal MockModelStringValidator MockValidator
        {
            get
            {
                var validator = new AlphaNumericValidator();
                return new MockModelStringValidator(validator);
            }
        }

        [Theory]
        [InlineData("abcdefghijklmnopqrstuvwxyz")]
        [InlineData("1234567890")]
        [InlineData("abc123")]
        public void IsValid_TrueTheories(string value)
        {
            var result = value.GetTestValidationResult(this.MockValidator);
            result.ShouldNotHaveValidationErrorFor(x => x.StringValue);
        }

        [Theory]
        [InlineData("asdf234*@#asdf")]
        public void IsValid_FalseTheories(string value)
        {
            var result = value.GetTestValidationResult(this.MockValidator);
            result.ShouldHaveValidationErrorFor(x => x.StringValue);
        }
    }
}
