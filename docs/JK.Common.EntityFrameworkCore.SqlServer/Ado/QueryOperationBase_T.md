[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > QueryOperationBase<T>

# QueryOperationBase<T>

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Ado`

Base class for ADO.NET query operations that return a collection of results.

**Type Parameter:** `T` — The type of items returned by the query.

<<<<<<< HEAD
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
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
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
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Executes the query and returns the results.

**Returns:** A collection of items returned by the query.

<<<<<<< HEAD
<<<<<<< HEAD
## ParseRecord

**Signature:** `ParseRecord(IDataRecord dataRecord)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### ParseRecord

**Signature:** ``ParseRecord(IDataRecord dataRecord)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Parses a data record into an instance of **T** .

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **dataRecord** — The data record to parse.

**Returns:** An instance of **T** .
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **dataRecord** — The data record to parse.

**Returns:** An instance of **T** .

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
