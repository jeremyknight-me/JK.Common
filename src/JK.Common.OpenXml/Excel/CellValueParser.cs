using System.Globalization;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace JK.Common.OpenXml.Excel
{
    internal static class CellValueParser
    {
        public static string GetValue(WorkbookPart workbookPart, CellType cellType)
        {
            if (workbookPart == null)
            {
                throw new ArgumentNullException(nameof(workbookPart));
            }

            if (cellType.CellValue == null
                || cellType.CellValue != null && string.IsNullOrWhiteSpace(cellType.CellValue.Text))
            {
                return string.Empty;
            }

            if (cellType.DataType == null)
            {
                return cellType.CellValue.Text;
            }

            return cellType.DataType.Value switch
            {
                CellValues.SharedString => GetSharedStringValue(workbookPart, cellType),
                CellValues.Date => GetDateValue(cellType),
                //case CellValues.Boolean:
                //case CellValues.Number:
                //case CellValues.Error:
                //case CellValues.String:
                //case CellValues.InlineString:
                _ => cellType.CellValue.Text,
            };
        }

        private static string GetDateValue(CellType cell)
        {
            if (double.TryParse(cell.CellValue.Text, out var parsed))
            {
                var date = DateTime.FromOADate(parsed);
                return date.ToString(CultureInfo.InvariantCulture);
            }

            return cell.CellValue.Text;
        }

        private static string GetSharedStringValue(WorkbookPart workbookPart, CellType cell)
        {
            var stringTablePart = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
            SharedStringTable stringTable = null;
            if (stringTablePart != null)
            {
                stringTable = stringTablePart.SharedStringTable;
            }

            if (stringTable == null)
            {
                return string.Empty;
            }

            var sharedStringId = int.Parse(cell.CellValue.Text);
            var sharedString = stringTable.ChildElements[sharedStringId].InnerText;
            return sharedString;
        }
    }
}
