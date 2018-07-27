<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebServer.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/style.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="JS/script.js"></script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" multiple>
        <div id="home" style="min-height: 635px;">
            <div id="header">
                <div id="logo">
                </div>
                <div id="logoMask" onclick="redirectToHomePage()">
                </div>
                <div id="activeUser">
                    <asp:Label ID="lblActiveUser" runat="server" Text=""></asp:Label>
                </div>
                <div id="generalActions">
                    <asp:Button ID="buttonAdd" CssClass="generalActionsElement" runat="server" Text="Add" OnClick="buttonAdd_Click" />
                    <asp:Button ID="buttonItemCategories" CssClass="generalActionsElement" runat="server" Text="Shared To Me" OnClick="buttonItemCategories_Click" />
                    <asp:Button ID="buttonLogOut" CssClass="generalActionsElement" runat="server" Text="Log Out" OnClick="buttonLogOut_Click" />
                </div>
            </div>
            <div class="mainDiv">
                <div id="div1">
                    <% foreach (WebServer.Model.Item item in items)
                        {
                            if (item.isFolder)
                            {%>
                    <div class="itemDisplay" onclick="location.href = 'Home.aspx?id='+<%: item.id %>">
                        <%: item %>
                    </div>
                    <% }
                        else
                        {%>
                    <div class="itemDisplay" onclick="location.href = 'ItemView.aspx?id='+<%: item.id %>">
                        <%: item %>
                    </div>
                    <% }
                        } %>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
