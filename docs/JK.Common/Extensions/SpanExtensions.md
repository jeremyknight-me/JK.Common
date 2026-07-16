[Docs](../../README.md) > [JK.Common](../README.md) > SpanExtensions

# SpanExtensions

**Namespace:** `JK.Common.Extensions`

Extension methods for **ReadOnlySpan&lt;T&gt;**.

## Parse

**Signature:** `Parse<T>(ReadOnlySpan<Char> input, IFormatProvider formatProvider)`

**Summary:**
Parses a **ReadOnlySpan&lt;T&gt;** into a specified type.

**Parameters:**

- **input** — The span to parse.

- **formatProvider** — Format provider to pass down to the **Parse** method.

**Returns:** Parsed value of type T.