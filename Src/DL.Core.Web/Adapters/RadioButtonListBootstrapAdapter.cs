using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DL.Core.Web.Adapters
{
    public class RadioButtonListBootstrapAdapter : System.Web.UI.WebControls.Adapters.WebControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var control = this.Control as RadioButtonList;

            if (control == null)
            {
                base.Render(writer);
                return;
            }

            if (!string.IsNullOrEmpty(control.CssClass))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, control.CssClass);
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            var repeaterInfo = (IRepeatInfoUser)this.Control;

            for (int i = 0; i < control.Items.Count; i++)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "radio");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                writer.RenderBeginTag(HtmlTextWriterTag.Label);

                repeaterInfo.RenderItem(ListItemType.Item, i, new RepeatInfo(), writer);

                writer.RenderEndTag(); // label
                writer.RenderEndTag(); // div
            }

            writer.RenderEndTag();
        }
    }
}
