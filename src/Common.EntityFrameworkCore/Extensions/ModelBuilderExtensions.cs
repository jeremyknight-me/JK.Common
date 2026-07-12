using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JK.Common.EntityFrameworkCore.Extensions;

/// <summary>
/// Extension methods for <see cref="ModelBuilder"/>.
/// </summary>
public static class ModelBuilderExtensions
{
    extension(ModelBuilder modelBuilder)
    {
        /// <summary>
        /// Applies all <see cref="IEntityTypeConfiguration{T}"/> implementations from the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly to scan. If <c>null</c>, the calling assembly is used.</param>
        public void ApplyAllAssemblyConfigurations(Assembly assembly = null)
        {
            assembly ??= Assembly.GetCallingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        /// <summary>
        /// Sets the delete behavior for all relationships in the model.
        /// </summary>
        /// <param name="deleteBehavior">The delete behavior to apply. Defaults to <see cref="DeleteBehavior.NoAction"/>.</param>
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
