# JK.Common.EntityFrameworkCore.SqlServer

A set of extensions and helpers for `Microsoft.EntityFrameworkCore.SqlServer` that simplify common SQL Server-specific mappings and conventions.

## Key features

- `PropertyBuilderExtensions` — helpers such as `HasColumnTypeDateTime`, `HasColumnTypeNvarchar` to standardize column mappings.
- Convenience methods for applying SQL Server-specific configuration and migrations-friendly defaults.

## Supported frameworks

- `net10.0`, `net9.0`, `net8.0`

## Install

```bash
dotnet add package JK.Common.EntityFrameworkCore.SqlServer
```

## Build & Test

From repository root:

```bash
dotnet restore
dotnet build src/Common.EntityFrameworkCore.SqlServer/JK.Common.EntityFrameworkCore.SqlServer.csproj
```

Run EFCore-related tests via the root test project(s) targeting EF Core.
