using System.Collections.Generic;
using JK.Common.Patterns.Specification;
using JK.Common.Specifications;

namespace JK.Common.Geospatial
{
    /// <summary>Represents a longitude ("x" axis) coordinate.</summary>
    public sealed class Longitude : CoordinateBase
    {
        #region Constructors

        public Longitude() 
        {
        }

        public Longitude(double degrees) 
            : base(degrees)
        {
        }

        public Longitude(double degrees, double minutes)
            : base(degrees, minutes)
        {
        }

        public Longitude(double degrees, double minutes, double seconds)
            : base(degrees, minutes, seconds)
        {
        }

        public Longitude(double degrees, Direction direction)
            : base(degrees, direction)
        {
        }

        public Longitude(double degrees, double minutes, Direction direction)
            : base(degrees, minutes, direction)
        {
        }

        public Longitude(double degrees, double minutes, double seconds, Direction direction)
            : base(degrees, minutes, seconds, direction)
        {
        }

        #endregion

        public override Direction Direction => this.IsNegative ? Direction.W : Direction.E;

        public override CoordinateType CoordinateType => CoordinateType.Longitude;

        public override ICollection<Direction> GetValidDirections()
        {
            return new List<Direction> { Direction.E, Direction.W };
        }

        protected override ISpecification<double> ValidationSpecification => new LongitudeSpecification();

        protected override void SetIsNegative(Direction direction)
        {
            this.IsNegative = direction == Direction.W;
        }
    }
}
