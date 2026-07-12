[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > QueryOperationBase<T>

# QueryOperationBase<T>

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Ado`

Base class for ADO.NET query operations that return a collection of results.

**Type Parameter:** `T` — The type of items returned by the query.

<<<<<<< HEAD
## QueryOperationBase<T>

**Summary:** Initializes a new instance of the **QueryOperationBaseT** class.

**Parameters:**

- **dbContext** — The database context.

- **adoCommandType** — The ADO command type.

- **adoCommandText** — The ADO command text.

## Execute

**Signature:** `Execute()`
=======
### #ctor

**Signature:** ``#ctor(DbContext dbContext, CommandType adoCommandType, String adoCommandText)``

**Summary:**
Initializes a new instance of the **QueryOperationBase`1** class.

**Parameters:**
- **dbContext** — The database context.
- **adoCommandType** — The ADO command type.
- **adoCommandText** — The ADO command text.

**Remarks:**
### Execute

**Signature:** ``Execute()``
>>>>>>> initial docs folder changes

**Summary:**
Executes the query and returns the results.

**Returns:** A collection of items returned by the query.

<<<<<<< HEAD
## ParseRecord

**Signature:** `ParseRecord(IDataRecord dataRecord)`
=======
**Remarks:**
### ParseRecord

**Signature:** ``ParseRecord(IDataRecord dataRecord)``
>>>>>>> initial docs folder changes

**Summary:**
Parses a data record into an instance of **T** .

**Parameters:**
<<<<<<< HEAD

- **dataRecord** — The data record to parse.

**Returns:** An instance of **T** .
=======
- **dataRecord** — The data record to parse.

**Returns:** An instance of **T** .

**Remarks:**
>>>>>>> initial docs folder changes
