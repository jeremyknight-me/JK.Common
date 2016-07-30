using System;
using System.Web.Security;
using System.Web.UI.WebControls;

using DL.Core.Web.Security;

namespace DL.Core.UI.WebForms.Security
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadUserList();
            }
        }

        protected void UserListView_ItemDeleted(object sender, ListViewDeletedEventArgs e)
        {

        }

        protected void UserListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            var providerKey = e.Keys[0];
            this.DeleteUser(providerKey);
            this.LoadUserList();
        }

        protected void AddUserButton_Click(object sender, EventArgs e)
        {
            this.AddUserErrorLabel.Text = string.Empty;
            this.AddUser();
            this.LoadUserList();
        }

        private void LoadUserList()
        {
            var facade = new MembershipProviderFacade();
            var users = facade.GetAllUsers();

            this.UserListView.DataSource = users;
            this.UserListView.DataBind();
        }

        private void AddUser()
        {
            MembershipCreateStatus status;

            MembershipUser user
                = Membership.CreateUser(
                    this.AddUserUserNameInputTextBox.Text.Trim(),
                    this.AddUserPasswordInputTextBox.Text.Trim(),
                    this.AddUserEmailInputTextBox.Text.Trim(),
                    this.AddUserQuestionInputTextBox.Text.Trim(),
                    this.AddUserAnswerInputTextBox.Text.Trim(),
                    this.AddUserIsApprovedInputCheckBox.Checked,
                    out status);

            switch (status)
            {
                case MembershipCreateStatus.Success:
                case MembershipCreateStatus.UserRejected:
                case MembershipCreateStatus.InvalidProviderUserKey:
                case MembershipCreateStatus.DuplicateProviderUserKey:
                case MembershipCreateStatus.ProviderError:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    this.AddUserErrorLabel.Text = "Invalid user name.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    this.AddUserErrorLabel.Text = "Invalid password.";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    this.AddUserErrorLabel.Text = "Invalid question.";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    this.AddUserErrorLabel.Text = "Invalid answer.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    this.AddUserErrorLabel.Text = "Invalid email address.";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    this.AddUserErrorLabel.Text = "User already exists.";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    this.AddUserErrorLabel.Text = "Email address is already in use.";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void DeleteUser(object providerKey)
        {
            var membershipFacade = new MembershipProviderFacade();
            ProviderUser user = membershipFacade.GetUserByProviderKey(providerKey);
            membershipFacade.DeleteUser(user.UserName);
        }
    }
}