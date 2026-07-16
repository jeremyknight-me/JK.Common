[Docs](../README.md) > [JK.Common](README.md) > EquatableFacade<T>

# EquatableFacade<T>

**Namespace:** `JK.Common`

Provides a facade for comparing objects of type **T** for equality.

**Type Parameter:** `T` — The type of objects to compare.

## AreEqual

**Signature:** `AreEqual(Object left, Object right)`

**Summary:**
Determines whether two objects are equal, using the **AreObjectsEqual** function if both are of type **T**.

**Parameters:**

- **left** — The first object to compare.

- **right** — The second object to compare.

**Returns:** **true** if the objects are considered equal; otherwise, **false**.

**Exceptions:**

- **System.ArgumentException**: Thrown if either argument is not of type **T**.

## AreObjectsEqual

**Signature:** `AreObjectsEqual`

**Summary:**
Gets or sets the function used to determine equality between two objects of type **T**.