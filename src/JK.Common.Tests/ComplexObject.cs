﻿using JK.Common.Contracts;

namespace JK.Common.Tests;

public class ComplexObject : IIdentifiable<int>
{
    public ComplexObject()
    {
        this.Id = 0;
        this.StringProperty = string.Empty;
        this.IntProperty = 0;
        this.DateTimeProperty = DateTime.Now;
        this.DoubleProperty = 0;
        this.DecimalProperty = 0;
        this.FloatProperty = 0;
        this.BooleanProperty = false;
        this.ChildObjectSimple = new SimpleObject();
    }

    public ComplexObject(DateTime dateTime) : this()
    {
        this.DateTimeProperty = dateTime;
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
