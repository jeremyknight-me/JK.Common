# JK.Common Code Library

A utility library containing boilerplate code, extension methods, new classes, and/or improvements to existing classes.
| Library | Status |
| ------------ | ------------ |
| JK.Common | [![Nuget](https://img.shields.io/nuget/v/JK.Common.svg)](https://www.nuget.org/packages/JK.Common/) |
| JK.Common.EntityFrameworkCore  | [![Nuget](https://img.shields.io/nuget/v/JK.Common.EntityFrameworkCore.svg)](https://www.nuget.org/packages/JK.Common.EntityFrameworkCore/)  |
| JK.Common.EntityFrameworkCore.SqlServer  | [![Nuget](https://img.shields.io/nuget/v/JK.Common.EntityFrameworkCore.SqlServer.svg)](https://www.nuget.org/packages/JK.Common.EntityFrameworkCore.SqlServer/)  |
| JK.Common.FluentValidation  | [![Nuget](https://img.shields.io/nuget/v/JK.Common.FluentValidation.svg)](https://www.nuget.org/packages/JK.Common.FluentValidation/)  |
| Cross Library CI | ![.NET Core CI](https://github.com/jeremyknight-me/JK.Common/workflows/.NET%20Core%20CI/badge.svg) |

## Components

### JK.Common

 - Type helpers and extension methods for string, date time, IQueryable, IEnumerable, etc.
 - Deep Cloner
 - Latitude and Longitude Classes
 - Template Processing

### JK.Common.EntityFrameworkCore Components

 - ReadOnlyDbContext 
 - Context wide value change auditing. 
 - AuditableEntity with DateCreated, CreatedBy, DateModified, ModifiedBy properties as well as helper class to automatically update properties on SaveChanges

### JK.Common.EntityFrameworkCore.SqlServer Components

 - PropertyBuilderExtensions (HasColumnTypeDateTime, HasColumnTypeNvarchar, etc.)

### JK.Common.FluentValidation

 - Custom validators (address, email, etc.)
