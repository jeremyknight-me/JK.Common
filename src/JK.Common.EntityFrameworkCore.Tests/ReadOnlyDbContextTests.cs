using System.Threading.Tasks;

namespace JK.Common.EntityFrameworkCore.Tests;

public class ReadOnlyDbContextTests
{
    [Fact]
    public void SaveChanges_InvalidOperation()
    {
        var builder = new DbContextOptionsBuilder<ReadContext>();
        builder.UseInMemoryDatabase("SaveChanges_Create");
        DbContextOptions<ReadContext> options = builder.Options;
        using (var context = new ReadContext(options))
        {
            var entity = new SimpleEntity { Text = "Hello World" };
            context.SimpleEntities.Add(entity);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => context.SaveChanges());
            Assert.Equal("This context is read-only.", ex.Message);
        }
    }

    [Fact]
    public async Task SaveChangesAsync_InvalidOperation()
    {
        var builder = new DbContextOptionsBuilder<ReadContext>();
        builder.UseInMemoryDatabase("SaveChanges_Create");
        DbContextOptions<ReadContext> options = builder.Options;
        using (var context = new ReadContext(options))
        {
            var entity = new SimpleEntity { Text = "Hello World" };
            context.SimpleEntities.Add(entity);
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(async () => await context.SaveChangesAsync(TestContext.Current.CancellationToken));
            Assert.Equal("This context is read-only.", ex.Message);
        }
    }

    private class SimpleEntity
    {
        public SimpleEntity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; private set; }
        public string Text { get; set; }
    }

    private class ReadContext : ReadOnlyDbContext
    {
        public ReadContext()
        {
        }

        public ReadContext(DbContextOptions<ReadContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleEntity> SimpleEntities { get; set; }
    }
}
