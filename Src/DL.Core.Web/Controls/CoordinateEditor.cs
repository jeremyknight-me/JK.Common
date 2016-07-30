using System;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using DL.Core.Enums;
using DL.Core.Geospatial;

namespace DL.Core.Web.Controls
{
    /// <summary>
    /// CompositeControl which contains controls lettings users edit
    /// coordinates in multiple display formats.
    /// </summary>
    [ToolboxData("<{0}:CoordinateEditor runat=server></{0}:CoordinateEditor>")]
    public class CoordinateEditor : CompositeControl
    {
        private readonly Button selectEditModeButton = new Button();

        private readonly DropDownList directionDropDownList = new DropDownList();

        private readonly DropDownList editModeDropDownList = new DropDownList();

        private readonly HiddenField editModeHiddenField = new HiddenField();

        private readonly TextBox degreesTextBox = new TextBox();

        private readonly TextBox minutesTextBox = new TextBox();

        private readonly TextBox secondsTextBox = new TextBox();

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(CoordinateType.Latitude)]
        [DisplayName("CoordinateType")]
        public CoordinateType CoordinateType { get; set; }

        public int CurrentEditModeId
        {
            get { return Convert.ToInt32(this.editModeHiddenField.Value); }
            set { this.editModeHiddenField.Value = value.ToString(); }
        }

        #region Public Methods

        public CoordinateBase GetCoordinate()
        {
            int editModeId = this.GetSelectedEditModeId();
            return this.GetCoordinate(editModeId);
        }

        public decimal GetCoordinateValue()
        {
            var coordinate = this.GetCoordinate();
            return coordinate.Coordinate;
        }

        public void SetCoordinate(CoordinateBase coordinate)
        {
            int editModeId = this.GetSelectedEditModeId();
            var enumUtility = new EnumUtility();

            switch (editModeId)
            {
                case 0:
                    this.degreesTextBox.Text = coordinate.DecimalDegreesSigned.ToString(CultureInfo.InvariantCulture);
                    break;
                case 1:
                    this.degreesTextBox.Text = coordinate.DegreesSigned.ToString(CultureInfo.InvariantCulture);
                    this.minutesTextBox.Text = coordinate.DecimalMinutes.ToString(CultureInfo.InvariantCulture);
                    break;
                case 2:
                    this.degreesTextBox.Text = coordinate.DegreesSigned.ToString(CultureInfo.InvariantCulture);
                    this.minutesTextBox.Text = coordinate.Minutes.ToString(CultureInfo.InvariantCulture);
                    this.secondsTextBox.Text = coordinate.Seconds.ToString(CultureInfo.InvariantCulture);
                    break;
                case 3:
                    this.directionDropDownList.SelectedValue = enumUtility.GetInteger(coordinate.Direction).ToString(CultureInfo.InvariantCulture);
                    this.degreesTextBox.Text = coordinate.DecimalDegrees.ToString(CultureInfo.InvariantCulture);
                    break;
                case 4:
                    this.directionDropDownList.SelectedValue = enumUtility.GetInteger(coordinate.Direction).ToString(CultureInfo.InvariantCulture);
                    this.degreesTextBox.Text = coordinate.Degrees.ToString(CultureInfo.InvariantCulture);
                    this.minutesTextBox.Text = coordinate.DecimalMinutes.ToString(CultureInfo.InvariantCulture);
                    break;
                case 5:
                    this.directionDropDownList.SelectedValue = enumUtility.GetInteger(coordinate.Direction).ToString(CultureInfo.InvariantCulture);
                    this.degreesTextBox.Text = coordinate.Degrees.ToString(CultureInfo.InvariantCulture);
                    this.minutesTextBox.Text = coordinate.Minutes.ToString(CultureInfo.InvariantCulture);
                    this.secondsTextBox.Text = coordinate.Seconds.ToString(CultureInfo.InvariantCulture);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetCoordinateValue(decimal value)
        {
            var coordinate = this.GetEmptyCoordinate();
            coordinate.SetCoordinate(value);
            this.SetCoordinate(coordinate);
        }

        #endregion

        #region Protected Methods - Event Handlers

        protected void SelectEditModeButtonClick(object sender, EventArgs e)
        {
            var previousCoordinate = this.GetCoordinate(this.CurrentEditModeId);
            this.ClearTextBoxes();

            int selectedEditModeId = this.GetSelectedEditModeId();
            this.ShowFormat(selectedEditModeId);            

            this.SetAllTextBoxWidths();           

            this.SetCoordinate(previousCoordinate);
            this.CurrentEditModeId = selectedEditModeId;
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

            this.Controls.Add(this.selectEditModeButton);
            this.Controls.Add(this.directionDropDownList);
            this.Controls.Add(this.editModeDropDownList);
            this.Controls.Add(this.editModeHiddenField);
            this.Controls.Add(this.degreesTextBox);
            this.Controls.Add(this.minutesTextBox);
            this.Controls.Add(this.secondsTextBox);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.EnsureChildControls();

            if (this.HasControls())
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                this.editModeDropDownList.RenderControl(writer);
                this.selectEditModeButton.RenderControl(writer);
                this.editModeHiddenField.RenderControl(writer);
                writer.RenderEndTag(); // div

                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                this.directionDropDownList.RenderControl(writer);
                this.degreesTextBox.RenderControl(writer);
                this.minutesTextBox.RenderControl(writer);
                this.secondsTextBox.RenderControl(writer);
                writer.RenderEndTag(); // div
            }
        }

        #endregion

        #region Private Methods - Child Control Setup

        private void InitializeControls()
        {
            this.SetupEditModeDropDownList();
            this.SetupSelectEditModeButton();
            this.SetupEditModeHiddenField();
            this.SetupDirectionDropDownList();
            this.SetupDegreesTextBox();
            this.SetupMinutesTextBox();
            this.SetupSecondsTextBox();
        }

        private void SetupEditModeDropDownList()
        {
            DropDownList dropDown = this.editModeDropDownList;
            dropDown.Items.Clear();
            dropDown.Items.Add(new ListItem("Degrees", "0"));
            dropDown.Items.Add(new ListItem("Degrees Minutes", "1"));
            dropDown.Items.Add(new ListItem("Degrees Minutes Seconds", "2"));
            dropDown.Items.Add(new ListItem("Degrees Direction", "3"));
            dropDown.Items.Add(new ListItem("Degrees Minutes Direction", "4"));
            dropDown.Items.Add(new ListItem("Degrees Minutes Seconds Direction", "5"));
        }

        private void SetupSelectEditModeButton()
        {
            Button button = this.selectEditModeButton;
            button.Click += this.SelectEditModeButtonClick;
            button.Text = "Select";
        }

        private void SetupEditModeHiddenField()
        {
            this.editModeHiddenField.Value = "0";
        }

        private void SetupDirectionDropDownList()
        {
            DropDownList dropDown = this.directionDropDownList;
            dropDown.Visible = false;

            var coordinate = this.GetEmptyCoordinate();
            var directions = coordinate.GetValidDirections();

            var enumUtility = new EnumUtility();
            dropDown.Items.Clear();
            
            foreach (var direction in directions)
            {
                var item = new ListItem
                {
                    Value = enumUtility.GetInteger(direction).ToString(),
                    Text = direction.ToString()
                };
                dropDown.Items.Add(item);
            }
        }

        private void SetupDegreesTextBox()
        {
            TextBox textBox = this.degreesTextBox;
            textBox.MaxLength = this.IsLongitude()
                ? 10 // -###.#####
                : 9; // -##.#####

            this.SetTextBoxWidth(textBox);
        }

        private void SetupMinutesTextBox()
        {
            TextBox textBox = this.minutesTextBox;
            textBox.MaxLength = 0;
            textBox.Visible = false;

            this.SetTextBoxWidth(textBox);
        }

        private void SetupSecondsTextBox()
        {
            TextBox textBox = this.secondsTextBox;
            textBox.MaxLength = 4;
            textBox.Visible = false;

            this.SetTextBoxWidth(textBox);
        }

        #endregion

        #region Private Methods - Control Visibility & Styling

        private void ShowFormat(int editModeId)
        {
            switch (editModeId)
            {
                case 0:
                    this.ShowDegrees();
                    break;
                case 1:
                    this.ShowDegreesMinutes();
                    break;
                case 2:
                    this.ShowDegreesMinutesSeconds();
                    break;
                case 3:
                    this.ShowDegreesDirection();
                    break;
                case 4:
                    this.ShowDegreesMinutesDirection();
                    break;
                case 5:
                    this.ShowDegreesMinutesSecondsDirection();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("editModeId");
            }
        }

        private void ShowDegrees()
        {
            this.directionDropDownList.Visible = false;
            this.degreesTextBox.Visible = true;
            this.minutesTextBox.Visible = false;
            this.secondsTextBox.Visible = false;

            this.degreesTextBox.MaxLength = this.IsLongitude()
                ? 10 // -###.#####
                : 9; // -##.#####
        }

        private void ShowDegreesMinutes()
        {
            this.directionDropDownList.Visible = false;
            this.degreesTextBox.Visible = true;
            this.minutesTextBox.Visible = true;
            this.secondsTextBox.Visible = false;

            this.degreesTextBox.MaxLength = this.IsLongitude()
                ? 4 // -###
                : 3; // -##
            this.minutesTextBox.MaxLength = 6; // ##.###
        }

        private void ShowDegreesMinutesSeconds()
        {
            this.directionDropDownList.Visible = false;
            this.degreesTextBox.Visible = true;
            this.minutesTextBox.Visible = true;
            this.secondsTextBox.Visible = true;

            this.degreesTextBox.MaxLength = this.IsLongitude()
                ? 4 // -###
                : 3; // -##
            this.minutesTextBox.MaxLength = 2; // ##
        }

        private void ShowDegreesDirection()
        {
            this.directionDropDownList.Visible = true;
            this.degreesTextBox.Visible = true;
            this.minutesTextBox.Visible = false;
            this.secondsTextBox.Visible = false;

            this.degreesTextBox.MaxLength = this.IsLongitude()
                ? 9 // ###.#####
                : 8; // ##.#####
        }

        private void ShowDegreesMinutesDirection()
        {
            this.directionDropDownList.Visible = true;
            this.degreesTextBox.Visible = true;
            this.minutesTextBox.Visible = true;
            this.secondsTextBox.Visible = false;

            this.degreesTextBox.MaxLength = this.IsLongitude()
                ? 3 // ###
                : 2; // ##
            this.minutesTextBox.MaxLength = 6; // ##.###
        }

        private void ShowDegreesMinutesSecondsDirection()
        {
            this.directionDropDownList.Visible = true;
            this.degreesTextBox.Visible = true;
            this.minutesTextBox.Visible = true;
            this.secondsTextBox.Visible = true;

            this.degreesTextBox.MaxLength = this.IsLongitude()
                ? 3 // ###
                : 2; // ##
            this.minutesTextBox.MaxLength = 2; // ##
        }

        private void SetTextBoxWidth(TextBox textBox)
        {
            textBox.Width = new Unit(textBox.MaxLength, UnitType.Em);
        }

        private void SetAllTextBoxWidths()
        {
            this.SetTextBoxWidth(this.degreesTextBox);
            this.SetTextBoxWidth(this.minutesTextBox);
            this.SetTextBoxWidth(this.secondsTextBox);
        }

        private void ClearTextBoxes()
        {
            this.degreesTextBox.Text = string.Empty;
            this.minutesTextBox.Text = string.Empty;
            this.secondsTextBox.Text = string.Empty;
        }

        #endregion

        #region Private Methods

        private CoordinateBase GetCoordinate(int editModeId)
        {
            var coordinate = this.GetEmptyCoordinate();

            switch (editModeId)
            {
                case 0:
                    coordinate.SetCoordinate(this.GetDegrees());
                    break;
                case 1:
                    coordinate.SetCoordinate(this.GetDegrees(), this.GetMinutes());
                    break;
                case 2:
                    coordinate.SetCoordinate(this.GetDegrees(), this.GetMinutes(), this.GetSeconds());
                    break;
                case 3:
                    coordinate.SetCoordinate(this.GetDegrees(), this.GetDirection());
                    break;
                case 4:
                    coordinate.SetCoordinate(this.GetDegrees(), this.GetMinutes(), this.GetDirection());
                    break;
                case 5:
                    coordinate.SetCoordinate(this.GetDegrees(), this.GetMinutes(), this.GetSeconds(), this.GetDirection());
                    break;
                default:
                    throw new ArgumentOutOfRangeException("editModeId");
            }

            return coordinate;
        }       

        private CoordinateBase GetEmptyCoordinate()
        {
            var factory = new CoordinateFactory();
            return factory.Make(this.CoordinateType);
        }

        private int GetSelectedEditModeId()
        {
            return Convert.ToInt32(this.editModeDropDownList.SelectedValue);
        }

        private bool IsLongitude()
        {
            return this.CoordinateType == CoordinateType.Longitude;
        }

        private Direction GetDirection()
        {
            var enumUtility = new EnumUtility();
            int directionId = Convert.ToInt32(this.directionDropDownList.SelectedValue);
            return enumUtility.GetByInteger<Direction>(directionId);
        }

        private decimal GetDegrees()
        {
            if (!string.IsNullOrEmpty(this.degreesTextBox.Text))
            {
                return Convert.ToDecimal(this.degreesTextBox.Text);    
            }

            return 0;
        }

        private decimal GetMinutes()
        {
            if (!string.IsNullOrEmpty(this.minutesTextBox.Text))
            {
                return Convert.ToDecimal(this.minutesTextBox.Text);
            }

            return 0;
        }

        private decimal GetSeconds()
        {
            if (!string.IsNullOrEmpty(this.secondsTextBox.Text))
            {
                return Convert.ToDecimal(this.secondsTextBox.Text);
            }

            return 0;
        }

        #endregion
    }
}
