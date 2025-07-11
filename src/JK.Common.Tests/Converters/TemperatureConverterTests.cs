﻿using JK.Common.Converters;

namespace JK.Common.Tests.Converters;

public class TemperatureConverterTests
{
    [Fact]
    public void ConvertFahrenheitToCelsiusTest()
    {
        double fahrenheitTemperature = 212;
        double expected = 100;
        var actual = TemperatureConverter.ConvertFahrenheitToCelsius(fahrenheitTemperature);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertCelsiusToFahrenheitTest()
    {
        double celsiusTemperature = 100;
        double expected = 212;
        var actual = TemperatureConverter.ConvertCelsiusToFahrenheit(celsiusTemperature);
        Assert.Equal(expected, actual);
    }
}
