[Docs](../README.md) > [JK.Common](README.md) > ThrowHelper

# ThrowHelper

**Namespace:** `JK.Common`

Provides helper methods for common argument validation and exception throwing.

### IfNull

**Signature:** ``IfNull(Object value, String paramName)``

**Summary:**
Throws an **ArgumentNullException** if the value is null.

**Parameters:**
- **value** — The value to validate.
- **paramName** — The name of the parameter.

**Remarks:**
### IfNullOrEmpty

**Signature:** ``IfNullOrEmpty(String value, String paramName)``

**Summary:**
Throws an **ArgumentException** if the value is null or empty.

**Parameters:**
- **value** — The value to validate.
- **paramName** — The name of the parameter.

**Remarks:**
### IfNullOrWhiteSpace

**Signature:** ``IfNullOrWhiteSpace(String value, String paramName)``

**Summary:**
Throws an **ArgumentException** if the value is null, empty, or whitespace.

**Parameters:**
- **value** — The value to validate.
- **paramName** — The name of the parameter.

**Remarks:**