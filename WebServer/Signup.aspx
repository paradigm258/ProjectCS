﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="WebServer.Signup" %>

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
         <div id="signup" style="min-height: 635px;">
            <div id="header">
                <div id="logo">
                </div>
                <div id="logoMask" onclick="redirectToHomePage()">
                </div>
                <div id="activeUser">
                    <asp:Label ID="lblActiveUser" runat="server" Text="Label"></asp:Label>
                </div>
                <div id="generalActions">
                </div>
            </div>
             <div id="mainDiv">
                <h1>Sign Up</h1>
                <table align="center">
                    <tr>
                        <td>Username:</td>
                        <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Password:</td>
                        <td><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="buttonBack" runat="server" Text="Back" OnClick="buttonBack_Click" />
                            <asp:Button ID="buttonSignup" runat="server" Text="Sign up" OnClick="buttonSignup_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>