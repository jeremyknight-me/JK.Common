#if NET7_0_OR_GREATER

using System;

namespace JK.Common.Extensions;

public static class SpanExtensions
{
    public static T Parse<T>(this ReadOnlySpan<char> input, IFormatProvider formatProvider = null)
        where T : ISpanParsable<T>
        => T.Parse(input, formatProvider);
}

#endif
