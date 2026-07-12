[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > NonQueryOperationBase

# NonQueryOperationBase

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Ado`

Base class for ADO.NET non-query operations (INSERT, UPDATE, DELETE) executed through a **DbContext** .

<<<<<<< HEAD
## NonQueryOperationBase

**Summary:** Initializes a new instance of the **NonQueryOperationBase** class.

**Parameters:**

- **context** — The database context.

- **adoCommandType** — The ADO command type.

- **adoCommandText** — The ADO command text.

## Execute

**Signature:** `Execute()`

**Summary:**
Executes the non-query command against the database.
=======
### #ctor

**Signature:** ``#ctor(DbContext context, CommandType adoCommandType, String adoCommandText)``

**Summary:**
Initializes a new instance of the **NonQueryOperationBase** class.

**Parameters:**
- **context** — The database context.
- **adoCommandType** — The ADO command type.
- **adoCommandText** — The ADO command text.

**Remarks:**
### Execute

**Signature:** ``Execute()``

**Summary:**
Executes the non-query command against the database.

**Remarks:**
>>>>>>> initial docs folder changes
