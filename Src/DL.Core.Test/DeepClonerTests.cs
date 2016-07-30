using System;
using DL.Core.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test
{
    [TestClass]
    public class DeepClonerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Clone_Null_Exception()
        {
            SimpleObject simpleObject = null;
            var cloner = new DeepCloner();
            cloner.Clone(simpleObject);
        }

        [TestMethod]
        public void Clone_FilledObject_NotSameReference()
        {
            var original
                = new ComplexObject
                {
                    BooleanProperty = true,
                    ChildObjectSimple = new SimpleObject { Id = 123, Title = "foo bar" },
                    DateTimeProperty = DateTime.Now,
                    DecimalProperty = 12.34m,
                    DoubleProperty = 23.45D,
                    FloatProperty = 34.56F,
                    IntProperty = 4567,
                    StringProperty = "hello world"
                };

            var cloner = new DeepCloner();
            var actual = (ComplexObject)cloner.Clone(original);

            Assert.AreNotSame(original, actual);
            Assert.IsTrue(actual.BooleanProperty);
            Assert.AreEqual(123, actual.ChildObjectSimple.Id);
            Assert.AreEqual("foo bar", actual.ChildObjectSimple.Title);
            Assert.AreEqual(12.34m, actual.DecimalProperty);
            Assert.AreEqual(23.45D, actual.DoubleProperty);
            Assert.AreEqual(34.56F, actual.FloatProperty);
            Assert.AreEqual(4567, actual.IntProperty);
            Assert.AreEqual("hello world", actual.StringProperty);
        }
    }
}
