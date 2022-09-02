<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="webrestric.aspx.vb" Inherits="connection.webrestric" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

      <%--bootstrap css--%>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
      <%--datatables css--%>
    <link href="datatables/css/jquery.dataTables.min.css" rel="stylesheet" />
      <%--fontawesome css--%>
    <link href="fontawesome/css/all.css" rel="stylesheet" />
      <%--popper js--%>
    <script src="bootstrap/js/popper.min.js"></script>
     <%--jquery--%>
     <script src="bootstrap/js/bootstrap.bundle.min.js"></script>
      <%--bootstrap js--%>
    <script src="bootstrap/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>

        

        </div>
        <asp:Label ID="Label1" runat="server" Text="sorry some one is using the file."></asp:Label>
    </form>
</body>
</html>
