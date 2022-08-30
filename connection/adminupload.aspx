<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/DIC.Master" CodeBehind="adminupload.aspx.vb" Inherits="connection.adminupload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <br />
    <script type="text/javascript">
        function Set1() {
            document.forms[0].target = "_self";
        }
    </script>
       <asp:Button class="btn btn-primary" ID="btnLogout" OnClick="btnLogout_Click" OnClientClick="Set1();" runat="server" Text="Logout" Width="89px" />
    <br /> <br />
             <div class ="col">

                <div class="card" >
                    <div class="card-body">
                        <table>
                            <tr>
                                <td>
                                    <h5 class="card-title">Update e-Form</h5> 
                                </td>
                                <td>
                                         
                                    &nbsp;&nbsp; &nbsp;

                                </td>
                                 <td>
                                                                                     <script type="text/javascript">
                                                                                         function SetTarget() {
                                                                                             document.forms[0].target = "_blank";                                                                                        
                                                                                         }
                                                                                     </script>
                                    <asp:Button ID="btnview" runat="server" OnClick="btnview_Click" OnClientClick="SetTarget();" class="btn btn-primary" Text="View" Enabled="True" />
                                </td>
                                <td>
                                    <asp:Button ID="btndownload" runat="server" class="btn btn-primary" Text="Download" Enabled="True" />
                                </td>
                            </tr>
                        </table>
                        
                         <hr />

                        <table>

                     <tr>
                    <td><asp:Label ID="Label6" runat="server" Text="Request Status:"></asp:Label>
                    </td>
                         <td>
                             &nbsp;&nbsp;&nbsp;
                         </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-outline-primary">
                            <asp:ListItem>MIS</asp:ListItem>
                             <asp:ListItem>Security</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                         <td>

                             &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
                             &nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" OnClientClick="Set1();" class="btn btn-primary" Text="Update" />
                    </td>
                </tr>
                         
                        </table>
                           <hr />
                        <h6 class="card-subtitle mb-2 text-muted">Originator Details</h6>                       

             <table>

                <tr>
                    <td >
                        <asp:Label ID="Label1" runat="server" Text="Requestor Full Name :"></asp:Label>
                    </td>
                    <td class="auto-style1" >
                        <asp:Label ID="lblRequestor" runat="server" Text=" - "></asp:Label>
                    </td>
                    </tr>
                <tr>
                    <td >
                        <asp:Label ID="Label11" runat="server" Text="Requestor Department :"></asp:Label>
                    </td>   
                         <td class="auto-style1" >
                         <asp:Label ID="lblRequestordept" runat="server" Text=" - "></asp:Label>
                     </td>
                </tr>
                
            </table>

 <hr />
                         <h6 class="card-subtitle mb-2 text-muted">e-Forms Details
                             <asp:Label ID="lblfilename" runat="server" Text="Label" Visible="False"></asp:Label>
                             <asp:Label ID="lblContenttype" runat="server" Text="Label" Visible="False"></asp:Label>
                        </h6>
                      
                <table>
               
                <tr>
                    <td ><asp:Label ID="Label2" runat="server" Text="Department :"></asp:Label></td>
                    <td><asp:Label ID="lblFormdept" runat="server" Text="-"></asp:Label>
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
                    <td><asp:Label ID="Label5" runat="server" Text="Applicable Specifications :"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="txtasn" runat="server" Enabled="True"></asp:TextBox>--%>
                        <asp:Label ID="lblAppsspecs" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                
            </table>
                
                    </div>
                </div>

           </div>


</asp:Content>
