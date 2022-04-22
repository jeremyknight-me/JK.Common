using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace JK.Common.OpenXml.Excel.Extensions;

internal static class WorkbookPartExtensions
{
    internal static Sheet GetSheetFromName(this WorkbookPart workbookPart, string sheetName)
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
