using JK.Common.Data.Sql.BulkInsert.Attributes;
using Microsoft.CodeAnalysis;

namespace JK.Common.Data.Sql.BulkInsert;

internal static class NamedTypeSymbolExtensions
{
    internal static PropertyMetadata[] GetBulkInsertPropertyMetadata(this INamedTypeSymbol typeSymbol)
    {
        return typeSymbol.GetMembers().OfType<IPropertySymbol>()
            .Select(p => new
            {
                Property = p,
                Attribute = p.GetAttributes()
                    .FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == typeof(BulkInsertColumnAttribute).FullName)
            })
            .Where(x => x.Attribute != null)
            .Select(x =>
            {
                AttributeData attr = x.Attribute;
                return new PropertyMetadata
                {
                    PropertyName = x.Property.Name,
                    ColumnName = attr.ConstructorArguments[0].Value?.ToString() ?? x.Property.Name,
                    TypeName = x.Property.Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
                    IsNullable = x.Property.NullableAnnotation == NullableAnnotation.Annotated
                        || x.Property.Type.OriginalDefinition.SpecialType == SpecialType.System_Nullable_T
                };
            })
            .ToArray();
    }

    internal static string GetTableName(this INamedTypeSymbol typeSymbol)
    {
        AttributeData tableAttr = typeSymbol.GetAttributes()
            .FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == typeof(BulkInsertableAttribute).FullName);

        return tableAttr?.ConstructorArguments[0].Value?.ToString()
            ?? throw new InvalidOperationException($"Type '{typeSymbol.Name}' is missing [BulkInsertable] attribute.");
    }
}
