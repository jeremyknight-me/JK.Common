[Docs](../../README.md) > [JK.Common](../README.md) > HashSetExtensions

# HashSetExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **`HashSet<T>`**.

## AddRange

**Signature:** `AddRange<T>(HashSet<T>, IEnumerable<T>)`

**Summary:**
Adds a range of values to the **`HashSet<T>`**.

**Parameters:**

- **items** — The values to add to the set.

## AddRangeIfNotNull

**Signature:** `AddRangeIfNotNull<T>(HashSet<T>, IEnumerable<T>)`

**Summary:**
Adds a range of values to the **`HashSet<T>`** only if each value is not **null**.

**Parameters:**

- **items** — The values to add to the set. Null values are ignored.

**Remarks:** This method iterates through the provided **items** and adds each non-null value to the set.

## AddIfNotNull

**Signature:** `AddIfNotNull<T>(HashSet<T>, T)`

**Summary:**
Adds the specified value to the **`HashSet<T>`** if it is not **null**.

**Parameters:**

- **value** — The value to add to the set. If **null**, the value is ignored.

**Returns:** **true** if the value was added to the set; **false** if the value was **null** or already present.