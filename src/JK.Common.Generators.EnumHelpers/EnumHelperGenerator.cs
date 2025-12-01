using Microsoft.CodeAnalysis;

namespace JK.Common.Generators.EnumHelpers;

[Generator]
public sealed class EnumHelperGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context
            .RegisterPostInitializationOutput(i =>
            {
                i.AddEmbeddedAttributeDefinition();
                i.AddSource("EnumHelperAttribute.g.cs", EnumHelperAttributeFactory.SourceCode);
            });
    }
}
