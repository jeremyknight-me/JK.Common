[Docs](../../README.md) > [JK.Common.EntityFrameworkCore](../README.md) > ModelBuilderExtensions

# ModelBuilderExtensions

**Namespace:** `JK.Common.EntityFrameworkCore.Extensions`

Extension methods for **ModelBuilder**.

## ApplyAllAssemblyConfigurations

**Signature:** `ApplyAllAssemblyConfigurations(ModelBuilder, Assembly)`

**Summary:**
Applies all **`IEntityTypeConfiguration<T>`** implementations from the specified assembly.

**Parameters:**

- **assembly** — The assembly to scan. If **null**, the calling assembly is used.

## EnsureRelationshipDeleteBehavior

**Signature:** `EnsureRelationshipDeleteBehavior(ModelBuilder, DeleteBehavior)`

**Summary:**
Sets the delete behavior for all relationships in the model.

**Parameters:**

- **deleteBehavior** — The delete behavior to apply. Defaults to **NoAction**.