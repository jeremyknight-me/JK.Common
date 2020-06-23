using System;

namespace JK.Common.DateTimeProviders
{
    public abstract class DateTimeOffsetProvider
    {
        private static DateTimeOffsetProvider current = DefaultDateTimeOffsetProvider.Instance;

        public static DateTimeOffsetProvider Current
        {
            get => current;
            set => current = value ?? throw new ArgumentNullException(nameof(value));
        }

        public abstract DateTimeOffset Now { get; }

        public abstract DateTimeOffset UtcNow { get; }

        public static void ResetToDefault()
        {
            current = DefaultDateTimeOffsetProvider.Instance;
        }
    }
}
