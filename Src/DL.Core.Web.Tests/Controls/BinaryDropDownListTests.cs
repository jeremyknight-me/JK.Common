using DL.Core.Web.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Web.Tests.Controls
{
    [TestClass]
    public class BinaryDropDownListTests
    {
        private BinaryDropDownList control;

        [TestInitialize]
        public void TestInitialize()
        {
            this.control = new BinaryDropDownList();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.control = null;
        }

        #region GetSelectedValue() Tests

        [TestMethod]
        public void GetSelectedValue_TrueValue()
        {
            this.control.Items[0].Selected = true;
            Assert.IsTrue(this.control.GetSelectedValue());
        }

        [TestMethod]
        public void GetSelectedValue_FalseValue()
        {
            this.control.Items[1].Selected = true;
            Assert.IsFalse(this.control.GetSelectedValue());
        }

        #endregion
    }
}
