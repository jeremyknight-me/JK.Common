[Docs](../../README.md) > [JK.Common.EntityFrameworkCore](../README.md) > AuditableSaveChangesInterceptor

# AuditableSaveChangesInterceptor

**Namespace:** `JK.Common.EntityFrameworkCore.Interceptors`

A **SaveChangesInterceptor** that automatically sets audit timestamps on **IAuditableEntity** instances.

## SavingChanges *(Inherited)*

**Signature:** `SavingChanges(DbContextEventData, InterceptionResult<Int32>)`

**Summary:**

## SavingChangesAsync *(Inherited)*

**Signature:** `SavingChangesAsync(DbContextEventData, InterceptionResult<Int32>, CancellationToken)`

**Summary:**