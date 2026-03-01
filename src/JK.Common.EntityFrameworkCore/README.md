# JK.Common.EntityFrameworkCore

A set of utilities and extensions for `Microsoft.EntityFrameworkCore` that simplify common patterns such as read-only contexts, auditing, and entity base classes.

## Key features

- `ReadOnlyDbContext` — a lightweight base `DbContext` for read-only scenarios.
- `AuditableEntity` and audit helpers — automatic `DateCreated`, `CreatedBy`, `DateModified`, `ModifiedBy` handling via SaveChanges interception.
- Conventions and helper extensions to simplify EF Core configuration and common patterns.

## Supported frameworks

- `net10.0`, `net9.0`, `net8.0`

## Install

```bash
dotnet add package JK.Common.EntityFrameworkCore
```

## Build & Test

From repository root:

```bash
dotnet restore
dotnet build src/JK.Common.EntityFrameworkCore/JK.Common.EntityFrameworkCore.csproj
dotnet test src/JK.Common.EntityFrameworkCore.Tests/JK.Common.EntityFrameworkCore.Tests.csproj
```