using JK.Common.Patterns.ServiceLocator;

namespace JK.Common.Tests.Patterns.ServiceLocator;

public class DefaultServiceLocatorTests
{
    [Fact]
    public void Locate_GetCorrectTypeInstance()
    {
        DefaultServiceLocator.Instance.Register<IIdentifiable<int>>(new ComplexObject());
        IIdentifiable<int> actual = DefaultServiceLocator.Instance.Locate<IIdentifiable<int>>();
        Assert.IsType<ComplexObject>(actual);
    }
}
