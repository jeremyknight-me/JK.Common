<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="DL.Core.UI.WebForms.Security.UserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div>
        <h1>User Details</h1>

        <h2>General Information</h2>

        <table>
            <tr>
                <td>User ID/Key:</td>
                <td><asp:Label ID="ProviderKeyLabel" runat="server" /></td>
            </tr>
            <tr>
                <td>User Name:</td>
                <td><asp:TextBox ID="UserNameInputTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>Email address:</td>
                <td><asp:TextBox ID="EmailInputTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>Active User:</td>
                <td><asp:CheckBox ID="IsApprovedInputCheckBox" runat="server" /></td>
            </tr>
            <tr>
                <td>Description:</td>
                <td><asp:TextBox ID="CommentInputTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>Roles:</td>
                <td>
                    <asp:CheckBoxList ID="UserRolesInputCheckBoxList" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="SaveUserButton" runat="server" Text="Save" 
                        onclick="SaveUserButton_Click" />
                    <asp:HyperLink ID="CloseHyperLink" runat="server" NavigateUrl="~/Security/Users.aspx">Close</asp:HyperLink>
                </td>
            </tr>
        </table>

        <h2>Security Information</h2>

        <h3>Reset User Password</h3>
        
        <p>
            Click here to reset the user's password:
            <asp:LinkButton ID="ResetPasswordLinkButton" runat="server" 
                Text="Reset" OnClick="ResetPasswordLinkButton_Click" />
            <asp:UpdatePanel ID="ResetPasswordUpdatePanel" runat="server" 
                ChildrenAsTriggers="False" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Literal ID="ResetPasswordLiteral" runat="server" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ResetPasswordLinkButton" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </p>
        
        <h3>Change User Security Question and Answer</h3>
    </div>
    </form>
</body>
</html>
