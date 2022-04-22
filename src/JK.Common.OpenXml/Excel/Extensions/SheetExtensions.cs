using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace JK.Common.OpenXml.Excel.Extensions
{
    internal static class SheetExtensions
    {
        internal static Worksheet GetWorksheet(this Sheet sheet, WorkbookPart workbookPart)
        {
            if (workbookPart == null)
            {
                throw new ArgumentNullException(nameof(workbookPart));
            }

            var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
            return worksheetPart.Worksheet;
        }
    }
}
