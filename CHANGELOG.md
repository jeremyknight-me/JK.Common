# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Unless otherwise noted, all changes made by [@jeremyknight-me](https://github.com/jeremyknight-me).

## [Unreleased]

### Common

#### Added 

- Added DateTimeOffsetFactory to allow creating of DateTimeOffset from DateTime and TimeZoneId.
- Added DateTimeOffset overloads for all DateHelper methods.
- Added DateTimeOffset extension methods to match current DateTime extensions.
- Added math helpers for Fibonacci, IsEven, and IsOdd
- Added AsIndexedEnumerable extension method
- Added IsNullable check to determine if a type is using Nullable<T>

#### Changed

- Renamed DateTimeHelper to DateHelper to add DateTimeOffset overloads.
- Changed all DateHelper methods to static.

## [2.0.9] - 10 Dec 2020

### All

#### Added

- Added .editorconfig file

### Common

#### Added

- Added EquatableFacade<T>
- Added IsBetween DateTimeHelper/Extension method
- Added DoesOverlap DateTimeHelper method
  
#### Changed

- Changed DateTime/DateTimeOffset providers to use interfaces for dependency injection
- Changed ADO operation classes to work in .NET Core

### Common.Data.Sql

#### Added

- Added library
- Added SqlParameterFactory
- Added SqlBulkInsertOperation

### EntityFrameworkCore.SqlServer

#### Changed

- Changed PropertyBuilderExtensions to be type specific

## 2.0.6 - 23 June 2020

### Common

#### Added

- Added DistinctBy extension to IEnumerable.
- Added DoesImplement<T> to TypeExtensions.
- Added GetAttribute<T> to EnumHelper.
- Added new helper class ExcelHelper with GetColumnName(int columnNumber). 
- Added generic ADO classes for reference purposes (migrated from older code). 
- Added Gzip helper class with CompressFile and DecompressFile methods. 
- Added ServiceLocator namespace with basic pattern implementation.
- Added DistanceConverter class and DistanceUnit enum. 
- Added InMemory data repositories for reference purposes (migrated from older code).
- Added ADO Auditing for reference purposes (migrated from older code).

#### Changed

- Moved testable DateTime providers to their own folder/namespace.
- Moved converters to their own folder/namespace.

### EntityFrameworkCore

#### Added

- Added ReadOnlyDbContext.
- Added AuditableEntity and AuditableEntitySaveChangesHelper.
- Added AuditLog and AuditLogSaveChangesHelper.

### EntityFrameworkCore.SqlServer

#### Added

- Added PropertyBuilderExtensions.

## 1.0.6 - 05 Oct 2019

### Added

- Added AddWorkDays function to DateTimeHelper.

### Changed
- Updated email validation regex.
- Upgraded .NET version to Core 3.0.

[Unreleased]: https://github.com/jeremyknight-me/JK.Common/compare/v2.0.9...HEAD
[2.0.9]: https://github.com/jeremyknight-me/JK.Common/compare/2.0.6...v2.0.9
