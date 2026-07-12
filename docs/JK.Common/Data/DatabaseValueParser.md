[Docs](../../README.md) > [JK.Common](../README.md) > DatabaseValueParser

# DatabaseValueParser

**Namespace:** `JK.Common.Data`

Static class which adds database value parsing.

### GetValueOrDefault`

**Signature:** ``GetValueOrDefault`(Object value)``

**Summary:**
Gets the value of an object or returns the objects default type.

**Parameters:**
- **value** — Object to test.

**Returns:** Object's type default if DBNull, otherwise the object's value.

**Remarks:**
### GetValueOrDefault`

**Signature:** ``GetValueOrDefault`(Object value, ``0 defaultValue)``

**Summary:**
Gets the value of an object or returns the given default value.

**Parameters:**
- **value** — Object to test.
- **defaultValue** — Value to use is DBNull.

**Returns:** Given default value if DBNull, otherwise the object's value.

**Remarks:**
### GetValueOrNull`

**Signature:** ``GetValueOrNull`(Object value)``

**Summary:**
Gets the value of an object or null.

**Parameters:**
- **value** — Object to test.

**Returns:** Null if DBNull, otherwise the object's value.

**Remarks:**
### GetValueOrDbNull`

**Signature:** ``GetValueOrDbNull`(Nullable{``0} nullable)``

**Summary:**
Get value or DbNull from a Nullable type.

**Parameters:**
- **nullable** — Object to get value or DbNull.

**Returns:** If not null value of object, otherwise DbNull.

**Remarks:**