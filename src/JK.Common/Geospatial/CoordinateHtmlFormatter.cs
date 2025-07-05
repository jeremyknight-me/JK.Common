namespace JK.Common.Geospatial;

public sealed class CoordinateHtmlFormatter : CoordinateFormatterBase
{
    public CoordinateHtmlFormatter(CoordinateBase coordinateToUse)
        : base(coordinateToUse)
    {
    }

    protected override string ToStringDegrees()
        => $"{Coordinate.CoordinateSigned:###.#####;-###.#####}&deg;";

    protected override string ToStringDegreesMinutes()
        => $"{Coordinate.DegreesSigned:###;-###}&deg; {Coordinate.DecimalMinutes:##.###}'";

    protected override string ToStringDegreesMinutesSeconds()
        => $"{Coordinate.DegreesSigned:###;-###}&deg; {Coordinate.Minutes:##}' {Coordinate.Seconds:##.#}\"";

    protected override string ToStringDegreesDirection()
        => $"{Coordinate.CoordinateSigned:###.#####;###.#####}&deg; {Coordinate.Direction}";

    protected override string ToStringDegreesMinutesDirection()
        => $"{Coordinate.DegreesSigned:###;###}&deg; {Coordinate.DecimalMinutes:##.###}' {Coordinate.Direction}";

    protected override string ToStringDegreesMinutesSecondsDirection()
        => $"{Coordinate.DegreesSigned:###;###}&deg; {Coordinate.Minutes:##}' {Coordinate.Seconds:##.#}\" {Coordinate.Direction}";
}
