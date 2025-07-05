namespace JK.Common.Geospatial;

public sealed class CoordinateTextFormatter : CoordinateFormatterBase
{
    public CoordinateTextFormatter(CoordinateBase coordinateToUse)
        : base(coordinateToUse)
    {
    }

    protected override string ToStringDegrees()
        => $"{Coordinate.CoordinateSigned:###.#####;-###.#####}\u00B0";

    protected override string ToStringDegreesMinutes()
        => $"{Coordinate.DegreesSigned:###;-###}\u00B0 {Coordinate.DecimalMinutes:##.###}'";

    protected override string ToStringDegreesMinutesSeconds()
        => $"{Coordinate.DegreesSigned:###;-###}\u00B0 {Coordinate.Minutes:##}' {Coordinate.Seconds:##.#}\"";

    protected override string ToStringDegreesDirection()
        => $"{Coordinate.CoordinateSigned:###.#####;###.#####}\u00B0 {Coordinate.Direction}";

    protected override string ToStringDegreesMinutesDirection()
        => $"{Coordinate.DegreesSigned:###;###}\u00B0 {Coordinate.DecimalMinutes:##.###}' {Coordinate.Direction}";

    protected override string ToStringDegreesMinutesSecondsDirection()
        => $"{Coordinate.DegreesSigned:###;###}\u00B0 {Coordinate.Minutes:##}' {Coordinate.Seconds:##.#}\" {Coordinate.Direction}";
}
