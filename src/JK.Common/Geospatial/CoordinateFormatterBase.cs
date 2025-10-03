using System;
using System.Collections.Generic;

namespace JK.Common.Geospatial;

/// <summary>
/// Base class for formatting coordinates in various display formats.
/// </summary>
public abstract class CoordinateFormatterBase
{
    private readonly Dictionary<DisplayFormat, Func<string>> _displayFormatStrategies;

    /// <summary>
    /// Gets or sets the coordinate to format.
    /// </summary>
    protected CoordinateBase Coordinate { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinateFormatterBase"/> class.
    /// </summary>
    /// <param name="coordinateToUse">The coordinate to format.</param>
    protected CoordinateFormatterBase(CoordinateBase coordinateToUse)
    {
        Coordinate = coordinateToUse;
        _displayFormatStrategies = [];
        DefineDisplayFormatStrategies();
    }

    /// <summary>
    /// Formats the coordinate using the specified display format.
    /// </summary>
    /// <param name="format">The display format to use.</param>
    /// <returns>The formatted coordinate string.</returns>
    public string Format(in DisplayFormat format)
        => _displayFormatStrategies.TryGetValue(format, out Func<string> strategy)
            ? strategy()
            : string.Empty;

    /// <summary>
    /// Returns the coordinate as a string in degrees format.
    /// </summary>
    /// <returns>The coordinate in degrees format.</returns>
    protected abstract string ToStringDegrees();

    /// <summary>
    /// Returns the coordinate as a string in degrees and minutes format.
    /// </summary>
    /// <returns>The coordinate in degrees and minutes format.</returns>
    protected abstract string ToStringDegreesMinutes();

    /// <summary>
    /// Returns the coordinate as a string in degrees, minutes, and seconds format.
    /// </summary>
    /// <returns>The coordinate in degrees, minutes, and seconds format.</returns>
    protected abstract string ToStringDegreesMinutesSeconds();

    /// <summary>
    /// Returns the coordinate as a string in degrees and direction format.
    /// </summary>
    /// <returns>The coordinate in degrees and direction format.</returns>
    protected abstract string ToStringDegreesDirection();

    /// <summary>
    /// Returns the coordinate as a string in degrees, minutes, and direction format.
    /// </summary>
    /// <returns>The coordinate in degrees, minutes, and direction format.</returns>
    protected abstract string ToStringDegreesMinutesDirection();

    /// <summary>
    /// Returns the coordinate as a string in degrees, minutes, seconds, and direction format.
    /// </summary>
    /// <returns>The coordinate in degrees, minutes, seconds, and direction format.</returns>
    protected abstract string ToStringDegreesMinutesSecondsDirection();

    private void DefineDisplayFormatStrategies()
    {
        _displayFormatStrategies.Add(DisplayFormat.Degrees, ToStringDegrees);
        _displayFormatStrategies.Add(DisplayFormat.DegreesMinutes, ToStringDegreesMinutes);
        _displayFormatStrategies.Add(DisplayFormat.DegreesMinutesSeconds, ToStringDegreesMinutesSeconds);
        _displayFormatStrategies.Add(DisplayFormat.DegreesDirection, ToStringDegreesDirection);
        _displayFormatStrategies.Add(DisplayFormat.DegreesMinutesDirection, ToStringDegreesMinutesDirection);
        _displayFormatStrategies.Add(DisplayFormat.DegreesMinutesSecondsDirection, ToStringDegreesMinutesSecondsDirection);
    }
}
