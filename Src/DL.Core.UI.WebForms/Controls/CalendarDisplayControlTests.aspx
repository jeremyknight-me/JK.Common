<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarDisplayControlTests.aspx.cs" Inherits="DL.Core.UI.WebForms.Controls.CalendarDisplayControlTests" %>
<%@ Register tagPrefix="dl" assembly="DL.Core.Web" namespace="DL.Core.Web.Controls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body 
        {
            font-family: Verdana;
            font-size: 100%;
        }
        
        .day, .other-month-day {
            height: 50px;
            padding: 0.5em;
            text-align: left;
            vertical-align: top;
            width: 50px;
        }

        .day 
        {
            background-color: #fff;
            color: #000;
            font-weight: normal;
        }

        .day-header 
        {
            color: #000;
            background-color: #ccc;
            font-weight: bold;
            text-transform: uppercase;
        }

        .selected-day 
        {
            color: #000;    
        }

        .other-month-day 
        {
            background-color: #eee;
            color: #666;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dl:CalendarDisplay ID="CalendarDisplay1" runat="server" />    
    </div>
    </form>
</body>
</html>
