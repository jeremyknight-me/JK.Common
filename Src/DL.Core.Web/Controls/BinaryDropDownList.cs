using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DL.Core.Web.Controls
{
    /// <summary>
    /// Custom DropDownList which handles Yes/No scenario.
    /// </summary>
    [ToolboxData("<{0}:BinaryDropDownList runat=server></{0}:BinaryDropDownList>")]
    public sealed class BinaryDropDownList : DropDownList
    {
        private readonly string listItemsViewStateKey;

        private string falseDisplayText;

        private string trueDisplayText;

        public BinaryDropDownList()
        {
            this.falseDisplayText = "No";
            this.trueDisplayText = "Yes";

            this.listItemsViewStateKey = "ListItems";
            this.LoadItemsIntoViewState();
        }

        #region Public Properties - Hide in VS Property Grid

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AppendDataBoundItems
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
            get { return this.falseDisplayText; }
            set { this.falseDisplayText = value; }
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
        [DefaultValue("Yes")]
        [DisplayName("TrueDisplayText")]
        public string TrueDisplayText
        {
            get { return this.trueDisplayText; }
            set { this.trueDisplayText = value; }
        }

        #endregion

        #region Public Methods

        public bool GetSelectedValue()
        {
            return this.SelectedValue == "1";
        }

        #endregion

        #region Private Methods

        private ListItemCollection GetItemsFromViewState()
        {
            return (ListItemCollection)this.ViewState[this.listItemsViewStateKey];
        }

        private void LoadItemsIntoViewState()
        {
            var items
                = new List<ListItem>
                      {
                          new ListItem(this.trueDisplayText, "1"),
                          new ListItem(this.falseDisplayText, "0")
                      };

            var listItems = new ListItemCollection();
            listItems.AddRange(items.ToArray());

            this.ViewState.Add(this.listItemsViewStateKey, listItems);
        }

        private void RemoveUnwantedItems()
        {
            ListItemCollection items = this.GetItemsFromViewState();

            if (items.Count <= 2)
            {
                return;
            }

            items.RemoveAt(2);
            this.RemoveUnwantedItems();
        }

        #endregion
    }
}
