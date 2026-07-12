[Docs](../../../README.md) > [JK.Common](../../README.md) > DataRecordExtensions

# DataRecordExtensions

**Namespace:** `JK.Common.Data.Extensions`

Extension methods for IDataRecord

<<<<<<< HEAD
## GetValueOrDefault(IDataRecord, String name) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, String name)`
=======
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, String name)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **name** — Name of field within IDataRecord.

**Returns:** The given field's value or the default for the object type.

<<<<<<< HEAD
## GetValueOrDefault(IDataRecord, String name, T defaultValue) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, String name, T defaultValue)`
=======
**Remarks:**
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, String name, ``0 defaultValue)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
<<<<<<< HEAD

- **name** — Name of field within IDataRecord.

=======
- **name** — Name of field within IDataRecord.
>>>>>>> initial docs folder changes
- **defaultValue** — Value to use if null field value.

**Returns:** The given field's value or the given default.

<<<<<<< HEAD
## GetValueOrDefault(IDataRecord, Int32 index) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, Int32 index)`
=======
**Remarks:**
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, Int32 index)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **index** — Index of field within IDataRecord.

**Returns:** The given field's value or the default for the object type.

<<<<<<< HEAD
## GetValueOrDefault(IDataRecord, Int32 index, T defaultValue) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, Int32 index, T defaultValue)`
=======
**Remarks:**
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, Int32 index, ``0 defaultValue)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
<<<<<<< HEAD

- **index** — Index of field within IDataRecord.

=======
- **index** — Index of field within IDataRecord.
>>>>>>> initial docs folder changes
- **defaultValue** — Value to use if null field value.

**Returns:** The given field's value or the given default.

<<<<<<< HEAD
## GetValueOrNull(IDataRecord, String name) *(Inherited)*

**Signature:** `GetValueOrNull<T>(IDataRecord, String name)`
=======
**Remarks:**
### GetValueOrNull` *(Inherited)*

**Signature:** ``GetValueOrNull`(IDataRecord, String name)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the value of the given field from the data reader or null.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **name** — Name of field within IDataRecord.

**Returns:** The given field's value or null.

<<<<<<< HEAD
## GetValueOrNull(IDataRecord, Int32 index) *(Inherited)*

**Signature:** `GetValueOrNull<T>(IDataRecord, Int32 index)`
=======
**Remarks:**
### GetValueOrNull` *(Inherited)*

**Signature:** ``GetValueOrNull`(IDataRecord, Int32 index)``
>>>>>>> initial docs folder changes

**Summary:**
Gets the value of the given field from the data reader or null.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **index** — Index of field within IDataRecord.

**Returns:** The given field's value or null.

<<<<<<< HEAD
## HasColumn *(Inherited)*

**Signature:** `HasColumn(IDataRecord, String columnName)`
=======
**Remarks:**
### HasColumn *(Inherited)*

**Signature:** ``HasColumn(IDataRecord, String columnName)``
>>>>>>> initial docs folder changes

**Summary:**
Determine whether or not the given column exists in the record.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **columnName** — The column name to search for.

**Returns:** True if column found, otherwise false.

<<<<<<< HEAD
## IsDbNull *(Inherited)*

**Signature:** `IsDbNull(IDataRecord, String name)`
=======
**Remarks:**
### IsDbNull *(Inherited)*

**Signature:** ``IsDbNull(IDataRecord, String name)``
>>>>>>> initial docs folder changes

**Summary:**
Determines whether the given field is null.

**Parameters:**
<<<<<<< HEAD

- **name** — Name of field within IDataRecord.

**Returns:** True if DBNull, otherwise false.
=======
- **name** — Name of field within IDataRecord.

**Returns:** True if DBNull, otherwise false.

**Remarks:**
>>>>>>> initial docs folder changes
