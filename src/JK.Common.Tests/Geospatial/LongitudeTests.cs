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

    #region SetDegrees() Invalid Values

    [Theory]
    [InlineData(200)]
    [InlineData(-200)]
    public void SetDegrees_InvalidDegrees_Exception(double degrees)
    {
        var longitude = new Longitude();
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => longitude.SetCoordinate(degrees));
    }

    [Fact]
    public void SetDegrees_InvalidDegreesMinutes_Exception()
    {
        var longitude = new Longitude();
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => longitude.SetCoordinate(200, 26.767));
    }

    [Fact]
    public void SetDegrees_NegativeInvalidDegreesMinutes_Exception()
    {
        var longitude = new Longitude();
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => longitude.SetCoordinate(-200, 26.767));
    }

    [Fact]
    public void SetDegrees_InvalidDegreesMinutesSeconds_Exception()
    {
        var longitude = new Longitude();
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => longitude.SetCoordinate(200, 26, 46));
    }

    [Fact]
    public void SetDegrees_NegativeInvalidDegreesMinutesSeconds_Exception()
    {
        var longitude = new Longitude();
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => longitude.SetCoordinate(-200, 26, 46));
    }

    #endregion

    #region SetDegrees() Valid Values

    [Fact]
    public void SetDegrees_Degrees()
    {
        var longitude = new Longitude();
        longitude.SetCoordinate(-79.9822166667);

        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void SetDegrees_DegreesMinutes()
    {
        var longitude = new Longitude();
        longitude.SetCoordinate(-79, 58.933);

        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void SetDegrees_DegreesMinutesSeconds()
    {
        var longitude = new Longitude();
        longitude.SetCoordinate(-79, 58, 56);

        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void SetDegrees_DegreesDirection()
    {
        var longitude = new Longitude();
        longitude.SetCoordinate(79.9822166667, Direction.W);

        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void SetDegrees_DegreesMinutesDirection()
    {
        var longitude = new Longitude();
        longitude.SetCoordinate(79, 58.933, Direction.W);

        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void SetDegrees_DegreesMinutesSecondsDirection()
    {
        var longitude = new Longitude();
        longitude.SetCoordinate(79, 58, 56, Direction.W);

        this.AssertCoordinateData(longitude);
    }

    #endregion

    #region Ctor() Invalid Values

    [Fact]
    public void Ctor_InvalidDegrees_Exception()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(200));
    }

    [Fact]
    public void Ctor_NegativeInvalidDegrees_Exception()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(-200));
    }

    [Fact]
    public void Ctor_InvalidDegreesMinutes_Exception()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(200, 26.767));
    }

    [Fact]
    public void Ctor_NegativeInvalidDegreesMinutes_Exception()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(-200, 26.767));
    }

    [Fact]
    public void Ctor_InvalidDegreesMinutesSeconds_Exception()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(200, 26, 46));
    }

    [Fact]
    public void Ctor_NegativeInvalidDegreesMinutesSeconds_Exception()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Longitude(-200, 26, 46));
    }

    #endregion

    #region Ctor() Valid Values

    [Fact]
    public void Ctor_Degrees()
    {
        var longitude = new Longitude(-79.98222);
        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesMinutes()
    {
        var longitude = new Longitude(-79, 58.933);
        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesMinutesSeconds()
    {
        var longitude = new Longitude(-79, 58, 56);
        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesDirection()
    {
        var longitude = new Longitude(79.9822166667, Direction.W);
        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesMinutesDirection()
    {
        var longitude = new Longitude(79, 58.933, Direction.W);
        this.AssertCoordinateData(longitude);
    }

    [Fact]
    public void Ctor_DegreesMinutesSecondsDirection()
    {
        var longitude = new Longitude(79, 58, 56, Direction.W);
        this.AssertCoordinateData(longitude);
    }

    #endregion

    private void AssertCoordinateData(Longitude longitude)
    {
        //Assert.AreEqual(-79.9822166667m, longitude.DecimalDegreesSigned);
        Assert.Equal(79, longitude.Degrees);
        Assert.Equal(-79, longitude.DegreesSigned);
        Assert.Equal(58.933, longitude.DecimalMinutes);
        Assert.Equal(58, longitude.Minutes);
        Assert.Equal(56, longitude.Seconds);
        Assert.Equal(Direction.W, longitude.Direction);
    }
}
