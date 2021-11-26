using FluentValidation.TestHelper;

namespace JK.Common.FluentValidation.Tests.Extensions
{
    internal static class StringExtensions
    {
        internal static TestValidationResult<MockModel> GetTestValidationResult(this string value, AbstractValidator<MockModel> validator)
        {
            var model = new MockModel { StringValue = value };
            return validator.TestValidate(model);
        }
    }
}
