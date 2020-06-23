using JK.Common.Contracts;
using JK.Common.Xml;
using System;

namespace JK.Common.Data.Ado.Auditing
{
    [Obsolete("ADO Auditing has been left in for reference purposes. Use EF Core Auditing features instead.")]
    public class XmlAuditingService : IAuditingService
    {
        private readonly XmlSerializationFacade serializationFacade;

        private readonly IAuditRepository repository;

        public XmlAuditingService(IAuditRepository auditRepository)
        {
            this.repository = auditRepository;
            this.serializationFacade = new XmlSerializationFacade();
            this.Record = null;
        }

        public AuditRecord Record { get; private set; }

        public bool AreEqual<TKey, TEntity>(TEntity originalEntity, TEntity changedEntity) where TEntity : IIdentifiable<TKey>
        {
            this.ValidateObjects<TKey, TEntity>(originalEntity, changedEntity);
            string originalXml = this.serializationFacade.GetXmlAsString(originalEntity);
            string changedXml = this.serializationFacade.GetXmlAsString(changedEntity);

            this.Record
                = new AuditRecord
                {
                    ChangedObject = changedXml,
                    DateStamp = DateTime.UtcNow,
                    ObjectId = originalEntity.Id.ToString(),
                    ObjectName = typeof(TEntity).FullName,
                    OriginalObject = originalXml
                };

            return originalXml == changedXml;
        }

        public void LogChange()
        {
            this.repository.Add(this.Record);
        }

        private void ValidateObjects<TKey, TEntity>(TEntity originalEntity, TEntity changedEntity) where TEntity : IIdentifiable<TKey>
        {
            const string nullMessage = "Objects to be audited cannot be null.";

            if (originalEntity == null)
            {
                throw new ArgumentNullException(nameof(originalEntity), nullMessage);
            }

            if (changedEntity == null)
            {
                throw new ArgumentNullException(nameof(changedEntity), nullMessage);
            }

            if (ReferenceEquals(originalEntity, changedEntity))
            {
                throw new ArgumentException("Objects must not point to the same reference.");
            }

            if (!originalEntity.Id.Equals(changedEntity.Id))
            {
                throw new ArgumentException("Objects must have the same ID.");
            }
        }
    }
}
