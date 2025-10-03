using System;
using System.Linq;

namespace JK.Common.Converters;

/// <summary>
/// Class initially built to aid in data imports.
/// </summary>
public sealed class BooleanConverter
{
    private readonly object[] _trueItems;
    private readonly object[] _falseItems;
    private readonly object[] _nullItems;

    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanConverter"/> class.
    /// </summary>
    public BooleanConverter()
    {
        _trueItems = ["TRUE", "True", "true", "Y", "y", "YES", "Yes", "yes", 1, "1"];
        _falseItems = ["FALSE", "False", "false", "N", "n", "NO", "No", "no", 0, "0"];
        _nullItems = [null, "", string.Empty];
    }

    /// <summary>
    /// Converts the specified value to a boolean.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The boolean representation of the value.</returns>
    /// <exception cref="ArgumentException">Thrown when the value cannot be converted to a boolean.</exception>
    public bool Convert(object value)
    {
        if (value is string)
        {
            value = value.ToString().Trim();
        }

        return value switch
        {
            var t when IsTrue(t) => true,
            var f when IsFalse(f) => false,
            _ => throw new ArgumentException("Value is not supported."),
        };
    }

    /// <summary>
    /// Converts the specified value to a nullable boolean.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The nullable boolean representation of the value.</returns>
    public bool? ConvertToNullable(object value)
    {
        if (value is string)
        {
            value = value.ToString().Trim();
        }

        return IsNull(value)
            ? null
            : Convert(value);
    }

    private bool IsTrue(in object value) => _trueItems.Contains(value);
    private bool IsFalse(in object value) => _falseItems.Contains(value);
    private bool IsNull(in object value) => _nullItems.Contains(value);
}
