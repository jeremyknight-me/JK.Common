using FluentValidation.Validators;

namespace JK.Common.FluentValidation.Validators
{
    public abstract class StringValidatorBase : PropertyValidator
    {
        protected StringValidatorBase(string errorMessage) : base(errorMessage)
        {
        }

        protected abstract bool IsStringValid(string value);

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var stringToValidate = context.PropertyValue as string;
            return string.IsNullOrEmpty(stringToValidate)
                ? true
                : this.IsStringValid(stringToValidate);
        }
    }
}
