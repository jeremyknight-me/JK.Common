namespace DL.Common.Geospatial
{
    public class CoordinateTextFormatter : CoordinateFormatterBase
    {
        public CoordinateTextFormatter(CoordinateBase coordinateToUse)
            : base(coordinateToUse)
        {
        }

        protected override string ToStringDegrees()
        {
            return $"{this.Coordinate.CoordinateSigned:###.#####;-###.#####}\u00B0";
        }

        protected override string ToStringDegreesMinutes()
        {
            return $"{this.Coordinate.DegreesSigned:###;-###}\u00B0 {this.Coordinate.DecimalMinutes:##.###}'";
        }

        protected override string ToStringDegreesMinutesSeconds()
        {
            return $"{this.Coordinate.DegreesSigned:###;-###}\u00B0 {this.Coordinate.Minutes:##}' {this.Coordinate.Seconds:##.#}\"";
        }

        protected override string ToStringDegreesDirection()
        {
            return $"{this.Coordinate.CoordinateSigned:###.#####;###.#####}\u00B0 {this.Coordinate.Direction}";
        }

        protected override string ToStringDegreesMinutesDirection()
        {
            return $"{this.Coordinate.DegreesSigned:###;###}\u00B0 {this.Coordinate.DecimalMinutes:##.###}' {this.Coordinate.Direction}";
        }

        protected override string ToStringDegreesMinutesSecondsDirection()
        {
            return $"{this.Coordinate.DegreesSigned:###;###}\u00B0 {this.Coordinate.Minutes:##}' {this.Coordinate.Seconds:##.#}\" {this.Coordinate.Direction}";
        }
    }
}
