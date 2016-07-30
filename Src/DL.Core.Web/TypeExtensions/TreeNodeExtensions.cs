using System.Web.UI.WebControls;

namespace DL.Core.Web.TypeExtensions
{
    public static class TreeNodeExtensions
    {
        public static void ExpandAncestors(this TreeNode node, bool expandCurrent = false)
        {
            if (expandCurrent)
            {
                node.Expand();
            }

            if (node.Parent != null)
            {
                node.Parent.Expand();
                node.Parent.ExpandAncestors();
            }
        }

        public static string GetNodePath(this TreeNode node)
        {
            return node.Parent != null ? string.Concat(node.Parent.GetNodePath(), "/", node.Text) : node.Text;
        }
    }
}
