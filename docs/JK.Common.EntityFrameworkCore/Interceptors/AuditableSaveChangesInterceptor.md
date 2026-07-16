[Docs](../../README.md) > [JK.Common.EntityFrameworkCore](../README.md) > AuditableSaveChangesInterceptor

# AuditableSaveChangesInterceptor

**Namespace:** `JK.Common.EntityFrameworkCore.Interceptors`

A **SaveChangesInterceptor** that automatically sets audit timestamps on **IAuditableEntity** instances.

## SavingChanges

**Signature:** `SavingChanges(DbContextEventData, InterceptionResult<Int32>)`

## SavingChangesAsync

**Signature:** `SavingChangesAsync(DbContextEventData, InterceptionResult<Int32>, CancellationToken)`