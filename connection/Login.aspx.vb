Imports System.IO
Imports System.Web
Imports MySql.Data.MySqlClient

Public Class Login
    Inherits System.Web.UI.Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        '' search the file and display in datagridview based on the applicable specification 
        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        Dim username As String
        Dim password As String

        username = txtusername.Value
        password = txtpassword.Value


        query = ("SELECT * FROM tblLogin WHERE username = '" & username & "' AND password = '" & password & "'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = Command.ExecuteReader()
        reader.Read()

        Dim userType As String
        userType = reader(3)

        If reader.HasRows Then
            reader.Close()
            connection.Close()

            Select Case userType

                Case "approver"

                    Dim logindatentime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")


                        query = ("INSERT INTO tblloginhistory (empId, logstatus, loginDatenTime) VALUES  ('" & username & "', 'Login' ,'" & logindatentime & "')")


                        command = New MySqlCommand(query, connection)
                        connection.Open()

                        reader = command.ExecuteReader()
                        reader.Read()

                        reader.Close()
                        connection.Close()


                        query = ("SELECT EMP_NO, EMP_NAME, DEPARTMENT, emp_email FROM emp_masterlist WHERE EMP_NO = '" & username & "'")

                        command = New MySqlCommand(query, connection)
                        connection.Open()

                        reader = command.ExecuteReader()
                        reader.Read()

                        If reader.HasRows Then

                            HttpContext.Current.Session(“empname”) = reader(1)
                            HttpContext.Current.Session(“department”) = reader(2)
                            HttpContext.Current.Session(“empemail”) = reader(3)

                            reader.Close()
                            connection.Close()

                        End If

                        '' call niya na dito yung next window tab na for viewing for approval
                        HttpContext.Current.Session(“empId”) = username
                        Response.Redirect("WebForm10.aspx")


                        Case "editor"

                    Response.Redirect("DIC.aspx")

            End Select



        Else
            reader.Close()
            connection.Close()
            MsgBox("Invalid username or password")

        End If

    End Sub
End Class