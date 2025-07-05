using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JK.Common.EntityFrameworkCore.Interceptors;

namespace JK.Common.EntityFrameworkCore.Tests.Interceptors;

public class AuditableSaveChangesInterceptorTests
{
    private const string className = $"{nameof(AuditableSaveChangesInterceptorTests)}";

    protected CancellationToken CT => TestContext.Current.CancellationToken;

    [Fact]
    public void SaveChanges_Create()
    {
        const string databaseName = $"{className}_{nameof(SaveChanges_Create)}";
        Guid entityId;
        var auditedCount = 0;
        using (var context = this.MakeContext(databaseName))
        {
            var entity = new SimpleAuditableEntity { Text = "Hello World" };
            _ = context.SimpleEntities.Add(entity);
            auditedCount += context.SaveChanges();
            entityId = entity.Id;
        }

        using (var context = this.MakeContext(databaseName))
        {
            var entity = context.SimpleEntities.FirstOrDefault(x => x.Id == entityId);
            Assert.Equal(1, auditedCount);
            Assert.Equal(entity.DateCreatedUtc, entity.DateModifiedUtc);
        }
    }

    [Fact]
    public async Task SaveChangesAsync_Create()
    {
        const string databaseName = $"{className}_{nameof(SaveChangesAsync_Create)}";
        Guid entityId;
        var auditedCount = 0;
        using (var context = this.MakeContext(databaseName))
        {
            var entity = new SimpleAuditableEntity { Text = "Hello World" };
            _ = await context.SimpleEntities.AddAsync(entity, CT);
            auditedCount += await context.SaveChangesAsync(CT);
            entityId = entity.Id;
        }

        using (var context = this.MakeContext(databaseName))
        {
            var entity = await context.SimpleEntities.FirstOrDefaultAsync(x => x.Id == entityId, CT);
            Assert.Equal(1, auditedCount);
            Assert.Equal(entity.DateCreatedUtc, entity.DateModifiedUtc);
        }
    }

    [Fact]
    public void SaveChanges_Update()
    {
        const string databaseName = $"{className}_{nameof(SaveChanges_Update)}";
        Guid entityId;
        var auditedCount = 0;
        using (var context = this.MakeContext(databaseName))
        {
            // create
            var entityToCreate = new SimpleAuditableEntity { Text = "Hello World" };
            _ = context.SimpleEntities.Add(entityToCreate);
            auditedCount += context.SaveChanges();
            entityId = entityToCreate.Id;

            // modify
            var entityToModify = context.SimpleEntities.FirstOrDefault(x => x.Id == entityId);
            entityToModify.Text = "Change Me!";
            auditedCount += context.SaveChanges();
        }

        using (var context = this.MakeContext(databaseName))
        {
            var entity = context.SimpleEntities.FirstOrDefault(x => x.Id == entityId);
            Assert.Equal(2, auditedCount);
            Assert.NotEqual(entity.DateCreatedUtc, entity.DateModifiedUtc);
        }
    }

    [Fact]
    public async Task SaveChangesAsync_Update()
    {
        const string databaseName = $"{className}_{nameof(SaveChanges_Update)}";
        Guid entityId;
        var auditedCount = 0;
        using (var context = this.MakeContext(databaseName))
        {
            // create
            var entityToCreate = new SimpleAuditableEntity { Text = "Hello World" };
            _ = await context.SimpleEntities.AddAsync(entityToCreate, CT);
            auditedCount += await context.SaveChangesAsync(CT);
            entityId = entityToCreate.Id;

            // modify
            var entityToModify = await context.SimpleEntities.FirstOrDefaultAsync(x => x.Id == entityId, CT);
            entityToModify.Text = "Change Me!";
            auditedCount += await context.SaveChangesAsync(CT);
        }

        using (var context = this.MakeContext(databaseName))
        {
            var entity = await context.SimpleEntities.FirstOrDefaultAsync(x => x.Id == entityId, CT);
            Assert.Equal(2, auditedCount);
            Assert.NotEqual(entity.DateCreatedUtc, entity.DateModifiedUtc);
        }
    }

    private AuditableEntityContext MakeContext(string databaseName)
    {
        var builder = new DbContextOptionsBuilder<AuditableEntityContext>()
            .UseInMemoryDatabase(databaseName)
            .AddInterceptors(new AuditableSaveChangesInterceptor());
        var options = builder.Options;
        return new AuditableEntityContext(options);
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

        public AuditableEntityContext(DbContextOptions options)
        : base(options)
        {
        }

        public string UserName { get; set; } = contextName;
        public int AuditedCount { get; private set; }

        public DbSet<SimpleAuditableEntity> SimpleEntities { get; set; }
    }
}
