using System;

namespace JK.Common.TypeHelpers
{
    public abstract class DateTimeProvider
    {
        private static DateTimeProvider current = DefaultDateTimeProvider.Instance;

        public static DateTimeProvider Current
        {
            get => current;
            set => current = value ?? throw new ArgumentNullException(nameof(value));
        }

        public abstract DateTime Now { get; }

        public abstract DateTime UtcNow { get; }

        public static void ResetToDefault()
        {
            current = DefaultDateTimeProvider.Instance;
        }
    }
}
