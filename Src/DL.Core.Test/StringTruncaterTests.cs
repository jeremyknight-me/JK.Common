using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Tests
{
    [TestClass]
    public class StringTruncaterTests
    {
        [TestMethod]
        public void TruncateToLength_NoIndicator_TruncatedTextWithoutIndicator()
        {
            const string original = "abcdefghijklmnopqrstuvwxyz0123456789";
            const int length = 26;

            var truncater = new StringTruncater(original);
            string actual = truncater.TruncateToLength(length);
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", actual);
        }

        [TestMethod]
        public void TruncateToLength_Indicator_TruncatedTextWithIndicator()
        {
            const string original = "abcdefghijklmnopqrstuvwxyz0123456789";
            const int length = 26;
            const string indicator = "...";

            var truncater = new StringTruncater(original, indicator);
            string actual = truncater.TruncateToLength(length);
            Assert.AreEqual("abcdefghijklmnopqrstuvw...", actual);
        }

        [TestMethod]
        public void TruncateToLength_NoTruncationNeededNoIndicator_OriginalText()
        {
            const string original = "abcdefghijklmnopqrstuvwxyz";
            const int length = 26;

            var truncater = new StringTruncater(original);
            string actual = truncater.TruncateToLength(length);
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", actual);
        }

        [TestMethod]
        public void TruncateToLength_NoTruncationNeededIndicator_OriginalText()
        {
            const string original = "abcdefghijklmnopqrstuvwxyz";
            const int length = 26;
            const string indicator = "...";

            var truncater = new StringTruncater(original, indicator);
            string actual = truncater.TruncateToLength(length);
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", actual);
        }
    }
}
