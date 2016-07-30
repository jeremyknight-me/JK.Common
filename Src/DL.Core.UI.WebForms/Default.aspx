<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DL.Core.UI.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Adapters</h2>
        
        <ul>
            <li><a href="<%= Page.ResolveClientUrl("~/Adapters/RadioButtonListBootstrap.aspx") %>">RadioButton Bootstrap Adapter</a></li>
        </ul>

        <h2>Controls</h2>    
        
        <ul>
            <li><a href="<%= Page.ResolveClientUrl("~/Controls/BinaryDropDownListControlTests.aspx") %>">BinaryDropDownList Control</a></li>
            <li><a href="<%= Page.ResolveClientUrl("~/Controls/BootstrapMenuTests.aspx") %>">BootstrapMenu Control</a></li>
            <li><a href="<%= Page.ResolveClientUrl("~/Controls/CalendarDisplayControlTests.aspx") %>">CalendarDisplay Control</a></li>
            <li><a href="<%= Page.ResolveClientUrl("~/Controls/LatitudeLongitudeTests.aspx") %>">LatitudeLongitude Control</a></li>
            <li><a href="<%= Page.ResolveClientUrl("~/Controls/ListBoxToListBoxControlTests.aspx") %>">ListBoxToListBox Control</a></li>
            <li><a href="<%= Page.ResolveClientUrl("~/Controls/TernaryDropDownListControlTests.aspx") %>">TernaryDropDownList Control</a></li>
        </ul>

        <h2>Security</h2>
        
        <ul>
            <li><a href="<%= Page.ResolveClientUrl("~/Security/Users.aspx") %>">Users</a></li>
            <li><a href="<%= Page.ResolveClientUrl("~/Security/Roles.aspx") %>">Roles</a></li>
        </ul>
        
        <h2>Misc</h2>
        
        <ul>
            <li><a href="<%= Page.ResolveClientUrl("~/Pages/MimeTypes.aspx") %>">Mime Types</a></li>
        </ul>

    </div>
    </form>
</body>
</html>
