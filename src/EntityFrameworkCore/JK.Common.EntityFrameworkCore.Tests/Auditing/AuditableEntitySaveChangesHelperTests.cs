using JK.Common.EntityFrameworkCore.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace JK.Common.EntityFrameworkCore.Tests.Auditing
{
    public class AuditableEntitySaveChangesHelperTests
    {
        [Fact]
        public void SaveChanges_Create()
        {
            var builder = new DbContextOptionsBuilder<AuditableEntityContext>();
            builder.UseInMemoryDatabase("SaveChanges_Create");
            var options = builder.Options;
            Guid entityId;
            using (var context = new AuditableEntityContext(options))
            {
                context.UserName = "Jane Doe";
                var entity = new SimpleAuditableEntity { Text = "Hello World" };
                context.SimpleEntities.Add(entity);
                context.SaveChanges();
                entityId = entity.Id;
            }

            using (var context = new AuditableEntityContext(options))
            {
                var entity = context.SimpleEntities.FirstOrDefault(x => x.Id == entityId);
                Assert.Equal(entity.DateCreated, entity.DateModified);
                Assert.Equal("Jane Doe", entity.CreatedBy);
                Assert.Equal("Jane Doe", entity.ModifiedBy);
            }
        }

        [Fact]
        public void SaveChanges_Update()
        {
            var builder = new DbContextOptionsBuilder<AuditableEntityContext>();
            builder.UseInMemoryDatabase("SaveChanges_Update");
            var options = builder.Options;
            Guid entityId;
            using (var context = new AuditableEntityContext(options))
            {
                // create
                context.UserName = "Jane Doe";
                var entityToCreate = new SimpleAuditableEntity { Text = "Hello World" };
                context.SimpleEntities.Add(entityToCreate);
                context.SaveChanges();
                entityId = entityToCreate.Id;

                // modify
                context.UserName = "John Deaux";
                var entityToModify = context.SimpleEntities.FirstOrDefault(x => x.Id == entityId);
                entityToModify.Text = "Change Me!";
                context.SaveChanges();
            }

            using (var context = new AuditableEntityContext(options))
            {
                var entity = context.SimpleEntities.FirstOrDefault(x => x.Id == entityId);
                Assert.NotEqual(entity.DateCreated, entity.DateModified);
                Assert.Equal("Jane Doe", entity.CreatedBy);
                Assert.Equal("John Deaux", entity.ModifiedBy);
            }
        }

        private class SimpleAuditableEntity : AuditableEntity
        {
            public SimpleAuditableEntity()
            {
                this.Id = Guid.NewGuid();
            }

            [Key]
            public Guid Id { get; private set; }
            
            public string Text { get; set; }
        }

        private class AuditableEntityContext : DbContext
        {
            private const string contextName = "AuditableEntityContext";
            private readonly AuditableEntitySaveChangesHelper auditableEntitySaveChangesHelper = new AuditableEntitySaveChangesHelper(contextName);

            public AuditableEntityContext()
            {
            }

            public AuditableEntityContext(DbContextOptions options)
            : base(options)
            {
            }

            public string UserName { get; set; } = contextName;

            public DbSet<SimpleAuditableEntity> SimpleEntities { get; set; }

            public override int SaveChanges()
            {
                this.auditableEntitySaveChangesHelper.AuditChanges(this.ChangeTracker, this.Entry, this.UserName);
                return base.SaveChanges();
            }
        }
    }
}
