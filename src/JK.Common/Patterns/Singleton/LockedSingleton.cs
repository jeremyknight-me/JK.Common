namespace JK.Common.Patterns.Singleton;

internal sealed class LockedSingleton
{
    private static LockedSingleton instance = null;
    private static readonly object threadLock = new object();

    private LockedSingleton()
    {
    }

    public static LockedSingleton Instance
    {
        get
        {
            lock (threadLock)
            {
                if (instance == null)
                {
                    instance = new LockedSingleton();
                }
                return instance;
            }
        }
    }
}
