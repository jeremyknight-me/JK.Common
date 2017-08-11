using System;
using Xunit;

namespace DL.Common.Tests
{
    public class DeepClonerTests
    {
        [Fact]
        public void Clone_Null_ArgumentNullException()
        {
            var cloner = new DeepCloner();
            var ex = Assert.Throws<ArgumentNullException>(() => cloner.Clone(null));
        }

        [Fact]
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

            Assert.NotSame(original, actual);
            Assert.True(actual.BooleanProperty);
            Assert.Equal(123, actual.ChildObjectSimple.Id);
            Assert.Equal("foo bar", actual.ChildObjectSimple.Title);
            Assert.Equal(12.34m, actual.DecimalProperty);
            Assert.Equal(23.45D, actual.DoubleProperty);
            Assert.Equal(34.56F, actual.FloatProperty);
            Assert.Equal(4567, actual.IntProperty);
            Assert.Equal("hello world", actual.StringProperty);
        }
    }
}
