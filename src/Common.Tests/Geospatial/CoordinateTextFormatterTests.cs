using JK.Common.Geospatial;

namespace JK.Common.Tests.Geospatial;

public class CoordinateTextFormatterTests
{
    [Theory]
    [InlineData(DisplayFormat.Degrees, "40.44611\u00B0")]
    [InlineData(DisplayFormat.DegreesMinutes, "40\u00B0 26.767'")]
    [InlineData(DisplayFormat.DegreesMinutesSeconds, "40\u00B0 26' 46\"")]
    [InlineData(DisplayFormat.DegreesDirection, "40.44611\u00B0 N")]
    [InlineData(DisplayFormat.DegreesMinutesDirection, "40\u00B0 26.767' N")]
    [InlineData(DisplayFormat.DegreesMinutesSecondsDirection, "40\u00B0 26' 46\" N")]
    public void Format_Positive(DisplayFormat format, string expected)
    {
        var coordinate = new Latitude(40, 26, 46);
        var formatter = new CoordinateTextFormatter(coordinate);
        var actual = formatter.Format(format);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(DisplayFormat.Degrees, "-79.98222\u00B0")]
    [InlineData(DisplayFormat.DegreesMinutes, "-79\u00B0 58.933'")]
    [InlineData(DisplayFormat.DegreesMinutesSeconds, "-79\u00B0 58' 56\"")]
    [InlineData(DisplayFormat.DegreesDirection, "79.98222\u00B0 W")]
    [InlineData(DisplayFormat.DegreesMinutesDirection, "79\u00B0 58.933' W")]
    [InlineData(DisplayFormat.DegreesMinutesSecondsDirection, "79\u00B0 58' 56\" W")]
    public void Format_Negative(DisplayFormat format, string expected)
    {
        var coordinate = new Longitude(-79, 58, 56);
        var formatter = new CoordinateTextFormatter(coordinate);
        var actual = formatter.Format(format);
        Assert.Equal(expected, actual);
    }
}
