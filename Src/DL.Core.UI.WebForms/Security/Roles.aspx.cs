using System;
using DL.Core.Web.Security;

namespace DL.Core.UI.WebForms.Security
{
    public partial class Roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadRolesList();
            }
        }

        protected void AddNewRoleButton_Click(object sender, EventArgs e)
        {
            this.AddRole();

            this.LoadRolesList();
            this.RoleListUpdatePanel.Update();

            this.NewRoleNameTextBox.Text = string.Empty;
            this.NewRoleNameTextBox.Focus();
        }

        protected void DeleteRoleButton_Click(object sender, EventArgs e)
        {
            this.DeleteRole();
            this.LoadRolesList();
        }

        protected void RolesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DeleteRoleButton.Enabled = this.RolesListBox.SelectedIndex >= 0;
        }

        private void LoadRolesList()
        {
            var facade = new RolesProviderFacade();
            var roles = facade.GetAllRoles();

            this.RolesListBox.Items.Clear();
            this.RolesListBox.DataSource = roles;
            this.RolesListBox.DataBind();
        }

        private void AddRole()
        {
            var facade = new RolesProviderFacade();
            facade.AddRole(this.NewRoleNameTextBox.Text);
        }

        private void DeleteRole()
        {
            var facade = new RolesProviderFacade();
            facade.DeleteRole(this.RolesListBox.SelectedValue);
        }
    }
}