using System;
using System.Globalization;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DL.Common.OpenXml.Spreadsheet
{
    public class CellValueParser
    {
        private readonly CellType cell;
        private readonly WorkbookPart workbookPart;

        public CellValueParser(CellType cellTypeToUse, WorkbookPart workbookPartToUse)
        {
            this.cell = cellTypeToUse;
            this.workbookPart = workbookPartToUse;
        }

        public string GetValue()
        {
            if (this.workbookPart == null)
            {
                throw new ArgumentNullException(nameof(this.workbookPart));
            }

            if (this.cell.CellValue == null
                || this.cell.CellValue != null && string.IsNullOrWhiteSpace(this.cell.CellValue.Text))
            {
                return string.Empty;
            }

            if (this.cell.DataType == null)
            {
                return this.cell.CellValue.Text;
            }

            switch (this.cell.DataType.Value)
            {
                case CellValues.SharedString:
                    return GetSharedStringValue(this.workbookPart, this.cell);
                case CellValues.Date:
                    return GetDateValue(this.cell);
                case CellValues.Boolean:
                case CellValues.Number:
                case CellValues.Error:
                case CellValues.String:
                case CellValues.InlineString:
                default:
                    return this.cell.CellValue.Text;
            }
        }

        private static string GetDateValue(CellType cell)
        {
            double parsed;
            if (!double.TryParse(cell.CellValue.Text, out parsed))
            {
                return cell.CellValue.Text;
            }

            var date = DateTime.FromOADate(parsed);
            return date.ToString(CultureInfo.InvariantCulture);
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
