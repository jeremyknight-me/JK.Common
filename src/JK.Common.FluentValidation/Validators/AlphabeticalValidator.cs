using JK.Common.Specifications;

namespace JK.Common.FluentValidation.Validators;

/// <summary>
/// Validator to determine whether or not a string property contains only alphabetical characters.
/// </summary>
public class AlphabeticalValidator<T> : StringValidatorBase<T>
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
