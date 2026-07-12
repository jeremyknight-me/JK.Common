[Docs](../../README.md) > [JK.Common](../README.md) > QueryOperationBase<TQueryModel, TParameterModel>

# QueryOperationBase<TQueryModel, TParameterModel>

**Namespace:** `JK.Common.Data`

Provides a base class for query operations with parameter models.

**Type Parameter:** `TQueryModel` — The type of the query result model.
<<<<<<< HEAD

**Type Parameter:** `TParameterModel` — The type of the parameter model.

## QueryOperationBase<TQueryModel, TParameterModel>

**Summary:** Initializes a new instance of the **QueryOperationBaseT** class.

**Parameters:**

- **connectionFactory** — The connection factory to use.

## Execute

**Signature:** `Execute(TParameterModel parameterModel)`
=======
**Type Parameter:** `TParameterModel` — The type of the parameter model.

### #ctor

**Signature:** ``#ctor(IAdoConnectionFactory connectionFactory)``

**Summary:**
Initializes a new instance of the **QueryOperationBase`2** class.

**Parameters:**
- **connectionFactory** — The connection factory to use.

**Remarks:**
### Execute

**Signature:** ``Execute(TParameterModel parameterModel)``
>>>>>>> initial docs folder changes

**Summary:**
Executes the query operation with the specified parameter model.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **parameterModel** — The parameter model.

**Returns:** A read-only list of query result models.

<<<<<<< HEAD
## MakeModel

**Signature:** `MakeModel(IDataReader dataRecord, IDictionary<String, Int32> ordinalCache)`
=======
**Remarks:**
### MakeModel

**Signature:** ``MakeModel(IDataReader, String dataRecord, Int32} ordinalCache)``
>>>>>>> initial docs folder changes

**Summary:**
Creates a model instance from the data record and ordinal cache.

**Parameters:**
<<<<<<< HEAD

- **dataRecord** — The data record to read from.

=======
- **dataRecord** — The data record to read from.
>>>>>>> initial docs folder changes
- **ordinalCache** — The ordinal cache for column indexes.

**Returns:** The model instance.

<<<<<<< HEAD
## MakeOrdinalCache

**Signature:** `MakeOrdinalCache(IDataReader dataReader)`
=======
**Remarks:**
### MakeOrdinalCache

**Signature:** ``MakeOrdinalCache(IDataReader dataReader)``
>>>>>>> initial docs folder changes

**Summary:**
Creates the ordinal cache from the data reader.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **dataReader** — The data reader to use.

**Returns:** The ordinal cache.

<<<<<<< HEAD
## Behavior

**Signature:** `Behavior`

**Summary:**
Gets the command behavior for the data reader.
=======
**Remarks:**

### Behavior

**Signature:** ``Behavior``

**Summary:**
Gets the command behavior for the data reader.

**Remarks:**
>>>>>>> initial docs folder changes
