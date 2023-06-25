using JK.Common.Specifications.UnitedStates;

namespace JK.Common.FluentValidation.Validators;

public class SocialSecurityNumberValidator<T> : StringValidatorBase<T>
{
    ///<inheritdoc/>
    public override string Name => "SocialSecurityNumberValidator";

    ///<inheritdoc/>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "{PropertyName}: String must only contain valid United States social security numbers.";

    ///<inheritdoc/>
    protected override bool IsStringValid(string value)
    {
        var specification = new SocialSecurityNumberSpecification();
        return specification.IsSatisfiedBy(value);
    }
}
