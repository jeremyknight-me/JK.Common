using DL.Common.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Text
{
    [TestClass]
    public class TemplateProcessorTests
    {
        #region ProcessTemplate() Tests

        [TestMethod]
        public void ProcessTemplate_DefaultSettings_TokensReplaced()
        {
            var testObject = new TemplateTester { StringValue = "WIN" };
            string template = "The string is {{TemplateTester.StringValue}}.";
            string expected = "The string is WIN.";

            var templateProcessor = new TemplateProcessor(template);
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessTemplate_DefaultSettingsNullProperty_TokensReplaced()
        {
            var testObject = new TemplateTester();
            string template = "The string is: {{TemplateTester.StringValue}}";
            string expected = "The string is: ";

            var templateProcessor = new TemplateProcessor(template);
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessTemplate_DefaultSettingsDuplicateTokens_TokensReplaced()
        {
            var testObject = new TemplateTester { StringValue = "WIN" };
            string template = "The string is {{TemplateTester.StringValue}} and {{TemplateTester.StringValue}}.";
            string expected = "The string is WIN and WIN.";

            var templateProcessor = new TemplateProcessor(template);
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessTemplate_CustomTokenWrappers_TokensReplaced()
        {
            var testObject = new TemplateTester { StringValue = "WIN" };
            string template = "The string is [[TemplateTester.StringValue]].";
            string expected = "The string is WIN.";

            var templateProcessor = new TemplateProcessor(template, "[[", "]]");
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessTemplate_ValidObjectInvalidTemplateProperty_LeavesToken()
        {
            var testObject = new TemplateTester { StringValue = "WIN" };
            string template = "The string is {{TemplateTester.StringValue}} {{TemplateTester.Title}}.";
            string expected = "The string is WIN {{TemplateTester.Title}}.";

            var templateProcessor = new TemplateProcessor(template);
            templateProcessor.Objects.Add(testObject);

            string actual = templateProcessor.ProcessTemplate();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        private class TemplateTester
        {
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public string StringValue { get; set; }
        }
    }
}
