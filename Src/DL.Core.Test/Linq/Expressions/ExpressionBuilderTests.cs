using System;
using System.Linq.Expressions;
using DL.Core.Linq.Expressions;
using DL.Core.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Linq.Expressions
{
    [TestClass]
    public class ExpressionBuilderTests
    {
        private ExpressionBuilder<SimpleObject> expressionBuilder;

        private Expression<Func<SimpleObject, bool>> expression;

        [TestInitialize]
        public void TestInitialize()
        {
            this.expressionBuilder = new ExpressionBuilder<SimpleObject>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.expressionBuilder = null;
            this.expression = null;
        }

        #region GetExpression Tests

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetExpression_NoFilters_InvalidOperationException()
        {
            this.expressionBuilder.GetExpression();
        }

        #endregion
    }
}
