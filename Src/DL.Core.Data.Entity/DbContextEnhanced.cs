using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using DL.Core.Data.Entity.Auditing;

namespace DL.Core.Data.Entity
{
    public abstract class DbContextEnhanced : DbContext
    {
        #region Constructors

        protected DbContextEnhanced()
        {
        }

        protected DbContextEnhanced(DbCompiledModel model) 
            : base(model)
        {
        }

        protected DbContextEnhanced(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection) 
            : base(existingConnection, model, contextOwnsConnection)
        {   
        }

        protected DbContextEnhanced(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        protected DbContextEnhanced(ObjectContext objectContext, bool dbContextOwnsObjectContext) 
            : base(objectContext, dbContextOwnsObjectContext)
        {
        }

        protected DbContextEnhanced(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
        }

        protected DbContextEnhanced(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        #endregion

        public DbContext DbContext
        {
            get { return this; }
        }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public override int SaveChanges()
        {
            return this.SaveChanges("SYSTEM_USER");
        }

        public virtual int SaveChanges(string userId)
        {
            return this.ProcessChanges(userId);
        }

        protected abstract AuditorFactoryBase GetAuditorFactory();

        protected int ProcessChanges(string userToken)
        {
            var auditList = new List<AuditLog>();
            var list = new List<DbEntityEntry>();
            var auditorFactory = this.GetAuditorFactory();
            IEnumerable<DbEntityEntry> changedEntities = this.GetAuditableChanges();

            foreach (var entity in changedEntities)
            {
                IAuditor auditor = auditorFactory.MakeAuditor(entity.Entity.GetType());
                AuditLog audit = auditor.AuditChange(entity, userToken);
                auditList.Add(audit);
                list.Add(entity);
            }

            var retVal = base.SaveChanges();

            if (auditList.Any())
            {
                int i = 0;
                foreach (var audit in auditList)
                {
                    if (audit.Operation == AuditOperation.C.ToString())
                    {
                        audit.RecordId = audit.GetRecordIdAction(list[i]);
                    }

                    this.AuditLogs.Add(audit);
                    i++;
                }
                base.SaveChanges();
            }

            return retVal;
        }

        private IEnumerable<DbEntityEntry> GetAuditableChanges()
        {
            return this.ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Added
                    || p.State == EntityState.Deleted
                    || p.State == EntityState.Modified);
        }
    }
}
