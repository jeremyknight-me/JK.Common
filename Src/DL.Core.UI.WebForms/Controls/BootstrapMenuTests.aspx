<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BootstrapMenuTests.aspx.cs" Inherits="DL.Core.UI.WebForms.Controls.BootstrapMenuTests" %>
<%@ Register tagPrefix="dl" assembly="DL.Core.Web" namespace="DL.Core.Web.Controls" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    
    <title>Island Portal</title>
    <link href="http://ajax.aspnetcdn.com/ajax/bootstrap/3.1.0/css/bootstrap.min.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
               
        <h3>Bootstrap</h3>
        
        <div id="main-nav" class="navbar navbar-inverse navbar-static-top" role="navigation">
            <div class="container" style="padding: 0; margin: 0;">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="#">Home</a></li>
                        <li><a href="#about">About</a></li>
                        <li><a href="#contact">Contact</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Dropdown <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a href="#">Action</a></li>
                                <li><a href="#">Another action</a></li>
                                <li><a href="#">Something else here</a></li>
                            </ul>
                        </li>
                    </ul>
                </div><!--/.nav-collapse -->
            </div>
        </div>
        
        <h3>BootstrapMenu ASP.NET Control</h3>
        
        <div class="navbar navbar-inverse navbar-static-top" role="navigation">
            <div class="container" style="padding: 0; margin: 0;">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse">
                    <dl:BootstrapMenu ID="BootstrapMenu1" runat="server" HighlightActive="True">
                        <Items>
                            <asp:MenuItem Text="Home" NavigateUrl="#" />
                            <asp:MenuItem Text="About" NavigateUrl="#" />
                            <asp:MenuItem Text="Contact" NavigateUrl="#" />
                            <asp:MenuItem Text="Drop Down">
                                <asp:MenuItem Text="Action" NavigateUrl="#" />
                                <asp:MenuItem Text="Another action" NavigateUrl="#" />
                                <asp:MenuItem Text="Bootstrap Menu" NavigateUrl="~/Controls/BootstrapMenuTests.aspx" />
                                <asp:MenuItem Text="Something else here" NavigateUrl="#" />
                            </asp:MenuItem>
                            <asp:MenuItem Text="Help" NavigateUrl="#" />
                            <asp:MenuItem Text="Nothing" />
                        </Items>
                    </dl:BootstrapMenu>
                </div><!--/.nav-collapse -->
            </div>
        </div>

        <h3>BootstrapMenu ASP.NET Control SiteMap</h3>
        
        <%--<div class="navbar navbar-inverse navbar-static-top" role="navigation">
            <div class="container" style="padding: 0; margin: 0;">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse">
                    <dl:BootstrapMenu ID="BootstrapMenu2" runat="server" DataSourceId="SiteMapDataSource1" />
                    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="False" />
                </div><!--/.nav-collapse -->
            </div>
        </div>--%>
    </div>
    </form>
    
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/bootstrap/3.1.0/bootstrap.min.js"></script>
</body>
</html>
