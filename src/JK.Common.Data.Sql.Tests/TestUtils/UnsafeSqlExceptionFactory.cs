#if NET6_0_OR_GREATER

using System.Reflection;

namespace JK.Common.Data.Sql.Tests.TestUtils;

/// <summary>
/// WARNING: This is meant for unit testing only!!!
/// </summary>
public static class UnsafeSqlExceptionFactory
{
    public static SqlException Make(int number, string message)
    {
        SqlError error = MakeSqlError(number, message);
        SqlErrorCollection collection = MakeSqlErrorCollection(error);
        SqlException exception = MakeSqlException(collection);
        return exception;
    }

    private static SqlException MakeSqlException(SqlErrorCollection collection)
    {
        Type exceptionType = typeof(SqlException);
        MethodInfo createMethod = exceptionType.GetMethod(
            "CreateException",
            BindingFlags.NonPublic | BindingFlags.Static,
            [typeof(SqlErrorCollection), typeof(string)]
        );
        var exception = createMethod.Invoke(null, [collection, "TESTING"]) as SqlException;
        return exception;
    }

    private static SqlErrorCollection MakeSqlErrorCollection(SqlError error)
    {
        Type collectionType = typeof(SqlErrorCollection);
        ConstructorInfo ctor = collectionType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, []);
        SqlErrorCollection collection = ctor.Invoke([]) as SqlErrorCollection;
        MethodInfo addMethod = collectionType.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);
        addMethod.Invoke(collection, [error]);
        return collection;
    }

    private static SqlError MakeSqlError(int number, string message)
    {
        Type errorType = typeof(SqlError);
        SqlError error = Instantiate<SqlError>();
        BindingFlags privateBindings = BindingFlags.NonPublic | BindingFlags.Instance;

        FieldInfo numberMember = errorType.GetField("_number", privateBindings);
        numberMember.SetValue(error, number);

        if (!string.IsNullOrWhiteSpace(message))
        {
            FieldInfo messageMember = errorType.GetField("_message", privateBindings);
            messageMember.SetValue(error, message);
        }

        return error;
    }

    /// <summary>
    /// WARNING: GetUninitializedObject doesn't call the constructor.
    /// </summary>
    private static T Instantiate<T>() where T : class
        => GetUninitializedObjectHelper.Instantiate<T>();
}

#endif
