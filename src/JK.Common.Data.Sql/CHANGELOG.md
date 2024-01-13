# Changelog - JK.Common.Data.Sql

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Unless otherwise noted, all changes made by [@jeremyknight-me](https://github.com/jeremyknight-me).

## 5.2.0

### Added

- Added support for .NET 8

### Changed

- Upgraded `JK.Common.Abstractions` to v1.1.0

## 5.1.0

### Added

- Added package `JK.Common.Abstractions` at v1.0.0

## 5.0.0

### Added

- Added `IsTimeoutError` extension method on `SqlException`.
- Added `UnsafeSqlExceptionFactory` to aid in unit testing. 

### Changed

- Upgraded to `JK.Common` to 5.0.0
- Refactored logic for some parameter creation to reduce duplication.

## 4.0.0

### Added

- .NET 7 to multi-targetting
- Added `SqlBulkCopy` extension method to provide better exception on column length SqlExceptions.
- Added `SqlParameterCollection` extension methods to allow for easier `SqlParameter` configuration.

### Removed

- Removed .NET Standard 2.1 from multi-targetting
- Removed `SqlParameterFactory`

## 3.0.2

### Added 

- Multi-targeting for .NET Standard 2.0

## 3.0.1

### Added 

- Multi-targeting for .NET Standard 2.1, .NET 5, and .NET 6

### Changed

- Changed from System.Data.SqlClient to Microsoft.Data.SqlClient

## 2.0.9 - 10 Dec 2020

### Added

- Added SqlParameterFactory
- Added SqlBulkInsertOperation
