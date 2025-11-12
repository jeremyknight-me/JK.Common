using FluentValidation.Validators;
using JK.Common.Specifications;

namespace JK.Common.FluentValidation.Validators;

/// <summary>
/// Validator that validates that a double property is a valid longitude.
/// </summary>
public class LongitudeValidator<T> : PropertyValidator<T, decimal>
{
    ///<inheritdoc/>
    public override string Name => "LongitudeValidator";

    ///<inheritdoc/>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "{PropertyName}: Longitude must be between -180 and 180.";

    ///<inheritdoc/>
    public override bool IsValid(ValidationContext<T> context, decimal value)
    {
        var longitude = Convert.ToDecimal(value);
        var specification = new LongitudeSpecification();
        return specification.IsSatisfiedBy(longitude);
    }
}
