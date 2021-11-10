using System.Collections.Generic;
using JK.Common.Patterns.Specification;
using JK.Common.Specifications;

namespace JK.Common.Geospatial;

/// <summary>Represents a latitude ("y" axis) co-ordinate.</summary>
public sealed class Latitude : CoordinateBase
{
    #region Constructors

    public Latitude()
    {
    }

    public Latitude(double degrees)
        : base(degrees)
    {
    }

    public Latitude(double degrees, double minutes)
        : base(degrees, minutes)
    {
    }

    public Latitude(double degrees, double minutes, double seconds)
        : base(degrees, minutes, seconds)
    {
    }

    public Latitude(double degrees, Direction direction)
        : base(degrees, direction)
    {
    }

    public Latitude(double degrees, double minutes, Direction direction)
        : base(degrees, minutes, direction)
    {
    }

    public Latitude(double degrees, double minutes, double seconds, Direction direction)
        : base(degrees, minutes, seconds, direction)
    {
    }

    #endregion

    public override Direction Direction => this.IsNegative ? Direction.S : Direction.N;

    public override CoordinateType CoordinateType => CoordinateType.Latitude;

    public override ICollection<Direction> GetValidDirections() => new List<Direction> { Direction.N, Direction.S };

    protected override ISpecification<double> ValidationSpecification => new LatitudeSpecification();

    protected override void SetIsNegative(Direction direction) => this.IsNegative = direction == Direction.S;
}
