using System.Linq;

namespace JK.Common.EntityFrameworkCore.Tests;

public class ChangeTrackerExtensionsTests
{
    [Fact]
    public void SaveChanges_Create()
    {
        var builder = new DbContextOptionsBuilder<AuditableEntityContext>();
        builder.UseInMemoryDatabase("AuditableEntitySaveChangesHelperTests_SaveChanges_Create");
        var options = builder.Options;
        Guid entityId;
        var auditedCount = 0;
        using (var context = new AuditableEntityContext(options))
        {
            var entity = new SimpleAuditableEntity { Text = "Hello World" };
            context.SimpleEntities.Add(entity);
            context.SaveChanges();
            entityId = entity.Id;
            auditedCount = context.AuditedCount;
        }

        using (var context = new AuditableEntityContext(options))
        {
            var entity = context.SimpleEntities.FirstOrDefault(x => x.Id == entityId);
            Assert.Equal(0, auditedCount);
        }
    }

    [Fact]
    public void SaveChanges_Update()
    {
        var builder = new DbContextOptionsBuilder<AuditableEntityContext>();
        builder.UseInMemoryDatabase("AuditableEntitySaveChangesHelperTests_SaveChanges_Update");
        var options = builder.Options;
        Guid entityId;
        var auditedCount = 0;
        using (var context = new AuditableEntityContext(options))
        {
            // create
            var entityToCreate = new SimpleAuditableEntity { Text = "Hello World" };
            context.SimpleEntities.Add(entityToCreate);
            context.SaveChanges();
            entityId = entityToCreate.Id;

            // modify
            var entityToModify = context.SimpleEntities.FirstOrDefault(x => x.Id == entityId);
            entityToModify.Text = "Change Me!";
            context.SaveChanges();
            auditedCount = context.AuditedCount;
        }

        using (var context = new AuditableEntityContext(options))
        {
            var entity = context.SimpleEntities.FirstOrDefault(x => x.Id == entityId);
            Assert.Equal(1, auditedCount);
            Assert.NotEqual(entity.DateCreated, entity.DateModified);
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

        public AuditableEntityContext()
        {
        }

        public AuditableEntityContext(DbContextOptions options)
        : base(options)
        {
        }

        public string UserName { get; set; } = contextName;
        public int AuditedCount { get; private set; } 

        public DbSet<SimpleAuditableEntity> SimpleEntities { get; set; }

        public override int SaveChanges()
        {
            this.AuditedCount = this.ChangeTracker.EnsureAuditableEntitiesUpdated();
            return base.SaveChanges();
        }
    }
}
