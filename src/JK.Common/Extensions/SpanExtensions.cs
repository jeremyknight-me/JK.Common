#if NET7_0_OR_GREATER

using System;

namespace JK.Common.Extensions;

/// <summary>
/// Extension methods for <see cref="ReadOnlySpan{T}"/>.
/// </summary>
public static class SpanExtensions
{
    /// <summary>
    /// Parses a <see cref="ReadOnlySpan{T}"/> into a specified type.
    /// </summary>
    /// <typeparam name="T">Type to parse span value to which must implement <see cref="ISpanParsable{T}"/>.</typeparam>
    /// <param name="input">The span to parse.</param>
    /// <param name="formatProvider">Format provider to pass down to the <see cref="ISpanParsable{T}.Parse"/> method.</param>
    /// <returns>Parsed value of type T.</returns>
    public static T Parse<T>(this ReadOnlySpan<char> input, IFormatProvider formatProvider = null)
        where T : ISpanParsable<T>
        => T.Parse(input, formatProvider);
}

#endif
