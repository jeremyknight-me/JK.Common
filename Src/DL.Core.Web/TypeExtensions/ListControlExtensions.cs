using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DL.Core.Contracts;

namespace DL.Core.Web.TypeExtensions
{
    public static class ListControlExtensions
    {
        public static int? GetNullableInteger(this ListControl control)
        {
            return (new NullableValueParser()).GetNullableInteger(control.SelectedValue);
        }

        /// <summary>Gets the selected text of a control inheriting from ListControl.</summary>
        /// <param name="control">Control which inherits from ListControl. Ex: BulletedList, CheckBoxList, DropDownList, ListBox, RadioButtonList</param>
        /// <returns>Text from the selected item or empty string if selected item is null.</returns>
        public static string GetSelectedText(this ListControl control)
        {
            return control.SelectedItem == null || string.IsNullOrEmpty(control.SelectedItem.Text)
                ? string.Empty
                : control.SelectedItem.Text;
        }

        /// <summary>Gets the selected value of a control inheriting from ListControl.</summary>
        /// <param name="control">Control which inherits from ListControl. Ex: BulletedList, CheckBoxList, DropDownList, ListBox, RadioButtonList</param>
        /// <returns>Value from the selected item or empty string if selected item is null.</returns>
        public static string GetSelectedValue(this ListControl control)
        {
            return control.SelectedItem == null || string.IsNullOrEmpty(control.SelectedItem.Value)
                ? string.Empty
                : control.SelectedItem.Value;
        }

        public static void LoadList<T>(this ListControl control, IEnumerable<ILabeledIdentifiable<T>> list, string firstItemText = "")
        {
            control.Items.Clear();

            if (!string.IsNullOrEmpty(firstItemText))
            {
                control.Items.Add(new ListItem { Text = firstItemText, Value = string.Empty });
            }

            foreach (ILabeledIdentifiable<T> item in list.OrderBy(x => x.Label))
            {
                control.Items.Add(new ListItem { Text = item.Label, Value = item.Id.ToString() });
            }
        }
    }
}
