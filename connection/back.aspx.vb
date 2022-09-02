Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Net

Public Class back
    Inherits System.Web.UI.Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim query As String

        'Dim logoutdatentime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim logoutdatentime As String
        logoutdatentime = "0000-00-00 00:00:00"

        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

        query = ("UPDATE tblloginhistory SET applicableSpecs = '" & HttpContext.Current.Session(“appspecs”) & "', formControlnum = '" & HttpContext.Current.Session(“formctrlnum”) & "' , logoutDatentime = '" & logoutdatentime & "', docStatus = 'Inactive' WHERE empId = '" & HttpContext.Current.Session(“empId”) & "' AND logStatus = 'Login'")
        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = Command.ExecuteReader()
        reader.Read()

        reader.Close()
        connection.Close()

        HttpContext.Current.Session("documentStatus") = ""
        Response.Redirect("WebForm10.aspx")

    End Sub

End Class