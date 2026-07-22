# JK.Common.Polyfills

A Roslyn source generator that emits polyfill source files for missing language and runtime features on older target frameworks.

## Supported Polyfills

| Polyfill | Description |
|----------|---------|
| `IsExternalInit` | Enables `init`-only property setters. Emits only when targeting frameworks older than .NET 5 (`#if !NET5_0_OR_GREATER`) |

### Key features

- Conditionally emits polyfills only when the consuming project does not already define them.
- Zero runtime dependency — polyfills are source-generated at compile time.

## Supported frameworks

- `netstandard2.0` (compatible with .NET Framework 4.6.2+, .NET Core 2.0+, .NET 5+)

## Install

```bash
dotnet add package JK.Common.Polyfills
```

## Build & Test

From repository root:

```bash
dotnet build src/Common.Polyfills/JK.Common.Polyfills.csproj
dotnet test src/Common.Polyfills.Tests/JK.Common.Polyfills.Tests.csproj
```
