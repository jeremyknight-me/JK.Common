using JK.Common.TypeHelpers;

namespace JK.Common.Extensions;

/// <summary>Extension methods for the Decimal object.</summary>
public static class DecimalExtensions
{
    /// <summary>Gets the decimal part (right side of decimal) from the given decimal.</summary>
    /// <param name="value">Current Decimal object from extension method.</param>
    /// <returns>Right side of decimal as integer</returns>
    public static int GetDecimalPart(this decimal value) => DecimalHelper.GetDecimalPart(value);

    /// <summary>Gets the whole part (left side of decimal) from the given decimal.</summary>
    /// <param name="value">Current Decimal object from extension method.</param>
    /// <returns>Left side of decimal as integer</returns>
    public static int GetWholePart(this decimal value) => DecimalHelper.GetWholePart(value);
}
