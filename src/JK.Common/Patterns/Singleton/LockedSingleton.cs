namespace JK.Common.Patterns.Singleton;

internal sealed class LockedSingleton
{
    private static LockedSingleton _instance = null;
    private static readonly object _threadLock = new();

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
