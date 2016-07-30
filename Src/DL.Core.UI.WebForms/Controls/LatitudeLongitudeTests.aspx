<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LatitudeLongitudeTests.aspx.cs" Inherits="DL.Core.UI.WebForms.Controls.LatitudeLongitudeTests" %>
<%@ Register tagPrefix="dl" assembly="DL.Core.Web" namespace="DL.Core.Web.Controls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%-- 
            degrees minutes seconds: 79° 58′ 56″ W
            degrees decimal minutes: 79° 58.933′ W
            decimal degrees: 79.98222° W
            decimal: -79.98222
         
            degrees minutes seconds: 40° 26′ 46″ N 
            degrees decimal minutes: 40° 26.767′ N 
            decimal degrees: 40.44611° N
            decimal: 40.44611°
         --%>
        
        <h1>Editor</h1>
        
        <dl:CoordinateEditor ID="CoordinateEditor1" runat="server" CoordinateType="Latitude" />
        
        <asp:Button runat="server" ID="SubmitCoordinateEditor" Text="Submit" OnClick="SubmitCoordinateEditor_Click" />
        
        <h1>Display</h1>

        <h3>Degrees</h3>
        <asp:Literal ID="DisplayDegreesLiteral" runat="server" />

        <h3>Degrees Minutes</h3>
        <asp:Literal ID="DisplayDegreesMinutesLiteral" runat="server" />

        <h3>Degrees Minutes Seconds</h3>
        <asp:Literal ID="DisplayDegreesMinutesSecondsLiteral" runat="server" />

        <h3>Degrees Direction</h3>
        <asp:Literal ID="DisplayDegreesDirectionLiteral" runat="server" />
        
        <h3>Degrees Minutes Direction</h3>
        <asp:Literal ID="DisplayDegreesMinutesDirectionLiteral" runat="server" />
        
        <h3>Degrees Minutes Seconds Direction</h3>
        <asp:Literal ID="DisplayDegreesMinutesSecondsDirectionLiteral" runat="server" />

    </div>
    </form>
</body>
</html>
