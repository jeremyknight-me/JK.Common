using System;

namespace JK.Common.TypeHelpers
{
    public class ExcelHelper
    {
        public string GetColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = string.Empty;

            while (dividend > 0)
            {
                var modulus = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulus) + columnName;
                dividend = (dividend - modulus) / 26;
            }

            return columnName;
        }
    }
}
