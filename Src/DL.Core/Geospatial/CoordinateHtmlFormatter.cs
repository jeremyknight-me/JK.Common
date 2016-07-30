namespace DL.Core.Geospatial
{
    public class CoordinateHtmlFormatter : CoordinateFormatterBase
    {
        public CoordinateHtmlFormatter(CoordinateBase coordinateToUse)
            : base(coordinateToUse)
        {
        }

        protected override string ToStringDegrees()
        {
            return string.Format("{0:###.#####;-###.#####}&deg;",
                this.Coordinate.CoordinateSigned);
        }

        protected override string ToStringDegreesMinutes()
        {
            return string.Format("{0:###;-###}&deg; {1:##.###}'",
                this.Coordinate.DegreesSigned,
                this.Coordinate.DecimalMinutes);
        }

        protected override string ToStringDegreesMinutesSeconds()
        {
            return string.Format("{0:###;-###}&deg; {1:##}' {2:##.#}\"",
                this.Coordinate.DegreesSigned,
                this.Coordinate.Minutes,
                this.Coordinate.Seconds);
        }

        protected override string ToStringDegreesDirection()
        {
            return string.Format("{0:###.#####;###.#####}&deg; {1}",
                this.Coordinate.CoordinateSigned,
                this.Coordinate.Direction);
        }

        protected override string ToStringDegreesMinutesDirection()
        {
            return string.Format("{0:###;###}&deg; {1:##.###}' {2}",
                this.Coordinate.DegreesSigned,
                this.Coordinate.DecimalMinutes,
                this.Coordinate.Direction);
        }

        protected override string ToStringDegreesMinutesSecondsDirection()
        {
            return string.Format("{0:###;###}&deg; {1:##}' {2:##.#}\" {3}",
                this.Coordinate.DegreesSigned,
                this.Coordinate.Minutes,
                this.Coordinate.Seconds,
                this.Coordinate.Direction);
        }
    }
}
