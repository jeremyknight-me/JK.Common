using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DL.Core.UI.WebForms.Controls
{
    public partial class CalendarDisplayControlTests : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.CalendarDisplay1.SelectionChanged = () => { };
                this.CalendarDisplay1.GetTextPanel = (panel, date) =>
                    {
                        panel.Style.Add(HtmlTextWriterStyle.PaddingLeft, "1em");

                        if (date == DateTime.Now.Date)
                        {
                            panel.Controls.Add(new LiteralControl("Add Item"));
                        }
                        else
                        {
                            if (date.Day % 2 == 0)
                            {
                                var pobPanel = new Panel();
                                pobPanel.Controls.Add(new LiteralControl("Multi"));

                                var hoursPanel = new Panel();
                                hoursPanel.Controls.Add(new LiteralControl("Line"));

                                panel.Controls.Add(pobPanel);
                                panel.Controls.Add(hoursPanel);
                            }
                            else
                            {
                                panel.Controls.Add(new LiteralControl("Single Line"));
                            }
                        }
                    };
            }
        }
    }
}