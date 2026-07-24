using System.Collections.Immutable;
using JK.Common.Polyfills.Fills;

namespace JK.Common.Polyfills;

/// <summary>
/// A source generator that emits polyfill source files for missing language and runtime features.
/// </summary>
[Generator]
public sealed class PolyfillGenerator : IIncrementalGenerator
{
    /// <summary>
    /// Initializes the incremental generator.
    /// </summary>
    /// <param name="context">The initialization context.</param>
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
