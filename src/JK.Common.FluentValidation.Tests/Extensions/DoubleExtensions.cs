using FluentValidation.TestHelper;

namespace JK.Common.FluentValidation.Tests.Extensions
{
    internal static class DoubleExtensions
    {
        internal static TestValidationResult<MockModel> GetTestValidationResult(this double value, AbstractValidator<MockModel> validator)
        {
            var model = new MockModel { DoubleValue = value };
            return validator.TestValidate(model);
        }
    }
}
