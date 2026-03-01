# JK.Common

A utility library containing boilerplate code, extension methods, new classes, and improvements to existing types. This package provides small, focused helpers intended to be used across server-side .NET projects.

## Key features

- Type helpers and extension methods for `string`, `DateTime`, `IQueryable`, `IEnumerable`, and other core types.
- `DeepCloner` for creating deep copies of objects.
- Template processing utilities for simple text/template scenarios.

## Supported frameworks

- `net10.0`, `net9.0`, `net8.0`, `netstandard2.0`

## Install

Install from NuGet:

```bash
dotnet add package JK.Common
```

## Build & test

From repository root:

```bash
dotnet restore
cd src/JK.Common
dotnet build JK.Common.csproj
dotnet test JK.Common.Tests.csproj
```
