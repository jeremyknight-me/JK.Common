using System;
using System.Collections.Generic;
using JK.Common.Patterns.Specification;

namespace JK.Common.Geospatial;

/// <summary>Base object for latitudes and longitudes coordinates.</summary>
public abstract class CoordinateBase
{
    protected CoordinateBase(decimal degrees, decimal minutes = 0, decimal seconds = 0)
    {
        this.Validate(degrees);
        this.SetIsNegative(degrees);
        this.Coordinate = Math.Abs(degrees) + (Math.Abs(minutes) / 60.0m) + (Math.Abs(seconds) / 3600.0m);
    }

    protected CoordinateBase(decimal degrees, Direction direction)
        : this(degrees, 0m, 0m, direction)
    {
    }

    protected CoordinateBase(decimal degrees, decimal minutes, Direction direction)
        : this(degrees, minutes, 0m, direction)
    {
    }

    protected CoordinateBase(decimal degrees, decimal minutes, decimal seconds, Direction direction)
    {
        this.Validate(degrees, direction);
        this.SetIsNegative(direction);
        this.Coordinate = Math.Abs(degrees) + (Math.Abs(minutes) / 60.0m) + (Math.Abs(seconds) / 3600.0m);
    }

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
    public decimal CoordinateSigned => this.IsNegative ? this.Coordinate * -1 : this.Coordinate;

    /// <summary>
    /// Gets the unsigned degrees rounded to 10 decimal places.
    /// </summary>
    public decimal DecimalDegrees => Math.Round(this.Coordinate, 10);

    /// <summary>
    /// Gets the signed degrees rounded to 10 decimal places.
    /// </summary>
    public decimal DecimalDegreesSigned => this.IsNegative ? this.DecimalDegrees * -1 : this.DecimalDegrees;

    /// <summary>
    /// Gets the signed degrees as an integer.
    /// </summary>
    public int DegreesSigned
    {
        get
        {
            var floored = (int)Math.Floor(this.Coordinate);
            return this.IsNegative ? floored * -1 : floored;
        }
    }

    /// <summary>
    /// Gets the unsigned degrees as an integer.
    /// </summary>
    public int Degrees => (int)Math.Floor(this.Coordinate);

    /// <summary>
    /// Gets the minutes to 3 decimal places.
    /// </summary>
    public decimal DecimalMinutes
    {
        get
        {
            var minutes = (this.Coordinate - Math.Floor(this.Coordinate)) * 60.0m;
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
            var minutes = (this.Coordinate - Math.Floor(this.Coordinate)) * 60.0m;
            return (int)Math.Round((minutes - this.Minutes) * 60);
        }
    }

    #endregion

    /// <summary>
    /// Gets the cardinal direction of the coordinate.
    /// </summary>
    public abstract Direction Direction { get; }

    public abstract CoordinateType CoordinateType { get; }

    protected abstract ISpecification<decimal> ValidationSpecification { get; }

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
    public virtual string ToString(in DisplayFormat format)
    {
        var formatter = new CoordinateTextFormatter(this);
        return formatter.Format(format);
    }

    public virtual string ToHtmlString(in DisplayFormat format)
    {
        var formatter = new CoordinateHtmlFormatter(this);
        return formatter.Format(format);
    }

    public abstract ICollection<Direction> GetValidDirections();

    protected void SetIsNegative(in decimal degress) => this.IsNegative = degress < 0;

    protected abstract void SetIsNegative(in Direction direction);

    private void Validate(in decimal value)
    {
        if (!this.ValidationSpecification.IsSatisfiedBy(value))
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Not a valid value for this type of coordinate.");
        }
    }

    private void Validate(in decimal value, in Direction direction)
    {
        this.Validate(value);
        var validDirections = this.GetValidDirections();
        if (!validDirections.Contains(direction))
        {
            throw new ArgumentOutOfRangeException(nameof(direction), "Not a valid direction for this type of coordinate.");
        }
    }
}
