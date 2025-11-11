using FluentValidation.Validators;

namespace JK.Common.FluentValidation.Validators;

/// <summary>
/// String property abstract validator.
/// </summary>
public abstract class StringValidatorBase<T> : PropertyValidator<T, string>
{
    /// <summary>Determine if the given string is valid.</summary>
    /// <param name="value">String value to validate</param>
    /// <returns>True if valid, otherwise false.</returns>
    protected abstract bool IsStringValid(string value);

    ///<inheritdoc/>
    public override bool IsValid(ValidationContext<T> context, string value)
        => string.IsNullOrEmpty(value)
            || IsStringValid(value);
}
