# JK.Common.Data.Sql

A utility library providing helpers and operations for SQL Server data access, focused on high-performance bulk operations and convenience extensions for `Microsoft.Data.SqlClient`.

## Key features

- `SqlBulkInsertOperation` — a generic wrapper around bulk copy operations to simplify high-volume inserts.
- `SqlConnectionFactory` helpers and configuration patterns for creating connections consistently.
- `SqlBulkCopySettings` to centralize settings used by bulk operations.

## Supported frameworks

- `net10.0`, `net9.0`, `net8.0`, `netstandard2.0`

## Install

```bash
dotnet add package JK.Common.Data.Sql
```

## Build & Test

From repository root:

```bash
dotnet restore
cd src/JK.Common.Data.Sql
dotnet build
dotnet test
```
