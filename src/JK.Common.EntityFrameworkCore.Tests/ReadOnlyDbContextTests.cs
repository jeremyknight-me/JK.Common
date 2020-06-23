using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace JK.Common.EntityFrameworkCore.Tests
{
    public class ReadOnlyDbContextTests
    {
        [Fact]
        public void SaveChanges_InvalidOperation()
        {
            var builder = new DbContextOptionsBuilder<ReadContext>();
            builder.UseInMemoryDatabase("SaveChanges_Create");
            var options = builder.Options;
            using (var context = new ReadContext(options))
            {
                var entity = new SimpleEntity { Text = "Hello World" };
                context.SimpleEntities.Add(entity);
                var ex = Assert.Throws<InvalidOperationException>(() => context.SaveChanges());
                Assert.Equal("This context is read-only.", ex.Message);
            }
        }

        [Fact]
        public async Task SaveChangesAsync_InvalidOperation()
        {
            var builder = new DbContextOptionsBuilder<ReadContext>();
            builder.UseInMemoryDatabase("SaveChanges_Create");
            var options = builder.Options;
            using (var context = new ReadContext(options))
            {
                var entity = new SimpleEntity { Text = "Hello World" };
                context.SimpleEntities.Add(entity);
                var ex = await Assert.ThrowsAsync<InvalidOperationException>(async () => await context.SaveChangesAsync());
                Assert.Equal("This context is read-only.", ex.Message);
            }
        }

        private class SimpleEntity
        {
            public SimpleEntity()
            {
                this.Id = Guid.NewGuid();
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

            public ReadContext(DbContextOptions options)
                : base(options)
            {
            }

            public DbSet<SimpleEntity> SimpleEntities { get; set; }
        }
    }
}
