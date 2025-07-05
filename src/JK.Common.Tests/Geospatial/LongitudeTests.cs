using JK.Common.Geospatial;

namespace JK.Common.Tests.Geospatial;

public class LongitudeTests
{
    /*
        degrees minutes seconds: 79° 58′ 56″ W
        degrees decimal minutes: 79° 58.933′ W
        decimal degrees: 79.9822166667° W
        decimal: -79.9822166667
     */

    [Fact]
    public void Ctor_InvalidDegrees_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(200));
    }

    [Fact]
    public void Ctor_NegativeInvalidDegrees_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(-200));
    }

    [Fact]
    public void Ctor_InvalidDegreesMinutes_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(200, 26.767m));
    }

    [Fact]
    public void Ctor_NegativeInvalidDegreesMinutes_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(-200, 26.767m));
    }

    [Fact]
    public void Ctor_InvalidDegreesMinutesSeconds_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(200, 26, 46));
    }

    [Fact]
    public void Ctor_NegativeInvalidDegreesMinutesSeconds_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(-200, 26, 46));
    }

    [Fact]
    public void Ctor_Degrees()
    {
        var longitude = new Longitude(-79.98222m);
        AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesMinutes()
    {
        var longitude = new Longitude(-79, 58.933m);
        AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesMinutesSeconds()
    {
        var longitude = new Longitude(-79, 58, 56);
        AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesDirection()
    {
        var longitude = new Longitude(79.9822166667m, Direction.W);
        AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesMinutesDirection()
    {
        var longitude = new Longitude(79, 58.933m, Direction.W);
        AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesMinutesSecondsDirection()
    {
        var longitude = new Longitude(79, 58, 56, Direction.W);
        AssertCoordinateData(longitude);
    }

    private static void AssertCoordinateData(Longitude longitude)
    {
        //Assert.AreEqual(-79.9822166667m, longitude.DecimalDegreesSigned);
        Assert.Equal(79, longitude.Degrees);
        Assert.Equal(-79, longitude.DegreesSigned);
        Assert.Equal(58.933m, longitude.DecimalMinutes);
        Assert.Equal(58, longitude.Minutes);
        Assert.Equal(56, longitude.Seconds);
        Assert.Equal(Direction.W, longitude.Direction);
    }
}
