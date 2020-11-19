namespace JK.Common.Patterns
{
    public sealed class Singleton<T> where T : new()
    {
        #region Singleton Pattern Implementation

        private static readonly object threadLock = new object();

        private static T instance;

        private Singleton()
        {
        }

        public static T Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }

                return instance;
            }
        }

        #endregion
    }
}
