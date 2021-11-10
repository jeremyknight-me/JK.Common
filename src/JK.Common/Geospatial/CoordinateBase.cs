using System;
using System.Collections.Generic;
using JK.Common.Patterns.Specification;

namespace JK.Common.Geospatial;

/// <summary>Base object for latitudes and longitudes coordinates.</summary>
public abstract class CoordinateBase
{
    #region Constructors

    protected CoordinateBase()
    {
    }

    protected CoordinateBase(double degrees)
        : this()
    {
        this.SetCoordinate(degrees);
    }

    protected CoordinateBase(double degrees, double minutes)
        : this()
    {
        this.SetCoordinate(degrees, minutes);
    }

    protected CoordinateBase(double degrees, double minutes, double seconds)
        : this()
    {
        this.SetCoordinate(degrees, minutes, seconds);
    }

    protected CoordinateBase(double degrees, Direction direction)
        : this()
    {
        this.SetCoordinate(degrees, direction);
    }

    protected CoordinateBase(double degrees, double minutes, Direction direction)
        : this()
    {
        this.SetCoordinate(degrees, minutes, direction);
    }

    protected CoordinateBase(double degrees, double minutes, double seconds, Direction direction)
        : this()
    {
        this.SetCoordinate(degrees, minutes, seconds, direction);
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets whether the coordinate represents positive or negative point.
    /// </summary>
    public bool IsNegative
    {
        get; protected set;
    }

    /// <summary>
    /// Gets or sets the absolute value of the coordinate.
    /// </summary>
    public double Coordinate
    {
        get; private set;
    }

    /// <summary>
    /// Gets the signed value of the coordinate.
    /// </summary>
    public double CoordinateSigned => this.IsNegative ? this.Coordinate * -1 : this.Coordinate;

    /// <summary>
    /// Gets the unsigned degrees rounded to 10 decimal places.
    /// </summary>
    public double DecimalDegrees => Math.Round(this.Coordinate, 10);

    /// <summary>
    /// Gets the signed degrees rounded to 10 decimal places.
    /// </summary>
    public double DecimalDegreesSigned => Math.Round(this.IsNegative ? this.Coordinate * -1 : this.Coordinate, 10);

    /// <summary>
    /// Gets the signed degrees as an integer.
    /// </summary>
    public int DegreesSigned
    {
        get
        {
            var floored = (int)Math.Floor(this.Coordinate);

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
    public int Degrees => (int)Math.Floor(this.Coordinate);

    /// <summary>
    /// Gets the minutes to 3 decimal places.
    /// </summary>
    public double DecimalMinutes
    {
        get
        {
            var minutes = (this.Coordinate - Math.Floor(this.Coordinate)) * 60.0;
            return Math.Round(minutes, 3);
        }
    }

    /// <summary>
    /// Gets the minutes as an integer.
    /// </summary>
    public int Minutes => (int)((this.Coordinate - Math.Floor(this.Coordinate)) * 60);

    /// <summary>
    /// Gets the seconds as an integer.
    /// </summary>
    public int Seconds
    {
        get
        {
            var minutes = (this.Coordinate - Math.Floor(this.Coordinate)) * 60.0;
            return (int)Math.Round((minutes - this.Minutes) * 60);
        }
    }

    #endregion

    /// <summary>
    /// Gets the cardinal direction of the coordinate.
    /// </summary>
    public abstract Direction Direction
    {
        get;
    }

    public abstract CoordinateType CoordinateType
    {
        get;
    }

    protected abstract ISpecification<double> ValidationSpecification
    {
        get;
    }

    #region Public Methods - SetCoordinate Overloads

    /// <summary>Sets the coordinate details.</summary>
    /// <param name="degrees">The amount of degrees.</param>
    public void SetCoordinate(double degrees)
    {
        this.Validate(degrees);
        this.SetIsNegative(degrees);

        this.Coordinate = Math.Abs(degrees);
    }

    /// <summary>Sets the coordinate details.</summary>
    /// <param name="degrees">The amount of degrees.</param>
    /// <param name="minutes">The amount of minutes.</param>
    public void SetCoordinate(double degrees, double minutes)
    {
        this.Validate(degrees);
        this.SetIsNegative(degrees);
        var absoluteDegrees = Math.Abs(degrees);
        var absoluteMinutes = Math.Abs(minutes);
        this.Coordinate = absoluteDegrees + (absoluteMinutes / 60.0);
    }

    /// <summary>Sets the coordinate details.</summary>
    /// <param name="degrees">The amount of degrees.</param>
    /// <param name="minutes">The amount of minutes.</param>
    /// <param name="seconds">The amount of seconds.</param>
    public void SetCoordinate(double degrees, double minutes, double seconds)
    {
        this.Validate(degrees);
        this.SetIsNegative(degrees);

        var absoluteDegrees = Math.Abs(degrees);
        var absoluteMinutes = Math.Abs(minutes);
        var absoluteSeconds = Math.Abs(seconds);

        this.Coordinate = absoluteDegrees + (absoluteMinutes / 60.0) + (absoluteSeconds / 3600.0);
    }

    /// <summary>Sets the coordinate details.</summary>
    /// <param name="degrees">The amount of degrees.</param>
    /// <param name="direction">The cardinal direction.</param>
    public void SetCoordinate(double degrees, Direction direction)
    {
        this.Validate(degrees);
        this.SetIsNegative(direction);
        this.Coordinate = Math.Abs(degrees);
    }

    /// <summary>Sets the coordinate details.</summary>
    /// <param name="degrees">The amount of degrees.</param>
    /// <param name="minutes">The amount of minutes.</param>
    /// <param name="direction">The cardinal direction</param>
    public void SetCoordinate(double degrees, double minutes, Direction direction)
    {
        this.Validate(degrees);
        this.SetIsNegative(direction);
        var absoluteDegrees = Math.Abs(degrees);
        var absoluteMinutes = Math.Abs(minutes);
        this.Coordinate = absoluteDegrees + (absoluteMinutes / 60.0);
    }

    /// <summary>Sets the coordinate details.</summary>
    /// <param name="degrees">The amount of degrees.</param>
    /// <param name="minutes">The amount of minutes.</param>
    /// <param name="seconds">The amount of seconds.</param>
    /// <param name="direction">The cardinal direction</param>
    public void SetCoordinate(double degrees, double minutes, double seconds, Direction direction)
    {
        this.Validate(degrees, direction);
        this.SetIsNegative(direction);
        var absoluteDegrees = Math.Abs(degrees);
        var absoluteMinutes = Math.Abs(minutes);
        var absoluteSeconds = Math.Abs(seconds);
        this.Coordinate = absoluteDegrees + (absoluteMinutes / 60.0) + (absoluteSeconds / 3600.0);
    }

    #endregion

    /// <summary>
    /// Returns a string that represents the current coordinate in decimal degrees.
    /// </summary>
    /// <returns>A string that represents the current coordinate.</returns>
    public override string ToString() => this.ToString(DisplayFormat.Degrees);

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

    protected void SetIsNegative(double degress) => this.IsNegative = degress < 0;

    protected abstract void SetIsNegative(Direction direction);

    private void Validate(double value)
    {
        if (!this.ValidationSpecification.IsSatisfiedBy(value))
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Not a valid value for this type of coordinate.");
        }
    }

    private void Validate(double value, Direction direction)
    {
        this.Validate(value);

        var validDirections = this.GetValidDirections();
        if (!validDirections.Contains(direction))
        {
            throw new ArgumentOutOfRangeException(nameof(direction), "Not a valid direction for this type of coordinate.");
        }
    }

    //private double Floor(double value)
    //{
    //    return Math.Floor(value);
    //}
}
