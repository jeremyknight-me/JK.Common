using DL.Core.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Tests.Math
{
    [TestClass]
    public class TimeConverterTests
    {
        [TestMethod]
        public void ConvertSecondsToMillesecondsTest()
        {
            int seconds = 1; 
            int expected = 1000; 
            int actual = TimeConverter.ConvertSecondsToMilliseconds(seconds);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertMinutesToSecondsTest()
        {
            int minutes = 1; 
            int expected = 60; 
            int actual = TimeConverter.ConvertMinutesToSeconds(minutes);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertMinutesToMillesecondsTest()
        {
            int minutes = 1; 
            int expected = 60000; 
            int actual = TimeConverter.ConvertMinutesToMilliseconds(minutes);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertHoursToMillesecondsTest()
        {
            int hours = 1;
            int expected = 3600000; 
            int actual = TimeConverter.ConvertHoursToMilliseconds(hours);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertHoursToMinutesTest()
        {
            int hours = 1; 
            int expected = 60; 
            int actual = TimeConverter.ConvertHoursToMinutes(hours);
            Assert.AreEqual(expected, actual);
        }
    }
}
