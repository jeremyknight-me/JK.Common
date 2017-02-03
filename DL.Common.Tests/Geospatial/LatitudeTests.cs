using System;
using DL.Common.Geospatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Geospatial
{
    [TestClass]
    public class LatitudeTests
    {
        /*
            degrees minutes seconds: 40° 26′ 46″ N 
            degrees decimal minutes: 40° 26.772′ N 
            decimal degrees: 40.4461111111° N
            decimal: 40.4461111111°
         */

        #region SetDegrees() Invalid Values

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_InvalidDegrees_Exception()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(100m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_NegativeInvalidDegrees_Exception()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(-100m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_InvalidDegreesMinutes_Exception()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(100, 26.767m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_NegativeInvalidDegreesMinutes_Exception()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(-100, 26.767m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_InvalidDegreesMinutesSeconds_Exception()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(100, 26, 46);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_NegativeInvalidDegreesMinutesSeconds_Exception()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(-100, 26, 46);
        }

        #endregion

        #region SetDegrees() Valid Values

        [TestMethod]
        public void SetDegrees_Degrees()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40.446113m);

            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesMinutes()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40, 26.767m);

            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesMinutesSeconds()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40, 26, 46);

            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesDirection()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40.4461111111m, Direction.N);

            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesMinutesDirection()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40, 26.767m, Direction.N);

            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesMinutesSecondsDirection()
        {
            var latitude = new Latitude();
            latitude.SetCoordinate(40, 26, 46, Direction.N);

            this.AssertCoordinateData(latitude);
        }

        #endregion

        #region Ctor() Invalid Values

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_InvalidDegrees_Exception()
        {
            var latitude = new Latitude(100m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_NegativeInvalidDegrees_Exception()
        {
            var latitude = new Latitude(-100m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_InvalidDegreesMinutes_Exception()
        {
            var latitude = new Latitude(100, 26.767m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_NegativeInvalidDegreesMinutes_Exception()
        {
            var latitude = new Latitude(-100, 26.767m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_InvalidDegreesMinutesSeconds_Exception()
        {
            var latitude = new Latitude(100, 26, 46);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_NegativeInvalidDegreesMinutesSeconds_Exception()
        {
            var latitude = new Latitude(-100, 26, 46);
        }

        #endregion

        #region Ctor() Valid Values

        [TestMethod]
        public void Ctor_Degrees()
        {
            var latitude = new Latitude(40.446113m);
            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void Ctor_DegreesMinutes()
        {
            var latitude = new Latitude(40, 26.767m);
            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void Ctor_DegreesMinutesSeconds()
        {
            var latitude = new Latitude(40, 26, 46);
            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void Ctor_DegreesDirection()
        {
            var latitude = new Latitude(40.446113m, Direction.N);
            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void Ctor_DegreesMinutesDirection()
        {
            var latitude = new Latitude(40, 26.767m, Direction.N);
            this.AssertCoordinateData(latitude);
        }

        [TestMethod]
        public void Ctor_DegreesMinutesSecondsDirection()
        {
            var latitude = new Latitude(40, 26, 46, Direction.N);
            this.AssertCoordinateData(latitude);
        }

        #endregion

        private void AssertCoordinateData(Latitude latitude)
        {
            //Assert.AreEqual(40.4461111111m, latitude.DecimalDegreesSigned);
            Assert.AreEqual(40, latitude.Degrees);
            Assert.AreEqual(40, latitude.DegreesSigned);
            Assert.AreEqual(26.767m, latitude.DecimalMinutes);
            Assert.AreEqual(26, latitude.Minutes);
            Assert.AreEqual(46, latitude.Seconds);
            Assert.AreEqual(Direction.N, latitude.Direction);
        }
    }
}
