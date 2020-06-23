namespace JK.Common.Extensions
{
    public static class ClassExtensions
    {
        public static bool IsNull<T>(this T value)
        {
            return object.ReferenceEquals((object)value, (object)null);
        }

        public static bool IsNotNull<T>(this T value)
        {
            return !object.ReferenceEquals((object)value, (object)null);
        }
    }
}
