using System;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DL.Common.OpenXml.Spreadsheet.Extensions
{
    public static class WorksheetPartExtensions
    {
        public static Sheet GetSheet(this WorksheetPart worksheetPart, WorkbookPart workbookPart)
        {
            if (workbookPart == null)
            {
                throw new ArgumentNullException(nameof(workbookPart));
            }

            var relationshipId = workbookPart.GetIdOfPart(worksheetPart);
            return workbookPart.Workbook.Sheets.Elements<Sheet>().FirstOrDefault(s => s.Id.HasValue && s.Id.Value == relationshipId);
        }
    }
}
