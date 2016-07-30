using System;
using System.Web.UI;
using DL.Core.Geospatial;

namespace DL.Core.UI.WebForms.Controls
{
    public partial class LatitudeLongitudeTests : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
            }
        }

        protected void SubmitCoordinateEditor_Click(object sender, EventArgs e)
        {
            var coordinate = this.CoordinateEditor1.GetCoordinate();
            this.DisplayDegreesLiteral.Text = coordinate.ToHtmlString(DisplayFormat.Degrees);
            this.DisplayDegreesMinutesLiteral.Text = coordinate.ToHtmlString(DisplayFormat.DegreesMinutes);
            this.DisplayDegreesMinutesSecondsLiteral.Text = coordinate.ToHtmlString(DisplayFormat.DegreesMinutesSeconds);
            this.DisplayDegreesDirectionLiteral.Text = coordinate.ToHtmlString(DisplayFormat.DegreesDirection);
            this.DisplayDegreesMinutesDirectionLiteral.Text = coordinate.ToHtmlString(DisplayFormat.DegreesMinutesDirection);
            this.DisplayDegreesMinutesSecondsDirectionLiteral.Text = coordinate.ToHtmlString(DisplayFormat.DegreesMinutesSecondsDirection);
        }
    }
}