using System;
using JK.Common.Extensions;
using Xunit;

namespace JK.Common.Tests.Extensions
{
    public class TypeExtensionsTests
    {
        #region DoesImplement<T>() Tests

        [Fact]
        public void DoesImplement_NonInterface_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(() => typeof(TestWithInterface).DoesImplement<NotAnInterface>());
        }

        [Fact]
        public void DoesImplement_WithInterface_True()
        {
            var actual = typeof(TestWithInterface).DoesImplement<IInterface>();
            Assert.True(actual);
        }

        [Fact]
        public void DoesImplement_WithoutInterface_False()
        {
            var actual = typeof(TestWithoutInterface).DoesImplement<IInterface>();
            Assert.False(actual);
        }

        #endregion

        private interface IInterface { }
        private class TestWithInterface : IInterface { }
        private class TestWithoutInterface { }
        private class NotAnInterface { }
    }
}
