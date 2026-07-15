[Docs](../../../README.md) > [JK.Common](../../README.md) > DataRecordExtensions

# DataRecordExtensions

**Namespace:** `JK.Common.Data.Extensions`

Extension methods for IDataRecord

<<<<<<< HEAD
<<<<<<< HEAD
## GetValueOrDefault(IDataRecord, String name) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, String name)`
=======
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, String name)``
>>>>>>> initial docs folder changes
=======
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, String name)``
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **name** — Name of field within IDataRecord.

**Returns:** The given field's value or the default for the object type.

<<<<<<< HEAD
<<<<<<< HEAD
## GetValueOrDefault(IDataRecord, String name, T defaultValue) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, String name, T defaultValue)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, String name, ``0 defaultValue)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **name** — Name of field within IDataRecord.

=======
- **name** — Name of field within IDataRecord.
>>>>>>> initial docs folder changes
=======
- **name** — Name of field within IDataRecord.
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **defaultValue** — Value to use if null field value.

**Returns:** The given field's value or the given default.

<<<<<<< HEAD
<<<<<<< HEAD
## GetValueOrDefault(IDataRecord, Int32 index) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, Int32 index)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, Int32 index)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **index** — Index of field within IDataRecord.

**Returns:** The given field's value or the default for the object type.

<<<<<<< HEAD
<<<<<<< HEAD
## GetValueOrDefault(IDataRecord, Int32 index, T defaultValue) *(Inherited)*

**Signature:** `GetValueOrDefault<T>(IDataRecord, Int32 index, T defaultValue)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetValueOrDefault` *(Inherited)*

**Signature:** ``GetValueOrDefault`(IDataRecord, Int32 index, ``0 defaultValue)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the value of the given field from the data reader or the 
            default for the object type.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **index** — Index of field within IDataRecord.

=======
- **index** — Index of field within IDataRecord.
>>>>>>> initial docs folder changes
=======
- **index** — Index of field within IDataRecord.
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **defaultValue** — Value to use if null field value.

**Returns:** The given field's value or the given default.

<<<<<<< HEAD
<<<<<<< HEAD
## GetValueOrNull(IDataRecord, String name) *(Inherited)*

**Signature:** `GetValueOrNull<T>(IDataRecord, String name)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetValueOrNull` *(Inherited)*

**Signature:** ``GetValueOrNull`(IDataRecord, String name)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the value of the given field from the data reader or null.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **name** — Name of field within IDataRecord.

**Returns:** The given field's value or null.

<<<<<<< HEAD
<<<<<<< HEAD
## GetValueOrNull(IDataRecord, Int32 index) *(Inherited)*

**Signature:** `GetValueOrNull<T>(IDataRecord, Int32 index)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetValueOrNull` *(Inherited)*

**Signature:** ``GetValueOrNull`(IDataRecord, Int32 index)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the value of the given field from the data reader or null.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **index** — Index of field within IDataRecord.

**Returns:** The given field's value or null.

<<<<<<< HEAD
<<<<<<< HEAD
## HasColumn *(Inherited)*

**Signature:** `HasColumn(IDataRecord, String columnName)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### HasColumn *(Inherited)*

**Signature:** ``HasColumn(IDataRecord, String columnName)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Determine whether or not the given column exists in the record.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **columnName** — The column name to search for.

**Returns:** True if column found, otherwise false.

<<<<<<< HEAD
<<<<<<< HEAD
## IsDbNull *(Inherited)*

**Signature:** `IsDbNull(IDataRecord, String name)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### IsDbNull *(Inherited)*

**Signature:** ``IsDbNull(IDataRecord, String name)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Determines whether the given field is null.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **name** — Name of field within IDataRecord.

**Returns:** True if DBNull, otherwise false.
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **name** — Name of field within IDataRecord.

**Returns:** True if DBNull, otherwise false.

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
