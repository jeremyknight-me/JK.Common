namespace DL.Common
{
    /// <summary>
    /// Class meant to represent data to be displayed in any of 
    /// the .NET list controls such as the System.Web.UI.WebControls DropDownList, 
    /// the System.Windows.Controls ComboBox, etc.
    /// </summary>
    /// <typeparam name="T">Type of the object's identifier</typeparam>
    public class ListItem<T>
    {
        public T Value { get; set; }
        public string Text { get; set; }
    }
}
