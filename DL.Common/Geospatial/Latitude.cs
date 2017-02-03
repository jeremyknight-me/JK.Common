using System.Collections.Generic;
using DL.Common.Patterns.Specification;
using DL.Common.Specifications;

namespace DL.Common.Geospatial
{
    /// <summary>Represents a latitude ("y" axis) co-ordinate.</summary>
    public sealed class Latitude : CoordinateBase
    {
        #region Constructors

        public Latitude() 
        {
        }

        public Latitude(decimal degrees) 
            : base(degrees)
        {
        }

        public Latitude(decimal degrees, decimal minutes)
            : base(degrees, minutes)
        {
        }

        public Latitude(decimal degrees, decimal minutes, decimal seconds)
            : base(degrees, minutes, seconds)
        {
        }

        public Latitude(decimal degrees, Direction direction)
            : base(degrees, direction)
        {
        }

        public Latitude(decimal degrees, decimal minutes, Direction direction)
            : base(degrees, minutes, direction)
        {
        }

        public Latitude(decimal degrees, decimal minutes, decimal seconds, Direction direction)
            : base(degrees, minutes, seconds, direction)
        {
        }

        #endregion

        public override Direction Direction => this.IsNegative ? Direction.S : Direction.N;

        public override CoordinateType CoordinateType => CoordinateType.Latitude;

        public override ICollection<Direction> GetValidDirections()
        {
            return new List<Direction> { Direction.N, Direction.S };
        }

        protected override ISpecification<decimal> ValidationSpecification => new LatitudeSpecification();

        protected override void SetIsNegative(Direction direction)
        {
            this.IsNegative = direction == Direction.S;
        }        
    }
}
