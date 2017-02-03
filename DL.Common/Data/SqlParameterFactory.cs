using System;
using System.Data;
using System.Data.SqlClient;

namespace DL.Common.Data
{
    /// <summary>
    /// Class which created and sets up DbParameters for ADO use.
    /// </summary>
    public class SqlParameterFactory : ParameterFactoryBase<SqlDbType>
    {
        /// <summary>
        /// Initializes a new instance of the SqlParameterFactory class.
        /// </summary>
        /// <param name="commandToUse">The ADO DB Command.</param>
        public SqlParameterFactory(IDbCommand commandToUse)
            : base(commandToUse)
        {
        }

        /// <summary>
        /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
        /// </summary>
        /// <param name="name">Name of parameter.</param>
        /// <param name="databaseType">Database type of parameter.</param>
        /// <returns>DbParameter object for the provider.</returns>
        public override IDbDataParameter Make(string name, SqlDbType databaseType)
        {
            var parameter = this.Make(name) as SqlParameter;
            if (parameter == null)
            {
                return null;
            }

            parameter.SqlDbType = databaseType;
            return parameter;
        }

        protected override void DefineStrategies()
        {
            this.Strategies.Add(typeof(bool), SqlDbType.Bit);
            this.Strategies.Add(typeof(DateTime), SqlDbType.DateTime);
            this.Strategies.Add(typeof(DateTimeOffset), SqlDbType.DateTimeOffset);
            this.Strategies.Add(typeof(decimal), SqlDbType.Decimal);
            this.Strategies.Add(typeof(double), SqlDbType.Float);
            this.Strategies.Add(typeof(Guid), SqlDbType.UniqueIdentifier);
            this.Strategies.Add(typeof(int), SqlDbType.Int);
            this.Strategies.Add(typeof(string), SqlDbType.NVarChar);
            this.Strategies.Add(typeof(TimeSpan), SqlDbType.Time);
        }
    }
}
