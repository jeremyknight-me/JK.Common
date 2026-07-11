namespace JK.Common.Extensions;

/// <summary>Extension methods for the Decimal object.</summary>
public static class DecimalExtensions
{
    extension(decimal value)
    {
        /// <summary>Gets the decimal part (right side of decimal) from the given decimal.</summary>
        /// <returns>Right side of decimal as integer</returns>
        public decimal DecimalPart => value - Math.Truncate(value);

        /// <summary>Gets the whole part (left side of decimal) from the given decimal.</summary>
        /// <returns>Left side of decimal as integer</returns>
        public decimal WholePart => decimal.ToInt64(Math.Truncate(value));
    }
}
