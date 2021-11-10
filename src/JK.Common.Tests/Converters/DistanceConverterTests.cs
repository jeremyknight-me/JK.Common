using JK.Common.Converters;
using JK.Common.Enumerations;
using System.Collections.Generic;

namespace JK.Common.Tests.Converters;

public class DistanceConverterTests
{
    [Theory]
    [MemberData(nameof(BuildDataConvert))]
    public void Convert_Tests(decimal originalDistance, DistanceUnit originalUnit, DistanceUnit newUnit, decimal expected)
    {
        var actual = new DistanceConverter().Convert(originalDistance, originalUnit, newUnit);
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> BuildDataConvert()
        => new List<object[]>
            {
                new object[] { 1m, DistanceUnit.Feet, DistanceUnit.Inches, 12m },
                new object[] { 12m, DistanceUnit.Inches, DistanceUnit.Feet, 0.99999996m },
                new object[] { 1m, DistanceUnit.Meters, DistanceUnit.Centimeters, 100m },
                new object[] { 100m, DistanceUnit.Centimeters, DistanceUnit.Meters, 1m }
            };
}
