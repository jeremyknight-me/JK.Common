[Docs](../../README.md) > [JK.Common](../README.md) > ProjectionComparer<TSource>

# ProjectionComparer<TSource>

**Namespace:** `JK.Common.TypeHelpers`

Provides an **`IEqualityComparer<TSource>`** implementation that compares objects by a projected value.

**Type Parameter:** `TSource` — The type of objects to compare.

## CompareBy<T>(Func<TSource, T> selector)

**Signature:** `CompareBy<T>(Func<TSource, T> selector)`

**Summary:**
Creates an **`IEqualityComparer<TSource>`** that compares objects by the value returned by the specified selector.

**Parameters:**

- **selector** — The projection function used to extract the comparison value.

**Returns:** An **`IEqualityComparer<TSource>`** that compares objects by the projected value.

## CompareBy<T>(Func<TSource, T> selector, IEqualityComparer<T> comparer)

**Signature:** `CompareBy<T>(Func<TSource, T> selector, IEqualityComparer<T> comparer)`

**Summary:**
Creates an **`IEqualityComparer<TSource>`** that compares objects by the value returned by the specified selector, using the specified comparer.

**Parameters:**

- **selector** — The projection function used to extract the comparison value.

- **comparer** — The **`IEqualityComparer<TSource>`** used to compare projected values.

**Returns:** An **`IEqualityComparer<TSource>`** that compares objects by the projected value.