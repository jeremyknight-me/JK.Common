namespace JK.Common.TypeHelpers;

/// <summary>
/// Class initially built to aid in data imports.
/// </summary>
public sealed class BooleanConverter
{
    private readonly Dictionary<string, bool?> _values = new(9, StringComparer.OrdinalIgnoreCase)
    {
        { "true", true },
        { "y", true },
        { "yes", true },
        { "1", true },
        { "false", false },
        { "n", false },
        { "no", false },
        { "0", false },
        { string.Empty, null }
    };

    /// <summary>
    /// Converts the specified value to a boolean.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The boolean representation of the value.</returns>
    /// <exception cref="ArgumentException">Thrown when the value cannot be converted to a boolean.</exception>
    public bool Convert(object value)
    {
        ThrowHelper.IfNull(value, nameof(value));
        var stringValue = value is string s
            ? s.Trim()
            : value.ToString();
        if (!_values.TryGetValue(stringValue, out var boolean) || boolean is null)
        {
            throw new ArgumentException("Value is not supported.");
        }

        return boolean.Value;
    }

    /// <summary>
    /// Converts the specified value to a nullable boolean.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The nullable boolean representation of the value.</returns>
    public bool? ConvertToNullable(object value)
    {
        if (value is null)
        {
            return null;
        }

        var stringValue = value is string s
            ? s.Trim()
            : value.ToString();
        if (!_values.TryGetValue(stringValue, out var boolean))
        {
            throw new ArgumentException("Value is not supported.");
        }

        return boolean;
    }
}
