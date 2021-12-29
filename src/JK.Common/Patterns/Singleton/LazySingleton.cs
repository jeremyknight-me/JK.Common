using System;

namespace JK.Common.Patterns;

/// <summary>Example of singleton pattern LazyT implementation</summary>
internal sealed class LazySingleton
{
    private static readonly Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton());

    private LazySingleton()
    {
    }

    public static LazySingleton Instance => lazy.Value;
}
