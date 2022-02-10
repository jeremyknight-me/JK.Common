using System;

namespace JK.Common.TypeHelpers;

/// <summary>Class which contains methods for Decimal manipulation</summary>
public static class DecimalHelper
{
    /// <summary>Gets the decimal part (right side of decimal) from the given decimal.</summary>
    /// <param name="value">Decimal value</param>
    /// <returns>Right side of decimal as integer</returns>
    public static int GetDecimalPart(in decimal value)
    {
        var decimalPart = value - Math.Truncate(value);
        var leftOnly = $"{decimalPart}".Replace("0.", "");
        return int.Parse(leftOnly);
    }

    /// <summary>Gets the whole part (left side of decimal) from the given decimal.</summary>
    /// <param name="value">Decimal value</param>
    /// <returns>Left side of decimal as integer</returns>
    public static int GetWholePart(in decimal value) => decimal.ToInt32(Math.Truncate(value));
}
