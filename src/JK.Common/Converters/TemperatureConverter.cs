namespace JK.Common.Converters;

/// <summary>
/// Class which contains temperature conversion logic.
/// </summary>
public static class TemperatureConverter
{
    /// <summary>
    /// Converts Celsius temperature to Fahrenheit temperature.
    /// </summary>
    /// <param name="celsiusTemperature">Celsius temperature to convert.</param>
    /// <returns>Converted Fahrenheit temperature.</returns>
    public static double ConvertCelsiusToFahrenheit(in double celsiusTemperature)
        => (celsiusTemperature * 9 / 5) + 32;

    /// <summary>
    /// Converts Fahrenheit temperature to Celsius temperature.
    /// </summary>
    /// <param name="fahrenheitTemperature">Fahrenheit temperature to convert.</param>
    /// <returns>Converted Celsius temperature.</returns>
    public static double ConvertFahrenheitToCelsius(in double fahrenheitTemperature)
        => (fahrenheitTemperature - 32) * 5 / 9;
}
