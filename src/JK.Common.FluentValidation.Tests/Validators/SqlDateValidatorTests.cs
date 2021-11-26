using System;
using FluentValidation.TestHelper;
using FluentValidation.Validators;
using JK.Common.FluentValidation.Validators;

namespace JK.Common.FluentValidation.Tests.Validators
{
    public class SqlDateValidatorTests
    {
        internal AbstractValidator<MockModel> MockValidator
        {
            get
            {
                var validator = new SqlDateValidator();
                return new MockModelDateValidator(validator);
            }
        }

        [Theory]
        [InlineData(1753, 1, 1)] // = 1753
        [InlineData(1754, 1, 1)] // > 1753
        public void IsValid_TrueTheories(int year, int month, int day)
        {
            var result = this.GetTestValidationResult(year, month, day, this.MockValidator);
            result.ShouldNotHaveValidationErrorFor(x => x.DateValue);
        }

        [Theory]
        [InlineData(1752, 12, 31)] // < 1753
        public void IsValid_FalseTheories(int year, int month, int day)
        {
            var result = this.GetTestValidationResult(year, month, day, this.MockValidator);
            result.ShouldHaveValidationErrorFor(x => x.DateValue);
        }

        private TestValidationResult<MockModel> GetTestValidationResult(int year, int month, int day, AbstractValidator<MockModel> validator)
        {
            var date = new DateTime(year, month, day);
            var model = new MockModel { DateValue = date };
            return validator.TestValidate(model);
        }

        private class MockModelDateValidator : AbstractValidator<MockModel>
        {
            public MockModelDateValidator(PropertyValidator validator)
            {
                this.RuleFor(x => x.DateValue).SetValidator(validator);
            }
        }
    }
}
