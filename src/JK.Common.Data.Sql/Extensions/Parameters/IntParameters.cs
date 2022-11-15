﻿using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class IntParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, int value)
        => parameters.AddAlways(name, SqlDbType.Int, value);

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, int? value)
        => parameters.AddAlways(name, SqlDbType.Int, value);

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, int? value)
        => parameters.AddIfNonNull(name, SqlDbType.Int, value);
}

