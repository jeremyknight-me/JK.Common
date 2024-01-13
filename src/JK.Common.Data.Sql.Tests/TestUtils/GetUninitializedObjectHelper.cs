/*
This is setup as if/else due to the following GitHub issue:
"Legacy serialization infrastructure APIs marked obsolete"
https://github.com/dotnet/docs/issues/34893
 */

namespace JK.Common.Data.Sql.Tests.TestUtils;

#if NET6_0_OR_GREATER

internal static class GetUninitializedObjectHelper
{
    internal static T Instantiate<T>() where T : class
        => System.Runtime.CompilerServices.RuntimeHelpers.GetUninitializedObject(typeof(T)) as T;
}

#else

internal static class GetUninitializedObjectHelper
{
    internal static T Instantiate<T>() where T : class
        => System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(T)) as T;
}

#endif
