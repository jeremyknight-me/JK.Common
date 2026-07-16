[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > PropertyBuilderExtensions

# PropertyBuilderExtensions

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Extensions`

Extension methods for configuring SQL Server column types on **`PropertyBuilder<T>`**.

## HasColumnTypeUniqueIdentifier(PropertyBuilder<Guid> propertyBuilder)

**Signature:** `HasColumnTypeUniqueIdentifier(PropertyBuilder<Guid> propertyBuilder)`

**Summary:**
Configures the property to use the **uniqueidentifier** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

**Returns:** The property builder for chaining.

## HasColumnTypeUniqueIdentifier(PropertyBuilder<Nullable<Guid>> propertyBuilder)

**Signature:** `HasColumnTypeUniqueIdentifier(PropertyBuilder<Nullable<Guid>> propertyBuilder)`

**Summary:**
Configures the property to use the **uniqueidentifier** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

**Returns:** The property builder for chaining.