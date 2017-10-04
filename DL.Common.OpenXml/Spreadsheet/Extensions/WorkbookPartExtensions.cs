using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DL.Common.OpenXml.Spreadsheet.Extensions
{
    public static class WorkbookPartExtensions
    {
        public static IEnumerable<KeyValuePair<string, Worksheet>> GetNamedWorksheets(this WorkbookPart workbookPart)
        {
            return workbookPart.Workbook.Sheets.Elements<Sheet>()
                .Select(sheet => new KeyValuePair<string, Worksheet>(sheet.Name, sheet.GetWorksheet(workbookPart)));
        }

        public static Dictionary<string, Worksheet> GetNamedWorksheetsDictionary(this WorkbookPart workbookPart)
        {
            return GetNamedWorksheets(workbookPart).ToDictionary(x => x.Key, x => x.Value);
        }

        public static Sheet GetSheetFromName(this WorkbookPart workbookPart, string sheetName)
        {
            if (string.IsNullOrWhiteSpace(sheetName))
            {
                throw new ArgumentNullException(nameof(sheetName));
            }

            return workbookPart.Workbook.Sheets.Elements<Sheet>()
                .FirstOrDefault(s => s.Name.HasValue && s.Name.Value == sheetName);
        }
    }
}
