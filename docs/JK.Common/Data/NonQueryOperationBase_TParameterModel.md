[Docs](../../README.md) > [JK.Common](../README.md) > NonQueryOperationBase<TParameterModel>

# NonQueryOperationBase<TParameterModel>

**Namespace:** `JK.Common.Data`

Provides a base class for non-query operations with parameter models.

**Type Parameter:** `TParameterModel` — The type of the parameter model.

### #ctor

**Signature:** ``#ctor(IAdoConnectionFactory connectionFactory)``

**Summary:**
Initializes a new instance of the **NonQueryOperationBase`1** class.

**Parameters:**
- **connectionFactory** — The connection factory to use.

**Remarks:**
### Execute

**Signature:** ``Execute(TParameterModel parameterModel)``

**Summary:**
Executes the non-query operation with the specified parameter model.

**Parameters:**
- **parameterModel** — The parameter model.

**Returns:** The number of rows affected.

**Remarks:**