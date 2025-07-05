using JK.Common.Geospatial;

namespace JK.Common.Tests.Geospatial;

public class LatitudeTests
{
    /*
        degrees minutes seconds: 40° 26′ 46″ N 
        degrees decimal minutes: 40° 26.772′ N 
        decimal degrees: 40.4461111111° N
        decimal: 40.4461111111°
     */

    [Fact]
    public void Ctor_InvalidDegrees_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(100));
    }

    [Fact]
    public void Ctor_NegativeInvalidDegrees_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(-100));
    }

    [Fact]
    public void Ctor_InvalidDegreesMinutes_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(100, 26.767m));
    }

    [Fact]
    public void Ctor_NegativeInvalidDegreesMinutes_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(-100, 26.767m));
    }

    [Fact]
    public void Ctor_InvalidDegreesMinutesSeconds_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(100, 26, 46));
    }

    [Fact]
    public void Ctor_NegativeInvalidDegreesMinutesSeconds_Exception()
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(-100, 26, 46));
    }

    [Fact]
    public void Ctor_Degrees()
    {
        var latitude = new Latitude(40.446113m);
        AssertCoordinateData(latitude);
    }

    [Fact]
    public void Ctor_DegreesMinutes()
    {
        var latitude = new Latitude(40, 26.767m);
        AssertCoordinateData(latitude);
    }

    [Fact]
    public void Ctor_DegreesMinutesSeconds()
    {
        var latitude = new Latitude(40, 26, 46);
        AssertCoordinateData(latitude);
    }

    [Fact]
    public void Ctor_DegreesDirection()
    {
        var latitude = new Latitude(40.446113m, Direction.N);
        AssertCoordinateData(latitude);
    }

    [Fact]
    public void Ctor_DegreesMinutesDirection()
    {
        var latitude = new Latitude(40, 26.767m, Direction.N);
        AssertCoordinateData(latitude);
    }

    [Fact]
    public void Ctor_DegreesMinutesSecondsDirection()
    {
        var latitude = new Latitude(40, 26, 46, Direction.N);
        AssertCoordinateData(latitude);
    }

    private void AssertCoordinateData(Latitude latitude)
    {
        //Assert.Equal(40.4461111111m, latitude.DecimalDegreesSigned);
        Assert.Equal(40, latitude.Degrees);
        Assert.Equal(40, latitude.DegreesSigned);
        Assert.Equal(26.767m, latitude.DecimalMinutes);
        Assert.Equal(26, latitude.Minutes);
        Assert.Equal(46, latitude.Seconds);
        Assert.Equal(Direction.N, latitude.Direction);
    }
}
