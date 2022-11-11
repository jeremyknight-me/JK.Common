using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions;

public static partial class SqlParameterCollectionExtensions
{
    // todo: byte

    // todo: datetime2 w/ and w/o precision

    // todo: datetimeoffset w/ and w/o precision

    // todo: decimal

    // todo: double

    // todo: guid

    // todo: long

    // todo: short

    // todo: string (char, nchar, varchar, nvarchar)

    //public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, decimal? value, byte precision, byte scale)
    //{
    //    if (value is not null)
    //    {
    //        var parameter = parameters.Add(name, SqlDbType.Decimal);
    //        parameter.Precision = precision;
    //        parameter.Scale = scale;
    //        parameter.Value = value.Value;
    //    }

    //    return parameters;
    //}

    //public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, Guid? value)
    //    => parameters.AddIfNonNull(name, SqlDbType.UniqueIdentifier, value);

    //public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, int? value)
    //    => parameters.AddIfNonNull(name, SqlDbType.Int, value);

    //public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, string value, int length, SqlDbType dbType = SqlDbType.NVarChar)
    //{
    //    if (!string.IsNullOrWhiteSpace(value))
    //    {
    //        parameters.Add(name, dbType, length).Value = value;
    //    }

    //    return parameters;
    //}

    
}
