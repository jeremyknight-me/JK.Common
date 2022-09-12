namespace JK.Common.Geospatial;

public sealed class CoordinateTextFormatter : CoordinateFormatterBase
{
    public CoordinateTextFormatter(CoordinateBase coordinateToUse)
        : base(coordinateToUse)
    {
    }

    protected override string ToStringDegrees()
        => $"{this.Coordinate.CoordinateSigned:###.#####;-###.#####}\u00B0";

    protected override string ToStringDegreesMinutes()
        => $"{this.Coordinate.DegreesSigned:###;-###}\u00B0 {this.Coordinate.DecimalMinutes:##.###}'";

    protected override string ToStringDegreesMinutesSeconds()
        => $"{this.Coordinate.DegreesSigned:###;-###}\u00B0 {this.Coordinate.Minutes:##}' {this.Coordinate.Seconds:##.#}\"";

    protected override string ToStringDegreesDirection()
        => $"{this.Coordinate.CoordinateSigned:###.#####;###.#####}\u00B0 {this.Coordinate.Direction}";

    protected override string ToStringDegreesMinutesDirection()
        => $"{this.Coordinate.DegreesSigned:###;###}\u00B0 {this.Coordinate.DecimalMinutes:##.###}' {this.Coordinate.Direction}";

    protected override string ToStringDegreesMinutesSecondsDirection()
        => $"{this.Coordinate.DegreesSigned:###;###}\u00B0 {this.Coordinate.Minutes:##}' {this.Coordinate.Seconds:##.#}\" {this.Coordinate.Direction}";
}
