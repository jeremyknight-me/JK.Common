using System.Data.Entity;
using DL.Core.Data.Entity;
using DL.Core.Data.Entity.Auditing;

namespace DL.Core.UI.ConsoleApplication.Model
{
    internal class TestContext : DbContextEnhanced
    {
        public TestContext()
            : base("Testing")
        {
        }

        public IDbSet<EntityTest> EntityTests { get; set; }
        
        protected override AuditorFactoryBase GetAuditorFactory()
        {
            return new TestAuditorFactory();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuditLogMap("dbo"));

            var entity = modelBuilder.Entity<EntityTest>();
            entity.ToTable("EntityTest", "dbo");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired();
            entity.Property(x => x.Name).IsRequired();
        }
    }
}
