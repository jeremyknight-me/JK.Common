# Changelog - JK.Common.Data.Sql.BulkInsert

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Unless otherwise noted, all changes made by [@jeremyknight-me](https://github.com/jeremyknight-me).

## 1.0.0 - Unreleased

### Added

- Added Roslyn source generator `BulkInsertGenerator` that emits type-safe `SqlBulkCopy` helper classes at compile time.
- Added `BulkInsertableAttribute` to mark a class as bulk-insertable and specify its SQL table name.
- Added `BulkInsertColumnAttribute` to map an entity property to a SQL column.
- Generated inserters expose `TableName`, `ColumnMappings`, and an `Execute` method using `SqlBulkCopy`.
- Added improved error reporting for SQL column length violations.
