# JK.Common.Data.Sql.BulkInsert

A Roslyn source generator that emits type-safe `SqlBulkCopy` helper classes for SQL Server bulk insert operations at compile time. Provides a modern, generator-based alternative to `SqlBulkInsertOperation` in `JK.Common.Data.Sql`.

## Usage

Decorate a class with `[BulkInsertable]` and its properties with `[BulkInsertColumn]`:

```csharp
using JK.Common.Data.Sql.BulkInsert.Attributes;

// SQL Table Name = Customers
[BulkInsertable("Customers")]
public class Customer
{
    // SQL Column Name = Id
    [BulkInsertColumn("Id")]
    public int Id { get; set; }

    // SQL Column Name = FirstName
    [BulkInsertColumn("FirstName")]
    public string FirstName { get; set; }

    // SQL Column Name = LastName
    [BulkInsertColumn("LastName")]
    public string LastName { get; set; }
}
```

The generator produces a `CustomerBulkInserter` static class which can be used to bulk insert a collection of items using `SqlBulkCopy`.

```csharp
List<Customer> customers = [/* ... */];
CustomerBulkInserter.Execute(connection, customers);
```

## Supported frameworks

- `netstandard2.0` (compatible with .NET Framework 4.6.2+, .NET Core 2.0+, .NET 5+)

## Install

```bash
dotnet add package JK.Common.Data.Sql.BulkInsert
```

## Build & Test

From repository root:

```bash
dotnet build src/Common.Data.Sql.BulkInsert/JK.Common.Data.Sql.BulkInsert.csproj
dotnet test src/Common.Data.Sql.BulkInsert.Tests.Unit/JK.Common.Data.Sql.BulkInsert.Tests.Unit.csproj
```
