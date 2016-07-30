using System;
using DL.Core.Geospatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Geospatial
{
    [TestClass]
    public class LongitudeTests
    {
        /*
            degrees minutes seconds: 79° 58′ 56″ W
            degrees decimal minutes: 79° 58.933′ W
            decimal degrees: 79.982° W
            decimal: -79.982
         */

        #region SetDegrees() Invalid Values

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_InvalidDegrees_Exception()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(200m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_NegativeInvalidDegrees_Exception()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(-200m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_InvalidDegreesMinutes_Exception()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(200, 26.767m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_NegativeInvalidDegreesMinutes_Exception()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(-200, 26.767m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_InvalidDegreesMinutesSeconds_Exception()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(200, 26, 46);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetDegrees_NegativeInvalidDegreesMinutesSeconds_Exception()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(-200, 26, 46);
        }

        #endregion

        #region SetDegrees() Valid Values

        [TestMethod]
        public void SetDegrees_Degrees()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(-79.98222m);

            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesMinutes()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(-79, 58.933m);

            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesMinutesSeconds()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(-79, 58, 56);

            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesDirection()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(79.98222m, Direction.W);

            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesMinutesDirection()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(79, 58.933m, Direction.W);

            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void SetDegrees_DegreesMinutesSecondsDirection()
        {
            var longitude = new Longitude();
            longitude.SetCoordinate(79, 58, 56, Direction.W);

            this.AssertCoordinateData(longitude);
        }

        #endregion

        #region Ctor() Invalid Values

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_InvalidDegrees_Exception()
        {
            var longitude = new Longitude(200m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_NegativeInvalidDegrees_Exception()
        {
            var longitude = new Longitude(-200m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_InvalidDegreesMinutes_Exception()
        {
            var longitude = new Longitude(200, 26.767m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_NegativeInvalidDegreesMinutes_Exception()
        {
            var longitude = new Longitude(-200, 26.767m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_InvalidDegreesMinutesSeconds_Exception()
        {
            var longitude = new Longitude(200, 26, 46);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctor_NegativeInvalidDegreesMinutesSeconds_Exception()
        {
            var longitude = new Longitude(-200, 26, 46);
        }

        #endregion

        #region Ctor() Valid Values

        [TestMethod]
        public void Ctor_Degrees()
        {
            var longitude = new Longitude(-79.98222m);
            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void Ctor_DegreesMinutes()
        {
            var longitude = new Longitude(-79, 58.933m);
            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void Ctor_DegreesMinutesSeconds()
        {
            var longitude = new Longitude(-79, 58, 56);
            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void Ctor_DegreesDirection()
        {
            var longitude = new Longitude(79.98222m, Direction.W);
            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void Ctor_DegreesMinutesDirection()
        {
            var longitude = new Longitude(79, 58.933m, Direction.W);
            this.AssertCoordinateData(longitude);
        }

        [TestMethod]
        public void Ctor_DegreesMinutesSecondsDirection()
        {
            var longitude = new Longitude(79, 58, 56, Direction.W);
            this.AssertCoordinateData(longitude);
        }

        #endregion

        private void AssertCoordinateData(Longitude longitude)
        {
            Assert.AreEqual(-79.98222m, longitude.DecimalDegreesSigned);
            Assert.AreEqual(79, longitude.Degrees);
            Assert.AreEqual(-79, longitude.DegreesSigned);
            Assert.AreEqual(58.933m, longitude.DecimalMinutes);
            Assert.AreEqual(58, longitude.Minutes);
            Assert.AreEqual(56, longitude.Seconds);
            Assert.AreEqual(Direction.W, longitude.Direction);
        }
    }
}
