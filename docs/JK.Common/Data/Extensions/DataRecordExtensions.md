[Docs](../../../README.md) > [JK.Common](../../README.md) > DataRecordExtensions

# DataRecordExtensions

**Namespace:** `JK.Common.Data.Extensions`

Extension methods for IDataRecord

### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, String name)``

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
- **name** — Name of field within IDataRecord.

**Returns:** The given field's value or the default for the object type.

**Remarks:**
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, String name, ``0 defaultValue)``

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
- **name** — Name of field within IDataRecord.
- **defaultValue** — Value to use if null field value.

**Returns:** The given field's value or the given default.

**Remarks:**
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, Int32 index)``

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
- **index** — Index of field within IDataRecord.

**Returns:** The given field's value or the default for the object type.

**Remarks:**
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, Int32 index, ``0 defaultValue)``

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
- **index** — Index of field within IDataRecord.
- **defaultValue** — Value to use if null field value.

**Returns:** The given field's value or the given default.

**Remarks:**
### GetValueOrNull` *(Inherited)*

**Signature:** ``GetValueOrNull`(IDataRecord, String name)``

**Summary:**
Gets the value of the given field from the data reader or null.

**Parameters:**
- **name** — Name of field within IDataRecord.

**Returns:** The given field's value or null.

**Remarks:**
### GetValueOrNull` *(Inherited)*

**Signature:** ``GetValueOrNull`(IDataRecord, Int32 index)``

**Summary:**
Gets the value of the given field from the data reader or null.

**Parameters:**
- **index** — Index of field within IDataRecord.

**Returns:** The given field's value or null.

**Remarks:**
### HasColumn *(Inherited)*

**Signature:** ``HasColumn(IDataRecord, String columnName)``

**Summary:**
Determine whether or not the given column exists in the record.

**Parameters:**
- **columnName** — The column name to search for.

**Returns:** True if column found, otherwise false.

**Remarks:**
### IsDbNull *(Inherited)*

**Signature:** ``IsDbNull(IDataRecord, String name)``

**Summary:**
Determines whether the given field is null.

**Parameters:**
- **name** — Name of field within IDataRecord.

**Returns:** True if DBNull, otherwise false.

**Remarks:**