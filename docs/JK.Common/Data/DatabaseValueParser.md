[Docs](../../README.md) > [JK.Common](../README.md) > DatabaseValueParser

# DatabaseValueParser

**Namespace:** `JK.Common.Data`

Static class which adds database value parsing.

## GetValueOrDefault<T>(Object value)

**Signature:** `GetValueOrDefault<T>(Object value)`

**Summary:**
Gets the value of an object or returns the objects default type.

**Parameters:**

- **value** — Object to test.

**Returns:** Object's type default if DBNull, otherwise the object's value.

## GetValueOrDefault<T>(Object value, T defaultValue)

**Signature:** `GetValueOrDefault<T>(Object value, T defaultValue)`

**Summary:**
Gets the value of an object or returns the given default value.

**Parameters:**

- **value** — Object to test.

- **defaultValue** — Value to use is DBNull.

**Returns:** Given default value if DBNull, otherwise the object's value.

## GetValueOrNull

**Signature:** `GetValueOrNull<T>(Object value)`

**Summary:**
Gets the value of an object or null.

**Parameters:**

- **value** — Object to test.

**Returns:** Null if DBNull, otherwise the object's value.

## GetValueOrDbNull

**Signature:** `GetValueOrDbNull<T>(Nullable<T> nullable)`

**Summary:**
Get value or DbNull from a Nullable type.

**Parameters:**

- **nullable** — Object to get value or DbNull.

**Returns:** If not null value of object, otherwise DbNull.