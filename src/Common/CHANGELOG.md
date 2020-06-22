# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Unless otherwise noted, all changes made by [@jeremyknight-me](https://github.com/jeremyknight-me).

## [Unreleased]

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

### Changed

- Moved testable DateTime providers to their own folder/namespace.
- Moved converters to their own folder/namespace.

## [1.0.6] - 05 Oct 2019

### Added

- Added AddWorkDays function to DateTimeHelper.

### Changed
- Updated email validation regex.
- Upgraded .NET version to Core 3.0.

[Unreleased]: https://github.com/jeremyknight-me/JK.Common/compare/1.0.6...HEAD
[1.0.6]: https://github.com/jeremyknight-me/JK.Common/compare/1.0.5...1.0.6
