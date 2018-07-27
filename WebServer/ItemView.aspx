<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemView.aspx.cs" Inherits="WebServer.ItemView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/style.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="JS/script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="itemView" style="min-height: 635px;">
            <div id="header">
                <div id="logo">
                </div>
                <div id="logoMask" onclick="redirectToHomePage()">
                </div>
                <div id="activeUser">
                    <asp:Label ID="lblActiveUser" runat="server" Text=""></asp:Label>
                </div>
                <div id="generalActions">
                    <asp:Button ID="buttonBack" CssClass="generalActionsElement" runat="server" Text="Back" OnClick="buttonBack_Click" />
                    <asp:Button ID="buttonLogOut" CssClass="generalActionsElement" runat="server" Text="Log Out" OnClick="buttonLogOut_Click" />
                </div>
            </div>
            <div class="mainDiv">
                <div id="itemManager">
                    <div id="itemName">
                        <asp:Label ID="Name" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:Label ID="lblError" class="lblError" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblNoti" Style="color: #6495ED;" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="itemActions">
                        <%if (isOwner)
                            { %>
                        <div id="privacy" class="itemActionsElement">
                            <h1>Privacy</h1>
                            <asp:Label ID="Label1" runat="server" Text="Enter username to filter: "></asp:Label>
                            <asp:TextBox ID="Filter" runat="server" OnTextChanged="Filter_TextChanged" AutoPostBack="True"></asp:TextBox>
                            <br />
                            <asp:Button ID="buttonShare" runat="server" Text="Share" OnClick="buttonShare_Click" />
                            <asp:Button ID="buttonSwitchPrivacy" runat="server" Text="Switch to " OnClick="buttonSwitchPrivacy_Click" />
                            <asp:DropDownList ID="DropDownList1" Style="width: 100px;" runat="server"></asp:DropDownList>
                        </div>
                        <% } %>
                        <div id="download" class="itemActionsElement">
                            <h1>File Control</h1>
                            <%if (isOwner)
                            { %>
                            <asp:Button ID="buttonDelete" runat="server" OnClientClick="return confirm('Confirm delete?');" Text="Delete" OnClick="buttonDelete_Click" />
                            <% } %>
                            <asp:Button ID="buttonDownload" runat="server" OnClientClick="return confirm('Confirm download?');" Text="Download" OnClick="buttonDownload_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
