using System;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DL.Common.OpenXml.Spreadsheet.Extensions
{
    public static class SheetExtensions
    {
        public static Worksheet GetWorksheet(this Sheet sheet, WorkbookPart workbookPart)
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
