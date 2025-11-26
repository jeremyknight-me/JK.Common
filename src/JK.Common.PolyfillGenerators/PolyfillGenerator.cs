using System.Collections.Immutable;
using JK.Common.PolyfillGenerators.Polyfills;

namespace JK.Common.PolyfillGenerators;

[Generator]
public sealed class PolyfillGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<IGeneratedPolyfill> polyfills = context.CompilationProvider
            .SelectMany((compilation, ct) =>
            {
                IGeneratedPolyfill[] polyfills =
                [
                    new IsExternalInitPolyfill()
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
