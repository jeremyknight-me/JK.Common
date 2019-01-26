using JK.Common.Text;
using System;
using Xunit;

namespace JK.Common.Tests.Text
{
    public class TemplateProcessorTests
    {
        #region ProcessTemplate() Tests

        [Fact]
        public void ProcessTemplate_DefaultSettings_TokensReplaced()
        {
            var testObject = new TemplateTester { StringValue = "WIN" };
            string template = "The string is {{TemplateTester.StringValue}}.";
            string expected = "The string is WIN.";

            var templateProcessor = new TemplateProcessor(template);
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProcessTemplate_DefaultSettingsNullProperty_TokensReplaced()
        {
            var testObject = new TemplateTester();
            string template = "The string is: {{TemplateTester.StringValue}}";
            string expected = "The string is: ";

            var templateProcessor = new TemplateProcessor(template);
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProcessTemplate_DefaultSettingsDuplicateTokens_TokensReplaced()
        {
            var testObject = new TemplateTester { StringValue = "WIN" };
            string template = "The string is {{TemplateTester.StringValue}} and {{TemplateTester.StringValue}}.";
            string expected = "The string is WIN and WIN.";

            var templateProcessor = new TemplateProcessor(template);
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProcessTemplate_CustomTokenWrappers_TokensReplaced()
        {
            var testObject = new TemplateTester { StringValue = "WIN" };
            string template = "The string is [[TemplateTester.StringValue]].";
            string expected = "The string is WIN.";

            var templateProcessor = new TemplateProcessor(template, "[[", "]]");
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProcessTemplate_ValidObjectInvalidTemplateProperty_LeavesToken()
        {
            var testObject = new TemplateTester { StringValue = "WIN" };
            string template = "The string is {{TemplateTester.StringValue}} {{TemplateTester.Title}}.";
            string expected = "The string is WIN {{TemplateTester.Title}}.";

            var templateProcessor = new TemplateProcessor(template);
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProcessTemplate_ReadOnlyDisplayProperty_ReplacesToken()
        {
            var testObject = new TemplateTester { Option = OptionsEnum.Option1 };
            string template = "The option is {{TemplateTester.OptionDisplay}}.";
            var templateProcessor = new TemplateProcessor(template);
            templateProcessor.Objects.Add(testObject);
            string actual = templateProcessor.ProcessTemplate();
            Assert.Equal("The option is Option 1.", actual);
        }

        #endregion

        private class TemplateTester
        {
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public string StringValue { get; set; }

            public OptionsEnum Option { get; set; }

            public string OptionDisplay
            {
                get
                {
                    switch (this.Option)
                    {
                        case OptionsEnum.Option1:
                            return "Option 1";
                        case OptionsEnum.Option2:
                            return "Option 2";
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
}
