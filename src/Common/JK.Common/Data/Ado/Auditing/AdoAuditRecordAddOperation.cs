using System;
using System.Data;
using System.Data.Common;

namespace JK.Common.Data.Ado.Auditing
{
    [Obsolete("ADO Auditing has been left in for reference purposes. Use EF Core Auditing features instead.")]
    internal class AdoAuditRecordAddOperation : AdoNonQueryOperation
    {
        private const string commandText
            = @"INSERT INTO [AuditRecord] 
                ( [DateStamp], [ObjectName], [ObjectId], [OriginalObject], [ChangedObject] )
                VALUES 
                ( @dateStamp, @objectName, @objectId, @originalObject, @changedObject )";

        private readonly AuditRecord record;

        public AdoAuditRecordAddOperation(AdoBaseRepository repository, AuditRecord auditRecord)
            : base(repository, CommandType.Text, commandText)
        {
            this.record = auditRecord;
        }

        protected override void SetupParameters(DbCommand command)
        {
            var factory = this.GetParameterFactory(command);

            var dateStampParamenter = factory.Make("dateStamp", this.record.DateStamp);
            command.Parameters.Add(dateStampParamenter);

            var objectIdParameter = factory.Make("objectId", this.record.ObjectId);
            command.Parameters.Add(objectIdParameter);

            var objectNameParameter = factory.Make("objectName", this.record.ObjectName);
            command.Parameters.Add(objectNameParameter);

            var originalObjectParameter = factory.Make("originalObject", this.record.OriginalObject);
            command.Parameters.Add(originalObjectParameter);

            var changedObjectParameter = factory.Make("changedObject", this.record.ChangedObject);
            command.Parameters.Add(changedObjectParameter);
        }
    }
}
