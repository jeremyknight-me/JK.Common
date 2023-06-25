using JK.Common.Specifications.UnitedStates;

namespace JK.Common.FluentValidation.Validators;

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
