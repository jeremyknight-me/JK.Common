using System.Web.UI;
using System.Web.UI.WebControls;

namespace DL.Core.Web.TypeExtensions
{
    public static class WebControlExtensions
    {
        public static void AddCssClass(this WebControl control, string cssClass)
        {
            (new WebControlUtility()).AddCssClass(control, cssClass);
        }

        public static Control FindControlRecursive(this Control root, string idToFind)
        {
            return (new WebControlUtility()).FindControlRecursive(root, idToFind);
        }

        public static void ReplaceCssClass(this WebControl control, string classToRemove, string classToAdd)
        {
            (new WebControlUtility()).ReplaceCssClass(control, classToRemove, classToAdd);
        }

        public static void RemoveCssClass(this WebControl control, string cssClass)
        {
            (new WebControlUtility()).RemoveCssClass(control, cssClass);
        }
    }
}
