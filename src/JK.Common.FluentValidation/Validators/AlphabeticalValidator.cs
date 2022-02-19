using JK.Common.Specifications;

namespace JK.Common.FluentValidation.Validators;

public class AlphabeticalValidator<T, TProperty> : StringValidatorBase<T, TProperty>
{
    ///<inheritdoc/>
    public override string Name => "AlphabeticalValidator";

    ///<inheritdoc/>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "String in propery {PropertyName} must only contain uppercase letters or lowercase letters.";

    ///<inheritdoc/>
    protected override bool IsStringValid(string value)
    {
        var specification = new AlphabeticalSpecification();
        return specification.IsSatisfiedBy(value);
    }
}
