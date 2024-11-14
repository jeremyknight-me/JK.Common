# Changelog - JK.Common.EntityFrameworkCore

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Unless otherwise noted, all changes made by [@jeremyknight-me](https://github.com/jeremyknight-me).

## 5.0.0

### Added

- Added support for .NET 9.
- Added `AuditableSaveChangesInterceptor`

### Changed

- Updated `Microsoft.EntityFrameworkCore.SqlServer`

### Removed

- Removed support for .NET Standard 2.0 and .NET 6
- Removed `ChangeTrackerExtensions` in favor of interceptor

## 4.1.0

### Added

- Added support for .NET 8

## 4.0.0

### Added

- Added `ChangeTrackerExtensions.EnsureAuditableEntitiesUpdated` extension method

### Changed

- Changed multi-targeting to include .NET Standard 2.0 and .NET 7
- Changed `AuditableEntity` to handle dates only.

### Removed

- Removed .NET Standard 2.1 and .NET 5 from multi-targetting
- Removed column level auditing in favor of tools like SQL Server's Temporal Tables.

## 3.0.1

### Added 

- Multi-targeting for .NET Standard 2.1, .NET 5, and .NET 6

## 2.0.6 - 23 June 2020

### Added

- Added ReadOnlyDbContext.
- Added AuditableEntity and AuditableEntitySaveChangesHelper.
- Added AuditLog and AuditLogSaveChangesHelper.