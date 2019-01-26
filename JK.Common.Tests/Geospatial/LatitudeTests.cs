using System;
using JK.Common.Geospatial;
using Xunit;

namespace JK.Common.Tests.Geospatial
{
    public class LatitudeTests
    {
        /*
            degrees minutes seconds: 40° 26′ 46″ N 
            degrees decimal minutes: 40° 26.772′ N 
            decimal degrees: 40.4461111111° N
            decimal: 40.4461111111°
         */

        #region SetDegrees() Invalid Values

        [Theory]
        [InlineData(100)]
        [InlineData(-100)]
        public void SetDegrees_InvalidDegrees_Exception(decimal degrees)
        {
            var latitude = new Latitude();
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => latitude.SetCoordinate(degrees));
        }

        [Theory]
        [InlineData(100, 26.767)]
        [InlineData(-100, 26.767)]
        public void SetDegrees_InvalidDegreesMinutes_Exception(decimal degrees, decimal minutes)
        {
            var latitude = new Latitude();
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => latitude.SetCoordinate(degrees, minutes));
        }

        [Fact]
        public void SetDegrees_InvalidDegreesMinutesSeconds_Exception()
        {
            var latitude = new Latitude();
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => latitude.SetCoordinate(100, 26, 46));
        }

        [Fact]
        public void SetDegrees_NegativeInvalidDegreesMinutesSeconds_Exception()
        {
            var latitude = new Latitude();
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => latitude.SetCoordinate(-100, 26, 46));
        }

        #endregion

        #region SetDegrees() Valid Values

        [Fact]
        public void SetDegrees_Degrees()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40.446113m);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void SetDegrees_DegreesMinutes()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40, 26.767m);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void SetDegrees_DegreesMinutesSeconds()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40, 26, 46);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void SetDegrees_DegreesDirection()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40.4461111111m, Direction.N);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void SetDegrees_DegreesMinutesDirection()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40, 26.767m, Direction.N);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void SetDegrees_DegreesMinutesSecondsDirection()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40, 26, 46, Direction.N);
            this.AssertCoordinateData(latitude);
        }

        #endregion

        #region Ctor() Invalid Values

        [Fact]
        public void Ctor_InvalidDegrees_Exception()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(100m));
        }

        [Fact]
        public void Ctor_NegativeInvalidDegrees_Exception()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(-100m));
        }

        [Fact]
        public void Ctor_InvalidDegreesMinutes_Exception()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(100, 26.767m));
        }

        [Fact]
        public void Ctor_NegativeInvalidDegreesMinutes_Exception()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(-100, 26.767m));
        }

        [Fact]
        public void Ctor_InvalidDegreesMinutesSeconds_Exception()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(100, 26, 46));
        }

        [Fact]
        public void Ctor_NegativeInvalidDegreesMinutesSeconds_Exception()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Latitude(-100, 26, 46));
        }

        #endregion

        #region Ctor() Valid Values

        [Fact]
        public void Ctor_Degrees()
        {
            var latitude = new Latitude(40.446113m);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void Ctor_DegreesMinutes()
        {
            var latitude = new Latitude(40, 26.767m);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void Ctor_DegreesMinutesSeconds()
        {
            var latitude = new Latitude(40, 26, 46);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void Ctor_DegreesDirection()
        {
            var latitude = new Latitude(40.446113m, Direction.N);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void Ctor_DegreesMinutesDirection()
        {
            var latitude = new Latitude(40, 26.767m, Direction.N);
            this.AssertCoordinateData(latitude);
        }

        [Fact]
        public void Ctor_DegreesMinutesSecondsDirection()
        {
            var latitude = new Latitude(40, 26, 46, Direction.N);
            this.AssertCoordinateData(latitude);
        }

        #endregion

        private void AssertCoordinateData(Latitude latitude)
        {
            //Assert.AreEqual(40.4461111111m, latitude.DecimalDegreesSigned);
            Assert.Equal(40, latitude.Degrees);
            Assert.Equal(40, latitude.DegreesSigned);
            Assert.Equal(26.767m, latitude.DecimalMinutes);
            Assert.Equal(26, latitude.Minutes);
            Assert.Equal(46, latitude.Seconds);
            Assert.Equal(Direction.N, latitude.Direction);
        }
    }
}
