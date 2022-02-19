using JK.Common.Specifications;

namespace JK.Common.FluentValidation.Validators;

/// <summary>
/// Validator that validates that a string property contains alphanumeric characters.
/// </summary>
public class AlphaNumericValidator<T, TProperty> : StringValidatorBase<T, TProperty>
{
    ///<inheritdoc/>
    public override string Name => "AlphaNumericValidator";

    ///<inheritdoc/>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "String in propery {PropertyName} must only contain uppercase letters, lowercase letters, or numbers.";

    ///<inheritdoc/>
    protected override bool IsStringValid(string value)
    {
        var specification = new AlphanumericSpecification();
        return specification.IsSatisfiedBy(value);
    }
}
