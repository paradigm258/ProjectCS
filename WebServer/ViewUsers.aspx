<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="WebServer.ViewUsers" %>

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
        <div id="viewUsers" style="min-height: 635px;">
            <div id="header">
                <div id="logo">
                </div>
                <div id="logoMask" onclick="redirectToHomePage()">
                </div>
                <div id="activeUser">
                    <asp:Label ID="lblActiveUser" runat="server" Text=""></asp:Label>
                </div>
                <div id="generalActions">
                    <asp:Button ID="buttonLogOut" CssClass="generalActionsElement" runat="server" Text="Log Out" OnClick="buttonLogOut_Click" />
                </div>
            </div>
            <div class="mainDiv">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                        <asp:CheckBoxField DataField="isAdmin" HeaderText="isAdmin" SortExpression="isAdmin" />
                        <asp:BoundField DataField="usedQuota" HeaderText="usedQuota" SortExpression="usedQuota" />
                        <asp:BoundField DataField="maxQuota" HeaderText="maxQuota" SortExpression="maxQuota" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("username") %>' CommandName="Select" Text="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("username") %>' CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CSProjectConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
