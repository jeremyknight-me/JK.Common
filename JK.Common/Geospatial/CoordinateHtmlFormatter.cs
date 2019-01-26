namespace JK.Common.Geospatial
{
    public class CoordinateHtmlFormatter : CoordinateFormatterBase
    {
        public CoordinateHtmlFormatter(CoordinateBase coordinateToUse)
            : base(coordinateToUse)
        {
        }

        protected override string ToStringDegrees()
        {
            return $"{this.Coordinate.CoordinateSigned:###.#####;-###.#####}&deg;";
        }

        protected override string ToStringDegreesMinutes()
        {
            return $"{this.Coordinate.DegreesSigned:###;-###}&deg; {this.Coordinate.DecimalMinutes:##.###}'";
        }

        protected override string ToStringDegreesMinutesSeconds()
        {
            return $"{this.Coordinate.DegreesSigned:###;-###}&deg; {this.Coordinate.Minutes:##}' {this.Coordinate.Seconds:##.#}\"";
        }

        protected override string ToStringDegreesDirection()
        {
            return $"{this.Coordinate.CoordinateSigned:###.#####;###.#####}&deg; {this.Coordinate.Direction}";
        }

        protected override string ToStringDegreesMinutesDirection()
        {
            return $"{this.Coordinate.DegreesSigned:###;###}&deg; {this.Coordinate.DecimalMinutes:##.###}' {this.Coordinate.Direction}";
        }

        protected override string ToStringDegreesMinutesSecondsDirection()
        {
            return $"{this.Coordinate.DegreesSigned:###;###}&deg; {this.Coordinate.Minutes:##}' {this.Coordinate.Seconds:##.#}\" {this.Coordinate.Direction}";
        }
    }
}
