using System.Collections.Generic;
using JK.Common.Patterns.Specification;
using JK.Common.Specifications;

namespace JK.Common.Geospatial;

/// <summary>
/// Represents a latitude ("y" axis) coordinate.
/// </summary>
public sealed class Latitude : CoordinateBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Latitude"/> class.
    /// </summary>
    /// <param name="degrees">The degrees component of the latitude.</param>
    public Latitude(decimal degrees)
        : base(degrees)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Latitude"/> class.
    /// </summary>
    /// <param name="degrees">The degrees component of the latitude.</param>
    /// <param name="minutes">The minutes component of the latitude.</param>
    public Latitude(int degrees, decimal minutes)
        : base(degrees, minutes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Latitude"/> class.
    /// </summary>
    /// <param name="degrees">The degrees component of the latitude.</param>
    /// <param name="minutes">The minutes component of the latitude.</param>
    /// <param name="seconds">The seconds component of the latitude.</param>
    public Latitude(int degrees, int minutes, decimal seconds)
        : base(degrees, minutes, seconds)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Latitude"/> class with a direction.
    /// </summary>
    /// <param name="degrees">The degrees component of the latitude.</param>
    /// <param name="direction">The cardinal direction of the latitude.</param>
    public Latitude(decimal degrees, Direction direction)
        : base(degrees, direction)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Latitude"/> class with minutes and a direction.
    /// </summary>
    /// <param name="degrees">The degrees component of the latitude.</param>
    /// <param name="minutes">The minutes component of the latitude.</param>
    /// <param name="direction">The cardinal direction of the latitude.</param>
    public Latitude(int degrees, decimal minutes, Direction direction)
        : base(degrees, minutes, direction)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Latitude"/> class with minutes, seconds, and a direction.
    /// </summary>
    /// <param name="degrees">The degrees component of the latitude.</param>
    /// <param name="minutes">The minutes component of the latitude.</param>
    /// <param name="seconds">The seconds component of the latitude.</param>
    /// <param name="direction">The cardinal direction of the latitude.</param>
    public Latitude(int degrees, int minutes, decimal seconds, Direction direction)
        : base(degrees, minutes, seconds, direction)
    {
    }

    /// <inheritdoc />
    public override Direction Direction => IsNegative ? Direction.S : Direction.N;

    /// <inheritdoc />
    public override CoordinateType CoordinateType => CoordinateType.Latitude;

    /// <inheritdoc />
    public override ICollection<Direction> GetValidDirections() => [Direction.N, Direction.S];

    /// <inheritdoc />
    protected override ISpecification<decimal> ValidationSpecification => new LatitudeSpecification();

    /// <inheritdoc />
    protected override void SetIsNegative(in Direction direction) => IsNegative = direction == Direction.S;
}
