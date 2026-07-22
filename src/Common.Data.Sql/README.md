# JK.Common.Data.Sql

A utility library providing helpers and operations for SQL Server data access, focused on high-performance bulk operations and convenience extensions for `Microsoft.Data.SqlClient`.

## Key features

- `SqlBulkInsertOperation` — a generic wrapper around bulk copy operations to simplify high-volume inserts.
- `SqlConnectionFactory` helpers and configuration patterns for creating connections consistently.
- `SqlBulkCopySettings` to centralize settings used by bulk operations.

> **Note:** `SqlBulkInsertOperation`, `SqlBulkCopySettings`, and `SqlBulkCopyExtensions` are obsolete. Use [JK.Common.Data.Sql.BulkInsert](../Common.Data.Sql.BulkInsert/README.md) for a source-generated alternative.

## Supported frameworks

- `net10.0`, `net9.0`, `net8.0`, `netstandard2.0`

## Install

```bash
dotnet add package JK.Common.Data.Sql
```

## Build & test

From repository root:

```bash
dotnet build src/Common.Data.Sql/JK.Common.Data.Sql.csproj
dotnet test src/Common.Data.Sql.Tests/JK.Common.Data.Sql.Tests.csproj
```
