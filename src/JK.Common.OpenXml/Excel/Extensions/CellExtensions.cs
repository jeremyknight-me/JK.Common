using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace JK.Common.OpenXml.Excel.Extensions
{
    internal static class CellExtensions
    {
        /// <summary>
        /// Given a cell, parses the specified cell to get the zero based column index.
        /// </summary>
        /// <param name="cell">Cell with reference (ie. C8)</param>
        /// <returns>Column index (ie. 2)</returns>
        internal static int GetColumnIndex(this CellType cell)
        {
            var number = cell.GetColumnNumber();
            return number - 1;
        }

        /// <summary>
        /// Given a cell, parses the specified cell to get the column letter.
        /// </summary>
        /// <param name="cell">Cell with reference (ie. B2)</param>
        /// <returns>Column letter (ie. B)</returns>       
        internal static string GetColumnLetter(this CellType cell)
        {
            var reference = cell.CellReference;
            if (string.IsNullOrWhiteSpace(reference))
            {
                throw new ArgumentException("CellReference must be valid reference.");
            }

            var regex = new Regex("[A-Za-z]+"); // Create a regular expression to match the column name portion of the cell name.
            var match = regex.Match(reference);
            return match.Value;
        }

        /// <summary>
        /// Given a cell, parses the specified cell to get the column number.
        /// </summary>
        /// <param name="cell">Cell with reference (ie. C8)</param>
        /// <returns>Column number (ie. 3)</returns>
        internal static int GetColumnNumber(this CellType cell)
        {
            var letter = cell.GetColumnLetter();
            if (string.IsNullOrWhiteSpace(letter))
            {
                throw new ArgumentException("CellReference must be valid reference.");
            }

            letter = letter.ToUpperInvariant();
            var sum = 0;
            foreach (var c in letter.ToCharArray())
            {
                sum *= 26;
                sum += (c - 'A' + 1);
            }
            return sum;
        }

        internal static string GetValue(this CellType cell, WorkbookPart workbookPart)
            => CellValueParser.GetValue(workbookPart, cell);
    }
}
