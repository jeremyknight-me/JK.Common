using System.Collections.Generic;
using JK.Common.Patterns.Specification;
using JK.Common.Specifications;

namespace JK.Common.Geospatial;

/// <summary>Represents a longitude ("x" axis) coordinate.</summary>
public sealed class Longitude : CoordinateBase
{
    public Longitude(decimal degrees)
        : base(degrees)
    {
    }

    public Longitude(int degrees, decimal minutes)
        : base(degrees, minutes)
    {
    }

    public Longitude(int degrees, int minutes, decimal seconds)
        : base(degrees, minutes, seconds)
    {
    }

    public Longitude(decimal degrees, Direction direction)
        : base(degrees, direction)
    {
    }

    public Longitude(int degrees, decimal minutes, Direction direction)
        : base(degrees, minutes, direction)
    {
    }

    public Longitude(int degrees, int minutes, decimal seconds, Direction direction)
        : base(degrees, minutes, seconds, direction)
    {
    }

    public override Direction Direction => IsNegative ? Direction.W : Direction.E;

    public override CoordinateType CoordinateType => CoordinateType.Longitude;

    public override ICollection<Direction> GetValidDirections() => [Direction.E, Direction.W];

    protected override ISpecification<decimal> ValidationSpecification => new LongitudeSpecification();

    protected override void SetIsNegative(in Direction direction) => IsNegative = direction == Direction.W;
}
