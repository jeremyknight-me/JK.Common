namespace JK.Common.Geospatial;

/// <summary>
/// Formats a <see cref="CoordinateBase"/> as HTML in various display formats.
/// </summary>
public sealed class CoordinateHtmlFormatter : CoordinateFormatterBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinateHtmlFormatter"/> class.
    /// </summary>
    /// <param name="coordinateToUse">The coordinate to format as HTML.</param>
    public CoordinateHtmlFormatter(CoordinateBase coordinateToUse)
        : base(coordinateToUse)
    {
    }

    /// <inheritdoc/>
    protected override string ToStringDegrees()
        => $"{Coordinate.CoordinateSigned:###.#####;-###.#####}&deg;";

    /// <inheritdoc/>
    protected override string ToStringDegreesMinutes()
        => $"{Coordinate.DegreesSigned:###;-###}&deg; {Coordinate.DecimalMinutes:##.###}'";

    /// <inheritdoc/>
    protected override string ToStringDegreesMinutesSeconds()
        => $"{Coordinate.DegreesSigned:###;-###}&deg; {Coordinate.Minutes:##}' {Coordinate.Seconds:##.#}\"";

    /// <inheritdoc/>
    protected override string ToStringDegreesDirection()
        => $"{Coordinate.CoordinateSigned:###.#####;###.#####}&deg; {Coordinate.Direction}";

    /// <inheritdoc/>
    protected override string ToStringDegreesMinutesDirection()
        => $"{Coordinate.DegreesSigned:###;###}&deg; {Coordinate.DecimalMinutes:##.###}' {Coordinate.Direction}";

    /// <inheritdoc/>
    protected override string ToStringDegreesMinutesSecondsDirection()
        => $"{Coordinate.DegreesSigned:###;###}&deg; {Coordinate.Minutes:##}' {Coordinate.Seconds:##.#}\" {Coordinate.Direction}";
}
