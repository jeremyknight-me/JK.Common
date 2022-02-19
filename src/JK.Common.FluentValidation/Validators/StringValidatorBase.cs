using FluentValidation;
using FluentValidation.Validators;

namespace JK.Common.FluentValidation.Validators;

public abstract class StringValidatorBase<T, TProperty> : PropertyValidator<T, TProperty>
{
    /// <summary>Determine if the given string is valid.</summary>
    /// <param name="value">String value to validate</param>
    /// <returns>True if valid, otherwise false.</returns>
    protected abstract bool IsStringValid(string value);

    ///<inheritdoc/>
    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        var stringToValidate = value as string;
        return string.IsNullOrEmpty(stringToValidate)
            || this.IsStringValid(stringToValidate);
    }
}
