namespace JK.Common.Enumerations;

/// <summary>
/// Factory for creating abbreviations for <see cref="DistanceUnit"/> values.
/// </summary>
public static class DistanceUnitAbbreviationFactory
{
    /// <summary>
    /// Returns the abbreviation for the specified <see cref="DistanceUnit"/>.
    /// </summary>
    /// <param name="distanceUnit">The distance unit.</param>
    /// <returns>The abbreviation for the distance unit, or <c>null</c> if not recognized.</returns>
    public static string Make(DistanceUnit distanceUnit)
        => distanceUnit switch
        {
            DistanceUnit.Feet => "ft",
            DistanceUnit.Inches => "in",
            DistanceUnit.Meters => "m",
            DistanceUnit.Centimeters => "cm",
            _ => null,
        };
}
