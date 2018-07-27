<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="WebServer.AddItem" %>

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
        <div id="addItem" style="min-height: 635px;">
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
            <div id="mainDiv">
                <h1>Add Item</h1>
                <table align="center">
                    <tr>
                        <td><asp:FileUpload id="FileUploadControl" AllowMultiple="true" runat="server" /></td>
                        <td><asp:CheckBox ID="IsPublic" runat="server" Text="Is Public" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="buttonAdd" runat="server" Text="Add" OnClick="buttonAdd_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblError" class="lblError" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblNoti" class="lblNoti" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
