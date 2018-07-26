<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebServer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/style.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="JS/script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id ="login" style="height: 100px; background: blue;">
            <div id="header">
                <div id="logo">     
                </div>
                <div id="logoMask" onclick="redirectToHomePage()">
                </div>  
                <div id="activeUser">
                </div>
                <div id="generalActions" >
                </div>
            </div>
        </div>
    </form>
</body>
</html>
