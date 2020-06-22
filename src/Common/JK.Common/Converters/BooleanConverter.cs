using System;
using System.Linq;

namespace JK.Common.Converters
{
    /// <summary>
    /// Class initially built to aid in data imports.
    /// </summary>
    public class BooleanConverter
    {
        private readonly object[] trueItems;
        private readonly object[] falseItems;
        private readonly object[] nullItems;

        public BooleanConverter()
        {
            this.trueItems = new object[] { "TRUE", "True", "true", "Y", "y", "YES", "Yes", "yes", 1, "1" };
            this.falseItems = new object[] { "FALSE", "False", "false", "N", "n", "NO", "No", "no", 0, "0" };
            this.nullItems = new object[] { null, "", string.Empty };
        }

        public bool Convert(object value)
        {
            if (value is string)
            {
                value = value.ToString().Trim();
            }

            if (this.IsTrue(value))
            {
                return true;
            }

            if (this.IsFalse(value))
            {
                return false;
            }

            throw new ArgumentException("Value is not supported.");
        }

        public bool? ConvertToNullable(object value)
        {
            if (value is string)
            {
                value = value.ToString().Trim();
            }

            if (this.IsNull(value))
            {
                return null;
            }

            return this.Convert(value);
        }

        private bool IsTrue(object value)
        {
            return this.trueItems.Contains(value);
        }

        private bool IsFalse(object value)
        {
            return this.falseItems.Contains(value);
        }

        private bool IsNull(object value)
        {
            return this.nullItems.Contains(value);
        }
    }
}
