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

## SaveChanges()

**Signature:** `SaveChanges()`

## SaveChanges(Boolean)

**Signature:** `SaveChanges(Boolean)`

## SaveChangesAsync(Boolean, CancellationToken)

**Signature:** `SaveChangesAsync(Boolean, CancellationToken)`

## SaveChangesAsync(CancellationToken)

**Signature:** `SaveChangesAsync(CancellationToken)`