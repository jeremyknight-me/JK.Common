using JK.Common.EntityFrameworkCore.Auditing.Sets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JK.Common.EntityFrameworkCore.Tests.Auditing.Sets
{
    public class AuditLogSaveChangesHelperTests
    {
        [Fact]
        public void SaveChanges_Create()
        {
            var builder = new DbContextOptionsBuilder<AuditableContext>();
            builder.UseInMemoryDatabase("AuditLogSaveChangesHelperTests_SaveChanges_Create");
            var options = builder.Options;
            Guid entityOneId;
            Guid entityTwoId;
            using (var context = new AuditableContext(options))
            {
                var entityOne = new EntityOne { Text = "Hello World 123" };
                context.EntityOnes.Add(entityOne);
                var entityTwo = new EntityTwo { Text = "Hello World 234" };
                context.EntityTwos.Add(entityTwo);
                context.SaveChanges();
                entityOneId = entityOne.Id;
                entityTwoId = entityTwo.Id;
            }

            using (var context = new AuditableContext(options))
            {
                var entityOne = context.EntityOnes.FirstOrDefault(x => x.Id == entityOneId);
                var entityTwo = context.EntityTwos.FirstOrDefault(x => x.Id == entityTwoId);
                var logs = context.AuditLogs.ToArray();

                Assert.Equal("Hello World 123", entityOne.Text);
                Assert.Equal("Hello World 234", entityTwo.Text);
                Assert.Equal(2, logs.Count());
                Assert.Contains(logs, x => x.KeyValues.Contains(entityOneId.ToString()));
                Assert.Contains(logs, x => x.KeyValues.Contains(entityTwoId.ToString()));
                Assert.All(logs, x => Assert.Equal("Added", x.EventType));
            }
        }

        [Fact]
        public void SaveChanges_Update()
        {
            var builder = new DbContextOptionsBuilder<AuditableContext>();
            builder.UseInMemoryDatabase("AuditLogSaveChangesHelperTests_SaveChanges_Update");
            var options = builder.Options;
            Guid entityOneId;
            Guid entityTwoId;
            using (var context = new AuditableContext(options))
            {
                var entityOne = new EntityOne { Text = "Hello World 123" };
                context.EntityOnes.Add(entityOne);
                var entityTwo = new EntityTwo { Text = "Hello World 234" };
                context.EntityTwos.Add(entityTwo);
                context.SaveChanges();
                entityOneId = entityOne.Id;
                entityTwoId = entityTwo.Id;

                entityOne.Text = "Hi World 123";
                entityTwo.Text = "Hi World 234";
                context.SaveChanges();
            }

            using (var context = new AuditableContext(options))
            {
                var entityOne = context.EntityOnes.FirstOrDefault(x => x.Id == entityOneId);
                var entityTwo = context.EntityTwos.FirstOrDefault(x => x.Id == entityTwoId);
                var logs = context.AuditLogs.ToArray();

                Assert.Equal("Hi World 123", entityOne.Text);
                Assert.Equal("Hi World 234", entityTwo.Text);
                Assert.Equal(4, logs.Count());
                Assert.Contains(logs, x => x.KeyValues.Contains(entityOneId.ToString()));
                Assert.Contains(logs, x => x.KeyValues.Contains(entityTwoId.ToString()));
                Assert.Equal(2, logs.Count(x => x.EventType == "Added"));
                Assert.Equal(2, logs.Count(x => x.EventType == "Modified"));
            }
        }

        private class EntityOne
        {
            public EntityOne()
            {
                this.Id = Guid.NewGuid();
            }

            [Key]
            public Guid Id { get; private set; }

            public string Text { get; set; }
        }

        [Table("Entity_Two")]
        private class EntityTwo
        {
            public EntityTwo()
            {
                this.Id = Guid.NewGuid();
            }

            [Key]
            public Guid Id { get; private set; }

            public string Text { get; set; }
        }

        private class AuditableContext : DbContext, IAuditableContext
        {
            private readonly AuditLogSaveChangesHelper auditLogSaveChangesHelper;

            public AuditableContext()
            {
                this.auditLogSaveChangesHelper = new AuditLogSaveChangesHelper(this);
            }

            public AuditableContext(DbContextOptions options)
            : base(options)
            {
                this.auditLogSaveChangesHelper = new AuditLogSaveChangesHelper(this);
            }

            public DbSet<AuditLog> AuditLogs { get; set; }
            public DbSet<EntityOne> EntityOnes { get; set; }
            public DbSet<EntityTwo> EntityTwos { get; set; }

            public override int SaveChanges()
            {
                var auditEntries = this.auditLogSaveChangesHelper.OnBeforeSaveChanges();
                var result = base.SaveChanges();
                this.auditLogSaveChangesHelper.OnAfterSaveChanges(auditEntries);
                return result;
            }

            public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            {
                var auditEntries = this.auditLogSaveChangesHelper.OnBeforeSaveChanges();
                var result = await base.SaveChangesAsync(cancellationToken);
                await this.auditLogSaveChangesHelper.OnAfterSaveChangesAsync(auditEntries);
                return result;
            }
        }
    }
}
