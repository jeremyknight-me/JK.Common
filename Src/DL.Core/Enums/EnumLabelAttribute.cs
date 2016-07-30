using System;

namespace DL.Core.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumLabelAttribute : Attribute
    {
        public EnumLabelAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
