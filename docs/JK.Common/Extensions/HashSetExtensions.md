[Docs](../../README.md) > [JK.Common](../README.md) > HashSetExtensions

# HashSetExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **HashSet** .

### AddRange` *(Inherited)*

**Signature:** ``AddRange`(HashSet{``0}, IEnumerable{``0} items)``

**Summary:**
Adds a range of values to the **HashSet** .

**Parameters:**
- **items** — The values to add to the set.

**Remarks:**
### AddRangeIfNotNull` *(Inherited)*

**Signature:** ``AddRangeIfNotNull`(HashSet{``0}, IEnumerable{``0} items)``

**Summary:**
Adds a range of values to the **HashSet** only if each value is not **null** .

**Parameters:**
- **items** — The values to add to the set. Null values are ignored.

**Remarks:** This method iterates through the provided **items** and adds each non-null value to the set.
### AddIfNotNull` *(Inherited)*

**Signature:** ``AddIfNotNull`(HashSet{``0}, ``0 value)``

**Summary:**
Adds the specified value to the **HashSet** if it is not **null** .

**Parameters:**
- **value** — The value to add to the set. If **null** , the value is ignored.

**Returns:** **true** if the value was added to the set; **false** if the value was **null** or already present.

**Remarks:**