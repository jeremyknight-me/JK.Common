[Docs](../../README.md) > [JK.Common.EntityFrameworkCore](../README.md) > ModelBuilderExtensions

# ModelBuilderExtensions

**Namespace:** `JK.Common.EntityFrameworkCore.Extensions`

Extension methods for **ModelBuilder** .

<<<<<<< HEAD
## ApplyAllAssemblyConfigurations *(Inherited)*

**Signature:** `ApplyAllAssemblyConfigurations(ModelBuilder, Assembly assembly)`

**Summary:**
Applies all **IEntityTypeConfiguration&lt;T&gt;** implementations from the specified assembly.

**Parameters:**

- **assembly** — The assembly to scan. If **null** , the calling assembly is used.

## EnsureRelationshipDeleteBehavior *(Inherited)*

**Signature:** `EnsureRelationshipDeleteBehavior(ModelBuilder, DeleteBehavior deleteBehavior)`
=======
### ApplyAllAssemblyConfigurations *(Inherited)*

**Signature:** ``ApplyAllAssemblyConfigurations(ModelBuilder, Assembly assembly)``

**Summary:**
Applies all **IEntityTypeConfiguration** implementations from the specified assembly.

**Parameters:**
- **assembly** — The assembly to scan. If **null** , the calling assembly is used.

**Remarks:**
### EnsureRelationshipDeleteBehavior *(Inherited)*

**Signature:** ``EnsureRelationshipDeleteBehavior(ModelBuilder, DeleteBehavior deleteBehavior)``
>>>>>>> initial docs folder changes

**Summary:**
Sets the delete behavior for all relationships in the model.

**Parameters:**
<<<<<<< HEAD

- **deleteBehavior** — The delete behavior to apply. Defaults to **NoAction** .
=======
- **deleteBehavior** — The delete behavior to apply. Defaults to **NoAction** .

**Remarks:**
>>>>>>> initial docs folder changes
