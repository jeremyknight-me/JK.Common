using System;
using System.Collections.Generic;
using JK.Common.Enumerations;

namespace JK.Common.Converters;

/// <summary>
/// Provides distance conversion logic between supported units.
/// </summary>
public sealed class DistanceConverter
{
    private readonly Dictionary<Tuple<DistanceUnit, DistanceUnit>, decimal> _strategies;

    /// <summary>
    /// Initializes a new instance of the <see cref="DistanceConverter"/> class.
    /// </summary>
    public DistanceConverter()
    {
        _strategies = new Dictionary<Tuple<DistanceUnit, DistanceUnit>, decimal>
            {
                // Convert Centimeter to New Unit Of Measure
                { Tuple.Create(DistanceUnit.Centimeters, DistanceUnit.Feet), 0.0328084m },
                { Tuple.Create(DistanceUnit.Centimeters, DistanceUnit.Inches), 0.393701m },
                { Tuple.Create(DistanceUnit.Centimeters, DistanceUnit.Meters), 0.01m },
                // Convert Feet to New Unit Of Measure
                { Tuple.Create(DistanceUnit.Feet, DistanceUnit.Centimeters), 30.48m },
                { Tuple.Create(DistanceUnit.Feet, DistanceUnit.Inches), 12m },
                { Tuple.Create(DistanceUnit.Feet, DistanceUnit.Meters), 0.3048m },
                // Convert Inches to New Unit Of Measure
                { Tuple.Create(DistanceUnit.Inches, DistanceUnit.Centimeters), 2.54m },
                { Tuple.Create(DistanceUnit.Inches, DistanceUnit.Feet), 0.08333333m },
                { Tuple.Create(DistanceUnit.Inches, DistanceUnit.Meters), 0.0254m },
                // Convert Meters to New Unit of Measure
                { Tuple.Create(DistanceUnit.Meters, DistanceUnit.Centimeters), 100m },
                { Tuple.Create(DistanceUnit.Meters, DistanceUnit.Feet), 3.28084m },
                { Tuple.Create(DistanceUnit.Meters, DistanceUnit.Inches), 39.3701m }
            };
    }

    /// <summary>
    /// Converts a distance value from one unit to another.
    /// </summary>
    /// <param name="originalDistance">The original distance value.</param>
    /// <param name="originalUnit">The unit of the original distance value.</param>
    /// <param name="newUnit">The unit to convert to.</param>
    /// <returns>The converted distance value in the new unit.</returns>
    /// <exception cref="NotSupportedException">Thrown when the unit pairing is not supported.</exception>
    public decimal Convert(in decimal originalDistance, in DistanceUnit originalUnit, in DistanceUnit newUnit)
    {
        if (originalUnit == newUnit)
        {
            return originalDistance;
        }

        var tuple = Tuple.Create(originalUnit, newUnit);
        return !_strategies.TryGetValue(tuple, out var value)
            ? throw new NotSupportedException("Unit pairing is not supported.")
            : originalDistance * value;
    }
}
