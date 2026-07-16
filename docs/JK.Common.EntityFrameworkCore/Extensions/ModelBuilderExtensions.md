[Docs](../../README.md) > [JK.Common.EntityFrameworkCore](../README.md) > ModelBuilderExtensions

# ModelBuilderExtensions

**Namespace:** `JK.Common.EntityFrameworkCore.Extensions`

Extension methods for **ModelBuilder**.

## ApplyAllAssemblyConfigurations *(Inherited)*

**Signature:** `ApplyAllAssemblyConfigurations(ModelBuilder, Assembly)`

**Summary:**
Applies all **IEntityTypeConfiguration&lt;T&gt;** implementations from the specified assembly.

**Parameters:**

- **assembly** — The assembly to scan. If **null**, the calling assembly is used.

## EnsureRelationshipDeleteBehavior *(Inherited)*

**Signature:** `EnsureRelationshipDeleteBehavior(ModelBuilder, DeleteBehavior)`

**Summary:**
Sets the delete behavior for all relationships in the model.

**Parameters:**

- **deleteBehavior** — The delete behavior to apply. Defaults to **NoAction**.