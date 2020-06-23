using System;

namespace JK.Common.DateTimeProviders
{
    public sealed class DefaultDateTimeOffsetProvider : DateTimeOffsetProvider
    {
        #region Singleton Pattern Implementation

        private static readonly object threadLock = new object();

        private static DefaultDateTimeOffsetProvider instance;

        private DefaultDateTimeOffsetProvider()
        {
        }

        public static DefaultDateTimeOffsetProvider Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new DefaultDateTimeOffsetProvider();
                    }
                }

                return instance;
            }
        }

        #endregion

        public override DateTimeOffset Now => DateTimeOffset.Now;
        public override DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
