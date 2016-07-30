using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Calendar = System.Web.UI.WebControls.Calendar;

namespace DL.Core.Web.Controls
{
    /// <summary>
    /// Custom Calendar control which handles displaying data in a calendar. 
    /// This control gives a month view calendar.
    /// </summary>
    [ToolboxData("<{0}:CalendarDisplay runat=server></{0}:CalendarDisplay>")]
    public sealed class CalendarDisplay : CompositeControl
    {
        private const string startYearKey = "StartYear";

        private const int startYearDefaultValue = 2010;

        private readonly LinkButton previousMonthLinkButton = new LinkButton();

        private readonly DropDownList monthDropDownList = new DropDownList();

        private readonly DropDownList yearDropDownList = new DropDownList();

        private readonly Button selectYearMonthButton = new Button();

        private readonly LinkButton nextMonthLinkButton = new LinkButton();

        private readonly Calendar monthViewCalendar = new Calendar();

        #region Public Properties

        /// <summary>
        /// Gets or sets the start year for the year drop down.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(startYearDefaultValue)]
        [DisplayName("Start Year")]
        public int StartYear
        {
            get
            {
                if (this.ViewState[startYearKey] == null)
                {
                    return startYearDefaultValue;
                }

                return int.Parse(this.ViewState[startYearKey].ToString());
            }

            set
            {
                if (value > DateTime.Now.Year)
                {
                    throw new ArgumentException("'StartYear' must be less than or equal to current year.");    
                }

                this.ViewState[startYearKey] = value;
            }
        }

        public Action<Panel, DateTime> GetTextPanel { get; set; }

        public Action SelectionChanged { get; set; }

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

            this.Controls.Add(this.previousMonthLinkButton);
            this.Controls.Add(this.monthDropDownList);
            this.Controls.Add(this.yearDropDownList);
            this.Controls.Add(this.selectYearMonthButton);
            this.Controls.Add(this.nextMonthLinkButton);
            this.Controls.Add(this.monthViewCalendar);

            if (!this.Page.IsPostBack)
            {
                this.SetCalendarNavigationControls();
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.EnsureChildControls();

            if (this.HasControls())
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "#999");
                writer.AddStyleAttribute(HtmlTextWriterStyle.BorderColor, "#000");
                writer.AddStyleAttribute(HtmlTextWriterStyle.BorderStyle, "solid");
                writer.AddStyleAttribute(HtmlTextWriterStyle.BorderWidth, "1px");
                writer.AddStyleAttribute("border-bottom", "none");
                writer.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "bold");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");
                writer.RenderBeginTag(HtmlTextWriterTag.Table);

                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                this.RenderPreviousMonthCell(writer);
                this.RenderYearMonthCell(writer);
                this.RenderNextMonthCell(writer);
                writer.RenderEndTag(); // </tr>

                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                this.RenderCalendar(writer);
                writer.RenderEndTag(); // </tr>

                writer.RenderEndTag(); // </table>
            }
        }

        #endregion

        #region Private Methods - Event Handlers

        private void PreviousMonthLinkButtonClick(object sender, EventArgs e)
        {
            this.ChangeVisibleDateByNumberMonths(-1);
        }

        private void NextMonthLinkButtonClick(object sender, EventArgs e)
        {
            this.ChangeVisibleDateByNumberMonths(1);
        }

        private void SelectYearMonthButtonClick(object sender, EventArgs e)
        {
            DateTime currentDate = this.monthViewCalendar.VisibleDate;
            var date = new DateTime(
                Convert.ToInt32(this.yearDropDownList.SelectedValue),
                Convert.ToInt32(this.monthDropDownList.SelectedValue),
                currentDate.Day);
            this.monthViewCalendar.VisibleDate = date;
            this.SetCalendarNavigationControls();
        }

        private void MonthViewCalendarDayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth || e.Day.Date > DateTime.Now.Date)
            {
                e.Day.IsSelectable = false;
            }
            else
            {
                e.Day.IsSelectable = true;
                e.Cell.Controls.Clear();

                var dayNumberPanel = new Panel();
                dayNumberPanel.Controls.Add(new LiteralControl(e.Day.DayNumberText));
                e.Cell.Controls.Add(dayNumberPanel);

                var button = new LinkButton { OnClientClick = e.SelectUrl };
                button.Style.Add(HtmlTextWriterStyle.Cursor, "pointer");

                var textPanel = new Panel();

                if (this.GetTextPanel != null)
                {
                    this.GetTextPanel(textPanel, e.Day.Date);    
                }

                button.Controls.Add(textPanel);
                e.Cell.Controls.Add(button);
            }
        }

        private void MonthViewCalendarSelectionChanged(object sender, EventArgs e)
        {
            if (this.SelectionChanged != null)
            {
                this.SelectionChanged();    
            }
        }

        #endregion

        #region Private Methods - Render Helpers

        private void RenderPreviousMonthCell(HtmlTextWriter writer)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.PaddingLeft, "0.5em");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "33%");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            this.previousMonthLinkButton.RenderControl(writer);
            writer.RenderEndTag();
        }

        private void RenderYearMonthCell(HtmlTextWriter writer)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "33%");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            this.monthDropDownList.RenderControl(writer);
            this.yearDropDownList.RenderControl(writer);
            this.selectYearMonthButton.RenderControl(writer);
            writer.RenderEndTag();
        }

        private void RenderNextMonthCell(HtmlTextWriter writer)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.PaddingRight, "0.5em");
            writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "right");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "33%");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            this.nextMonthLinkButton.RenderControl(writer);
            writer.RenderEndTag();
        }

        private void RenderCalendar(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Colspan, "3");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            this.monthViewCalendar.RenderControl(writer);
            writer.RenderEndTag();
        }

        #endregion

        #region Private Methods - Control Setup

        private void InitializeControls()
        {
            this.SetupPreviousMonthLinkButton();
            this.SetupMonthDropDownList();
            this.SetupYearDropDownList();
            this.SetupSelectYearMonthButton();
            this.SetupNextMonthLinkButton();
            this.SetupMonthViewCalendar();
        }

        private void SetupPreviousMonthLinkButton()
        {
            var button = this.previousMonthLinkButton;
            button.Click += this.PreviousMonthLinkButtonClick;
            button.ForeColor = Color.Black;
            button.Style.Add(HtmlTextWriterStyle.TextDecoration, "none");
            button.Text = "&laquo;";
        }

        private void SetupMonthDropDownList()
        {
            var ddl = this.monthDropDownList;

            for (int i = 1; i <= 12; i++)
            {
                string name = this.GetMonthName(i);
                ddl.Items.Add(new ListItem(name, i.ToString()));
            }
        }

        private void SetupYearDropDownList()
        {
            var ddl = this.yearDropDownList;

            int currentYear = DateTime.Now.Year;
            int loopYear = currentYear;

            while (this.StartYear <= loopYear)
            {
                ddl.Items.Add(new ListItem(loopYear.ToString(), loopYear.ToString()));
                loopYear--;
            }
        }

        private void SetupSelectYearMonthButton()
        {
            var button = this.selectYearMonthButton;
            button.Click += this.SelectYearMonthButtonClick;
            button.Text = "Select";
        }

        private void SetupNextMonthLinkButton()
        {
            var button = this.nextMonthLinkButton;
            button.Click += this.NextMonthLinkButtonClick;
            button.ForeColor = Color.Black;
            button.Style.Add(HtmlTextWriterStyle.TextDecoration, "none");
            button.Text = "&raquo;";
        }

        private void SetupMonthViewCalendar()
        {
            var calendar = this.monthViewCalendar;
            calendar.DayRender += this.MonthViewCalendarDayRender;
            calendar.SelectionChanged += this.MonthViewCalendarSelectionChanged;
            calendar.ShowTitle = false;
            calendar.ShowGridLines = true;
            calendar.Width = Unit.Percentage(100);

            var dayHeader = calendar.DayHeaderStyle;
            dayHeader.CssClass = "day-header";

            var otherMonthDay = calendar.OtherMonthDayStyle;
            otherMonthDay.CssClass = "other-month-day";

            var day = calendar.DayStyle;
            day.CssClass = "day";

            var selectedDay = calendar.SelectedDayStyle;
            selectedDay.CssClass = "selected-day";
        }

        #endregion

        private void ChangeVisibleDateByNumberMonths(int change)
        {
            DateTime currentDate = this.monthViewCalendar.VisibleDate;
            this.monthViewCalendar.VisibleDate = currentDate.AddMonths(change);
            this.SetCalendarNavigationControls();
        }

        private void SetCalendarNavigationControls()
        {
            DateTime visibleDate = this.monthViewCalendar.VisibleDate;

            this.monthDropDownList.SelectedValue = visibleDate.Month.ToString();
            this.yearDropDownList.SelectedValue = visibleDate.Year.ToString();

            DateTime now = DateTime.Now;
            if (now.Year == visibleDate.Year && now.Month == visibleDate.Month)
            {
                this.nextMonthLinkButton.Visible = false;
                this.nextMonthLinkButton.Text = string.Empty;
            }
            else
            {
                this.nextMonthLinkButton.Visible = true;
                int nextMonth = visibleDate.Month + 1;
                this.nextMonthLinkButton.Text = string.Concat(this.GetMonthName(nextMonth), " &raquo;");
            }

            int previousMonth = visibleDate.Month - 1;
            this.previousMonthLinkButton.Text = string.Concat("&laquo; ", this.GetMonthName(previousMonth));
        }

        private string GetMonthName(int month)
        {
            if (month < 1)
            {
                month = 12;
            }
            else if (month > 12)
            {
                month = 1;
            }

            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }
    }
}
