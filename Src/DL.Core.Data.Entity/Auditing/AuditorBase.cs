using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace DL.Core.Data.Entity.Auditing
{
    public class AuditorBase : IAuditor
    {
        private const string format = "[{0}]={1} || ";

        private readonly DateTimeOffset changeTime;

        public AuditorBase()
        {
            this.changeTime = DateTimeOffset.UtcNow;
        }

        public AuditLog AuditChange(DbEntityEntry entry, string userToken)
        {
            Func<string, DbEntityEntry, AuditLog> action;

            switch (entry.State)
            {
                case EntityState.Added:
                    action = this.GetAddedAudit;
                    break;
                case EntityState.Deleted:
                    action = this.GetDeleteAudit;
                    break;
                case EntityState.Modified:
                    action = this.GetModifiedAudit;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("entry", "EntityState of DbEntityEntry object is not valid for this function.");
            }

            return action(userToken, entry);
        }

        protected virtual string GetRecordId(DbPropertyValues values)
        {
            return values.GetValue<object>("Id").ToString();
        }

        protected virtual string GetRecordIdFromCurrentValues(DbEntityEntry entry)
        {
            return this.GetRecordId(entry.CurrentValues);
        }

        protected virtual string GetRecordIdFromOriginalValues(DbEntityEntry entry)
        {
            return this.GetRecordId(entry.OriginalValues);
        }

        protected virtual string GetTableName(DbEntityEntry entry)
        {
            var tableAttribute = entry.Entity.GetType()
                .GetCustomAttributes(typeof(TableAttribute), false)
                .SingleOrDefault() as TableAttribute;

            if (tableAttribute != null)
            {
                return tableAttribute.Name;
            }

            Type entryType = entry.Entity.GetType();
            string name = entryType.Name;

            if (name.Contains("_"))
            {
                int position = name.IndexOf("_");
                return name.Substring(0, position);
            }

            return entryType.Name;
        }

        private AuditLog GetBaseLog(string userToken, DbEntityEntry entry)
        {
            return new AuditLog
            {
                Id = Guid.NewGuid(),
                UserToken = userToken,
                Datestamp = this.changeTime,
                TableName = this.GetTableName(entry)
            };
        }

        private AuditLog GetDeleteAudit(string userToken, DbEntityEntry entry)
        {
            AuditLog audit = this.GetBaseLog(userToken, entry);
            audit.Operation = AuditOperation.D.ToString();
            audit.RecordId = this.GetRecordIdFromOriginalValues(entry);
            audit.NewValue = null;
            audit.OriginalValue = this.ListAllProperties(entry.OriginalValues);
            return audit;
        }

        private AuditLog GetAddedAudit(string userToken, DbEntityEntry entry)
        {
            AuditLog audit = this.GetBaseLog(userToken, entry);
            audit.Operation = AuditOperation.C.ToString();
            audit.OriginalValue = null;
            audit.GetRecordIdAction = this.GetRecordIdFromCurrentValues;
            audit.NewValue = this.ListAllProperties(entry.CurrentValues);
            return audit;
        }

        private AuditLog GetModifiedAudit(string userToken, DbEntityEntry entry)
        {
            var audit = this.GetBaseLog(userToken, entry);
            audit.Operation = AuditOperation.U.ToString();
            audit.RecordId = this.GetRecordIdFromOriginalValues(entry);
            var currentBuilder = new StringBuilder();
            var originalBuilder = new StringBuilder();
            this.RecurseProperties(entry.OriginalValues, entry.CurrentValues, currentBuilder, originalBuilder);

            if (currentBuilder.Length > 0)
            {
                currentBuilder = currentBuilder.Remove(currentBuilder.Length - 3, 3);
            }

            if (originalBuilder.Length > 0)
            {
                originalBuilder = originalBuilder.Remove(originalBuilder.Length - 3, 3);
            }

            audit.NewValue = currentBuilder.ToString();
            audit.OriginalValue = originalBuilder.ToString();
            return audit;
        }

        private string ListAllProperties(DbPropertyValues values)
        {
            var builder = new StringBuilder();

            foreach (var propertyName in values.PropertyNames)
            {
                var currentValueObject = values.GetValue<object>(propertyName);
                var currentValue = currentValueObject == null ? "NULL" : currentValueObject.ToString();
                builder.AppendFormat(format, propertyName, currentValue);
            }

            if (builder.Length > 0)
            {
                builder = builder.Remove(builder.Length - 3, 3);
            }

            return builder.ToString();
        }

        private void RecurseProperties(DbPropertyValues originalValues, DbPropertyValues currentValues, StringBuilder currentBuider, StringBuilder originalBuilder)
        {
            foreach (var propertyName in originalValues.PropertyNames)
            {
                var originalValueObject = originalValues.GetValue<object>(propertyName);

                if (originalValueObject != null && originalValueObject.GetType() == typeof(DbPropertyValues))
                {
                    var childOriginalValues = originalValues.GetValue<DbPropertyValues>(propertyName);
                    var childCurrentValues = currentValues.GetValue<DbPropertyValues>(propertyName);
                    this.RecurseProperties(childOriginalValues, childCurrentValues, currentBuider, originalBuilder);
                }
                else
                {
                    var originalValue = originalValueObject == null ? "NULL" : originalValueObject.ToString();
                    var currentValueObject = currentValues.GetValue<object>(propertyName);
                    var currentValue = currentValueObject == null ? "NULL" : currentValueObject.ToString();

                    if (originalValue != currentValue)
                    {
                        currentBuider.AppendFormat(format, propertyName, currentValue);
                        originalBuilder.AppendFormat(format, propertyName, originalValue);    
                    }
                }
            }
        }
    }
}
