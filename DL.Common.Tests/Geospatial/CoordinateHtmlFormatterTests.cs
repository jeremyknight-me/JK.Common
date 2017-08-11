using DL.Common.Geospatial;
using Xunit;

namespace DL.Common.Tests.Geospatial
{
    public class CoordinateHtmlFormatterTests
    {
        [Theory]
        [InlineData(DisplayFormat.Degrees, "40.44611&deg;")]
        [InlineData(DisplayFormat.DegreesMinutes, "40&deg; 26.767'")]
        [InlineData(DisplayFormat.DegreesMinutesSeconds, "40&deg; 26' 46\"")]
        [InlineData(DisplayFormat.DegreesDirection, "40.44611&deg; N")]
        [InlineData(DisplayFormat.DegreesMinutesDirection, "40&deg; 26.767' N")]
        [InlineData(DisplayFormat.DegreesMinutesSecondsDirection, "40&deg; 26' 46\" N")]
        public void Format_Positive(DisplayFormat format, string expected)
        {
            var coordinate = new Latitude(40, 26, 46);
            var formatter = new CoordinateHtmlFormatter(coordinate);
            string actual = formatter.Format(format);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(DisplayFormat.Degrees, "-79.98222&deg;")]
        [InlineData(DisplayFormat.DegreesMinutes, "-79&deg; 58.933'")]
        [InlineData(DisplayFormat.DegreesMinutesSeconds, "-79&deg; 58' 56\"")]
        [InlineData(DisplayFormat.DegreesDirection, "79.98222&deg; W")]
        [InlineData(DisplayFormat.DegreesMinutesDirection, "79&deg; 58.933' W")]
        [InlineData(DisplayFormat.DegreesMinutesSecondsDirection, "79&deg; 58' 56\" W")]
        public void Format_Negative(DisplayFormat format, string expected)
        {
            var coordinate = new Longitude(-79, 58, 56);
            var formatter = new CoordinateHtmlFormatter(coordinate);
            string actual = formatter.Format(format);
            Assert.Equal(expected, actual);
        }
    }
}
