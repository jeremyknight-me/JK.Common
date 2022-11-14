namespace JK.Common.Data.Sql.Extensions;

public static partial class SqlParameterCollectionExtensions
{
    // todo: datetime2 w/ and w/o precision (tests only left)

    // todo: datetimeoffset w/ and w/o precision

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


}
