// ── Template Engine (Fluid) ──

using Fluid;

public class Template
{
    private static readonly FluidParser _parser = new();
    private static readonly TemplateOptions _options;

    static Template()
    {
        _options = new TemplateOptions();
        _options.Trimming = TrimmingFlags.None;
        _options.Greedy = false;
        _options.MemberAccessStrategy.Register<MemberDoc>();
        _options.MemberAccessStrategy.Register<ParamInfo>();
        _options.MemberAccessStrategy.Register<ExceptionInfo>();
    }

    private readonly IFluidTemplate _template;

    private Template(IFluidTemplate template) => _template = template;

    public static Template Load(string path)
    {
        var source = File.ReadAllText(path);
        if (!_parser.TryParse(source, out var template, out var error))
        {
            throw new InvalidOperationException($"Template parse error: {error}");
        }

        return new Template(template);
    }

    public string Render(object model)
    {
        var ctx = new TemplateContext(_options);
        if (model is IDictionary<string, object?> dict)
        {
            foreach (var (key, value) in dict)
            {
                ctx.SetValue(key, value);
            }
        }
        else
        {
            ctx = new TemplateContext(model, _options);
        }
        return _template.Render(ctx);
    }
}