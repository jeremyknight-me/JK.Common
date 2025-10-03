using JK.Common.Patterns.ServiceLocator;

namespace JK.Common.Tests.Patterns.ServiceLocator;

public class DefaultServiceLocatorTests
{
    [Fact]
    public void Locate_GetCorrectTypeInstance()
    {
        DefaultServiceLocator.Instance.Register<ITestInterface>(new TestClass());
        ITestInterface actual = DefaultServiceLocator.Instance.Locate<ITestInterface>();
        Assert.IsType<TestClass>(actual);
    }

    private interface ITestInterface
    {
    }

    private class TestClass : ITestInterface
    {
    }
}
