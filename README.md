# JK.Common Code Library

A utility library containing boilerplate code, extension methods, new classes, and/or improvements to existing classes.  

[![buy me a coffee button](https://img.shields.io/badge/buy%20me%20a%20coffee-donate-yellowgreen)](https://ko-fi.com/jeremyknight) ![GitHub last commit](https://img.shields.io/github/last-commit/jeremyknight-me/JK.Common?color=red) [![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](CODE_OF_CONDUCT.md)

| Library (Link = Changelog) | CI | Download |
| ------------ | ------------ | ------------ |
| [JK.Common](src/JK.Common/CHANGELOG.md) | [![JK.Common CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.svg)](https://www.nuget.org/packages/JK.Common/) |
| [JK.Common.Abstractions](src/JK.Common.Abstractions/CHANGELOG.md) | [![Common.Abstractions CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-abstractions.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-abstractions.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.Abstractions.svg)](https://www.nuget.org/packages/JK.Common.Abstractions/) |
| [JK.Common.Data.Sql](src/JK.Common.Data.Sql/CHANGELOG.md) | [![JK.Common.Data.SQL CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-data-sql.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-data-sql.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.Data.Sql.svg)](https://www.nuget.org/packages/JK.Common.Data.Sql/) |
| [JK.Common.EntityFrameworkCore](src/JK.Common.EntityFrameworkCore/CHANGELOG.md) | [![JK.Common.EFCore CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-efcore.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-efcore.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.EntityFrameworkCore.svg)](https://www.nuget.org/packages/JK.Common.EntityFrameworkCore/)  |
| [JK.Common.EntityFrameworkCore.SqlServer](src/JK.Common.EntityFrameworkCore.SqlServer/CHANGELOG.md) | [![JK.Common.EFCore.SqlServer CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-efcore-sql.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-efcore-sql.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.EntityFrameworkCore.SqlServer.svg)](https://www.nuget.org/packages/JK.Common.EntityFrameworkCore.SqlServer/)  |
| [JK.Common.FluentValidation](src/JK.Common.FluentValidation/CHANGELOG.md) | [![Common.FluentValidation CI](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-fluentvalidation.yml/badge.svg)](https://github.com/jeremyknight-me/JK.Common/actions/workflows/ci-common-fluentvalidation.yml) | [![Nuget](https://img.shields.io/nuget/v/JK.Common.FluentValidation.svg)](https://www.nuget.org/packages/JK.Common.FluentValidation/)  |

## Components

### JK.Common

 - Type helpers and extension methods for string, date time, IQueryable, IEnumerable, etc.
 - Deep Cloner
 - Latitude and Longitude Classes
 - Template Processing

### JK.Common.Data.Sql
 - Generic SqlBulkCopy Operation

### JK.Common.EntityFrameworkCore Components

 - ReadOnlyDbContext 
 - Context wide value change auditing. 
 - AuditableEntity with DateCreated, CreatedBy, DateModified, ModifiedBy properties as well as helper class to automatically update properties on SaveChanges

### JK.Common.EntityFrameworkCore.SqlServer Components

 - PropertyBuilderExtensions (HasColumnTypeDateTime, HasColumnTypeNvarchar, etc.)

### JK.Common.FluentValidation

 - Custom validators (address, email, etc.)
