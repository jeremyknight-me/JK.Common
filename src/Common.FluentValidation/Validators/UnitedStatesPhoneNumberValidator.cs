using JK.Common.Specifications.UnitedStates;

namespace JK.Common.FluentValidation.Validators;

/// <summary>
/// Validator to determine whether or not a string property is a valid United States phone number.
/// </summary>
public class UnitedStatesPhoneNumberValidator<T> : StringValidatorBase<T>
{
    ///<inheritdoc/>
    public override string Name => "UnitedStatesPhoneNumberValidator";

    ///<inheritdoc/>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "{PropertyName}: String must only contain valid United States phone numbers.";

    ///<inheritdoc/>
    protected override bool IsStringValid(string value)
    {
        var specification = new PhoneNumberSpecification();
        return specification.IsSatisfiedBy(value);
    }
}
