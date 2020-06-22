using JK.Common.Contracts;
using JK.Common.ServiceLocator;
using Xunit;

namespace JK.Common.Tests.ServiceLocator
{
    public class DefaultServiceLocatorTests
    {
        [Fact]
        public void Locate_GetCorrectTypeInstance()
        {
            DefaultServiceLocator.Instance.Register<IIdentifiable<object>>(new ComplexObject());
            var actual = DefaultServiceLocator.Instance.Locate<IIdentifiable<object>>();
            Assert.IsType<ComplexObject>(actual);
        }
    }
}
