using DL.Core.Enums;

namespace DL.Core.Math
{
    public class DistanceMeasurement
    {
        public DistanceMeasurement()
        {
        }

        public DistanceMeasurement(UnitOfMeasureDistance unitOfMeasure, decimal distance)
        {
            this.Distance = distance;
            this.UnitOfMeasure = unitOfMeasure;
        }

        public UnitOfMeasureDistance UnitOfMeasure { get; set; }

        public decimal Distance { get; set; }

        public DistanceMeasurement Add(DistanceMeasurement other)
        {
            decimal newAmount = this.Distance + other.ConvertTo(this.UnitOfMeasure).Distance;
            return new DistanceMeasurement(this.UnitOfMeasure, newAmount);
        }

        public DistanceMeasurement ConvertTo(UnitOfMeasureDistance unitOfMeasure)
        {
            var converter = new DistanceConverter(this.Distance, this.UnitOfMeasure);
            decimal newAmount = converter.ConvertTo(unitOfMeasure);
            return new DistanceMeasurement(unitOfMeasure, newAmount);
        }

        public DistanceMeasurement Subtract(DistanceMeasurement other)
        {
            decimal newAmount = this.Distance - other.ConvertTo(this.UnitOfMeasure).Distance;
            return new DistanceMeasurement(this.UnitOfMeasure, newAmount);
        }
    }
}
