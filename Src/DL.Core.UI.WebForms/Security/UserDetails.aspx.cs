using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DL.Core.Web.Security;

namespace DL.Core.UI.WebForms.Security
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["key"] != null
                    && !string.IsNullOrEmpty(this.Request.QueryString["key"]))
                {
                    this.ProviderKeyLabel.Text = this.Request.QueryString["key"];
                    this.LoadRolesList();
                    this.LoadUserDetails();
                }
                else
                {
                    this.Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void SaveUserButton_Click(object sender, EventArgs e)
        {
            this.UpdateUser();
        }

        protected void ResetPasswordLinkButton_Click(object sender, EventArgs e)
        {
            var membershipFacade = new MembershipProviderFacade();
            ProviderUser user = membershipFacade.GetUserByProviderKey(Guid.Parse(this.ProviderKeyLabel.Text));
            string newPassword = membershipFacade.ResetPassword(user.UserName);
            this.ResetPasswordLiteral.Text = newPassword;
        }

        private void LoadUserDetails()
        {
            var membershipFacade = new MembershipProviderFacade();
            ProviderUser user = membershipFacade.GetUserByProviderKey(Guid.Parse(this.ProviderKeyLabel.Text));

            this.CommentInputTextBox.Text = user.Comment;
            this.EmailInputTextBox.Text = user.Email;
            this.IsApprovedInputCheckBox.Checked = user.IsApproved;
            this.UserNameInputTextBox.Text = user.UserName;

            var rolesFacade = new RolesProviderFacade();

            IEnumerable<string> selectedItems = rolesFacade.GetRolesForUser(user.UserName);
            foreach (string item in selectedItems)
            {
                ListItem listItem = this.UserRolesInputCheckBoxList.Items.FindByValue(item);
                if (listItem != null)
                {
                    listItem.Selected = true;
                }
            }
        }

        private void LoadRolesList()
        {
            var facade = new RolesProviderFacade();
            var roles = facade.GetAllRoles();

            this.UserRolesInputCheckBoxList.Items.Clear();
            this.UserRolesInputCheckBoxList.DataSource = roles;
            this.UserRolesInputCheckBoxList.DataBind();
        }

        private void UpdateUser()
        {
            var membershipFacade = new MembershipProviderFacade();

            ProviderUser user = membershipFacade.GetUserByProviderKey(Guid.Parse(this.ProviderKeyLabel.Text));
            user.Comment = this.CommentInputTextBox.Text.Trim();
            user.Email = this.EmailInputTextBox.Text.Trim();
            user.IsApproved = this.IsApprovedInputCheckBox.Checked;

            membershipFacade.UpdateUser(user);

            var rolesFacade = new RolesProviderFacade();
            IEnumerable<string> allRoles = rolesFacade.GetAllRoles();
            IEnumerable<string> selectedRoles = (from ListItem item in this.UserRolesInputCheckBoxList.Items where item.Selected select item.Value).ToList();

            if (allRoles != null && selectedRoles != null)
            {
                foreach (string role in allRoles)
                {
                    bool isInRole = rolesFacade.IsUserInRole(user.UserName, role);
                    bool containsRole = selectedRoles.Contains(role);

                    if (!isInRole && containsRole)
                    {
                        rolesFacade.AddUserToRole(user.UserName, role);
                    }
                    else if (isInRole && !containsRole)
                    {
                        rolesFacade.RemoveUserFromRole(user.UserName, role);
                    }
                }
            }
        }
    }
}