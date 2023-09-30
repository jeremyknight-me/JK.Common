using JK.Common.ServiceLocator;

namespace JK.Common.Tests.ServiceLocator;

public class DefaultServiceLocatorTests
{
    [Fact]
    public void Locate_GetCorrectTypeInstance()
    {
        DefaultServiceLocator.Instance.Register<IIdentifiable<int>>(new ComplexObject());
        var actual = DefaultServiceLocator.Instance.Locate<IIdentifiable<int>>();
        Assert.IsType<ComplexObject>(actual);
    }
}
