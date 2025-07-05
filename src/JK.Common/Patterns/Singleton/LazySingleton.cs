using System;

namespace JK.Common.Patterns.Singleton;

/// <summary>Example of singleton pattern LazyT implementation</summary>
internal sealed class LazySingleton
{
    private static readonly Lazy<LazySingleton> _lazy = new(() => new LazySingleton());

    private LazySingleton()
    {
    }

    public static LazySingleton Instance => _lazy.Value;
}
