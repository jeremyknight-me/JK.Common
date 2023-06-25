using JK.Common.Specifications.UnitedStates;

namespace JK.Common.FluentValidation.Validators;

/// <summary>
/// Validator that validates that a string property is a valid zip code.
/// </summary>
public class ZipCodeValidator<T> : StringValidatorBase<T>
{
    ///<inheritdoc/>
    public override string Name => "ZipCodeValidator";

    ///<inheritdoc/>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "Property {PropertyName} must contain a valid zip code.";

    ///<inheritdoc/>
    protected override bool IsStringValid(string value)
    {
        var specification = new ZipCodeSpecification();
        return specification.IsSatisfiedBy(value);
    }
}
