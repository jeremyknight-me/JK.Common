using System.Collections.Generic;

namespace DL.Core.Enums
{
    public sealed class UnitOfMeasureDistanceHelper
    {
        private static readonly object threadLock = new object();

        private static UnitOfMeasureDistanceHelper instance;

        private readonly Dictionary<UnitOfMeasureDistance, string> abbreviationStrategies = new Dictionary<UnitOfMeasureDistance, string>();

        private UnitOfMeasureDistanceHelper()
        {
            this.DefineAbbreviationStrategies();
        }

        public static UnitOfMeasureDistanceHelper Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new UnitOfMeasureDistanceHelper();
                    }
                }

                return instance;
            }
        }

        public string GetAbbreviation(UnitOfMeasureDistance unit)
        {
            return this.abbreviationStrategies[unit];
        }

        private void DefineAbbreviationStrategies()
        {
            this.abbreviationStrategies.Add(UnitOfMeasureDistance.Feet, "ft");
            this.abbreviationStrategies.Add(UnitOfMeasureDistance.Inches, "in");
            this.abbreviationStrategies.Add(UnitOfMeasureDistance.Centimeters, "cm");
            this.abbreviationStrategies.Add(UnitOfMeasureDistance.Meters, "m");
        }
    }
}
