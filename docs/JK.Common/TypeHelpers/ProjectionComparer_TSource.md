[Docs](../../README.md) > [JK.Common](../README.md) > ProjectionComparer<TSource>

# ProjectionComparer<TSource>

**Namespace:** `JK.Common.TypeHelpers`

<<<<<<< HEAD
<<<<<<< HEAD
Provides an **IEqualityComparer&lt;T&gt;** implementation that compares objects by a projected value.

**Type Parameter:** `TSource` — The type of objects to compare.

## CompareBy(Func<TSource, T> selector)

**Signature:** `CompareBy<T>(Func<TSource, T> selector)`

**Summary:**
Creates an **IEqualityComparer&lt;T&gt;** that compares objects by the value returned by the specified selector.

**Parameters:**

- **selector** — The projection function used to extract the comparison value.

**Returns:** An **IEqualityComparer&lt;T&gt;** that compares objects by the projected value.

## CompareBy(Func<TSource, T> selector, IEqualityComparer<T> comparer)

**Signature:** `CompareBy<T>(Func<TSource, T> selector, IEqualityComparer<T> comparer)`

**Summary:**
Creates an **IEqualityComparer&lt;T&gt;** that compares objects by the value returned by the specified selector, using the specified comparer.

**Parameters:**

- **selector** — The projection function used to extract the comparison value.

- **comparer** — The **IEqualityComparer&lt;T&gt;** used to compare projected values.

**Returns:** An **IEqualityComparer&lt;T&gt;** that compares objects by the projected value.
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
Provides an **IEqualityComparer`1** implementation that compares objects by a projected value.

**Type Parameter:** `TSource` — The type of objects to compare.

### CompareBy`

**Signature:** ``CompareBy`(Func{TSource, `TSource} selector)``

**Summary:**
Creates an **IEqualityComparer`1** that compares objects by the value returned by the specified selector.

**Parameters:**
- **selector** — The projection function used to extract the comparison value.

**Returns:** An **IEqualityComparer`1** that compares objects by the projected value.

**Remarks:**
### CompareBy`

**Signature:** ``CompareBy`(Func{TSource, `TSource} selector, IEqualityComparer{`TSource} comparer)``

**Summary:**
Creates an **IEqualityComparer`1** that compares objects by the value returned by the specified selector, using the specified comparer.

**Parameters:**
- **selector** — The projection function used to extract the comparison value.
- **comparer** — The **IEqualityComparer`1** used to compare projected values.

**Returns:** An **IEqualityComparer`1** that compares objects by the projected value.

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
