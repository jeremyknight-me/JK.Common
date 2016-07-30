using System.Web.UI.WebControls;

namespace DL.Core.Web.TypeExtensions
{
    public static class HiddenFieldExtensions
    {
        public static decimal? GetNullableDecimal(this HiddenField control)
        {
            return (new NullableValueParser()).GetNullableDecimal(control.Value);
        }

        public static int? GetNullableInteger(HiddenField control)
        {
            return (new NullableValueParser()).GetNullableInteger(control.Value);
        }
    }
}
