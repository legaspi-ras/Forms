<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm7.aspx.vb" Inherits="connection.WebForm7" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>

            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">&nbsp;<asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
                    <td>&nbsp;<asp:TextBox ID="txtUsername" runat="server" Width="256px"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;<asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                    <td>&nbsp;<asp:TextBox ID="txtPassword" runat="server" Width="253px"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;<asp:Label ID="Label3" runat="server" Text="Full Name:"></asp:Label></td>
                    <td>&nbsp;<asp:TextBox ID="txtFullname" runat="server" Width="253px"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td class="auto-style1">&nbsp;<asp:Label ID="Label4" runat="server" Text="Email Address:"></asp:Label></td>
                    <td>&nbsp;<asp:TextBox ID="txtEmailaddress" runat="server" Width="253px"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="Login" /></td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
</asp:Content>
