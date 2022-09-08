Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Net

Public Class webrestric
    Inherits System.Web.UI.Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' start restriction-----------------------------------------------------------------------

        Dim query As String
        Dim empid As String
        Dim appspecs As String
        Dim pdffilename As String
        Dim logstatus As String
        Dim docstatus As String


        appspecs = HttpContext.Current.Session(“appspecs”)
        ' empid = HttpContext.Current.Session(“empid”)

        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

        query = ("SELECT * FROM tblloginhistory WHERE logstatus = 'Login' AND applicableSpecs = '" & appspecs & "' AND docStatus = 'Active'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then

            empid = reader(1)
            pdffilename = reader(5)
            logstatus = reader(2)
            docstatus = reader(7)

            reader.Close()
            connection.Close()

            query = ("SELECT EMP_NAME FROM emp_masterlist where EMP_NO = '" & empid & "'")

            command = New MySqlCommand(query, connection)
            connection.Open()

            reader = command.ExecuteReader()
            reader.Read()

            Dim emp_fullname As String

            emp_fullname = reader(0)

            Label1.Text = emp_fullname

            reader.Close()
            connection.Close()

            If logstatus = "Login" And pdffilename = appspecs And docstatus = "Active" Then

                ' Response.Redirect("WebForm10.aspx")

            Else

                'update loginhistory - status -------------------------------------
                query = ("UPDATE tblloginhistory SET applicableSpecs = '" & HttpContext.Current.Session(“appspecs”) & "', formControlnum = '" & HttpContext.Current.Session(“formctrlnum”) & "', docStatus = 'Active' WHERE empId = '" & HttpContext.Current.Session(“empId”) & "' AND logStatus = 'Login'")

                command = New MySqlCommand(query, connection)
                connection.Open()

                reader = command.ExecuteReader()
                reader.Read()

                reader.Close()
                connection.Close()
                '        ' end update --------------------------------------------------------
                Response.Redirect("WebForm11.aspx")

            End If

        Else
            reader.Close()
            connection.Close()

            'update loginhistory - status -------------------------------------
            query = ("UPDATE tblloginhistory SET applicableSpecs = '" & HttpContext.Current.Session(“appspecs”) & "', formControlnum = '" & HttpContext.Current.Session(“formctrlnum”) & "', docStatus = 'Active' WHERE empId = '" & HttpContext.Current.Session(“empId”) & "' AND logStatus = 'Login'")

            command = New MySqlCommand(query, connection)
            connection.Open()

            reader = command.ExecuteReader()
            reader.Read()

            reader.Close()
            connection.Close()
            '        ' end update --------------------------------------------------------
            Response.Redirect("WebForm11.aspx")


        End If

        reader.Close()
        connection.Close()

        'End restriction ------------------------------

    End Sub

End Class