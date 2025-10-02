namespace JK.Common;

/// <summary>
/// Class meant to represent data to be displayed in any of 
/// the .NET list controls such as the System.Web.UI.WebControls DropDownList, 
/// the System.Windows.Controls ComboBox, etc.
/// </summary>
/// <typeparam name="T">Type of the object's identifier</typeparam>
public class ListItem<T>
{
    /// <summary>
    /// Gets or sets the value associated with the list item.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Gets or sets the display text of the list item.
    /// </summary>
    public string Text { get; set; }
}
