using DL.Core.Contracts;

namespace DL.Core
{
    /// <summary>
    /// Class meant to represent data to be displayed in any of 
    /// the .NET list controls such as the System.Web.UI.WebControls DropDownList, 
    /// the System.Windows.Controls ComboBox, etc.
    /// </summary>
    /// <typeparam name="T">Type of the object's identifier</typeparam>
    public class ListItemData<T> : ILabeledIdentifiable<T>
    {
        public T Id { get; set; }

        public string Label { get; set; }
    }
}
