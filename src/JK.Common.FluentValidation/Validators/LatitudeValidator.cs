using System;
using JK.Common.Specifications;
using FluentValidation.Validators;
using FluentValidation;

namespace JK.Common.FluentValidation.Validators;

/// <summary>
/// Validator that validates that a double property is a valid latitude.
/// </summary>
public class LatitudeValidator<T> : PropertyValidator<T, decimal>
{
    ///<inheritdoc/>
    public override string Name => "LatitudeValidator";

    ///<inheritdoc/>
    protected override string GetDefaultMessageTemplate(string errorCode) => "{PropertyName}: Latitude must be between -90 and 90.";

    ///<inheritdoc/>
    public override bool IsValid(ValidationContext<T> context, decimal value)
    {
        var latitude = Convert.ToDecimal(value);
        var specification = new LatitudeSpecification();
        return specification.IsSatisfiedBy(latitude);
    }
}
