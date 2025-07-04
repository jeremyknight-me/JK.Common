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

    public BooleanConverter()
    {
        _trueItems = ["TRUE", "True", "true", "Y", "y", "YES", "Yes", "yes", 1, "1"];
        _falseItems = ["FALSE", "False", "false", "N", "n", "NO", "No", "no", 0, "0"];
        _nullItems = [null, "", string.Empty];
    }

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
