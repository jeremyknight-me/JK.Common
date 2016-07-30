using System;
using System.Collections.Generic;
using DL.Core.Enums;

namespace DL.Core.Math
{
    public class DistanceConverter
    {
        private readonly Dictionary<KeyValuePair<UnitOfMeasureDistance, UnitOfMeasureDistance>, Func<decimal>> strategies 
            = new Dictionary<KeyValuePair<UnitOfMeasureDistance, UnitOfMeasureDistance>, Func<decimal>>();

        private readonly decimal originalDistance;

        private readonly UnitOfMeasureDistance originalUnitOfMeasure;

        public DistanceConverter(decimal originalDistanceToUse, UnitOfMeasureDistance originalUnitOfMeasureToUse)
        {
            this.originalDistance = originalDistanceToUse;
            this.originalUnitOfMeasure = originalUnitOfMeasureToUse;
            this.DefineStrategies();
        }

        public decimal ConvertTo(UnitOfMeasureDistance newUnitOfMeasure)
        {
            if (this.originalUnitOfMeasure == newUnitOfMeasure)
            {
                return this.originalDistance;
            }

            var keyValuePair = this.GetKeyValuePair(this.originalUnitOfMeasure, newUnitOfMeasure);
            var method = this.strategies[keyValuePair];
            return method();
        }

        private void DefineStrategies()
        {
            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Centimeters, UnitOfMeasureDistance.Feet), this.ConvertCentimeterToFeet);
            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Centimeters, UnitOfMeasureDistance.Inches), this.ConvertCentimeterToInches);
            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Centimeters, UnitOfMeasureDistance.Meters), this.ConvertCentimeterToMeters);

            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Feet, UnitOfMeasureDistance.Centimeters), this.ConvertFeetToCentimeters);
            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Feet, UnitOfMeasureDistance.Inches), this.ConvertFeetToInches);
            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Feet, UnitOfMeasureDistance.Meters), this.ConvertFeetToMeters);

            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Inches, UnitOfMeasureDistance.Centimeters), this.ConvertInchesToCentimeters);
            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Inches, UnitOfMeasureDistance.Feet), this.ConvertInchesToFeet);
            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Inches, UnitOfMeasureDistance.Meters), this.ConvertInchesToMeters);

            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Meters, UnitOfMeasureDistance.Centimeters), this.ConvertMetersToCentimeters);
            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Meters, UnitOfMeasureDistance.Feet), this.ConvertMetersToFeet);
            this.strategies.Add(this.GetKeyValuePair(UnitOfMeasureDistance.Meters, UnitOfMeasureDistance.Inches), this.ConvertMetersToInches);
        }

        private KeyValuePair<UnitOfMeasureDistance, UnitOfMeasureDistance> GetKeyValuePair(UnitOfMeasureDistance left, UnitOfMeasureDistance right)
        {
            return new KeyValuePair<UnitOfMeasureDistance, UnitOfMeasureDistance>(left, right);
        }

        #region Private Methods - Convert Centimeter to New Unit Of Measure

        private decimal ConvertCentimeterToFeet()
        {
            return this.originalDistance * 0.0328084m;
        }

        private decimal ConvertCentimeterToInches()
        {
            return this.originalDistance * 0.393701m;
        }

        private decimal ConvertCentimeterToMeters()
        {
            return this.originalDistance * 0.01m;
        }

        #endregion

        #region Private Methods - Convert Feet to New Unit Of Measure

        private decimal ConvertFeetToCentimeters()
        {
            return this.originalDistance * 30.48m;
        }

        private decimal ConvertFeetToInches()
        {
            return this.originalDistance * 12m;
        }

        private decimal ConvertFeetToMeters()
        {
            return this.originalDistance * 0.3048m;
        }

        #endregion

        #region Private Methods - Convert Inches to New Unit Of Measure

        private decimal ConvertInchesToCentimeters()
        {
            return this.originalDistance * 2.54m;
        }

        private decimal ConvertInchesToFeet()
        {
            return this.originalDistance * 0.0833333m;
        }

        private decimal ConvertInchesToMeters()
        {
            return this.originalDistance * 0.0254m;
        }

        #endregion

        #region Private Methods - Convert Meters to New Unit of Measure

        private decimal ConvertMetersToCentimeters()
        {
            return this.originalDistance * 100m;
        }

        private decimal ConvertMetersToFeet()
        {
            return this.originalDistance * 3.28084m;
        }

        private decimal ConvertMetersToInches()
        {
            return this.originalDistance * 39.3701m;
        }

        #endregion
    }
}
