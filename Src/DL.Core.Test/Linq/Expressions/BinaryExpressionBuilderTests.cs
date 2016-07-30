using System.Linq.Expressions;
using DL.Core.Linq.Expressions;
using DL.Core.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Linq.Expressions
{
    [TestClass]
    public class BinaryExpressionBuilderTests
    {
        private BinaryExpressionBuilder builder;

        private ExpressionFilter<SimpleObject> filter;
            
        [TestInitialize]
        public void TestInitialize()
        {
            this.builder = new BinaryExpressionBuilder();
            this.filter = new ExpressionFilter<SimpleObject>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.builder = null;
        }

        #region GetEqualsExpression Tests

        [TestMethod]
        public void GetEqualsExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = 2;
            this.filter.SetMemberExpression(x => x.Id);

            BinaryExpression expression = this.builder.GetEqualsExpression(this.filter.MemberExpression, this.filter.Value);
            Assert.AreEqual("(x.Id == 2)", expression.ToString());
        }

        #endregion

        #region GetGreaterThanExpression Tests

        [TestMethod]
        public void GetGreaterThanExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = 2;
            this.filter.SetMemberExpression(x => x.Id);

            BinaryExpression expression = this.builder.GetGreaterThanExpression(this.filter.MemberExpression, this.filter.Value);
            Assert.AreEqual("(x.Id > 2)", expression.ToString());
        }

        #endregion

        #region GetGreaterThanOrEqualExpression Tests

        [TestMethod]
        public void GetGreaterThanOrEqualExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = 10;
            this.filter.SetMemberExpression(x => x.Id);

            BinaryExpression expression = this.builder.GetGreaterThanOrEqualExpression(this.filter.MemberExpression, this.filter.Value);
            Assert.AreEqual("(x.Id >= 10)", expression.ToString());
        }

        #endregion

        #region GetLessThanExpression Tests

        [TestMethod]
        public void GetLessThanExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = 0;
            this.filter.SetMemberExpression(x => x.Id);

            BinaryExpression expression = this.builder.GetLessThanExpression(this.filter.MemberExpression, this.filter.Value);
            Assert.AreEqual("(x.Id < 0)", expression.ToString());
        }

        #endregion

        #region GetLessThanOrEqualExpression Tests

        [TestMethod]
        public void GetLessThanOrEqualExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = 0;
            this.filter.SetMemberExpression(x => x.Id);

            BinaryExpression expression = this.builder.GetLessThanOrEqualExpression(this.filter.MemberExpression, this.filter.Value);
            Assert.AreEqual("(x.Id <= 0)", expression.ToString());
        }

        #endregion

        #region GetBetweenExclusiveExpression Tests

        [TestMethod]
        public void GetBetweenExclusiveExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = 10;
            this.filter.ValueTwo = 20;
            this.filter.SetMemberExpression(x => x.Id);

            BinaryExpression expression = this.builder.GetBetweenExclusiveExpression(this.filter.MemberExpression, this.filter.Value, this.filter.ValueTwo);
            Assert.AreEqual("((x.Id > 10) And (x.Id < 20))", expression.ToString());
        }

        #endregion

        #region GetBetweenInclusiveExpression Tests

        [TestMethod]
        public void GetBetweenInclusiveExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = 10;
            this.filter.ValueTwo = 20;
            this.filter.SetMemberExpression(x => x.Id);

            BinaryExpression expression = this.builder.GetBetweenInclusiveExpression(this.filter.MemberExpression, this.filter.Value, this.filter.ValueTwo);
            Assert.AreEqual("((x.Id >= 10) And (x.Id <= 20))", expression.ToString());
        }

        #endregion
    }
}
