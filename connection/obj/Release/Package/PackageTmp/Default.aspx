<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="connection._Default" %>


        <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            
            <br />

           <div class="container-fluid">
        <div class = "row">
            <div class ="col">

                <div class="card">
                 <div class="card-body">
                    <h5 class="card-title">List of e-forms</h5>
                    <h6 class="card-subtitle mb-2 text-muted">Search the e-form your looking for</h6>
     
                     <div class="input-group mb-3">
                        <%-- <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>--%>
                       <%-- <button class="btn btn-outline-secondary" type="button" id="button-addon2">Button</button>--%>
                         <input type="text" id="txtsearch" runat="server"  class ="form-control" placeholder="" aria-label="Recipient's username" aria-describedby="button-addon2">
                         <asp:Button ID="btnsearch" runat="server" Text="Search"  class="btn btn-outline-secondary" />
                    </div>

                     <asp:GridView ID="gvfiles" class="table table-bordered table-condensed table-responsive table-hover " runat="server"  AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPaging" PageSize="4">
                         <Columns>
                             <asp:BoundField HeaderText="Form Control Number" DataField="formControlnum" SortExpression="formControlnum" />
                             <asp:BoundField HeaderText="Form Title" DataField="formTitle" SortExpression="formTitle" />
                             <asp:TemplateField HeaderText="Action">
                                 <ItemTemplate>
                                     <asp:Button ID="Button1" runat="server" class="btn btn-primary" CausesValidation="false" CommandName="Select" Text="Select" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>

                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eformsConnectionString %>" ProviderName="<%$ ConnectionStrings:eformsConnectionString.ProviderName %>" SelectCommand="SELECT formControlnum, formTitle FROM tblform_masterlist"></asp:SqlDataSource>

                    </div>
                </div>

               </div>

           <div class ="col">

                <div class="card" >
                    <div class="card-body">
                        <h5 class="card-title">Download e-Form</h5>        
                        <h6 class="card-subtitle mb-2 text-muted">e-Form Details</h6>
                      
                <table>
               
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
                    <td><asp:Label ID="Label5" runat="server" Text="Applicable Specifications :"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="txtasn" runat="server" Enabled="True"></asp:TextBox>--%>
                        <input type="text" id="txtasn" runat="server"  class ="form-control" placeholder=""  aria-label="Recipient's username" >
                    </td>
                    
                </tr>
            </table>
                
                        <hr />
                         <h6 class="card-subtitle mb-2 text-muted">Originator Details<asp:Label ID="lblfilename" runat="server" Text="Label" Visible="False"></asp:Label>
                             <asp:Label ID="lblContenttype" runat="server" Text="Label" Visible="False"></asp:Label>
                        </h6>

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
                 <tr>
                     <td></td>
                    <td><asp:Button ID="btnDowload" runat="server" class="btn btn-primary" Text="Download e-Form" Enabled="False" /> </td>
                </tr>

            </table>

                          <asp:HyperLink ID="HyperLink1" runat="server">Please fillup all the Information before you download</asp:HyperLink> 

                    </div>
                </div>

           </div>

        </div>


    </div>


</asp:Content>
