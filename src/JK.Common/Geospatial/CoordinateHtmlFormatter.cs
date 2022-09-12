namespace JK.Common.Geospatial;

public sealed class CoordinateHtmlFormatter : CoordinateFormatterBase
{
    public CoordinateHtmlFormatter(CoordinateBase coordinateToUse)
        : base(coordinateToUse)
    {
    }

    protected override string ToStringDegrees()
        => $"{this.Coordinate.CoordinateSigned:###.#####;-###.#####}&deg;";

    protected override string ToStringDegreesMinutes()
        => $"{this.Coordinate.DegreesSigned:###;-###}&deg; {this.Coordinate.DecimalMinutes:##.###}'";

    protected override string ToStringDegreesMinutesSeconds()
        => $"{this.Coordinate.DegreesSigned:###;-###}&deg; {this.Coordinate.Minutes:##}' {this.Coordinate.Seconds:##.#}\"";

    protected override string ToStringDegreesDirection()
        => $"{this.Coordinate.CoordinateSigned:###.#####;###.#####}&deg; {this.Coordinate.Direction}";

    protected override string ToStringDegreesMinutesDirection()
        => $"{this.Coordinate.DegreesSigned:###;###}&deg; {this.Coordinate.DecimalMinutes:##.###}' {this.Coordinate.Direction}";

    protected override string ToStringDegreesMinutesSecondsDirection()
        => $"{this.Coordinate.DegreesSigned:###;###}&deg; {this.Coordinate.Minutes:##}' {this.Coordinate.Seconds:##.#}\" {this.Coordinate.Direction}";
}
