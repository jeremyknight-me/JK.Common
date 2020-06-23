using System;

namespace JK.Common.DateTimeProviders
{
    public sealed class DefaultDateTimeProvider : DateTimeProvider
    {
        #region Singleton Pattern Implementation

        private static readonly object threadLock = new object();

        private static DefaultDateTimeProvider instance;

        private DefaultDateTimeProvider()
        {
        }

        public static DefaultDateTimeProvider Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new DefaultDateTimeProvider();
                    }
                }

                return instance;
            }
        }

        #endregion

        public override DateTime Now => DateTime.Now;
        public override DateTime UtcNow => DateTime.UtcNow;
    }
}
