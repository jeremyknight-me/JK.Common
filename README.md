# JK.Common Code Library

A collection of reusable .NET utilities and extension methods. The collection of JK.Common packages provide general-purpose helpers (string, date/time, collections), EF Core utilities, SQL bulk operations, and FluentValidation extensions to speed development of server-side services.

[![buy me a coffee button](https://img.shields.io/badge/buy%20me%20a%20coffee-donate-yellowgreen)](https://ko-fi.com/jeremyknight) ![GitHub last commit](https://img.shields.io/github/last-commit/jeremyknight-me/JK.Common?color=red) [![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](CODE_OF_CONDUCT.md)

| Library (Link = Changelog) | CI | Download |
| ------------ | ------------ | ------------ |
| [JK.Common](src/Common/CHANGELOG.md) | [![JK.Common CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.svg)](https://www.nuget.org/packages/JK.Common/) |
| [JK.Common.Data.Sql](src/Common.Data.Sql/CHANGELOG.md) | [![JK.Common.Data.SQL CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-data-sql.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-data-sql.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.Data.Sql.svg)](https://www.nuget.org/packages/JK.Common.Data.Sql/) |
| [JK.Common.Data.Sql.BulkInsert](src/Common.Data.Sql.BulkInsert/CHANGELOG.md) | | [![Nuget](https://img.shields.io/nuget/v/JK.Common.Data.Sql.BulkInsert.svg)](https://www.nuget.org/packages/JK.Common.Data.Sql.BulkInsert/) |
| [JK.Common.EntityFrameworkCore](src/Common.EntityFrameworkCore/CHANGELOG.md) | [![JK.Common.EFCore CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-efcore.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-efcore.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.EntityFrameworkCore.svg)](https://www.nuget.org/packages/JK.Common.EntityFrameworkCore/)  |
| [JK.Common.EntityFrameworkCore.SqlServer](src/Common.EntityFrameworkCore.SqlServer/CHANGELOG.md) | [![JK.Common.EFCore.SqlServer CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-efcore-sql.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-efcore-sql.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.EntityFrameworkCore.SqlServer.svg)](https://www.nuget.org/packages/JK.Common.EntityFrameworkCore.SqlServer/)  |
| [JK.Common.FluentValidation](src/Common.FluentValidation/CHANGELOG.md) | [![Common.FluentValidation CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-fluentvalidation.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-fluentvalidation.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.FluentValidation.svg)](https://www.nuget.org/packages/JK.Common.FluentValidation/)  |
| [JK.Common.Polyfills](src/Common.Polyfills/CHANGELOG.md) | | [![Nuget](https://img.shields.io/nuget/v/JK.Common.Polyfills.svg)](https://www.nuget.org/packages/JK.Common.Polyfills/) |

## Packages & Features

- **JK.Common:** Helpers for `string`, `DateTime`, `IQueryable`, `IEnumerable`, deep cloning (`DeepCloner`), template processing utilities, and small geospatial types (latitude/longitude). Usage & docs: [src/Common/README.md](src/Common/README.md)
- **JK.Common.Data.Sql:** Generic `SqlBulkCopy` operation and helpers for bulk insertion. Usage & docs: [src/Common.Data.Sql/README.md](src/Common.Data.Sql/README.md)
- **JK.Common.Data.Sql.BulkInsert:** A Roslyn source generator that creates type-safe `SqlBulkCopy` helper classes at compile time. Usage & docs: [src/Common.Data.Sql.BulkInsert/README.md](src/Common.Data.Sql.BulkInsert/README.md)
- **JK.Common.EntityFrameworkCore:** `ReadOnlyDbContext`, `AuditableEntity` with automatic audit property updates via SaveChanges interceptors. Usage & docs: [src/Common.EntityFrameworkCore/README.md](src/Common.EntityFrameworkCore/README.md)
- **JK.Common.EntityFrameworkCore.SqlServer:** `PropertyBuilderExtensions` (`HasColumnTypeDateTime`, `HasColumnTypeNvarchar`, etc.) to simplify EF Core mappings. Usage & docs: [src/Common.EntityFrameworkCore.SqlServer/README.md](src/Common.EntityFrameworkCore.SqlServer/README.md)
- **JK.Common.FluentValidation:** Common validators (address, email, etc.) to reuse across services. Usage & docs: [src/Common.FluentValidation/README.md](src/Common.FluentValidation/README.md)
- **JK.Common.Polyfills:** A Roslyn source generator that emits polyfill types for missing language features on older target frameworks. Usage & docs: [src/Common.Polyfills/README.md](src/Common.Polyfills/README.md)

> Notes: 
> - `DistanceConverter`, `TemperatureConverter`, and `TimeConverter` were removed — prefer `UnitsNet` for unit conversions. 
> - `JK.Common.OpenXml` removed — prefer `ClosedXML`.
> - `SqlBulkInsertOperation` in JK.Common.Data.Sql is obsolete — prefer JK.Common.Data.Sql.BulkInsert.

## Contributing

- Follow the `.editorconfig` rules in `src/.editorconfig`.
- Create feature branches from `main` and open a PR with a descriptive summary.
- Add unit tests for new behavior; run `dotnet test` locally.
- CI runs on PRs; ensure checks pass before merging.
- For release/versioning: update package versions and changelogs in the package folders.

## License & Code of Conduct

- Code of Conduct: `CODE_OF_CONDUCT.md`
- License: See `LICENSE` in repository root.

## Release Notes & Changelog

Each package has its own changelog; see the links in the table above.
