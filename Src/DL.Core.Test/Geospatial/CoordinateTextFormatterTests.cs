using DL.Core.Geospatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Geospatial
{
    [TestClass]
    public class CoordinateTextFormatterTests
    {
        private CoordinateTextFormatter positiveFormatter;

        private CoordinateTextFormatter negativeFormatter;

        [TestInitialize]
        public void TestInitialize()
        {
            var positiveCoordinate = new Latitude(40, 26, 46);
            this.positiveFormatter = new CoordinateTextFormatter(positiveCoordinate);

            var negativeCoordinate = new Longitude(-79, 58, 56);
            this.negativeFormatter = new CoordinateTextFormatter(negativeCoordinate);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.positiveFormatter = null;
            this.negativeFormatter = null;
        }

        #region Format() Positive Coordinate Values

        [TestMethod]
        public void Format_PositiveDegrees()
        {
            string actual = this.positiveFormatter.Format(DisplayFormat.Degrees);
            Assert.AreEqual("40.44611\u00B0", actual);
        }

        [TestMethod]
        public void Format_PositiveDegreesMinutes()
        {
            string actual = this.positiveFormatter.Format(DisplayFormat.DegreesMinutes);
            Assert.AreEqual("40\u00B0 26.767'", actual);
        }

        [TestMethod]
        public void Format_PositiveDegreesMinutesSeconds()
        {
            string actual = this.positiveFormatter.Format(DisplayFormat.DegreesMinutesSeconds);
            Assert.AreEqual("40\u00B0 26' 46\"", actual);
        }

        [TestMethod]
        public void Format_PositiveDegreesDirection()
        {
            string actual = this.positiveFormatter.Format(DisplayFormat.DegreesDirection);
            Assert.AreEqual("40.44611\u00B0 N", actual);
        }

        [TestMethod]
        public void Format_PositiveDegreesMinutesDirection()
        {
            string actual = this.positiveFormatter.Format(DisplayFormat.DegreesMinutesDirection);
            Assert.AreEqual("40\u00B0 26.767' N", actual);
        }

        [TestMethod]
        public void Format_PositiveDegreesMinutesSecondsDirection()
        {
            string actual = this.positiveFormatter.Format(DisplayFormat.DegreesMinutesSecondsDirection);
            Assert.AreEqual("40\u00B0 26' 46\" N", actual);
        }

        #endregion

        #region Format() Negative Coordinate Values

        [TestMethod]
        public void Format_NegativeDegrees()
        {
            string actual = this.negativeFormatter.Format(DisplayFormat.Degrees);
            Assert.AreEqual("-79.98222\u00B0", actual);
        }

        [TestMethod]
        public void Format_NegativeDegreesMinutes()
        {
            string actual = this.negativeFormatter.Format(DisplayFormat.DegreesMinutes);
            Assert.AreEqual("-79\u00B0 58.933'", actual);
        }

        [TestMethod]
        public void Format_NegativeDegreesMinutesSeconds()
        {
            string actual = this.negativeFormatter.Format(DisplayFormat.DegreesMinutesSeconds);
            Assert.AreEqual("-79\u00B0 58' 56\"", actual);
        }

        [TestMethod]
        public void Format_NegativeDegreesDirection()
        {
            string actual = this.negativeFormatter.Format(DisplayFormat.DegreesDirection);
            Assert.AreEqual("79.98222\u00B0 W", actual);
        }

        [TestMethod]
        public void Format_NegativeDegreesMinutesDirection()
        {
            string actual = this.negativeFormatter.Format(DisplayFormat.DegreesMinutesDirection);
            Assert.AreEqual("79\u00B0 58.933' W", actual);
        }

        [TestMethod]
        public void Format_NegativeDegreesMinutesSecondsDirection()
        {
            string actual = this.negativeFormatter.Format(DisplayFormat.DegreesMinutesSecondsDirection);
            Assert.AreEqual("79\u00B0 58' 56\" W", actual);
        }

        #endregion
    }
}
