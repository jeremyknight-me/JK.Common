namespace JK.Common.Tests;

public class ComplexObject : IIdentifiable<int>
{
    public ComplexObject()
    {
        Id = 0;
        StringProperty = string.Empty;
        IntProperty = 0;
        DateTimeProperty = DateTime.Now;
        DoubleProperty = 0;
        DecimalProperty = 0;
        FloatProperty = 0;
        BooleanProperty = false;
        ChildObjectSimple = new SimpleObject();
    }

    public ComplexObject(DateTime dateTime) : this()
    {
        DateTimeProperty = dateTime;
    }

    public string StringProperty { get; set; }

    public int IntProperty { get; set; }

    public DateTime DateTimeProperty { get; set; }

    public double DoubleProperty { get; set; }

    public decimal DecimalProperty { get; set; }

    public float FloatProperty { get; set; }

    public bool BooleanProperty { get; set; }

    public SimpleObject ChildObjectSimple { get; set; }

    public ComplexObject ChildObjectComplex { get; set; }

    public int Id { get; set; }
}
