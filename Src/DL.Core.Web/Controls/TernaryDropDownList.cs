using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DL.Core.Web.Controls
{
    /// <summary>
    /// Custom DropDownList which handles Yes/No/Not Available (null-able boolean) scenario.
    /// </summary>
    [ToolboxData("<{0}:TernaryDropDownList runat=server></{0}:TernaryDropDownList>")]
    public sealed class TernaryDropDownList : DropDownList
    {
        private const string listItemsViewStateKey = "ListItems";

        /// <summary>
        /// Initializes a new instance of the <see cref="TernaryDropDownList"/> class. 
        /// </summary>
        public TernaryDropDownList()
        {
            var items
                = new List<ListItem>
                      {
                          new ListItem("N/A", "2"),
                          new ListItem("Yes", "1"),
                          new ListItem("No", "0")
                      };

            var listItems = new ListItemCollection();
            listItems.AddRange(items.ToArray());

            this.ViewState.Add(listItemsViewStateKey, listItems);
        }

        #region Public Properties - Hide in VS Property Grid

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool AppendDataBoundItems
        {
            get { return base.AppendDataBoundItems; }
            set { base.AppendDataBoundItems = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string DataMember
        {
            get { return base.DataMember; }
            set { base.DataMember = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object DataSource
        {
            get { return base.DataSource; }
            set { base.DataSource = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string DataSourceID
        {
            get { return base.DataSourceID; }
            set { base.DataSourceID = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string DataTextField
        {
            get { return base.DataTextField; }
            set { base.DataTextField = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string DataTextFormatString
        {
            get { return base.DataTextFormatString; }
            set { base.DataTextFormatString = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string DataValueField
        {
            get { return base.DataValueField; }
            set { base.DataValueField = value; }
        }

        #endregion

        #region Public Properties

        [Browsable(true)]
        [DefaultValue("No")]
        [DisplayName("FalseDisplayText")]
        public string FalseDisplayText
        {
            get { return this.Items[2].Text; }
            set { this.Items[2].Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ListItemCollection Items
        {
            get
            {
                this.RemoveUnwantedItems();
                return this.GetItemsFromViewState();
            }
        }

        [Browsable(true)]
        [DefaultValue("N/A")]
        [DisplayName("NullDisplayText")]
        public string NullDisplayText
        {
            get { return this.Items[0].Text; }
            set { this.Items[0].Text = value; }
        }

        [Browsable(true)]
        [DefaultValue("Yes")]
        [DisplayName("TrueDisplayText")]
        public string TrueDisplayText
        {
            get { return this.Items[1].Text; }
            set { this.Items[1].Text = value; }
        }

        #endregion

        #region Public Methods

        public bool? GetSelectedValue()
        {
            if (this.SelectedValue == "0")
            {
                return false;
            }

            if (this.SelectedValue == "1")
            {
                return true;
            }

            return null;
        }

        public void SetSelectedValue(bool? value)
        {
            if (value.HasValue)
            {
                this.SetSelectedValue(value.Value);
            }
            else
            {
                this.SelectedValue = "2";
            }
        }

        public void SetSelectedValue(bool value)
        {
            this.SelectedValue = value ? "1" : "0";
        }

        #endregion

        #region Private Methods

        private ListItemCollection GetItemsFromViewState()
        {
            return (ListItemCollection)this.ViewState[listItemsViewStateKey];
        }

        private void RemoveUnwantedItems()
        {
            ListItemCollection items = this.GetItemsFromViewState();

            if (items.Count <= 3)
            {
                return;
            }

            items.RemoveAt(3);
            this.RemoveUnwantedItems();
        }

        #endregion
    }
}
