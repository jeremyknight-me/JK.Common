<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="DL.Core.UI.WebForms.Security.Roles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div>
        <h1>Roles</h1>

        <h2>Create New Role</h2>

        <asp:UpdatePanel ID="AddRoleUpdatePanel" runat="server" 
            ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <div>
                    New role name:
                    <asp:TextBox ID="NewRoleNameTextBox" runat="server" />
                    <asp:Button ID="AddNewRoleButton" runat="server" Text="Add Role" 
                        onclick="AddNewRoleButton_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <h2>Roles List</h2>

        <asp:UpdatePanel ID="RoleListUpdatePanel" runat="server" 
            ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:ListBox ID="RolesListBox" runat="server" 
                    AutoPostBack="true"
                    onselectedindexchanged="RolesListBox_SelectedIndexChanged" />
                <asp:Button runat="server" ID="DeleteRoleButton" 
                    Text="Delete Role"
                    onclick="DeleteRoleButton_Click" 
                    Enabled="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
