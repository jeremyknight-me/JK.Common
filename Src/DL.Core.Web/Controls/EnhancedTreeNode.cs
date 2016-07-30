using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DL.Core.Web.Controls
{
    [ToolboxData("<{0}:EnhancedTreeNode runat=server></{0}:EnhancedTreeNode>")]
    public class EnhancedTreeNode : TreeNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnhancedTreeNode"/> class. 
        /// </summary>
        public EnhancedTreeNode()
        {
            this.Enabled = true;
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(true)]
        [DisplayName("LeftHeaderText")]
        public bool Enabled { get; set; }
    }
}
