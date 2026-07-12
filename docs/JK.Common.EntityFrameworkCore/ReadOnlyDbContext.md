[Docs](../README.md) > [JK.Common.EntityFrameworkCore](README.md) > ReadOnlyDbContext

# ReadOnlyDbContext

**Namespace:** `JK.Common.EntityFrameworkCore`

A read-only **DbContext** that disables change tracking and throws on save attempts.

### #ctor

**Signature:** ``#ctor()``

**Summary:**
Initializes a new instance of the **ReadOnlyDbContext** class.

**Remarks:**
### #ctor

**Signature:** ``#ctor(DbContextOptions options)``

**Summary:**
Initializes a new instance of the **ReadOnlyDbContext** class.

**Parameters:**
- **options** — The options for this context.

**Remarks:**
### SaveChanges *(Inherited)*

**Signature:** ``SaveChanges()``

**Summary:**

**Remarks:**
### SaveChanges *(Inherited)*

**Signature:** ``SaveChanges(Boolean)``

**Summary:**

**Remarks:**
### SaveChangesAsync *(Inherited)*

**Signature:** ``SaveChangesAsync(Boolean, CancellationToken)``

**Summary:**

**Remarks:**
### SaveChangesAsync *(Inherited)*

**Signature:** ``SaveChangesAsync(CancellationToken)``

**Summary:**

**Remarks:**