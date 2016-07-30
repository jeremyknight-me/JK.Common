<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DL.Core.UI.WebForms.Security.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div>
        <h1>Users</h1>

        <h2>Add User</h2>

        <table>
            <tr>
                <td>User Name:</td>
                <td>
                    <asp:TextBox ID="AddUserUserNameInputTextBox" runat="server" />
                    <asp:RequiredFieldValidator ID="UserNameRequiredValidator" runat="server" 
                        ControlToValidate="AddUserUserNameInputTextBox"
                        ErrorMessage="User name is required."
                        Text="*"
                        ForeColor="Red"
                        ValidationGroup="AddUser" />
                </td>
            </tr>
            <tr>
                <td>Email address:</td>
                <td>
                    <asp:TextBox ID="AddUserEmailInputTextBox" runat="server" />
                    <asp:RequiredFieldValidator ID="EmailRequiredValidator" runat="server" 
                        ControlToValidate="AddUserEmailInputTextBox"
                        ErrorMessage="Email is required."
                        Text="*"
                        ForeColor="Red"
                        ValidationGroup="AddUser" />
                    <asp:RegularExpressionValidator ID="EmailRegExValidator" runat="server" 
                        ControlToValidate="AddUserEmailInputTextBox"
                        ErrorMessage="Email address must be valid."
                        Text="*"
                        ForeColor="Red"
                        ValidationGroup="AddUser" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="AddUserPasswordInputTextBox" runat="server" 
                        TextMode="Password" />
                    <asp:RequiredFieldValidator ID="PasswordRequiredValidator" runat="server" 
                        ControlToValidate="AddUserPasswordInputTextBox"
                        ErrorMessage="Password is required."
                        Text="*"
                        ForeColor="Red"
                        ValidationGroup="AddUser" />
                </td>
            </tr>
            <tr>
                <td>Confirm Password:</td>
                <td>
                    <asp:TextBox ID="AddUserPasswordConfirmTextBox" runat="server" 
                        TextMode="Password" />
                    <asp:RequiredFieldValidator ID="PasswordConfirmRequiredValidator" runat="server" 
                        ControlToValidate="AddUserPasswordConfirmTextBox"
                        ErrorMessage="Password confirmation is required."
                        Text="*"
                        ForeColor="Red"
                        ValidationGroup="AddUser" />
                    <asp:CompareValidator ID="PasswordCompareValidator" runat="server" 
                        ControlToValidate="AddUserPasswordConfirmTextBox"
                        ControlToCompare="AddUserPasswordInputTextBox"
                        ErrorMessage="Passwords must match" 
                        Text="*"
                        ForeColor="Red" 
                        ValidationGroup="AddUser" />
                </td>
            </tr>
            <tr>
                <td>Security Question:</td>
                <td>
                    <asp:TextBox ID="AddUserQuestionInputTextBox" runat="server" />
                    <asp:RequiredFieldValidator ID="QuestionRequiredValidator" runat="server" 
                        ControlToValidate="AddUserQuestionInputTextBox"
                        ErrorMessage="Security question is required."
                        Text="*"
                        ForeColor="Red"
                        ValidationGroup="AddUser" />
                </td>
            </tr>
            <tr>
                <td>Security Answer:</td>
                <td>
                    <asp:TextBox ID="AddUserAnswerInputTextBox" runat="server" />
                    <asp:RequiredFieldValidator ID="AnswerRequiredValidator" runat="server" 
                        ControlToValidate="AddUserAnswerInputTextBox"
                        ErrorMessage="Security answer is required."
                        Text="*"
                        ForeColor="Red"
                        ValidationGroup="AddUser" />
                </td>
            </tr>
            <tr>
                <td>Active User:</td>
                <td><asp:CheckBox ID="AddUserIsApprovedInputCheckBox" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2" class="alignCenter">
                    <asp:Button ID="AddUserButton" runat="server" 
                        Text="Add User" 
                        ValidationGroup="AddUser"
                        onclick="AddUserButton_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="alignCenter">
                    <asp:ValidationSummary ID="AddUserValidationSummary" runat="server" 
                        ForeColor="Red"
                        ValidationGroup="AddUser" />
                    <asp:Label ID="AddUserErrorLabel" runat="server" EnableViewState="false" ForeColor="Red" />
                </td>
            </tr>
        </table>

        <h2>User List</h2>
        
        <asp:ListView ID="UserListView" runat="server" 
            DataKeyNames="ProviderKey" OnItemDeleted="UserListView_ItemDeleted" OnItemDeleting="UserListView_ItemDeleting">
            <LayoutTemplate>
                <table id="userList" style="width: 100%;">
                    <tr>
                        <th></th>
                        <th>User Name</th>
                        <th>Email</th>
                        <th>Active?</th>
                        <th>Description</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td>
                        <asp:HyperLink ID="SelectUserHyperLink" runat="server" Text="Details"
                            ToolTip="View details and edit" 
                            NavigateUrl='<%# string.Concat("~/Security/UserDetails.aspx?key=", Eval("ProviderKey")) %>' />

                        <asp:LinkButton ID="DeleteLinkButton" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="Delete" OnClientClick='return confirm("Are you sure you want to delete this user?");' />
                    </td>
                    <td>
                        <asp:HiddenField ID="UserIdHiddenField" runat="server" Value='<%#Eval("ProviderKey") %>' />
                        <asp:Literal ID="UserNameLiteral" runat="server" Text='<%#Eval("UserName") %>' />
                    </td>
                    <td>
                        <asp:Literal ID="UserEmailLiteral" runat="server" Text='<%#Eval("Email") %>' />
                    </td>
                    <td>
                        <asp:Literal ID="UserActiveLiteral" runat="server" Text='<%#Eval("IsApproved") %>' />
                    </td>
                    <td>
                        <asp:Literal ID="UserDescriptionLiteral" runat="server" Text='<%#Eval("Comment") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <table style="width: 100%;">
                    <tr>
                        <th></th>
                        <th>User Name</th>
                        <th>Email</th>
                        <th>Active?</th>
                        <th>Description</th>
                    </tr>
                    <tr>
                        <td colspan="5">
                            No Users Found.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
