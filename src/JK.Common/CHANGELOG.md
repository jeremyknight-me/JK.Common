# Changelog - JK.Common

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Unless otherwise noted, all changes made by [@jeremyknight-me](https://github.com/jeremyknight-me).

## Unreleased

### Added 

- Added INameable and ISortable interfaces
- Added Singleton pattern Lazy<T> implementation reference class
- Added DateOnly version of DateHelper methods. 
- Added DateOnly extension methods.
- Added DecimalHelper with `GetDecimalPart` and `GetWholePart` methods
- Added RegexHelper with multiple built in pattern searches
- Added sorting algorithm implementations: QuickSort, MergeSort

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
- Added DateTimeOffset overloads for all DateHelper methods.
- Added DateTimeOffset extension methods to match current DateTime extensions.
- Added math helpers for Fibonacci, IsEven, and IsOdd
- Added AsIndexedEnumerable extension method
- Added IsNullable check to determine if a type is using Nullable<T>

### Changed

- Renamed DateTimeHelper to DateHelper to add DateTimeOffset overloads.
- Changed all DateHelper methods to static.
