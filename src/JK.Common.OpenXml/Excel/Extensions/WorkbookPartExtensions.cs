using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace JK.Common.OpenXml.Excel.Extensions;

internal static class WorkbookPartExtensions
{
    internal static Dictionary<string, Worksheet> GetNamedWorksheets(this WorkbookPart workbookPart)
    {
        var items = workbookPart.Workbook.Sheets
            .Elements<Sheet>()
            .Select(sheet => new KeyValuePair<string, Worksheet>(sheet.Name, sheet.GetWorksheet(workbookPart)));
        return items.ToDictionary(x => x.Key, x => x.Value);
    }

    internal static Sheet GetSheetByName(this WorkbookPart workbookPart, string sheetName)
    {
        if (string.IsNullOrWhiteSpace(sheetName))
        {
            throw new ArgumentNullException(nameof(sheetName));
        }

        return workbookPart
            .Workbook
            .Sheets.Elements<Sheet>()
            .FirstOrDefault(s => s.Name.HasValue && s.Name.Value == sheetName);
    }
}
