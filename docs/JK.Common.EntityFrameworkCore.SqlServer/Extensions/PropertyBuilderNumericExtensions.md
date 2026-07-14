[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > PropertyBuilderNumericExtensions

# PropertyBuilderNumericExtensions

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Extensions`

Extension methods for configuring SQL Server numeric column types on **PropertyBuilder** .

### HasColumnTypeDecimal

**Signature:** `HasColumnTypeDecimal(Decimal> propertyBuilder, Int32 precision, Int32 scale)`

**Summary:**
Configures the property to use the **decimal(precision, scale)** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

- **precision** — The precision of the column.

- **scale** — The scale of the column.

**Returns:** The property builder for chaining.

### HasColumnTypeDecimal

**Signature:** `HasColumnTypeDecimal(Decimal>> propertyBuilder, Int32 precision, Int32 scale)`

**Summary:**
Configures the property to use the **decimal(precision, scale)** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

- **precision** — The precision of the column.

- **scale** — The scale of the column.

**Returns:** The property builder for chaining.

### HasColumnTypeMoney

**Signature:** `HasColumnTypeMoney(Decimal> propertyBuilder)`

**Summary:**
Configures the property to use the **money** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

**Returns:** The property builder for chaining.

### HasColumnTypeMoney

**Signature:** `HasColumnTypeMoney(Decimal>> propertyBuilder)`

**Summary:**
Configures the property to use the **money** SQL Server column type.

**Parameters:**

- **propertyBuilder** — The property builder.

**Returns:** The property builder for chaining.