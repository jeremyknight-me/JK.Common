using DL.Common.Math;
using Xunit;

namespace DL.Common.Tests.Math
{
    public class TemperatureConverterTests
    {
        [Fact]
        public void ConvertFahrenheitToCelsiusTest()
        {
            double fahrenheitTemperature = 212; 
            double expected = 100; 
            double actual = TemperatureConverter.ConvertFahrenheitToCelsius(fahrenheitTemperature);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertCelsiusToFahrenheitTest()
        {
            double celsiusTemperature = 100;
            double expected = 212;
            double actual = TemperatureConverter.ConvertCelsiusToFahrenheit(celsiusTemperature);
            Assert.Equal(expected, actual);
        }
    }
}
