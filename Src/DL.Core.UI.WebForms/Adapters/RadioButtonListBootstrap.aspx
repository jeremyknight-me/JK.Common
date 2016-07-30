<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadioButtonListBootstrap.aspx.cs" Inherits="DL.Core.UI.WebForms.Adapters.RadioButtonListBootstrap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://ajax.aspnetcdn.com/ajax/bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="form-group">

        <asp:RadioButtonList runat="server">
            <Items>
                <asp:ListItem Text="Radio Button 1" Value="1" />
                <asp:ListItem Text="Radio Button 2" Value="2" />
            </Items>
        </asp:RadioButtonList>
            
        </div>
    </div>
    </form>
</body>
</html>
