using System;

namespace JK.Common.TypeHelpers;

/// <summary>Class which contains methods for Decimal manipulation</summary>
public static class DecimalHelper
{
    /// <summary>Gets the decimal part (right side of decimal) from the given decimal.</summary>
    /// <param name="value">Decimal value</param>
    /// <returns>Right side of decimal as integer</returns>
    public static long GetDecimalPart(in decimal value)
    {
        var decimalPart = value - Math.Truncate(value);
        var right = $"{decimalPart}".Replace("0.", "").TrimEnd('0');
        return string.IsNullOrWhiteSpace(right) ? 0 : long.Parse(right);
    }

    /// <summary>Gets the whole part (left side of decimal) from the given decimal.</summary>
    /// <param name="value">Decimal value</param>
    /// <returns>Left side of decimal as integer</returns>
    public static long GetWholePart(in decimal value) => decimal.ToInt64(Math.Truncate(value));
}
