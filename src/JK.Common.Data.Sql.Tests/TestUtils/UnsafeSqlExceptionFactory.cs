#if NET6_0_OR_GREATER

using System;
using System.Reflection;
using JK.Common.Data.Sql.Tests.TestUtils;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.TestUtils;

/// <summary>
/// WARNING: This is meant for unit testing only!!!
/// </summary>
public static class UnsafeSqlExceptionFactory
{
    public static SqlException Make(int number, string message)
    {
        var error = MakeSqlError(number, message);
        var collection = MakeSqlErrorCollection(error);
        var exception = MakeSqlException(collection);
        return exception;
    }

    private static SqlException MakeSqlException(SqlErrorCollection collection)
    {
        var exceptionType = typeof(SqlException);
        var createMethod = exceptionType.GetMethod(
            "CreateException",
            BindingFlags.NonPublic | BindingFlags.Static,
            new Type[] { typeof(SqlErrorCollection), typeof(string) }
        );
        var exception = createMethod.Invoke(null, new object[] { collection, "TESTING" }) as SqlException;
        return exception;
    }

    private static SqlErrorCollection MakeSqlErrorCollection(SqlError error)
    {
        var collectionType = typeof(SqlErrorCollection);
        var ctor = collectionType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Array.Empty<Type>());
        var collection = ctor.Invoke(Array.Empty<object>()) as SqlErrorCollection;
        var addMethod = collectionType.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);
        addMethod.Invoke(collection, new object[] { error });
        return collection;
    }

    private static SqlError MakeSqlError(int number, string message)
    {
        var errorType = typeof(SqlError);
        var error = Instantiate<SqlError>();
        var privateBindings = BindingFlags.NonPublic | BindingFlags.Instance;

        var numberMember = errorType.GetField("_number", privateBindings);
        numberMember.SetValue(error, number);

        if (!string.IsNullOrWhiteSpace(message))
        {
            var messageMember = errorType.GetField("_message", privateBindings);
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
