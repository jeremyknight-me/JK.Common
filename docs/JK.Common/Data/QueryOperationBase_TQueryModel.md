[Docs](../../README.md) > [JK.Common](../README.md) > QueryOperationBase<TQueryModel>

# QueryOperationBase<TQueryModel>

**Namespace:** `JK.Common.Data`

Provides a base class for query operations without parameter models.

**Type Parameter:** `TQueryModel` — The type of the query result model.

### QueryOperationBase<TQueryModel>

**Summary:** Initializes a new instance of the **QueryOperationBase`1** class.

**Parameters:**

- **connectionFactory** — The connection factory to use.

### Execute

**Signature:** `Execute()`

**Summary:**
Executes the query operation.

**Returns:** A read-only list of query result models.

### MakeModel

**Signature:** `MakeModel(IDataReader, String dataRecord, Int32> ordinalCache)`

**Summary:**
Creates a model instance from the data record and ordinal cache.

**Parameters:**

- **dataRecord** — The data record to read from.

- **ordinalCache** — The ordinal cache for column indexes.

**Returns:** The model instance.

### MakeOrdinalCache

**Signature:** `MakeOrdinalCache(IDataReader dataReader)`

**Summary:**
Creates the ordinal cache from the data reader.

**Parameters:**

- **dataReader** — The data reader to use.

**Returns:** The ordinal cache.

### Behavior

**Signature:** `Behavior`

**Summary:**
Gets the command behavior for the data reader.