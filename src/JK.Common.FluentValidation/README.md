# JK.Common.FluentValidation

A collection of reusable `FluentValidation` validators and extension helpers for common validation scenarios.

## Key features

- Common validators for addresses, emails, and other reusable rules.
- Extension methods to integrate `FluentValidation` rules with shared models across services.

## Supported frameworks

- `net10.0`, `net9.0`, `net8.0`

## Install

```bash
dotnet add package JK.Common.FluentValidation
```

## Build & Test

From repository root:

```bash
dotnet restore
dotnet build src/JK.Common.FluentValidation/JK.Common.FluentValidation.csproj
dotnet test src/JK.Common.FluentValidation.Tests/JK.Common.FluentValidation.Tests.csproj
```
