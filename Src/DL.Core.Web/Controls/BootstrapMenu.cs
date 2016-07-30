//-----------------------------------------------------------------------
// <copyright file="BootstrapMenu.cs">
//     Copyright (c) Jeremy Knight. All rights reserved.
//     This source is subject to the Microsoft Reciprocal License (Ms-RL).
//     For more information, see https://codelibrary.codeplex.com/license
// </copyright>
// <author>Jeremy Knight</author>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DL.Core.Web.Controls
{
    [ControlValueProperty("SelectedValue")]
    [DefaultEvent("MenuItemClick")]
    [SupportsEventValidation]
    [ToolboxData("<{0}:BootstrapMenu runat=\"server\"></{0}:BootstrapMenu>")]
    public sealed class BootstrapMenu : Menu
    {
        private const string hightlightActiveKey = "HighlightActive";

        public BootstrapMenu()
        {
        }

        /// <summary>
        /// Gets or sets the header text over the left list box.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        [DisplayName("HighlightActive")]
        public bool HighlightActive
        {
            get { return this.ViewState[hightlightActiveKey] != null && Convert.ToBoolean(this.ViewState[hightlightActiveKey]); }
            set { this.ViewState[hightlightActiveKey] = value; }
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            // don't call base.RenderBeginTag()
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            // don't call base.RenderEndTag()
        }

        protected override void OnPreRender(EventArgs e)
        {
            // don't call base.OnPreRender(e);
            this.EnsureDataBound();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.BuildItems(writer, this.Items, true);
        }

        protected override void EnsureDataBound()
        {
            base.EnsureDataBound();
        }

        private void BuildItems(HtmlTextWriter writer, MenuItemCollection items, bool isRoot = false)
        {
            if (items.Count <= 0)
            {
                return;
            }

            string cssClass = "dropdown-menu";

            if (isRoot)
            {
                cssClass = "nav navbar-nav";
                if (!string.IsNullOrEmpty(this.CssClass))
                {
                    cssClass += " " + this.CssClass;
                }
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Class, cssClass);
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);

            foreach (MenuItem item in items)
            {
                this.BuildItem(writer, item);
            }

            writer.RenderEndTag(); // </ul>
        }

        private void BuildItem(HtmlTextWriter writer, MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            if (item.ChildItems.Count > 0)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "dropdown");    
            }
            
            if (this.IsLink(item))
            {
                if (this.HighlightActive && this.Page.ResolveUrl(item.NavigateUrl) == this.Page.Request.Url.AbsolutePath)
                {
                    writer.AddAttribute("class", "active");
                }

                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                this.RenderLink(writer, item);
            }
            else if (this.HasChildren(item))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                this.RenderDropDown(writer, item);
            }
            else
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write(item.Text);
                writer.RenderEndTag();
            }

            writer.RenderEndTag(); // </li>
        }

        private bool HasChildren(MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return item.ChildItems.Count > 0;
        }

        private bool IsLink(MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return item.Enabled && !string.IsNullOrEmpty(item.NavigateUrl);
        }

        private void RenderLink(HtmlTextWriter writer, MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            string href = !string.IsNullOrEmpty(item.NavigateUrl)
                    ? this.Page.Server.HtmlEncode(this.ResolveClientUrl(item.NavigateUrl))
                    : this.Page.ClientScript.GetPostBackClientHyperlink(
                        this,
                        "b" + item.ValuePath.Replace(this.PathSeparator.ToString(), "\\"),
                        true);
            writer.AddAttribute(HtmlTextWriterAttribute.Href, href);

            string toolTip = !string.IsNullOrEmpty(item.ToolTip)
                ? item.ToolTip
                : item.Text;
            writer.AddAttribute(HtmlTextWriterAttribute.Title, toolTip);

            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write(item.Text);
            writer.RenderEndTag(); // </a>
        }

        private void RenderDropDown(HtmlTextWriter writer, MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "dropdown-toggle");
            writer.AddAttribute("data-toggle", "dropdown");
            writer.RenderBeginTag(HtmlTextWriterTag.A);

            string anchorValue = item.Text + "&nbsp;";
            writer.Write(anchorValue);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "caret");
            writer.RenderBeginTag(HtmlTextWriterTag.B);
            writer.RenderEndTag(); // </b>          

            writer.RenderEndTag(); // </a>

            this.BuildItems(writer, item.ChildItems);
        }
    }
}
