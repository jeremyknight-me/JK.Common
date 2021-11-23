namespace JK.Common.Enumerations
{
    public static class DistanceUnitAbbreviationFactory
    {
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
}
