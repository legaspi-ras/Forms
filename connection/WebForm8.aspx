<%@ Page Language="vb"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm8.aspx.vb" Inherits="connection.WebForm8" %>


 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


               <br />

           <div class="container-fluid">
        <div class = "row">
            <div class ="col">

                <div class="card">
                 <div class="card-body">
                    <h5 class="card-title">List of request for Approval</h5>
                    <h6 class="card-subtitle mb-2 text-muted">Search the request your looking for</h6>
     
                     <div class="input-group mb-3">
                         <%-- insert textbox here --%>
                        <%-- <asp:TextBox ID="txtSearch" runat="server" ></asp:TextBox>--%>
                         <input type="text" id="txtSearch" runat="server"  class ="form-control" placeholder="" aria-label="Recipient's username" aria-describedby="button-addon2">
                         <asp:Button ID="Button1" runat="server" Text="Search"  class="btn btn-outline-secondary" />
                    </div>

                    <%-- grid view and data source here --%>

                     <asp:GridView ID="GridView1"  class="table table-bordered table-condensed table-responsive table-hover " runat="server"  AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPaging">
                <Columns>
                    <asp:BoundField DataField="formTitle" HeaderText="Form Title" SortExpression="formTitle" />
                    <asp:BoundField DataField="formControlnum" HeaderText="Form Control Number" SortExpression="formControlnum" />
                    <asp:BoundField DataField="applicableSpecs" HeaderText="Applicable Specification" SortExpression="applicableSpecs" />
                    <asp:BoundField DataField="requestorName" HeaderText="Originator" SortExpression="requestorName" />
                    <asp:BoundField DataField="requestorDepartment" HeaderText="Department" SortExpression="requestorDepartment" />
                    <asp:BoundField DataField="requestStatus" HeaderText="Status" SortExpression="requestStatus" />
                    <asp:BoundField DataField="requestDate" DataFormatString="&quot;{0:d}&quot;" HeaderText="Request Date" SortExpression="requestDate" />
                    <asp:BoundField DataField="approvDate" DataFormatString="&quot;{0:d}&quot;" HeaderText="Approve Date" SortExpression="approvDate" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>

                                <script type="text/javascript">
                                      function SetTarget() {
                                          document.forms[0].target = "_blank";
                                         }
                                </script>

                            <asp:Button ID="Button1" runat="server" class="btn btn-primary" CausesValidation="false" OnClientClick="SetTarget();" CommandName="Select" Text="View" />

                        
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:eformsConnectionString %>" ProviderName="<%$ ConnectionStrings:eformsConnectionString.ProviderName %>" SelectCommand="SELECT tblform_masterlist.formTitle, tblapprovalrequest.formControlnum, tblapprovalrequest.filename, tblapprovalrequest.applicableSpecs, tblapprovalrequest.requestorName, tblapprovalrequest.requestorDepartment, tblapprovalrequest.requestStatus, tblapprovalrequest.requestDate FROM tblform_masterlist INNER JOIN tblapprovalrequest ON tblform_masterlist.formControlnum = tblapprovalrequest.formControlnum"></asp:SqlDataSource>
            

                    </div>
                </div>

               </div>

        </div>


    </div>

</asp:Content>
