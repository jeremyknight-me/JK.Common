using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using JK.Common.OpenXml.Excel.Extensions;

namespace JK.Common.OpenXml.Excel;

public class ExcelDocument : IDisposable
{
    private SpreadsheetDocument spreadsheet;
    private WorkbookPart workbookPart;

    public ExcelDocument(string path, bool editable = false)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        this.spreadsheet = SpreadsheetDocument.Open(path, isEditable: editable);
        if (this.spreadsheet != null)
        {
            this.workbookPart = this.spreadsheet.WorkbookPart;
        }
    }

    internal ExcelDocument(SpreadsheetDocument spreadsheetDocument)
    {
        this.spreadsheet = spreadsheetDocument;
        if (spreadsheetDocument != null)
        {
            this.workbookPart = this.spreadsheet.WorkbookPart;
        }   
    }

    public void Dispose()
    {
        this.workbookPart = null;
        this.spreadsheet.Dispose();
    }

    public DataSet GetDataSet()
    {
        var sheets = this.workbookPart.GetNamedWorksheets();
        var set = new DataSet();
        foreach (var sheet in sheets)
        {
            var table = this.BuildDataTable(sheet.Value, sheet.Key);
            set.Tables.Add(table);
        }
        return set;
    }

    public DataTable GetDataTableBySheetName(string sheetName, int headerRows = 0)
    {
        if (string.IsNullOrWhiteSpace(sheetName))
        {
            throw new ArgumentNullException(nameof(sheetName));
        }

        var sheet = this.workbookPart.GetSheetByName(sheetName);
        var worksheet = sheet.GetWorksheet(this.workbookPart);
        return this.BuildDataTable(worksheet, sheetName, headerRows);
    }

    private DataTable BuildDataTable(Worksheet worksheet, string sheetName, int headerRows = 0)
    {
        var rows = worksheet.Elements<SheetData>().First().Elements<Row>().ToArray();
        var table = new DataTable(sheetName);
        if (!rows.Any())
        {
            return table;
        }

        var columnCells = rows.ElementAt(0).Cast<Cell>();
        var columnIndex = 0;
        foreach (var cell in columnCells)
        {
            var cellColumnIndex = cell.GetColumnIndex();
            while (columnIndex < cellColumnIndex)
            {
                table.Columns.Add($"Column{columnIndex + 1}");
                columnIndex++;
            }

            var value = cell.GetValue(this.workbookPart);
            var valueColumnName = string.IsNullOrWhiteSpace(value)
                ? $"Column{columnIndex + 1}"
                : $"Column{columnIndex + 1}_{value}";
            table.Columns.Add(valueColumnName);
            columnIndex++;
        }

        foreach (var row in rows)
        {
            var dataRow = table.NewRow();
            this.LoadRow(dataRow, row);
            table.Rows.Add(dataRow);
        }

        for (var i = 0; i < headerRows; i++)
        {
            table.Rows.RemoveAt(0);
        }

        return table;
    }

    private void LoadRow(DataRow dataRow, Row row)
    {
        var cells = row.Elements<Cell>().ToArray();
        var columnIndex = 0;
        foreach (var cell in cells)
        {
            var cellColumnIndex = cell.GetColumnIndex();
            while (columnIndex < cellColumnIndex)
            {
                dataRow[columnIndex] = string.Empty;
                columnIndex++;
            }

            dataRow[columnIndex] = cell.GetValue(this.workbookPart);
            columnIndex++;
        }
    }
}
