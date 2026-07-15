[Docs](../../README.md) > [JK.Common](../README.md) > QueryOperationBase<TQueryModel>

# QueryOperationBase<TQueryModel>

**Namespace:** `JK.Common.Data`

Provides a base class for query operations without parameter models.

**Type Parameter:** `TQueryModel` — The type of the query result model.

<<<<<<< HEAD
<<<<<<< HEAD
## QueryOperationBase<TQueryModel>

**Summary:** Initializes a new instance of the **QueryOperationBaseT** class.

**Parameters:**

- **connectionFactory** — The connection factory to use.

## Execute

**Signature:** `Execute()`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
### #ctor

**Signature:** ``#ctor(IAdoConnectionFactory connectionFactory)``

**Summary:**
Initializes a new instance of the **QueryOperationBase`1** class.

**Parameters:**
- **connectionFactory** — The connection factory to use.

**Remarks:**
### Execute

**Signature:** ``Execute()``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Executes the query operation.

**Returns:** A read-only list of query result models.

<<<<<<< HEAD
<<<<<<< HEAD
## MakeModel

**Signature:** `MakeModel(IDataReader dataRecord, IDictionary<String, Int32> ordinalCache)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### MakeModel

**Signature:** ``MakeModel(IDataReader, String dataRecord, Int32} ordinalCache)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Creates a model instance from the data record and ordinal cache.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **dataRecord** — The data record to read from.

=======
- **dataRecord** — The data record to read from.
>>>>>>> initial docs folder changes
=======
- **dataRecord** — The data record to read from.
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **ordinalCache** — The ordinal cache for column indexes.

**Returns:** The model instance.

<<<<<<< HEAD
<<<<<<< HEAD
## MakeOrdinalCache

**Signature:** `MakeOrdinalCache(IDataReader dataReader)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### MakeOrdinalCache

**Signature:** ``MakeOrdinalCache(IDataReader dataReader)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Creates the ordinal cache from the data reader.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **dataReader** — The data reader to use.

**Returns:** The ordinal cache.

<<<<<<< HEAD
<<<<<<< HEAD
## Behavior

**Signature:** `Behavior`

**Summary:**
Gets the command behavior for the data reader.
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**

### Behavior

**Signature:** ``Behavior``

**Summary:**
Gets the command behavior for the data reader.

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
