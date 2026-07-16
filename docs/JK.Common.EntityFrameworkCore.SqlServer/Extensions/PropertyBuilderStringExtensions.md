[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > PropertyBuilderStringExtensions

# PropertyBuilderStringExtensions

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Extensions`

Extension methods for configuring SQL Server string column types on **PropertyBuilder&lt;T&gt;**.

## HasColumnTypeNvarchar(PropertyBuilder<String> propertyBuilder)

**Signature:** `HasColumnTypeNvarchar(PropertyBuilder<String> propertyBuilder)`

**Summary:**
Configures the property to use the **nvarchar(max)** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

**Returns:** The property builder for chaining.

## HasColumnTypeNvarchar(PropertyBuilder<String> propertyBuilder, Int32 length)

**Signature:** `HasColumnTypeNvarchar(PropertyBuilder<String> propertyBuilder, Int32 length)`

**Summary:**
Configures the property to use the **nvarchar(length)** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

- **length** — The maximum length of the column.

**Returns:** The property builder for chaining.

## HasColumnTypeVarchar(PropertyBuilder<String> propertyBuilder)

**Signature:** `HasColumnTypeVarchar(PropertyBuilder<String> propertyBuilder)`

**Summary:**
Configures the property to use the **varchar(max)** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

**Returns:** The property builder for chaining.

## HasColumnTypeVarchar(PropertyBuilder<String> propertyBuilder, Int32 length)

**Signature:** `HasColumnTypeVarchar(PropertyBuilder<String> propertyBuilder, Int32 length)`

**Summary:**
Configures the property to use the **varchar(length)** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

- **length** — The maximum length of the column.

**Returns:** The property builder for chaining.