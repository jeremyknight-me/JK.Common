using System;

namespace JK.Common.TypeHelpers;

/// <summary>
/// Provides helper methods for working with Excel-related data.
/// </summary>
public static class ExcelHelper
{
    /// <summary>
    /// Converts a column number to its corresponding Excel column name (e.g., 1 = "A", 27 = "AA").
    /// </summary>
    /// <param name="columnNumber">The column number to convert.</param>
    /// <returns>The corresponding Excel column name.</returns>
    public static string GetColumnName(in int columnNumber)
    {
        var dividend = columnNumber;
        var columnName = string.Empty;
        while (dividend > 0)
        {
            var modulus = (dividend - 1) % 26;
            columnName = Convert.ToChar(65 + modulus) + columnName;
            dividend = (dividend - modulus) / 26;
        }

        return columnName;
    }
}
