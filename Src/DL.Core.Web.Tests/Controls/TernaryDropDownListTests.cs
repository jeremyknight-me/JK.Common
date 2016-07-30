using DL.Core.Web.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Web.Tests.Controls
{
    [TestClass]
    public class TernaryDropDownListTests
    {
        private TernaryDropDownList control;

        [TestInitialize]
        public void TestInitialize()
        {
            this.control = new TernaryDropDownList();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.control = null;
        }

        #region GetSelectedValue() Tests

        [TestMethod]
        public void GetSelectedValue_NullValue()
        {
            this.control.Items[0].Selected = true;
            Assert.IsNull(this.control.GetSelectedValue());
        }

        [TestMethod]
        public void GetSelectedValue_TrueValue()
        {
            this.control.Items[1].Selected = true;
            Assert.IsTrue(this.control.GetSelectedValue().Value);
        }

        [TestMethod]
        public void GetSelectedValue_FalseValue()
        {
            this.control.Items[2].Selected = true;
            Assert.IsFalse(this.control.GetSelectedValue().Value);
        }

        #endregion
    }
}
