using System.Web.UI.WebControls;
using DL.Core.Web.TypeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Web.Tests.TypeExtensions
{
    [TestClass]
    public class WebControlUtilityTests
    {
        private MockWebControl webControl;

        private WebControlUtility utility;

        [TestInitialize]
        public void TestInitialize()
        {
            this.webControl = new MockWebControl();
            this.utility = new WebControlUtility();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.webControl = null;
            this.utility = null;
        }

        #region AddCssClass() Tests

        [TestMethod]
        public void AddCssClass_EmptyString_OnlyAddedClass()
        {
            this.webControl.CssClass = "";
            this.utility.AddCssClass(this.webControl, "added");
            Assert.AreEqual("added", this.webControl.CssClass);
        }

        [TestMethod]
        public void AddCssClass_OneClass_OriginalAndAdded()
        {
            this.webControl.CssClass = "one";
            this.utility.AddCssClass(this.webControl, "added");
            Assert.AreEqual("one added", this.webControl.CssClass);
        }

        [TestMethod]
        public void AddCssClass_MultipleClasses_OriginalPlusAddedClass()
        {
            this.webControl.CssClass = "one two";
            this.utility.AddCssClass(this.webControl, "added");
            Assert.AreEqual("one two added", this.webControl.CssClass);
        }

        [TestMethod]
        public void AddCssClass_ContainsNameClass_OriginalPlusAdded()
        {
            this.webControl.CssClass = "one added-two";
            this.utility.AddCssClass(this.webControl, "added");
            Assert.AreEqual("one added-two added", this.webControl.CssClass);
        }

        [TestMethod]
        public void AddCssClass_MultipleAdd_OriginalPlusMultipleAdditions()
        {
            this.webControl.CssClass = "one two";
            this.utility.AddCssClass(this.webControl, "three four");
            Assert.AreEqual("one two three four", this.webControl.CssClass);
        }

        #endregion

        #region ReplaceCssClass() Tests

        [TestMethod]
        public void ReplaceCssClass_EmptyRemoveValidAdd_OnlyAddedClass()
        {
            this.webControl.CssClass = "";
            this.utility.ReplaceCssClass(this.webControl, string.Empty, "added");
            Assert.AreEqual("added", this.webControl.CssClass);
        }

        [TestMethod]
        public void ReplaceCssClass_OneClass_CorrectlyReplaced()
        {
            this.webControl.CssClass = "one";
            this.utility.ReplaceCssClass(this.webControl, "one", "two");
            Assert.AreEqual("two", this.webControl.CssClass);
        }

        [TestMethod]
        public void ReplaceCssClass_MultipleClasses_CorrectlyReplaced()
        {
            this.webControl.CssClass = "one two";
            this.utility.ReplaceCssClass(this.webControl, "two", "added");
            Assert.AreEqual("one added", this.webControl.CssClass);
        }

        [TestMethod]
        public void ReplaceCssClass_ContainsNameClass_CorrectlyReplaced()
        {
            this.webControl.CssClass = "one added-two";
            this.utility.ReplaceCssClass(this.webControl, "one", "added");
            Assert.AreEqual("added-two added", this.webControl.CssClass);
        }

        [TestMethod]
        public void ReplaceCssClass_BootstrapAlerts_CorrectlyReplaced()
        {
            this.webControl.CssClass = "alert alert-danger";
            this.utility.ReplaceCssClass(this.webControl, "alert-danger", "alert-warning");
            Assert.AreEqual("alert alert-warning", this.webControl.CssClass);
        }

        #endregion

        #region RemoveCssClass() Tests

        [TestMethod]
        public void RemoveCssClass_NoClasses_EmptyString()
        {
            this.webControl.CssClass = "";
            this.utility.RemoveCssClass(this.webControl, "remove");
            Assert.AreEqual("", this.webControl.CssClass);
        }

        [TestMethod]
        public void RemoveCssClass_OneClassMatching_EmptyString()
        {
            this.webControl.CssClass = "remove";
            this.utility.RemoveCssClass(this.webControl, "remove");
            Assert.AreEqual("", this.webControl.CssClass);
        }

        [TestMethod]
        public void RemoveCssClass_OneClassNonMatching_OriginalString()
        {
            this.webControl.CssClass = "one";
            this.utility.RemoveCssClass(this.webControl, "remove");
            Assert.AreEqual("one", this.webControl.CssClass);
        }

        [TestMethod]
        public void RemoveCssClass_MultipleClassesNonMatching_OriginalString()
        {
            this.webControl.CssClass = "one two";
            this.utility.RemoveCssClass(this.webControl, "remove");
            Assert.AreEqual("one two", this.webControl.CssClass);
        }

        [TestMethod]
        public void RemoveCssClass_MultipleClassesOneMatching_OriginalStringMinusRemoveClass()
        {
            this.webControl.CssClass = "one two remove";
            this.utility.RemoveCssClass(this.webControl, "remove");
            Assert.AreEqual("one two", this.webControl.CssClass);
        }

        [TestMethod]
        public void RemoveCssClass_MultipleClassesMultipleMatching_OriginalStringMinusRemoveClass()
        {
            this.webControl.CssClass = "remove one two remove";
            this.utility.RemoveCssClass(this.webControl, "remove");
            Assert.AreEqual("one two", this.webControl.CssClass);
        }

        [TestMethod]
        public void RemoveCssClass_MultipleRemove_OriginalMinusMultipleRemoves()
        {
            this.webControl.CssClass = "one two three four";
            this.utility.RemoveCssClass(this.webControl, "three four");
            Assert.AreEqual("one two", this.webControl.CssClass);
        }

        #endregion

        private class MockWebControl : WebControl
        {}
    }
}
