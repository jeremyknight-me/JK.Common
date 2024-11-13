# Changelog - JK.Common

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Unless otherwise noted, all changes made by [@jeremyknight-me](https://github.com/jeremyknight-me).

## Unreleased

## Added

- Added support for .NET 9.
- `IsNullable` helper method in `TypeHelper`

## Changed

- `IsNullable`  to `IsNullableT` int `TypeHelper`.
- Moved `ServiceLocator` folder to `Patterns` folder.

### Removed

- Removed support for .NET 6.

## 5.2.0

### Added

- .NET 8.0 to multi-targetting

## 5.0.1

### Added

- Added package `JK.Common.Abstractions` at v1.0.0

### Removed

- Removed obsolete `Data.InMemory` namespace.
- Removed interfaces taken over by `JK.Common.Abstractions`

## 5.0.0

### Added

- Added `TransactionScopeFactory`

### Changed

- Changed ADO base classes to allow for more flexibility.

### Removed

- Removed `IAdoDatabase` and `AdoDatabase`

## 4.1.0

### Added

- Added `Parse` methods to `SpanExtensions`
- Added `Parse` methods to `StringExtensions`
- Added `Range` and `Index` "polyfills"
- Added Regex code generation to `RegexHelper`
- Added `HasItem` extension methods for `ICollection<T>` and `IReadOnlyCollection<T>`

### Changed

- Changed `DateTimeOffsetFactory` to static class.
- Changed `StringHelper.Right` to use range operator

## 4.0.0

### Added

- .NET 7 to multi-targetting
- Added `Slice` methods to `StringHelper` to take advantage of `Span<T>`
- Added `DeserializeString` method to `XmlSerializerHelper`

### Changed

- Changed Latitude and Longitude to use `decimal` instead of `double`
- Renamed `XmlSerializationFacade` to `XmlSerializerHelper` and moved to `TypeHelpers`
- Renamed `GetXmlAsString` method to `Serialize` in `XmlSerializerHelper`
- Renamed `NonQueryOperation` class to `NonQueryOperationBase`

### Removed

- Removed .NET Standard 2.1 from multi-targetting
- Removed `IParameterFactory`, `ParameterFactoryBase`, and `AdoParameterFactory`

## 3.1.0

### Added 

- Added `INameable` and `ISortable` interfaces
- Added Singleton pattern `Lazy<T>` implementation reference class
- Added `DateOnly` version of DateHelper methods. 
- Added `DateOnly` extension methods.
- Added DecimalHelper with `GetDecimalPart` and `GetWholePart` methods
- Added RegexHelper with multiple built in pattern searches
- Added sorting algorithms: Bubble, Heap, Insertion, Merge, Quick, Selection, Shell

### Changed

- Changed Singleton pattern reference class to `internal` as they are meant for reference only.

## 3.0.2

### Added

- .NET Standard 2.0 to multi-targetting

## 3.0.1

### Added

- Last alias for Right on StringHelper

### Changed

- Changed StringHelper to static class

## 3.0.0

### Added 

- Added DateTimeOffsetFactory to allow creating of DateTimeOffset from DateTime and TimeZoneId.
- Added `DateTimeOffset` overloads for all DateHelper methods.
- Added `DateTimeOffset` extension methods to match current DateTime extensions.
- Added math helpers for Fibonacci, IsEven, and IsOdd
- Added AsIndexedEnumerable extension method
- Added IsNullable check to determine if a type is using Nullable<T>

### Changed

- Renamed DateTimeHelper to DateHelper to add DateTimeOffset overloads.
- Changed all DateHelper methods to static.

## 2.0.9 - 10 Dec 2020

### Added

- Added EquatableFacade<T>
- Added IsBetween DateTimeHelper/Extension method
- Added DoesOverlap DateTimeHelper method
  
### Changed

- Changed DateTime/DateTimeOffset providers to use interfaces for dependency injection
- Changed ADO operation classes to work in .NET Core

## 2.0.6 - 23 June 2020

### Added

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

### Changed

- Moved testable DateTime providers to their own folder/namespace.
- Moved converters to their own folder/namespace.

## 1.0.6 - 05 Oct 2019

### Added

- Added AddWorkDays function to DateTimeHelper.

### Changed
- Updated email validation regex.
- Upgraded .NET version to Core 3.0.
