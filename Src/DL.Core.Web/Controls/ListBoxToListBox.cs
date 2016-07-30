using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DL.Core.Web.Controls
{
    /// <summary>
    /// CompositeControl which contains side by side list boxes. The left box is meant for
    /// available items and the right box is meant for currently selected items.
    /// </summary>
    [ToolboxData("<{0}:ListBoxToListBox runat=server></{0}:ListBoxToListBox>")]
    public class ListBoxToListBox : CompositeControl
    {
        private const string leftHeaderTextKey = "LeftHeaderText";

        private const string rightHeaderTextKey = "RightHeaderText";

        private const string showMessageKey = "ShowMessage";

        private const string useBootstrapKey = "UseBootstrap";

        private const string leftHeaderTextDefaultValue = "Available Items";

        private const string rightHeaderTextDefaultValue = "Selected Items";

        private readonly Button addButton = new Button();

        private readonly Button removeButton = new Button();

        private readonly Literal messageLiteral = new Literal();

        private ListBox leftListBox = new ListBox();

        private ListBox rightListBox = new ListBox();

        #region Public Properties

        /// <summary>
        /// Gets or sets the header text over the left list box.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(leftHeaderTextDefaultValue)]
        [DisplayName("LeftHeaderText")]
        public string LeftHeaderText
        {
            get
            {
                return this.ViewState[leftHeaderTextKey] == null 
                    ? leftHeaderTextDefaultValue 
                    : this.ViewState[leftHeaderTextKey].ToString();
            }

            set
            {
                this.ViewState[leftHeaderTextKey] = value;
            }
        }

        /// <summary>
        /// Gets or sets the left list box object.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListBox LeftListBox
        {
            get { return this.leftListBox; }
            set { this.leftListBox = value; }
        }

        /// <summary>
        /// Gets or sets the header text over the right list box.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(rightHeaderTextDefaultValue)]
        [DisplayName("RightHeaderText")]
        public string RightHeaderText
        {
            get
            {
                if (this.ViewState[rightHeaderTextKey] == null)
                {
                    return rightHeaderTextDefaultValue;
                }

                return this.ViewState[rightHeaderTextKey].ToString();
            }

            set
            {
                this.ViewState[rightHeaderTextKey] = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the control renders with Bootstrap capabilities.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        [DisplayName("UseBootstrap")]
        public bool UseBootstrap
        {
            get
            {
                if (this.ViewState[useBootstrapKey] == null)
                {
                    return false;
                }

                return Convert.ToBoolean(this.ViewState[useBootstrapKey]);
            }

            set
            {
                this.ViewState[useBootstrapKey] = value;
            }
        }

        /// <summary>
        /// Gets or sets the right list box object.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListBox RightListBox
        {
            get { return this.rightListBox; }
            set { this.rightListBox = value; }
        }

        #endregion

        /// <summary>
        /// Gets or sets whether the controls message area should be displayed.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool ShowMessage
        {
            get
            {
                if (this.ViewState[showMessageKey] == null)
                {
                    return false;
                }

                return Convert.ToBoolean(this.ViewState[showMessageKey]);
            }

            set
            {
                this.ViewState[showMessageKey] = value;
            }
        }

        #region Protected Methods - Event Handlers

        protected void AddButtonClick(object sender, EventArgs e)
        {
            List<ListItem> items
                = this.leftListBox.Items
                    .Cast<ListItem>()
                    .Where(x => x.Selected)
                    .ToList();

            if (items.Count > 0)
            {
                this.ClearMessageLabel();

                this.rightListBox.Items.AddRange(items.ToArray());

                for (int i = 0; i < items.Count; i++)
                {
                    this.leftListBox.Items.Remove(items[i]);
                }

                this.UnselectAll();
            }
            else
            {
                this.ShowMessageLabel(this.LeftHeaderText);
            }
        }

        protected void RemoveButtonClick(object sender, EventArgs e)
        {
            List<ListItem> items
                = this.rightListBox.Items
                    .Cast<ListItem>()
                    .Where(x => x.Selected)
                    .ToList();

            if (items.Count > 0)
            {
                this.ClearMessageLabel();

                this.leftListBox.Items.AddRange(items.ToArray());

                for (int i = 0; i < items.Count; i++)
                {
                    this.rightListBox.Items.Remove(items[i]);
                }

                this.UnselectAll();
            }
            else
            {
                this.ShowMessageLabel(this.RightHeaderText);
            }
        }

        #endregion

        #region Protected Methods - Overridden Methods

        protected override void OnInit(EventArgs e)
        {
            this.InitializeControls();
            base.OnInit(e);
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this.Controls.Add(this.leftListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.rightListBox);
            this.Controls.Add(this.messageLiteral);

            if (!this.Page.IsPostBack)
            {
                this.leftListBox.DataBind();
                this.rightListBox.DataBind();
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.EnsureChildControls();

            if (this.HasControls())
            {
                if (this.UseBootstrap)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "table-responsive");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                }

                if (!string.IsNullOrEmpty(this.CssClass))
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);
                }
                writer.RenderBeginTag(HtmlTextWriterTag.Table);

                writer.RenderBeginTag(HtmlTextWriterTag.Tr);

                this.RenderLeftHeaderCell(writer);

                this.RenderButtonCell(writer);

                this.RenderRightHeaderCell(writer);

                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.Tr);

                this.RenderLeftListBoxCell(writer);

                this.RenderRightListBoxCell(writer);

                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.Tr);

                this.RenderMessageLabelCell(writer);

                writer.RenderEndTag();

                writer.RenderEndTag();

                if (this.UseBootstrap)
                {
                    writer.RenderEndTag();
                }
            }
        }

        #endregion

        #region Private Methods - Render Helpers

        private void RenderLeftHeaderCell(HtmlTextWriter writer)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.VerticalAlign, "bottom");
            writer.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "bold");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);

            (new LiteralControl(this.LeftHeaderText)).RenderControl(writer);

            writer.RenderEndTag();
        }

        private void RenderButtonCell(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Rowspan, "2");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);

            this.addButton.RenderControl(writer);

            writer.WriteBreak();

            this.removeButton.RenderControl(writer);

            writer.RenderEndTag();
        }

        private void RenderRightHeaderCell(HtmlTextWriter writer)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.VerticalAlign, "bottom");
            writer.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "bold");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);

            (new LiteralControl(this.RightHeaderText)).RenderControl(writer);

            writer.RenderEndTag();
        }

        private void RenderLeftListBoxCell(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Td);

            this.leftListBox.RenderControl(writer);

            writer.RenderEndTag();
        }

        private void RenderRightListBoxCell(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Td);

            this.rightListBox.RenderControl(writer);

            writer.RenderEndTag();
        }

        private void RenderMessageLabelCell(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Colspan, "3");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);

            if (this.ShowMessage)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class,
                    this.UseBootstrap ? "alert alert-danger" : "message-error");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                this.messageLiteral.RenderControl(writer);
                writer.RenderEndTag();
            }

            writer.RenderEndTag();
        }

        #endregion

        #region Private Methods - Child Control Setup

        private void InitializeControls()
        {
            this.SetupLeftListBox();
            this.SetupAddButton();
            this.SetupRemoveButton();
            this.SetupRightListBox();
        }

        private void SetupLeftListBox()
        {
            this.SetupBaseListBox(this.leftListBox);
            this.leftListBox.ID = "LeftListBox";
        }

        private void SetupAddButton()
        {
            this.SetupBaseButton(this.addButton);
            this.addButton.ID = "AddButton";

            this.addButton.CssClass = this.UseBootstrap 
                ? "btn btn-primary" 
                : "button positive";
            
            this.addButton.Text = "Add " + System.Net.WebUtility.HtmlDecode("&raquo;");
            this.addButton.Click += this.AddButtonClick;
        }

        private void SetupRemoveButton()
        {
            this.SetupBaseButton(this.removeButton);
            this.removeButton.ID = "RemoveButton";

            this.removeButton.CssClass = this.UseBootstrap 
                ? "btn btn-danger" 
                : "button negative";

            this.removeButton.Style.Add(HtmlTextWriterStyle.MarginTop, "0.5em");
            this.removeButton.Text = System.Net.WebUtility.HtmlDecode("&laquo;") + " Remove";
            this.removeButton.Click += this.RemoveButtonClick;
        }

        private void SetupRightListBox()
        {
            this.SetupBaseListBox(this.rightListBox);
            this.rightListBox.ID = "RightListBox";
        }

        private void SetupBaseListBox(ListBox listBox)
        {
            if (this.UseBootstrap)
            {
                listBox.CssClass = "form-control";    
            }

            listBox.SelectionMode = ListSelectionMode.Multiple;
            listBox.Rows = 10;
            listBox.Width = Unit.Pixel(220);
        }

        private void SetupBaseButton(Button button)
        {
            button.Enabled = true;
            button.Width = Unit.Pixel(110);
        }

        #endregion

        private void UnselectAll()
        {
            foreach (ListItem item in this.leftListBox.Items.Cast<ListItem>().Where(item => item.Selected))
            {
                item.Selected = false;
            }

            foreach (ListItem item in this.rightListBox.Items.Cast<ListItem>().Where(item => item.Selected))
            {
                item.Selected = false;
            }
        }

        private void ShowMessageLabel(string listboxHeaderText)
        {
            this.messageLiteral.Text = string.Concat("You must select at least one item from ", listboxHeaderText, ".");
            this.ShowMessage = true;
        }

        private void ClearMessageLabel()
        {
            this.ShowMessage = false;
            this.messageLiteral.Text = string.Empty;
        }
    }
}
