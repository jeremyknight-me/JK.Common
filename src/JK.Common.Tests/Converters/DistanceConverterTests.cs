using JK.Common.Converters;
using JK.Common.Enumerations;

namespace JK.Common.Tests.Converters;

public class DistanceConverterTests
{
    [Theory]
    [MemberData(nameof(Convert_Data))]
    public void Convert_Tests(decimal originalDistance, DistanceUnit originalUnit, DistanceUnit newUnit, decimal expected)
    {
        var actual = new DistanceConverter().Convert(originalDistance, originalUnit, newUnit);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<decimal, DistanceUnit, DistanceUnit, decimal> Convert_Data()
        => new()
        {
            { 1m, DistanceUnit.Feet, DistanceUnit.Inches, 12m },
            { 12m, DistanceUnit.Inches, DistanceUnit.Feet, 0.99999996m },
            { 1m, DistanceUnit.Meters, DistanceUnit.Centimeters, 100m },
            { 100m, DistanceUnit.Centimeters, DistanceUnit.Meters, 1m }
        };
}
