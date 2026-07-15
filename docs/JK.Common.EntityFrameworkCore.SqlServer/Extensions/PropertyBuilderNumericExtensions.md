[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > PropertyBuilderNumericExtensions

# PropertyBuilderNumericExtensions

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Extensions`

Extension methods for configuring SQL Server numeric column types on **PropertyBuilder&lt;T&gt;** .

## HasColumnTypeDecimal(PropertyBuilder<Decimal> propertyBuilder, Int32 precision, Int32 scale)

**Signature:** `HasColumnTypeDecimal(PropertyBuilder<Decimal> propertyBuilder, Int32 precision, Int32 scale)`

**Summary:**
Configures the property to use the **decimal(precision, scale)** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

- **precision** — The precision of the column.

- **scale** — The scale of the column.

**Returns:** The property builder for chaining.

## HasColumnTypeDecimal(PropertyBuilder<Nullable<Decimal>> propertyBuilder, Int32 precision, Int32 scale)

**Signature:** `HasColumnTypeDecimal(PropertyBuilder<Nullable<Decimal>> propertyBuilder, Int32 precision, Int32 scale)`

**Summary:**
Configures the property to use the **decimal(precision, scale)** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

- **precision** — The precision of the column.

- **scale** — The scale of the column.

**Returns:** The property builder for chaining.

## HasColumnTypeMoney(PropertyBuilder<Decimal> propertyBuilder)

**Signature:** `HasColumnTypeMoney(PropertyBuilder<Decimal> propertyBuilder)`

**Summary:**
Configures the property to use the **money** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

**Returns:** The property builder for chaining.

## HasColumnTypeMoney(PropertyBuilder<Nullable<Decimal>> propertyBuilder)

**Signature:** `HasColumnTypeMoney(PropertyBuilder<Nullable<Decimal>> propertyBuilder)`

**Summary:**
Configures the property to use the **money** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

**Returns:** The property builder for chaining.