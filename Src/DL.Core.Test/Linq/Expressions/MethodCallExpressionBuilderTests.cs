using System;
using System.Linq.Expressions;
using DL.Core.Linq.Expressions;
using DL.Core.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Linq.Expressions
{
    [TestClass]
    public class MethodCallExpressionBuilderTests
    {
        private MethodCallExpressionBuilder builder;

        private ExpressionFilter<SimpleObject> filter;

        [TestInitialize]
        public void TestInitialize()
        {
            this.builder = new MethodCallExpressionBuilder();
            this.filter = new ExpressionFilter<SimpleObject>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.builder = null;
        }

        #region GetContainsExpression Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetContainsExpression_InvalidValueType_ArgumentException()
        {
            this.filter.Value = 2;
            this.filter.SetMemberExpression(x => x.Id);

            this.builder.GetContainsExpression(this.filter.MemberExpression, this.filter.Value);
        }

        [TestMethod]
        public void GetContainsExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = "2";
            this.filter.SetMemberExpression(x => x.Title);

            MethodCallExpression expression = this.builder.GetContainsExpression(this.filter.MemberExpression, this.filter.Value);
            Assert.AreEqual("x.Title.Contains(\"2\")", expression.ToString());
        }

        #endregion

        #region GetEndsWithExpression Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetEndsWithExpression_InvalidValueType_ArgumentException()
        {
            this.filter.Value = 2;
            this.filter.SetMemberExpression(x => x.Id);

            this.builder.GetEndsWithExpression(this.filter.MemberExpression, this.filter.Value);
        }

        [TestMethod]
        public void GetEndsWithExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = "2";
            this.filter.SetMemberExpression(x => x.Title);

            MethodCallExpression expression = this.builder.GetEndsWithExpression(this.filter.MemberExpression, this.filter.Value);
            Assert.AreEqual("x.Title.EndsWith(\"2\")", expression.ToString());
        }

        #endregion

        #region GetStartsWithExpression Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStartsWithExpression_InvalidValueType_ArgumentException()
        {
            this.filter.Value = 2;
            this.filter.SetMemberExpression(x => x.Id);
            this.builder.GetStartsWithExpression(this.filter.MemberExpression, this.filter.Value);
        }

        [TestMethod]
        public void GetStartsWithExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            this.filter.Value = "Title 2";
            this.filter.SetMemberExpression(x => x.Title);

            MethodCallExpression expression
                = this.builder.GetStartsWithExpression(this.filter.MemberExpression, this.filter.Value);
            Assert.AreEqual("x.Title.StartsWith(\"Title 2\")", expression.ToString());
        }

        #endregion
    }
}
