using System.Collections.Generic;
using JK.Common.Patterns.Specification;
using JK.Common.Specifications;

namespace JK.Common.Geospatial;

/// <summary>Represents a latitude ("y" axis) co-ordinate.</summary>
public sealed class Latitude : CoordinateBase
{
    public Latitude(decimal degrees)
        : base(degrees)
    {
    }

    public Latitude(int degrees, decimal minutes)
        : base(degrees, minutes)
    {
    }

    public Latitude(int degrees, int minutes, decimal seconds)
        : base(degrees, minutes, seconds)
    {
    }

    public Latitude(decimal degrees, Direction direction)
        : base(degrees, direction)
    {
    }

    public Latitude(int degrees, decimal minutes, Direction direction)
        : base(degrees, minutes, direction)
    {
    }

    public Latitude(int degrees, int minutes, decimal seconds, Direction direction)
        : base(degrees, minutes, seconds, direction)
    {
    }

    public override Direction Direction => this.IsNegative ? Direction.S : Direction.N;

    public override CoordinateType CoordinateType => CoordinateType.Latitude;

    public override ICollection<Direction> GetValidDirections() => new List<Direction> { Direction.N, Direction.S };

    protected override ISpecification<decimal> ValidationSpecification => new LatitudeSpecification();

    protected override void SetIsNegative(in Direction direction) => this.IsNegative = direction == Direction.S;
}
