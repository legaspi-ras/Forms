<%@ Page Title="Contact" Language="VB" MasterPageFile="~/DIC.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="connection.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%--for validation lang to--%>Update e-Form</h2>
        
    <div>
        <table style="width: 100%;">
            <tr>
                <td>

                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 191px"> 

                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 191px"> 
                    <asp:Label ID="Label10" runat="server" Text="Form Control Number : "></asp:Label>
                </td>
                <td style="width: 555px"> 
                    <asp:TextBox ID="txtSearch" runat="server" Width="559px"></asp:TextBox>
                </td>
                <td class="modal-sm" style="width: 504px"> 
                    <asp:Button ID="btnsearch" runat="server" Text="Search" Width="117px" />

                </td>
            </tr>
             <tr>
                <td class="modal-sm" style="width: 191px"> 

                </td>              
            </tr>
        </table>

    </div>
    <div>

        <hr />
    </div>
    <div>
        <table style="width: 44%; height: 457px; margin-top: 0px; ">
            
            <tr><%--for validation lang to--%>
                <td style="width: 192px; height: 50px;">
                     <asp:Label ID="Label1" runat="server" Text="Department Area: "></asp:Label>
                </td>
                <td style="height: 50px">
                     <asp:TextBox ID="txtDeptarea" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>

            <tr><%--for validation lang to--%>
                <td style="width: 192px; height: 50px;">
                     <asp:Label ID="Label8" runat="server" Text="Form Control Number : "></asp:Label>
                </td>
                <td style="height: 50px">
                     <asp:TextBox ID="txtFormctrlnum" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>

            <tr><%--for validation lang to--%>
                <td style="height: 50px; width: 192px;">
                     <asp:Label ID="Label2" runat="server" Text="Form Tiltle : "></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="txtFormtitle" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>

             <tr><%--for validation lang to--%>
                <td style="width: 192px; height: 50px;">
                     <asp:Label ID="Label9" runat="server" Text="Revision number: "></asp:Label>
                </td>
                <td style="height: 50px">
                     <asp:TextBox ID="txtRevisionnum" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>

            <tr><%--for validation lang to--%>
                <td style="height: 54px">
                    <asp:Label ID="Label5" runat="server" Text="Select file for upload : "></asp:Label>
                </td>
                <td style="height: 54px">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="355px" Enabled="False" />
                </td>
            </tr>

            <tr><%--for validation lang to--%>
                <td style="height: 66px">

                    <asp:Label ID="lblFilename" runat="server" Text="Label" Visible="False"></asp:Label> <%--for validation lang to--%>
                    <br />
                    <br />
                    <%--for validation lang to--%>

                <td style="height: 66px; text-align: right;">
                     <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="127px" Enabled="False" />
                </td>
            </tr>


        </table>           
    </div>

</asp:Content>
