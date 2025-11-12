using JK.Common.Patterns.Specification;
using JK.Common.Specifications;

namespace JK.Common.Geospatial;

/// <summary>
/// Represents a longitude ("x" axis) coordinate.
/// </summary>
public sealed class Longitude : CoordinateBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Longitude"/> class.
    /// </summary>
    /// <param name="degrees">The degrees component of the longitude.</param>
    public Longitude(decimal degrees)
        : base(degrees)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Longitude"/> class.
    /// </summary>
    /// <param name="degrees">The degrees component of the longitude.</param>
    /// <param name="minutes">The minutes component of the longitude.</param>
    public Longitude(int degrees, decimal minutes)
        : base(degrees, minutes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Longitude"/> class.
    /// </summary>
    /// <param name="degrees">The degrees component of the longitude.</param>
    /// <param name="minutes">The minutes component of the longitude.</param>
    /// <param name="seconds">The seconds component of the longitude.</param>
    public Longitude(int degrees, int minutes, decimal seconds)
        : base(degrees, minutes, seconds)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Longitude"/> class with a direction.
    /// </summary>
    /// <param name="degrees">The degrees component of the longitude.</param>
    /// <param name="direction">The cardinal direction of the longitude.</param>
    public Longitude(decimal degrees, Direction direction)
        : base(degrees, direction)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Longitude"/> class with minutes and a direction.
    /// </summary>
    /// <param name="degrees">The degrees component of the longitude.</param>
    /// <param name="minutes">The minutes component of the longitude.</param>
    /// <param name="direction">The cardinal direction of the longitude.</param>
    public Longitude(int degrees, decimal minutes, Direction direction)
        : base(degrees, minutes, direction)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Longitude"/> class with minutes, seconds, and a direction.
    /// </summary>
    /// <param name="degrees">The degrees component of the longitude.</param>
    /// <param name="minutes">The minutes component of the longitude.</param>
    /// <param name="seconds">The seconds component of the longitude.</param>
    /// <param name="direction">The cardinal direction of the longitude.</param>
    public Longitude(int degrees, int minutes, decimal seconds, Direction direction)
        : base(degrees, minutes, seconds, direction)
    {
    }

    /// <inheritdoc />
    public override Direction Direction => IsNegative ? Direction.W : Direction.E;

    /// <inheritdoc />
    public override CoordinateType CoordinateType => CoordinateType.Longitude;

    /// <inheritdoc />
    public override ICollection<Direction> GetValidDirections() => [Direction.E, Direction.W];

    /// <inheritdoc />
    protected override ISpecification<decimal> ValidationSpecification => new LongitudeSpecification();

    /// <inheritdoc />
    protected override void SetIsNegative(in Direction direction) => IsNegative = direction == Direction.W;
}
