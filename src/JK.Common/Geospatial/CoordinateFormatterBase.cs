using System;
using System.Collections.Generic;

namespace JK.Common.Geospatial;

public abstract class CoordinateFormatterBase
{
    private readonly Dictionary<DisplayFormat, Func<string>> _displayFormatStrategies;

    protected CoordinateFormatterBase(CoordinateBase coordinateToUse)
    {
        Coordinate = coordinateToUse;
        _displayFormatStrategies = [];
        DefineDisplayFormatStrategies();
    }

    protected CoordinateBase Coordinate { get; set; }

    public string Format(in DisplayFormat format)
        => _displayFormatStrategies.TryGetValue(format, out Func<string> strategy)
            ? strategy()
            : string.Empty;

    protected abstract string ToStringDegrees();

    protected abstract string ToStringDegreesMinutes();

    protected abstract string ToStringDegreesMinutesSeconds();

    protected abstract string ToStringDegreesDirection();

    protected abstract string ToStringDegreesMinutesDirection();

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
