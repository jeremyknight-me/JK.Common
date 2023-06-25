using System;
using JK.Common.Specifications;
using FluentValidation.Validators;
using FluentValidation;

namespace JK.Common.FluentValidation.Validators;

/// <summary>
/// Validator that validates that a double property is a valid longitude.
/// </summary>
public class LongitudeValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    ///<inheritdoc/>
    public override string Name => "LongitudeValidator";

    ///<inheritdoc/>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "{PropertyName}: Longitude must be between -180 and 180.";

    ///<inheritdoc/>
    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        var longitude = Convert.ToDecimal(value);
        var specification = new LongitudeSpecification();
        return specification.IsSatisfiedBy(longitude);
    }
}
