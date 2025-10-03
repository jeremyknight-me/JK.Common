using System;
using System.Collections.Generic;
using JK.Common.Patterns.Specification;

namespace JK.Common.Geospatial;

/// <summary>
/// Base object for latitudes and longitudes coordinates.
/// </summary>
public abstract class CoordinateBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinateBase"/> class.
    /// </summary>
    /// <param name="degrees">The degrees component of the coordinate.</param>
    /// <param name="minutes">The minutes component of the coordinate. Defaults to 0.</param>
    /// <param name="seconds">The seconds component of the coordinate. Defaults to 0.</param>
    protected CoordinateBase(decimal degrees, decimal minutes = 0, decimal seconds = 0)
    {
        Validate(degrees);
        SetIsNegative(degrees);
        Coordinate = Math.Abs(degrees) + (Math.Abs(minutes) / 60.0m) + (Math.Abs(seconds) / 3600.0m);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinateBase"/> class with a direction.
    /// </summary>
    /// <param name="degrees">The degrees component of the coordinate.</param>
    /// <param name="direction">The cardinal direction of the coordinate.</param>
    protected CoordinateBase(decimal degrees, Direction direction)
        : this(degrees, 0m, 0m, direction)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinateBase"/> class with minutes and a direction.
    /// </summary>
    /// <param name="degrees">The degrees component of the coordinate.</param>
    /// <param name="minutes">The minutes component of the coordinate.</param>
    /// <param name="direction">The cardinal direction of the coordinate.</param>
    protected CoordinateBase(decimal degrees, decimal minutes, Direction direction)
        : this(degrees, minutes, 0m, direction)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinateBase"/> class with minutes, seconds, and a direction.
    /// </summary>
    /// <param name="degrees">The degrees component of the coordinate.</param>
    /// <param name="minutes">The minutes component of the coordinate.</param>
    /// <param name="seconds">The seconds component of the coordinate.</param>
    /// <param name="direction">The cardinal direction of the coordinate.</param>
    protected CoordinateBase(decimal degrees, decimal minutes, decimal seconds, Direction direction)
    {
        Validate(degrees, direction);
        SetIsNegative(direction);
        Coordinate = Math.Abs(degrees) + (Math.Abs(minutes) / 60.0m) + (Math.Abs(seconds) / 3600.0m);
    }

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
    public decimal CoordinateSigned => IsNegative ? Coordinate * -1 : Coordinate;

    /// <summary>
    /// Gets the unsigned degrees rounded to 10 decimal places.
    /// </summary>
    public decimal DecimalDegrees => Math.Round(Coordinate, 10);

    /// <summary>
    /// Gets the signed degrees rounded to 10 decimal places.
    /// </summary>
    public decimal DecimalDegreesSigned => IsNegative ? DecimalDegrees * -1 : DecimalDegrees;

    /// <summary>
    /// Gets the signed degrees as an integer.
    /// </summary>
    public int DegreesSigned
    {
        get
        {
            var floored = (int)Math.Floor(Coordinate);
            return IsNegative ? floored * -1 : floored;
        }
    }

    /// <summary>
    /// Gets the unsigned degrees as an integer.
    /// </summary>
    public int Degrees => (int)Math.Floor(Coordinate);

    /// <summary>
    /// Gets the minutes to 3 decimal places.
    /// </summary>
    public decimal DecimalMinutes
    {
        get
        {
            var minutes = (Coordinate - Math.Floor(Coordinate)) * 60.0m;
            return Math.Round(minutes, 3);
        }
    }

    /// <summary>
    /// Gets the minutes as an integer.
    /// </summary>
    public int Minutes => (int)((Coordinate - Math.Floor(Coordinate)) * 60);

    /// <summary>
    /// Gets the seconds as an integer.
    /// </summary>
    public int Seconds
    {
        get
        {
            var minutes = (Coordinate - Math.Floor(Coordinate)) * 60.0m;
            return (int)Math.Round((minutes - Minutes) * 60);
        }
    }

    /// <summary>
    /// Gets the cardinal direction of the coordinate.
    /// </summary>
    public abstract Direction Direction { get; }

    /// <summary>
    /// Gets the coordinate type (latitude or longitude).
    /// </summary>
    public abstract CoordinateType CoordinateType { get; }

    /// <summary>
    /// Gets the validation specification for the coordinate.
    /// </summary>
    protected abstract ISpecification<decimal> ValidationSpecification { get; }

    /// <summary>
    /// Returns a string that represents the current coordinate in decimal degrees.
    /// </summary>
    /// <returns>A string that represents the current coordinate.</returns>
    public override string ToString() => ToString(DisplayFormat.Degrees);

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

    /// <summary>
    /// Formats the value of the current coordinate as HTML using the specified format.
    /// </summary>
    /// <param name="format">The format to use.</param>
    /// <returns>The value of the current coordinate in the specified HTML format.</returns>
    public virtual string ToHtmlString(in DisplayFormat format)
    {
        var formatter = new CoordinateHtmlFormatter(this);
        return formatter.Format(format);
    }

    /// <summary>
    /// Gets the valid directions for the coordinate type.
    /// </summary>
    /// <returns>A collection of valid directions.</returns>
    public abstract ICollection<Direction> GetValidDirections();

    /// <summary>
    /// Sets whether the coordinate is negative based on the degrees value.
    /// </summary>
    /// <param name="degrees">The degrees value to evaluate.</param>
    protected void SetIsNegative(in decimal degrees) => IsNegative = degrees < 0;

    /// <summary>
    /// Sets whether the coordinate is negative based on the direction.
    /// </summary>
    /// <param name="direction">The direction to evaluate.</param>
    protected abstract void SetIsNegative(in Direction direction);

    /// <summary>
    /// Validates the coordinate value using the validation specification.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is not valid for this type of coordinate.</exception>
    private void Validate(in decimal value)
    {
        if (!ValidationSpecification.IsSatisfiedBy(value))
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Not a valid value for this type of coordinate.");
        }
    }

    /// <summary>
    /// Validates the coordinate value and direction using the validation specification.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="direction">The direction to validate.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value or direction is not valid for this type of coordinate.</exception>
    private void Validate(in decimal value, in Direction direction)
    {
        Validate(value);
        ICollection<Direction> validDirections = GetValidDirections();
        if (!validDirections.Contains(direction))
        {
            throw new ArgumentOutOfRangeException(nameof(direction), "Not a valid direction for this type of coordinate.");
        }
    }
}
