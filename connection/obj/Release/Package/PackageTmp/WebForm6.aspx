<%@ Page Language="vb"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm6.aspx.vb" Inherits="connection.WebForm6" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       
       <br />

           <div class="container-fluid">
        <div class = "row">
            <div class ="col">

                <div class="card">
                 <div class="card-body">
                    <h5 class="card-title">Submission of request form for approval</h5>
                    <h6 class="card-subtitle mb-2 text-muted">Please provide the necesary information</h6>

                     <%-- insert dito yung body --%>

               <table>
                <tr>
                    <td >
                        <asp:Label ID="Label6" runat="server" Text="Requestor Employee number :"></asp:Label>
                    </td>
                    </tr>
                <tr>
                    <td>
                         <div class="input-group mb-3">
                        <%-- <asp:TextBox ID="txtEmpnum" runat="server"></asp:TextBox>--%>
                         <input type="text" id="txtEmpnum" runat="server"  class ="form-control" placeholder="" aria-label="Recipient's username" aria-describedby="button-addon2">
                         <asp:Button ID="btnsearch1" runat="server" Text="Search"  class="btn btn-outline-secondary" />
                    </div>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="Label1" runat="server" Text="Requestor Full Name :"></asp:Label>
                    </td>
                    </tr>
                <tr>
                    <td class="auto-style1" >
                        <asp:Label ID="lblRequestor" runat="server" Text=" - "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="Label11" runat="server" Text="Requestor Department :"></asp:Label>
                    </td>                   
                </tr>
                <tr>
                     <td class="auto-style1" >
                         <asp:Label ID="lblRequestordept" runat="server" Text=" - "></asp:Label>
                     </td>
                </tr>

            </table>

            <hr />

           <h6>  Search and attached the document needed for approval/s </h6>

            <hr />

            <table>
                <tr>
                     <td "><asp:Label ID="Label10" runat="server" Text="Form Control Number"></asp:Label></td>

                     <td>
                          <div class="input-group mb-3">
                         <%--<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>--%>
                         <input type="text" id="txtSearch" runat="server"  class ="form-control" placeholder="" aria-label="Recipient's username" aria-describedby="button-addon2">
                         <asp:Button ID="btnsearch2" runat="server" Text="Search"  class="btn btn-outline-secondary" />
                    </div>
                      
                      </td>

                </tr>
                <tr>
                    <td ><asp:Label ID="Label2" runat="server" Text="Department :"></asp:Label></td>
                    <td><asp:Label ID="lblDepartment" runat="server" Text="-"></asp:Label>
                    </td>
               </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Form Control Number :"></asp:Label></td>
                    <td><asp:Label ID="lblFormctrlnum" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="Form Title :"></asp:Label></td>
                    <td><asp:Label ID="lblFormtitle" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label5" runat="server" Text="Applicable Specifications :"></asp:Label></td>
                    <td><asp:TextBox ID="txtasn" runat="server" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                     <td><asp:Label ID="Label8" runat="server" Text="Select File for Upload : "></asp:Label></td>
                    <td><asp:FileUpload ID="FileUpload1" runat="server" Enabled="False"/></td>
                </tr>

                  <tr>
                     <td></td>
                    <td><br /> <asp:Button ID="btnUploadnSend" runat="server" class="btn btn-primary" Text="Submit eForm" Enabled="False" /> </td>
                </tr>
            </table>

          

                    </div>
                </div>

               </div>


        </div>


    </div>

   
</asp:Content>
