﻿namespace JK.Common.Converters;

/// <summary>
/// Class which contains time conversion logic.
/// </summary>
public static class TimeConverter
{
    /// <summary>
    /// Converts hours to minutes.
    /// </summary>
    /// <param name="hours">Number of hours to convert.</param>
    /// <returns>Number of minutes in the given number of hours.</returns>
    public static int ConvertHoursToMinutes(in int hours) => checked(hours * 60);

    /// <summary>
    /// Converts minutes to seconds.
    /// </summary>
    /// <param name="minutes">Number of minutes to convert.</param>
    /// <returns>Number of seconds in the given number of minutes.</returns>
    public static int ConvertMinutesToSeconds(in int minutes) => checked(minutes * 60);

    /// <summary>
    /// Converts seconds to milliseconds.
    /// </summary>
    /// <param name="seconds">Number of seconds to convert.</param>
    /// <returns>Number of milliseconds in the given number of seconds.</returns>
    public static int ConvertSecondsToMilliseconds(in int seconds) => checked(seconds * 1000);

    /// <summary>
    /// Converts hours to milliseconds.
    /// </summary>
    /// <param name="hours">Number of hours to convert.</param>
    /// <returns>Number of milliseconds in the given number of hours.</returns>
    public static int ConvertHoursToMilliseconds(in int hours)
    {
        var minutes = ConvertHoursToMinutes(hours);
        return ConvertMinutesToMilliseconds(minutes);
    }

    /// <summary>
    /// Converts minutes to milliseconds.
    /// </summary>
    /// <param name="minutes">Number of minutes to convert.</param>
    /// <returns>Number of milliseconds in the given number of minutes.</returns>
    public static int ConvertMinutesToMilliseconds(in int minutes)
    {
        var seconds = ConvertMinutesToSeconds(minutes);
        return ConvertSecondsToMilliseconds(seconds);
    }
}
