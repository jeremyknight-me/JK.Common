[Docs](../../README.md) > [JK.Common.EntityFrameworkCore](../README.md) > ModelBuilderExtensions

# ModelBuilderExtensions

**Namespace:** `JK.Common.EntityFrameworkCore.Extensions`

Extension methods for **ModelBuilder** .

### ApplyAllAssemblyConfigurations *(Inherited)*

**Signature:** ``ApplyAllAssemblyConfigurations(ModelBuilder, Assembly assembly)``

**Summary:**
Applies all **IEntityTypeConfiguration** implementations from the specified assembly.

**Parameters:**
- **assembly** — The assembly to scan. If **null** , the calling assembly is used.

**Remarks:**
### EnsureRelationshipDeleteBehavior *(Inherited)*

**Signature:** ``EnsureRelationshipDeleteBehavior(ModelBuilder, DeleteBehavior deleteBehavior)``

**Summary:**
Sets the delete behavior for all relationships in the model.

**Parameters:**
- **deleteBehavior** — The delete behavior to apply. Defaults to **NoAction** .

**Remarks:**