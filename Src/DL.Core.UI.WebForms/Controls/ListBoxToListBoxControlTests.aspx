<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListBoxToListBoxControlTests.aspx.cs" Inherits="DL.Core.UI.WebForms.Controls.ListBoxToListBoxControlTests" %>
<%@ Register tagPrefix="dl" assembly="DL.Core.Web" namespace="DL.Core.Web.Controls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://ajax.aspnetcdn.com/ajax/bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dl:ListBoxToListBox ID="NonBootstrapListBoxToListBox" runat="server" UseBootstrap="False" CssClass="list-to-list" />
        </div>
        <div>
            <dl:ListBoxToListBox ID="BootstrapListBoxToListBox" runat="server" UseBootstrap="True" CssClass="list-to-list" />
        </div>
    </form>
    
    <script src="http://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/bootstrap/3.0.3/bootstrap.min.js"></script>
</body>
</html>
