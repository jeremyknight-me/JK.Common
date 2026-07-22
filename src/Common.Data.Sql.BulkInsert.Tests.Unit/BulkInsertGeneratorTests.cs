using System.Data;

namespace JK.Common.Data.Sql.BulkInsert.Tests;

public class BulkInsertGeneratorTests
{
    [Fact]
    public void TableName_ReturnsCorrectValue()
    {
        Assert.Equal("Employees", SampleTypeBulkInserter.TableName);
    }

    [Fact]
    public void ColumnMappings_ReturnsCorrectMappings()
    {
        IDictionary<string, string> mappings = SampleTypeBulkInserter.ColumnMappings;

        Assert.Equal(3, mappings.Count);
        Assert.Equal("FirstName", mappings["FirstName"]);
        Assert.Equal("LastName", mappings["LastName"]);
        Assert.Equal("Age", mappings["Age"]);
    }

    [Fact]
    public void BuildDataTable_CreatesCorrectColumns()
    {
        List<SampleType> items = [];
        DataTable table = SampleTypeBulkInserter.BuildDataTable(items);

        Assert.Equal(3, table.Columns.Count);
        Assert.Equal("FirstName", table.Columns[0].ColumnName);
        Assert.Equal(typeof(string), table.Columns[0].DataType);
        Assert.Equal("LastName", table.Columns[1].ColumnName);
        Assert.Equal(typeof(string), table.Columns[1].DataType);
        Assert.Equal("Age", table.Columns[2].ColumnName);
        Assert.Equal(typeof(int), table.Columns[2].DataType);
    }

    [Fact]
    public void BuildDataTable_PopulatesRows()
    {
        List<SampleType>? items =
        [
            new SampleType { FirstName = "John", LastName = "Doe", Age = 30 },
            new SampleType { FirstName = "Jane", LastName = "Smith", Age = 25 }
        ];

        DataTable table = SampleTypeBulkInserter.BuildDataTable(items);

        Assert.Equal(2, table.Rows.Count);
        Assert.Equal("John", table.Rows[0]["FirstName"]);
        Assert.Equal("Doe", table.Rows[0]["LastName"]);
        Assert.Equal(30, table.Rows[0]["Age"]);
        Assert.Equal("Jane", table.Rows[1]["FirstName"]);
        Assert.Equal("Smith", table.Rows[1]["LastName"]);
        Assert.Equal(25, table.Rows[1]["Age"]);
    }

    [Fact]
    public void BuildDataTable_EmptyList_ReturnsEmptyTable()
    {
        List<SampleType> items = [];
        DataTable table = SampleTypeBulkInserter.BuildDataTable(items);

        Assert.Equal(0, table.Rows.Count);
        Assert.Equal(3, table.Columns.Count);
    }
}
