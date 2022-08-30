<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="connection.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>e-Form Login</title>

     <%--bootstrap css--%>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
      <%--datatables css--%>
    <link href="datatables/css/jquery.dataTables.min.css" rel="stylesheet" />
      <%--fontawesome css--%>
    <link href="fontawesome/css/all.css" rel="stylesheet" />
      <%--jquery--%>
     <script src="bootstrap/js/bootstrap.bundle.min.js"></script>
      <%--popper js--%>
    <script src="bootstrap/js/popper.min.js"></script>
      <%--bootstrap js--%>
    <script src="bootstrap/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
      <div class="position-absolute top-50 start-50 translate-middle">



         <div class="card text-center" style="width: 20rem;" >
           
                <div class="card-body">

                    <img src="imgs/dcc_logo.png" class="rounded" width="200" height="100"/>

                    <h4 class="card-title">e-Forms - Login</h4>
                    
                          <div class="form-floating mb-3">
                            <input id="txtusername" runat="server" type="text" class="form-control"  placeholder="username"/>
                            <label for="txtusername">Username</label>
                          </div>

                          <div class="form-floating">
                            <input id ="txtpassword" runat="server" type="password" class="form-control" placeholder="Password"/>
                            <label for="txtpassword">Password</label>
                          </div>
                    
                    <br />

                    <asp:Button ID="btnLogin" runat="server" class="btn btn-primary" Text="Login" />
                    <br /><br />
                    <a href="Default.aspx" class="link-primary"> go to view e-forms website </a>
                </div>
            
             
</div>

    </div>
    </form>
</body>
</html>
