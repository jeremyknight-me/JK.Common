using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JK.Common.EntityFrameworkCore.Extensions;

public static class ModelBuilderExtensions
{
    extension(ModelBuilder modelBuilder)
    {
        public void ApplyAllAssemblyConfigurations(Assembly assembly = null)
        {
            assembly ??= Assembly.GetCallingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        public void EnsureRelationshipDeleteBehavior(DeleteBehavior deleteBehavior = DeleteBehavior.NoAction)
        {
            IEnumerable<IMutableForeignKey> relationships = modelBuilder.Model.GetEntityTypes()
                .Where(e => !e.IsOwned())
                .SelectMany(e => e.GetForeignKeys());

            foreach (IMutableForeignKey relationship in relationships)
            {
                relationship.DeleteBehavior = deleteBehavior;
            }
        }
    }
}
