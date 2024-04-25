using System;
using System.Collections.Generic;

namespace JK.Common.Geospatial;

public abstract class CoordinateFormatterBase
{
    private readonly Dictionary<DisplayFormat, Func<string>> displayFormatStrategies;

    protected CoordinateFormatterBase(CoordinateBase coordinateToUse)
    {
        this.Coordinate = coordinateToUse;
        this.displayFormatStrategies = [];
        this.DefineDisplayFormatStrategies();
    }

    protected CoordinateBase Coordinate { get; set; }

    public string Format(in DisplayFormat format)
        => this.displayFormatStrategies.TryGetValue(format, out var strategy)
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
        this.displayFormatStrategies.Add(DisplayFormat.Degrees, this.ToStringDegrees);
        this.displayFormatStrategies.Add(DisplayFormat.DegreesMinutes, this.ToStringDegreesMinutes);
        this.displayFormatStrategies.Add(DisplayFormat.DegreesMinutesSeconds, this.ToStringDegreesMinutesSeconds);
        this.displayFormatStrategies.Add(DisplayFormat.DegreesDirection, this.ToStringDegreesDirection);
        this.displayFormatStrategies.Add(DisplayFormat.DegreesMinutesDirection, this.ToStringDegreesMinutesDirection);
        this.displayFormatStrategies.Add(DisplayFormat.DegreesMinutesSecondsDirection, this.ToStringDegreesMinutesSecondsDirection);
    }
}
