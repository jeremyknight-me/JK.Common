namespace JK.Common.TypeHelpers;

/// <summary>Class which contains methods for Decimal manipulation</summary>
public static class DecimalHelper
{
    /// <summary>Gets the decimal part (right side of decimal) from the given decimal.</summary>
    /// <param name="value">Decimal value</param>
    /// <returns>Right side of decimal</returns>
    public static decimal GetDecimalPart(in decimal value) => value - Math.Truncate(value);

    /// <summary>Gets the whole part (left side of decimal) from the given decimal.</summary>
    /// <param name="value">Decimal value</param>
    /// <returns>Left side of decimal</returns>
    public static decimal GetWholePart(in decimal value) => decimal.ToInt64(Math.Truncate(value));
}
