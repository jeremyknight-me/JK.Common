namespace JK.Common.Geospatial;

/// <summary>
/// Formats a <see cref="CoordinateBase"/> as plain text in various display formats.
/// </summary>
public sealed class CoordinateTextFormatter : CoordinateFormatterBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinateTextFormatter"/> class.
    /// </summary>
    /// <param name="coordinateToUse">The coordinate to format as text.</param>
    public CoordinateTextFormatter(CoordinateBase coordinateToUse)
        : base(coordinateToUse)
    {
    }

    /// <inheritdoc/>
    protected override string ToStringDegrees()
        => $"{Coordinate.CoordinateSigned:###.#####;-###.#####}\u00B0";

    /// <inheritdoc/>
    protected override string ToStringDegreesMinutes()
        => $"{Coordinate.DegreesSigned:###;-###}\u00B0 {Coordinate.DecimalMinutes:##.###}'";

    /// <inheritdoc/>
    protected override string ToStringDegreesMinutesSeconds()
        => $"{Coordinate.DegreesSigned:###;-###}\u00B0 {Coordinate.Minutes:##}' {Coordinate.Seconds:##.#}\"";

    /// <inheritdoc/>
    protected override string ToStringDegreesDirection()
        => $"{Coordinate.CoordinateSigned:###.#####;###.#####}\u00B0 {Coordinate.Direction}";

    /// <inheritdoc/>
    protected override string ToStringDegreesMinutesDirection()
        => $"{Coordinate.DegreesSigned:###;###}\u00B0 {Coordinate.DecimalMinutes:##.###}' {Coordinate.Direction}";

    /// <inheritdoc/>
    protected override string ToStringDegreesMinutesSecondsDirection()
        => $"{Coordinate.DegreesSigned:###;###}\u00B0 {Coordinate.Minutes:##}' {Coordinate.Seconds:##.#}\" {Coordinate.Direction}";
}
