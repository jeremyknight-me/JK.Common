namespace JK.Common.Patterns.Singleton;

internal sealed class LockedSingleton
{
    private static LockedSingleton _instance = null;

#if NET9_0_OR_GREATER
    private static readonly System.Threading.Lock _threadLock = new();
#else
    private static readonly object _threadLock = new();
#endif

    private LockedSingleton()
    {
    }

    public static LockedSingleton Instance
    {
        get
        {
            lock (_threadLock)
            {
                _instance ??= new LockedSingleton();
                return _instance;
            }
        }
    }
}

