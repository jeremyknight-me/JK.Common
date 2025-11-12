namespace JK.Common.Extensions;

/// <summary>Extension methods for the Decimal object.</summary>
public static class DecimalExtensions
{
    /// <summary>Gets the decimal part (right side of decimal) from the given decimal.</summary>
    /// <param name="value">Current Decimal object from extension method.</param>
    /// <returns>Right side of decimal as integer</returns>
    public static decimal GetDecimalPart(this decimal value) => value - Math.Truncate(value);

    /// <summary>Gets the whole part (left side of decimal) from the given decimal.</summary>
    /// <param name="value">Current Decimal object from extension method.</param>
    /// <returns>Left side of decimal as integer</returns>
    public static decimal GetWholePart(this decimal value) => decimal.ToInt64(Math.Truncate(value));
}
