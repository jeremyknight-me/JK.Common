using System;
using FluentValidation;
using FluentValidation.Validators;
using JK.Common.Specifications;

namespace JK.Common.FluentValidation.Validators;

/// <summary>
/// Validator that validates that a date property is a valid SQL date.
/// </summary>
public class SqlDateValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    ///<inheritdoc/>
    public override string Name => "SqlDateValidator";

    ///<inheritdoc/>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "Year in property {PropertyName} must be greater than 1753";

    ///<inheritdoc/>
    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        DateTime? date = GetDateTime(value);
        if (!date.HasValue)
        {
            return true;
        }

        var specification = new SqlDateSpecification();
        return specification.IsSatisfiedBy(date.Value);
    }

    private static DateTime? GetDateTime(object value)
        => value switch
        {
            var v when v is null => null,
            var v when v is DateTimeOffset => ((DateTimeOffset)value).DateTime,
            _ => (DateTime)value,
        };
}
