[Docs](../../README.md) > [JK.Common.EntityFrameworkCore.SqlServer](../README.md) > ScalarOperationBase<T>

# ScalarOperationBase<T>

**Namespace:** `JK.Common.EntityFrameworkCore.SqlServer.Ado`

Base class for ADO.NET operations that return a single scalar value.

**Type Parameter:** `T` — The type of the scalar result.

<<<<<<< HEAD
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
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
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
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Executes the command and returns the scalar result.

<<<<<<< HEAD
<<<<<<< HEAD
**Returns:** The scalar value returned by the command.
=======
**Returns:** The scalar value returned by the command.

**Remarks:**
>>>>>>> initial docs folder changes
=======
**Returns:** The scalar value returned by the command.

**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
