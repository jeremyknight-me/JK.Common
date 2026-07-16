[Docs](../../../README.md) > [JK.Common](../../README.md) > DataRecordExtensions

# DataRecordExtensions

**Namespace:** `JK.Common.Data.Extensions`

Extension methods for IDataRecord

## GetValueOrDefault<T>(IDataRecord, String) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, String)`

**Summary:**
Gets the value of the given field from the data reader or the default for the object type.

**Parameters:**

- **name** — Name of field within IDataRecord.

**Returns:** The given field's value or the default for the object type.

## GetValueOrDefault<T>(IDataRecord, String, T) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, String, T)`

**Summary:**
Gets the value of the given field from the data reader or the default for the object type.

**Parameters:**

- **name** — Name of field within IDataRecord.

- **defaultValue** — Value to use if null field value.

**Returns:** The given field's value or the given default.

## GetValueOrDefault<T>(IDataRecord, Int32) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, Int32)`

**Summary:**
Gets the value of the given field from the data reader or the default for the object type.

**Parameters:**

- **index** — Index of field within IDataRecord.

**Returns:** The given field's value or the default for the object type.

## GetValueOrDefault<T>(IDataRecord, Int32, T) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, Int32, T)`

**Summary:**
Gets the value of the given field from the data reader or the default for the object type.

**Parameters:**

- **index** — Index of field within IDataRecord.

- **defaultValue** — Value to use if null field value.

**Returns:** The given field's value or the given default.

## GetValueOrNull<T>(IDataRecord, String) *(Inherited)*

**Signature:** `GetValueOrNull<T>(IDataRecord, String)`

**Summary:**
Gets the value of the given field from the data reader or null.

**Parameters:**

- **name** — Name of field within IDataRecord.

**Returns:** The given field's value or null.

## GetValueOrNull<T>(IDataRecord, Int32) *(Inherited)*

**Signature:** `GetValueOrNull<T>(IDataRecord, Int32)`

**Summary:**
Gets the value of the given field from the data reader or null.

**Parameters:**

- **index** — Index of field within IDataRecord.

**Returns:** The given field's value or null.

## HasColumn *(Inherited)*

**Signature:** `HasColumn(IDataRecord, String)`

**Summary:**
Determine whether or not the given column exists in the record.

**Parameters:**

- **columnName** — The column name to search for.

**Returns:** True if column found, otherwise false.

## IsDbNull *(Inherited)*

**Signature:** `IsDbNull(IDataRecord, String)`

**Summary:**
Determines whether the given field is null.

**Parameters:**

- **name** — Name of field within IDataRecord.

**Returns:** True if DBNull, otherwise false.