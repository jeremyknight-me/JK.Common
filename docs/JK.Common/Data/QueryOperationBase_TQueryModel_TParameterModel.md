[Docs](../../README.md) > [JK.Common](../README.md) > QueryOperationBase<TQueryModel, TParameterModel>

# QueryOperationBase<TQueryModel, TParameterModel>

**Namespace:** `JK.Common.Data`

Provides a base class for query operations with parameter models.

**Type Parameter:** `TQueryModel` — The type of the query result model.
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

**Summary:**
Executes the query operation with the specified parameter model.

**Parameters:**
- **parameterModel** — The parameter model.

**Returns:** A read-only list of query result models.

**Remarks:**
### MakeModel

**Signature:** ``MakeModel(IDataReader, String dataRecord, Int32} ordinalCache)``

**Summary:**
Creates a model instance from the data record and ordinal cache.

**Parameters:**
- **dataRecord** — The data record to read from.
- **ordinalCache** — The ordinal cache for column indexes.

**Returns:** The model instance.

**Remarks:**
### MakeOrdinalCache

**Signature:** ``MakeOrdinalCache(IDataReader dataReader)``

**Summary:**
Creates the ordinal cache from the data reader.

**Parameters:**
- **dataReader** — The data reader to use.

**Returns:** The ordinal cache.

**Remarks:**

### Behavior

**Signature:** ``Behavior``

**Summary:**
Gets the command behavior for the data reader.

**Remarks:**