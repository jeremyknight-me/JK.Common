using JK.Common.Text;

namespace JK.Common.Tests.Text;

public class TemplateProcessorTests
{
    [Fact]
    public void ProcessTemplate_DefaultSettings_TokensReplaced()
    {
        var testObject = new TemplateTester { StringValue = "WIN" };
        var template = "The string is {{TemplateTester.StringValue}}.";
        var expected = "The string is WIN.";

        var templateProcessor = new TemplateProcessor(template);
        templateProcessor.Objects.Add(testObject);

        var actual = templateProcessor.ProcessTemplate();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ProcessTemplate_DefaultSettingsNullProperty_TokensReplaced()
    {
        var testObject = new TemplateTester();
        var template = "The string is: {{TemplateTester.StringValue}}";
        var expected = "The string is: ";

        var templateProcessor = new TemplateProcessor(template);
        templateProcessor.Objects.Add(testObject);

        var actual = templateProcessor.ProcessTemplate();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ProcessTemplate_DefaultSettingsDuplicateTokens_TokensReplaced()
    {
        var testObject = new TemplateTester { StringValue = "WIN" };
        var template = "The string is {{TemplateTester.StringValue}} and {{TemplateTester.StringValue}}.";
        var expected = "The string is WIN and WIN.";

        var templateProcessor = new TemplateProcessor(template);
        templateProcessor.Objects.Add(testObject);

        var actual = templateProcessor.ProcessTemplate();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ProcessTemplate_CustomTokenWrappers_TokensReplaced()
    {
        var testObject = new TemplateTester { StringValue = "WIN" };
        var template = "The string is [[TemplateTester.StringValue]].";
        var expected = "The string is WIN.";

        var templateProcessor = new TemplateProcessor(template, "[[", "]]");
        templateProcessor.Objects.Add(testObject);

        var actual = templateProcessor.ProcessTemplate();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ProcessTemplate_ValidObjectInvalidTemplateProperty_LeavesToken()
    {
        var testObject = new TemplateTester { StringValue = "WIN" };
        var template = "The string is {{TemplateTester.StringValue}} {{TemplateTester.Title}}.";
        var expected = "The string is WIN {{TemplateTester.Title}}.";

        var templateProcessor = new TemplateProcessor(template);
        templateProcessor.Objects.Add(testObject);

        var actual = templateProcessor.ProcessTemplate();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ProcessTemplate_ReadOnlyDisplayProperty_ReplacesToken()
    {
        var testObject = new TemplateTester { Option = OptionsEnum.Option1 };
        var template = "The option is {{TemplateTester.OptionDisplay}}.";
        var templateProcessor = new TemplateProcessor(template);
        templateProcessor.Objects.Add(testObject);
        var actual = templateProcessor.ProcessTemplate();
        Assert.Equal("The option is Option 1.", actual);
    }

    private class TemplateTester
    {
        public string StringValue { get; set; }

        public OptionsEnum Option { get; set; }

        public string OptionDisplay
            => Option switch
            {
                OptionsEnum.Option1 => "Option 1",
                OptionsEnum.Option2 => "Option 2",
                _ => throw new ArgumentOutOfRangeException(),
            };
    }
}
