[Docs](../../README.md) > [JK.Common.EntityFrameworkCore](../README.md) > ModelBuilderExtensions

# ModelBuilderExtensions

**Namespace:** `JK.Common.EntityFrameworkCore.Extensions`

Extension methods for **ModelBuilder** .

<<<<<<< HEAD
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
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
### ApplyAllAssemblyConfigurations *(Inherited)*

**Signature:** ``ApplyAllAssemblyConfigurations(ModelBuilder, Assembly assembly)``

**Summary:**
Applies all **IEntityTypeConfiguration** implementations from the specified assembly.

**Parameters:**
- **assembly** — The assembly to scan. If **null** , the calling assembly is used.

**Remarks:**
### EnsureRelationshipDeleteBehavior *(Inherited)*

**Signature:** ``EnsureRelationshipDeleteBehavior(ModelBuilder, DeleteBehavior deleteBehavior)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Sets the delete behavior for all relationships in the model.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **deleteBehavior** — The delete behavior to apply. Defaults to **NoAction** .
=======
- **deleteBehavior** — The delete behavior to apply. Defaults to **NoAction** .

**Remarks:**
>>>>>>> initial docs folder changes
=======
- **deleteBehavior** — The delete behavior to apply. Defaults to **NoAction** .

**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
