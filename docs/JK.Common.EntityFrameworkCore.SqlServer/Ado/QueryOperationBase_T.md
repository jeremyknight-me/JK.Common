[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > QueryOperationBase<T>

# QueryOperationBase<T>

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Ado`

Base class for ADO.NET query operations that return a collection of results.

**Type Parameter:** `T` — The type of items returned by the query.

### QueryOperationBase<T>

**Summary:** Initializes a new instance of the **QueryOperationBase`1** class.

**Parameters:**

- **dbContext** — The database context.

- **adoCommandType** — The ADO command type.

- **adoCommandText** — The ADO command text.

### Execute

**Signature:** `Execute()`

**Summary:**
Executes the query and returns the results.

**Returns:** A collection of items returned by the query.

### ParseRecord

**Signature:** `ParseRecord(IDataRecord dataRecord)`

**Summary:**
Parses a data record into an instance of **T** .

**Parameters:**

- **dataRecord** — The data record to parse.

**Returns:** An instance of **T** .