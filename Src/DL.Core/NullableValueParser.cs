namespace DL.Core
{
    public class NullableValueParser
    {
        public decimal? GetNullableDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            decimal number;
            if (!decimal.TryParse(value, out number))
            {
                return null;
            }

            return number;
        }

        public int? GetNullableInteger(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            int number;
            if (!int.TryParse(value, out number))
            {
                return null;
            }

            return number;
        }
    }
}
