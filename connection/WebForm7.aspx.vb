Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.IO
Imports MySql.Data.MySqlClient



Public Class WebForm7
    Inherits System.Web.UI.Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '' search the file and display in datagridview based on the applicable specification 
        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")


        query = ("SELECT * FROM tblLogin WHERE username = '" & txtUsername.Text & "' AND password = '" & txtPassword.Text & "'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()


        If reader.HasRows Then
            reader.Close()
            connection.Close()

            Dim logstatus As String
            Dim usernow As String

            query = ("SELECT * FROM tblloginhistory ORDER BY id DESC LIMIT 1")

            command = New MySqlCommand(query, connection)
            connection.Open()

            reader = command.ExecuteReader()
            reader.Read()

            logstatus = reader(3)
            usernow = reader(1)

            reader.Close()
            connection.Close()

            If logstatus = "Logout" Then

                Dim fullName As String
                Dim emailAddress As String
                Dim logindatentime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                fullName = txtFullname.Text
                emailAddress = txtEmailaddress.Text

                query = ("INSERT INTO tblloginhistory (empName, emailAddress, logstatus, loginDatenTime) VALUES  ('" & txtFullname.Text & "','" & txtEmailaddress.Text & "', 'Login' ,'" & logindatentime & "')")

                command = New MySqlCommand(query, connection)
                connection.Open()

                reader = command.ExecuteReader()
                reader.Read()

                reader.Close()
                connection.Close()

                MsgBox("proceed to next step")
                '' call niya na dito yung next window tab na for viewing for approval
                Response.Redirect("WebForm8.aspx")

            Else

                MsgBox("Sorry, " + usernow + " is current login and updating the file. Please wait for him to logout. Thank you and try again later. ")

            End If

        Else
            reader.Close()
            connection.Close()
            MsgBox("Invalid username or password")

        End If


    End Sub
End Class