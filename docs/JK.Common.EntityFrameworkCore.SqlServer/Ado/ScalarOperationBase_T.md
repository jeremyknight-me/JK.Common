[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > ScalarOperationBase<T>

# ScalarOperationBase<T>

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Ado`

Base class for ADO.NET operations that return a single scalar value.

**Type Parameter:** `T` — The type of the scalar result.

<<<<<<< HEAD
## ScalarOperationBase<T>

**Summary:** Initializes a new instance of the **ScalarOperationBaseT** class.

**Parameters:**

- **context** — The database context.

- **adoCommandType** — The ADO command type.

- **adoCommandText** — The ADO command text.

## Execute

**Signature:** `Execute()`
=======
### #ctor

**Signature:** ``#ctor(DbContext context, CommandType adoCommandType, String adoCommandText)``

**Summary:**
Initializes a new instance of the **ScalarOperationBase`1** class.

**Parameters:**
- **context** — The database context.
- **adoCommandType** — The ADO command type.
- **adoCommandText** — The ADO command text.

**Remarks:**
### Execute

**Signature:** ``Execute()``
>>>>>>> initial docs folder changes

**Summary:**
Executes the command and returns the scalar result.

<<<<<<< HEAD
**Returns:** The scalar value returned by the command.
=======
**Returns:** The scalar value returned by the command.

**Remarks:**
>>>>>>> initial docs folder changes
