using System.Collections.Generic;
using DL.Core.SpecificationPattern;
using DL.Core.Specifications;

namespace DL.Core.Geospatial
{
    /// <summary>Represents a longitude ("x" axis) coordinate.</summary>
    public sealed class Longitude : CoordinateBase
    {
        #region Constructors

        public Longitude() 
        {
        }

        public Longitude(decimal degrees) 
            : base(degrees)
        {
        }

        public Longitude(decimal degrees, decimal minutes)
            : base(degrees, minutes)
        {
        }

        public Longitude(decimal degrees, decimal minutes, decimal seconds)
            : base(degrees, minutes, seconds)
        {
        }

        public Longitude(decimal degrees, Direction direction)
            : base(degrees, direction)
        {
        }

        public Longitude(decimal degrees, decimal minutes, Direction direction)
            : base(degrees, minutes, direction)
        {
        }

        public Longitude(decimal degrees, decimal minutes, decimal seconds, Direction direction)
            : base(degrees, minutes, seconds, direction)
        {
        }

        #endregion

        public override Direction Direction
        {
            get { return this.IsNegative ? Direction.W : Direction.E; }
        }

        public override CoordinateType CoordinateType
        {
            get { return CoordinateType.Longitude; }
        }

        public override ICollection<Direction> GetValidDirections()
        {
            return new List<Direction> { Direction.E, Direction.W };
        }

        protected override ISpecification<decimal> ValidationSpecification
        {
            get { return new LongitudeSpecification(); }
        }

        protected override void SetIsNegative(Direction direction)
        {
            this.IsNegative = direction == Direction.W;
        }
    }
}
