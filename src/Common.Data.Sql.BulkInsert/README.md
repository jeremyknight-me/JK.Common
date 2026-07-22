# JK.Common.Data.Sql.BulkInsert

A Roslyn source generator that creates type-safe `SqlBulkCopy`-based bulk insert helper classes at compile time.

## Usage

Decorate a class with `[BulkInsertable]` and its properties with `[BulkInsertColumn]`:

```csharp
using JK.Common.Data.Sql.BulkInsert.Attributes;

[BulkInsertable("Customers")]
public class Customer
{
    [BulkInsertColumn("Id")]
    public int Id { get; set; }

    [BulkInsertColumn("FirstName")]
    public string FirstName { get; set; }

    [BulkInsertColumn("LastName")]
    public string LastName { get; set; }
}
```

The generator produces a `CustomerBulkInserter` static class containing:

- **`TableName`** — the target table name constant.
- **`ColumnMappings`** — a dictionary mapping property names to column names.
- **`Execute`** — bulk inserts a collection of items using `SqlBulkCopy`.
- **`BuildDataTable`** — converts items to a `DataTable` for insertion.

```csharp
List<Customer> customers = [/* ... */];
await CustomerBulkInserter.ExecuteAsync(connection, customers);
```

## Supported frameworks

- .NET Framework 4.6.2+
- .NET Core 2.0+
- .NET 5+

## Dependencies

- `Microsoft.Data.SqlClient`
