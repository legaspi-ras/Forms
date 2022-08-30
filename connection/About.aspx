<%@ Page Title="About" Language="VB" MasterPageFile="~/DIC.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="connection.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script language=javascript>

   function UcaseTxt(UpCstr) {
      var UCStr = UpCstr.value;
      UpCstr.value = UCStr.toUpperCase();
   }
    </script>

    <h2>Add New e-Form</h2>
   
    <div style="height: 891px; width: 1270px">
        <br />
        <br />
        <table style="width: 54%; height: 457px; margin-top: 0px; ">
            
            <tr><%--applicable specifications field--%>
                <td style="width: 312px; height: 50px;">
                     <asp:Label ID="Label1" runat="server" Text="Department Area: "></asp:Label>
                </td>
                <td style="height: 50px; width: 422px;">
                     <%--revision number/letter field--%>
                     <asp:DropDownList ID="ddlDepartment" runat="server" DataSourceID="SqlDataSource2" DataTextField="DEPARTMENT" DataValueField="DEPARTMENT" Height="25px" ToolTip="Please select depeartment" Width="431px">
                     </asp:DropDownList>
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:eformsConnectionString2 %>" ProviderName="<%$ ConnectionStrings:eformsConnectionString2.ProviderName %>" SelectCommand="SELECT DISTINCT DEPARTMENT FROM emp_masterlist"></asp:SqlDataSource>
                </td>
            </tr>

            <tr><%--revision number/letter field--%>
                <td style="width: 312px; height: 50px;">
                     <asp:Label ID="Label8" runat="server" Text="Form Control Number : "></asp:Label>
                </td>
                <td style="height: 50px; width: 422px;">
                     <asp:TextBox ID="txtFormctrlnum" runat="server" onkeyup="UcaseTxt(this)" Width="431px" ToolTip="Please avoid using spaces"></asp:TextBox>
                </td>
            </tr>

            <tr><%--for validation lang to--%>
                <td style="height: 50px; width: 312px;">
                     <asp:Label ID="Label2" runat="server" Text="Form Tiltle : "></asp:Label>
                </td>
                <td style="height: 50px; width: 422px;">
                    <asp:TextBox ID="txtFormtitle" runat="server" Width="431px"></asp:TextBox>
                </td>
            </tr>

                        <tr><%--for validation lang to--%>
                <td style="height: 50px; width: 312px;">
                     <asp:Label ID="Label3" runat="server" Text="Revision Number : "></asp:Label>
                </td>
                <td style="height: 50px; width: 422px;">
                    <asp:TextBox ID="txtRevnum" runat="server" Width="431px" ToolTip="Use capital letters if necessary"></asp:TextBox>
                </td>
            </tr>

            <tr><%--for validation lang to--%>
                <td style="height: 54px; width: 312px;">
                    <asp:Label ID="Label5" runat="server" Text="Select file for upload : "></asp:Label>
                </td>
                <td style="height: 54px; width: 422px;">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="448px" ToolTip="Please select PDF files only." />
                </td>
            </tr>

            <tr><%--for validation lang to--%>
                <td style="height: 66px; width: 312px;">

                    <%--for validation lang to--%>
                    <br />
                    <br />
                    <%--for validation lang to--%>

                <td style="height: 66px; text-align: right; width: 422px;">
                     <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="127px" />
                </td>
            </tr>


        </table>
    </div>
</asp:Content>
