using DL.Core.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Tests.Math
{
    [TestClass]
    public class TemperatureConverterTests
    {
        [TestMethod]
        public void ConvertFahrenheitToCelsiusTest()
        {
            double fahrenheitTemperature = 212; 
            double expected = 100; 
            double actual = TemperatureConverter.ConvertFahrenheitToCelsius(fahrenheitTemperature);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertCelsiusToFahrenheitTest()
        {
            double celsiusTemperature = 100;
            double expected = 212;
            double actual = TemperatureConverter.ConvertCelsiusToFahrenheit(celsiusTemperature);
            Assert.AreEqual(expected, actual);
        }
    }
}
