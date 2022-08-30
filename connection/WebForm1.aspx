<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="connection.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 148px;
        }
        .auto-style2 {
            height: 961px;
            margin-left: 662px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br />
        <br />
        <div class="auto-style1">
            <div class="auto-style2">
                <asp:GridView ID="GridView2" runat="server">
                    <Columns>
                        <asp:ButtonField CommandName="Select" Text="view" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="pdfName" HeaderText="pdfName" SortExpression="pdfName" />
                        <asp:BoundField DataField="specsNumber" HeaderText="specsNumber" SortExpression="specsNumber" />
                        <asp:BoundField DataField="revNumber" HeaderText="revNumber" SortExpression="revNumber" />
                        <asp:BoundField DataField="dateUpload" HeaderText="dateUpload" SortExpression="dateUpload" />
                        <asp:BoundField DataField="contentType" HeaderText="contentType" SortExpression="contentType" />
                        <asp:ButtonField CommandName="Select" Text="download" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <br />
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <br />
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" Text="Button" />
                <br />
                <br />
                <br />
            </div>
        </div>
        <br />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="pdfName" HeaderText="pdfName" SortExpression="pdfName" />
                <asp:BoundField DataField="specsNumber" HeaderText="specsNumber" SortExpression="specsNumber" />
                <asp:BoundField DataField="revNumber" HeaderText="revNumber" SortExpression="revNumber" />
                <asp:BoundField DataField="dateUpload" HeaderText="dateUpload" SortExpression="dateUpload" />
                <asp:BoundField DataField="contentType" HeaderText="contentType" SortExpression="contentType" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eformsConnectionString %>" ProviderName="<%$ ConnectionStrings:eformsConnectionString.ProviderName %>" SelectCommand="SELECT * FROM tblpdfdata"></asp:SqlDataSource>
        <div>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />

            <br />
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" Width="144px" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="connect" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </div>
        <div style="height: 14px">
        </div>
        <div style="height: 191px">
            <asp:Button ID="btnOpen" runat="server" Text="1st way" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnpdf" runat="server" Text="2nd way" />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
            <br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
