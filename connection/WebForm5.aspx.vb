Imports System.IO
Imports System.Net
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration


Public Class WebForm5
    Inherits System.Web.UI.Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        query = ("SELECT * FROM tblmasterlist")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Using sda As New MySqlDataAdapter(command)
            Dim dt As New DataTable()
            sda.Fill(dt)
            gvFiles.DataSource = dt
            gvFiles.DataBind()
        End Using

        connection.Close()

    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function GetPDF(ByVal fileId As Integer) As Object
        Dim connection As MySqlConnection
        Dim command As MySqlCommand

        Dim bytes As Byte()
        Dim fileName As String, contentType As String

        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        query = ("SELECT * FROM tblmasterlist WHERE applicableSpecs = @id")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()

        fileName = reader(7)
        contentType = reader(8)
        bytes = reader(9)
        connection.Close()

        Return New With {.FileName = fileName, .ContentType = contentType, .Data = bytes}


    End Function

    Protected Sub Upload(sender As Object, e As EventArgs) Handles btnUpload.Click

        Dim filename As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
        Dim contentType As String = FileUpload1.PostedFile.ContentType




        Response.Redirect(Request.Url.AbsoluteUri)

    End Sub
End Class