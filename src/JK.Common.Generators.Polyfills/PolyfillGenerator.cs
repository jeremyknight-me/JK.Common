using System.Collections.Immutable;

namespace JK.Common.Generators.Polyfills;

[Generator]
public sealed class PolyfillGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<Polyfill> polyfills = context.CompilationProvider
            .SelectMany((compilation, ct) =>
            {
                Polyfill[] polyfills =
                [
                    IsExternalInitPolyfillFactory.Create()
                ];

                return polyfills.ToImmutableArray();
            })
            .Select((s, ct) => s);

        context.RegisterSourceOutput(polyfills, (ctx, polyfill) =>
        {
            var fileName = $"{polyfill.FileName}.g.cs";
            ctx.AddSource(fileName, polyfill.SourceCode);
        });
    }
}
