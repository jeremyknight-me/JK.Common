using System;
using System.Collections.Generic;
using DL.Core.SpecificationPattern;

namespace DL.Core.Geospatial
{
    /// <summary>Base object for latitudes and longitudes coordinates.</summary>
    public abstract class CoordinateBase
    {
        #region Constructors

        protected CoordinateBase()
        {
        }

        protected CoordinateBase(decimal degrees) 
            : this()
        {
            this.SetCoordinate(degrees);
        }

        protected CoordinateBase(decimal degrees, decimal minutes)
            : this()
        {
            this.SetCoordinate(degrees, minutes);
        }

        protected CoordinateBase(decimal degrees, decimal minutes, decimal seconds)
            : this()
        {
            this.SetCoordinate(degrees, minutes, seconds);
        }

        protected CoordinateBase(decimal degrees, Direction direction)
            : this()
        {
            this.SetCoordinate(degrees, direction);
        }

        protected CoordinateBase(decimal degrees, decimal minutes, Direction direction)
            : this()
        {
            this.SetCoordinate(degrees, minutes, direction);
        }

        protected CoordinateBase(decimal degrees, decimal minutes, decimal seconds, Direction direction)
            : this()
        {
            this.SetCoordinate(degrees, minutes, seconds, direction);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets whether the coordinate represents positive or negative point.
        /// </summary>
        public bool IsNegative { get; protected set; }

        /// <summary>
        /// Gets or sets the absolute value of the coordinate.
        /// </summary>
        public decimal Coordinate { get; private set; }

        /// <summary>
        /// Gets the signed value of the coordinate.
        /// </summary>
        public decimal CoordinateSigned
        {
            get
            {
                if (this.IsNegative)
                {
                    return this.Coordinate * -1;
                }

                return this.Coordinate;
            }
        }

        /// <summary>
        /// Gets the unsigned degrees to 5 decimal places.
        /// </summary>
        public decimal DecimalDegrees
        {
            get { return System.Math.Round(this.Coordinate, 5); }
        }

        /// <summary>
        /// Gets the signed degrees to 5 decimal places.
        /// </summary>
        public decimal DecimalDegreesSigned
        {
            get
            {
                decimal rounded = System.Math.Round(this.Coordinate, 5);

                if (this.IsNegative)
                {
                    return rounded * -1;
                }

                return rounded;
            }
        }

        /// <summary>
        /// Gets the signed degrees as an integer.
        /// </summary>
        public int DegreesSigned
        {
            get
            {
                var floored = (int)this.Floor(this.Coordinate);

                if (this.IsNegative)
                {
                    return floored * -1;
                }

                return floored;
            }
        }

        /// <summary>
        /// Gets the unsigned degrees as an integer.
        /// </summary>
        public int Degrees
        {
            get { return (int)this.Floor(this.Coordinate); }
        }

        /// <summary>
        /// Gets the minutes to 3 decimal places.
        /// </summary>
        public decimal DecimalMinutes
        {
            get
            {
                decimal minutes = (this.Coordinate - this.Floor(this.Coordinate)) * 60;
                return System.Math.Round(minutes, 3);
            }
        }

        /// <summary>
        /// Gets the minutes as an integer.
        /// </summary>
        public int Minutes
        {
            get
            {
                return (int)((this.Coordinate - this.Floor(this.Coordinate)) * 60);
            }
        }

        /// <summary>
        /// Gets the seconds as an integer.
        /// </summary>
        public int Seconds
        {
            get
            {
                decimal minutes = (this.Coordinate - this.Floor(this.Coordinate)) * 60;
                return (int)System.Math.Round((minutes - this.Minutes) * 60);
            }
        }

        #endregion

        /// <summary>
        /// Gets the cardinal direction of the coordinate.
        /// </summary>
        public abstract Direction Direction { get; }

        public abstract CoordinateType CoordinateType { get; }

        protected abstract ISpecification<decimal> ValidationSpecification { get; }       

        #region Public Methods - SetCoordinate Overloads

        /// <summary>Sets the coordinate details.</summary>
        /// <param name="degrees">The amount of degrees.</param>
        public void SetCoordinate(decimal degrees)
        {
            this.Validate(degrees);
            this.SetIsNegative(degrees);

            this.Coordinate = System.Math.Abs(degrees);
        }

        /// <summary>Sets the coordinate details.</summary>
        /// <param name="degrees">The amount of degrees.</param>
        /// <param name="minutes">The amount of minutes.</param>
        public void SetCoordinate(decimal degrees, decimal minutes)
        {
            this.Validate(degrees);
            this.SetIsNegative(degrees);

            decimal absoluteDegrees = System.Math.Abs(degrees);
            decimal absoluteMinutes = System.Math.Abs(minutes);

            this.Coordinate = absoluteDegrees + (absoluteMinutes / 60m);
        }

        /// <summary>Sets the coordinate details.</summary>
        /// <param name="degrees">The amount of degrees.</param>
        /// <param name="minutes">The amount of minutes.</param>
        /// <param name="seconds">The amount of seconds.</param>
        public void SetCoordinate(decimal degrees, decimal minutes, decimal seconds)
        {
            this.Validate(degrees);
            this.SetIsNegative(degrees);

            decimal absoluteDegrees = System.Math.Abs(degrees);
            decimal absoluteMinutes = System.Math.Abs(minutes);
            decimal absoluteSeconds = System.Math.Abs(seconds);

            this.Coordinate = absoluteDegrees + (absoluteMinutes / 60m) + (absoluteSeconds / 3600);
        }

        /// <summary>Sets the coordinate details.</summary>
        /// <param name="degrees">The amount of degrees.</param>
        /// <param name="direction">The cardinal direction.</param>
        public void SetCoordinate(decimal degrees, Direction direction)
        {
            this.Validate(degrees);
            this.SetIsNegative(direction);

            this.Coordinate = System.Math.Abs(degrees);
        }

        /// <summary>Sets the coordinate details.</summary>
        /// <param name="degrees">The amount of degrees.</param>
        /// <param name="minutes">The amount of minutes.</param>
        /// <param name="direction">The cardinal direction</param>
        public void SetCoordinate(decimal degrees, decimal minutes, Direction direction)
        {
            this.Validate(degrees);
            this.SetIsNegative(direction);

            decimal absoluteDegrees = System.Math.Abs(degrees);
            decimal absoluteMinutes = System.Math.Abs(minutes);

            this.Coordinate = absoluteDegrees + (absoluteMinutes / 60m);
        }

        /// <summary>Sets the coordinate details.</summary>
        /// <param name="degrees">The amount of degrees.</param>
        /// <param name="minutes">The amount of minutes.</param>
        /// <param name="seconds">The amount of seconds.</param>
        /// <param name="direction">The cardinal direction</param>
        public void SetCoordinate(decimal degrees, decimal minutes, decimal seconds, Direction direction)
        {
            this.Validate(degrees, direction);
            this.SetIsNegative(direction);

            decimal absoluteDegrees = System.Math.Abs(degrees);
            decimal absoluteMinutes = System.Math.Abs(minutes);
            decimal absoluteSeconds = System.Math.Abs(seconds);

            this.Coordinate = absoluteDegrees + (absoluteMinutes / 60m) + (absoluteSeconds / 3600);
        }

        #endregion

        /// <summary>
        /// Returns a string that represents the current coordinate in decimal degrees.
        /// </summary>
        /// <returns>A string that represents the current coordinate.</returns>
        public override string ToString()
        {
            return this.ToString(DisplayFormat.Degrees);
        }

        /// <summary>
        /// Formats the value of the current coordinate using the specified format.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <returns>The value of the current coordinate in the specified format.</returns>
        public virtual string ToString(DisplayFormat format)
        {
            var formatter = new CoordinateTextFormatter(this);
            return formatter.Format(format);
        }

        public virtual string ToHtmlString(DisplayFormat format)
        {
            var formatter = new CoordinateHtmlFormatter(this);
            return formatter.Format(format);
        }

        public abstract ICollection<Direction> GetValidDirections();

        protected void SetIsNegative(decimal degress)
        {
            this.IsNegative = degress < 0;
        }

        protected abstract void SetIsNegative(Direction direction);

        private void Validate(decimal value)
        {
            if (!this.ValidationSpecification.IsSatisfiedBy(value))
            {
                throw new ArgumentOutOfRangeException("value", "Not a valid value for this type of coordinate.");
            }
        }

        private void Validate(decimal value, Direction direction)
        {
            this.Validate(value);

            ICollection<Direction> validDirections = this.GetValidDirections();
            if (!validDirections.Contains(direction))
            {
                throw new ArgumentOutOfRangeException("direction", "Not a valid direction for this type of coordinate.");
            }
        }

        private decimal Floor(decimal value)
        {
            double doubleValue = Convert.ToDouble(value);
            return Convert.ToDecimal(System.Math.Floor(doubleValue));
        }
    }
}
