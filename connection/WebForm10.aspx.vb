Imports MySql.Data.MySqlClient

Public Class WebForm10
    Inherits System.Web.UI.Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Application("docstatus") = "active"

        lblEmpname.Text = HttpContext.Current.Session(“empname”)

        ''call function Searchfile for loading data gridview
        If Not Me.IsPostBack Then
            Me.Searchfile()
        End If

    End Sub

    Private Sub Searchfile()
        'function that loads all the file information in data gridview

        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

        query = ("SELECT tblform_masterlist.formTitle, tblapprovalrequest.formControlnum, tblapprovalrequest.filename, tblapprovalrequest.applicableSpecs ,tblapprovalrequest.requestorName, tblapprovalrequest.requestorDepartment,  tblapprovalrequest.requestStatus, tblapprovalrequest.requestDate, tblapprovalrequest.approvDate FROM tblform_masterlist INNER JOIN tblapprovalrequest ON tblform_masterlist.formControlnum = tblapprovalrequest.formControlnum;")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Try
            Using sda As New MySqlDataAdapter(command)
                Dim dt As New DataTable()
                sda.Fill(dt)
                GridView1.DataSource = dt
                GridView1.DataBind()
            End Using
        Catch ex As Exception
            'MsgBox("for update")
        End Try


        connection.Close()

    End Sub
    Protected Sub OnPaging(sender As Object, e As GridViewPageEventArgs)
        '' displaying the other data in next page

        GridView1.PageIndex = e.NewPageIndex
        Me.Searchfile()

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' search the file and display in datagridview based on the applicable specification 
        Dim query As String
        Dim search As String

        search = txtSearch.Value

        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")


        query = ("SELECT tblform_masterlist.formTitle, tblapprovalrequest.formControlnum, tblapprovalrequest.filename, tblapprovalrequest.applicableSpecs ,tblapprovalrequest.requestorName, tblapprovalrequest.requestorDepartment,  tblapprovalrequest.requestStatus, tblapprovalrequest.requestDate, tblapprovalrequest.approvDate FROM tblform_masterlist INNER JOIN tblapprovalrequest ON tblform_masterlist.formControlnum = tblapprovalrequest.formControlnum WHERE tblapprovalrequest.formControlnum = '" & search & "' OR tblapprovalrequest.applicableSpecs = '" & search & "'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Using sda As New MySqlDataAdapter(command)
            Dim dt As New DataTable()
            sda.Fill(dt)
            GridView1.DataSource = dt
            GridView1.DataBind()
        End Using

        connection.Close()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

        ''getting the value of seleted index in grid view
        Dim formtitle As String = GridView1.SelectedRow.Cells(0).Text
        '' Dim applicablespecs As String = GridView1.SelectedRow.Cells(1).Text '' sila na mag iinput ng applicable specs kaya d na ma uulit or same for the meantime sa filename muna tayo mag base for viewing lang naman

        Dim applicablespecs As String = GridView1.SelectedRow.Cells(2).Text
        Dim formctrlnum As String = GridView1.SelectedRow.Cells(1).Text '' affected lahat ng data gridview kasi ito yung nakalagay sa where clause sa mysql database FOR TESTING LANG TO 

        Dim filename As String

        ''create a connection to database
        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")


        ''MySql query that select the file based on the formtitle And applicable specifications
        Dim query As String
        query = ("SELECT tblform_masterlist.formTitle, tblapprovalrequest.formControlnum, tblapprovalrequest.filename, tblapprovalrequest.applicableSpecs ,tblapprovalrequest.requestorName, tblapprovalrequest.requestorDepartment,  tblapprovalrequest.requestStatus, tblapprovalrequest.requestDate, tblapprovalrequest.approvDate FROM tblform_masterlist INNER JOIN tblapprovalrequest ON tblform_masterlist.formControlnum = tblapprovalrequest.formControlnum WHERE tblapprovalrequest.formControlnum = '" & formctrlnum & "'")
        command = New MySqlCommand(query, connection)

        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        reader.Read()


        Dim kuha As String
        kuha = GridView1.PageIndex.ToString

        filename = reader(2) 'getting the filename of the form

        HttpContext.Current.Session(“requestor”) = GridView1.SelectedRow.Cells(3).Text
        HttpContext.Current.Session(“formdepartment”) = GridView1.SelectedRow.Cells(4).Text
        HttpContext.Current.Session(“formctrlnum”) = GridView1.SelectedRow.Cells(1).Text
        HttpContext.Current.Session(“formtitle”) = GridView1.SelectedRow.Cells(0).Text
        HttpContext.Current.Session(“appspecs”) = GridView1.SelectedRow.Cells(2).Text
        HttpContext.Current.Session(“filename”) = filename

        reader.Close()
        connection.Close()

        Response.Redirect("webrestric.aspx")

    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        empuser.Text = HttpContext.Current.Session(“empId”)

        Dim query As String
        Dim logstatus As String
        Dim usernow As String
        Dim empid As String

        empid = HttpContext.Current.Session(“empId”)

        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

        query = ("SELECT * FROM tblloginhistory WHERE empid ='" & empid & "' AND logstatus = 'Login'")

        command = New MySqlCommand(query, connection)
        connection.Open()
        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()

        logstatus = reader(2)
        usernow = reader(1)

        reader.Close()
        connection.Close()


        Dim logoutdatentime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")


        query = ("UPDATE tblloginhistory SET logstatus = 'Logout', applicableSpecs = '" & HttpContext.Current.Session(“appspecs”) & "', formControlnum = '" & HttpContext.Current.Session(“formctrlnum”) & "' , logoutDatentime = '" & logoutdatentime & "' WHERE empId = '" & empuser.Text & "' AND logStatus = 'Login'")


        command = New MySqlCommand(query, connection)
            connection.Open()

            reader = command.ExecuteReader()
            reader.Read()

            reader.Close()
            connection.Close()


        '' call niya na dito yung next window tab na for viewing for approval

        HttpContext.Current.Session.Remove(“empId”)
        Session.RemoveAll()
        Session.Clear()
        Session.Abandon()

        Response.Redirect("Login.aspx")



    End Sub
End Class