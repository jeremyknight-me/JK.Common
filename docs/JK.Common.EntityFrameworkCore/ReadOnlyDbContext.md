[Docs](../README.md) > [JK.Common.EntityFrameworkCore](README.md) > ReadOnlyDbContext

# ReadOnlyDbContext

**Namespace:** `JK.Common.EntityFrameworkCore`

A read-only **DbContext** that disables change tracking and throws on save attempts.

## ReadOnlyDbContext

**Signature:** `ReadOnlyDbContext()`

**Summary:**
Initializes a new instance of the **ReadOnlyDbContext** class.

## ReadOnlyDbContext

**Signature:** `ReadOnlyDbContext(DbContextOptions options)`

**Summary:**
Initializes a new instance of the **ReadOnlyDbContext** class.

**Parameters:**

- **options** — The options for this context.

## SaveChanges() *(Inherited)*

**Signature:** `SaveChanges()`

**Summary:**

## SaveChanges(Boolean) *(Inherited)*

**Signature:** `SaveChanges(Boolean)`

**Summary:**

## SaveChangesAsync(Boolean, CancellationToken) *(Inherited)*

**Signature:** `SaveChangesAsync(Boolean, CancellationToken)`

**Summary:**

## SaveChangesAsync(CancellationToken) *(Inherited)*

**Signature:** `SaveChangesAsync(CancellationToken)`

**Summary:**