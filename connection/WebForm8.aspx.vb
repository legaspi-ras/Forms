Imports System.IO
Imports System.Net
Imports MySql.Data.MySqlClient

Public Class WebForm8
    Inherits System.Web.UI.Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''call function Searchfile for loading data gridview
        If Not Me.IsPostBack Then
            Me.Searchfile()
        End If

    End Sub

    Private Sub Searchfile()
        'function that loads all the file information in data gridview

        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

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
            MsgBox("for update")
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
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")


        query = ("SELECT tblform_masterlist.formTitle, tblapprovalrequest.formControlnum, tblapprovalrequest.filename, tblapprovalrequest.applicableSpecs ,tblapprovalrequest.requestorName, tblapprovalrequest.requestorDepartment,  tblapprovalrequest.requestStatus, tblapprovalrequest.requestDate, tblapprovalrequest.approvDate FROM tblform_masterlist INNER JOIN tblapprovalrequest ON tblform_masterlist.formControlnum = tblapprovalrequest.formControlnum WHERE tblapprovalrequest.formControlnum = '" & search & "' OR tblapprovalrequest.appplicableSpecs = '" & search & "'")

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
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")


        ''MySql query that select the file based on the formtitle And applicable specifications
        Dim query As String
        query = ("SELECT tblform_masterlist.formTitle, tblapprovalrequest.formControlnum, tblapprovalrequest.filename, tblapprovalrequest.applicableSpecs ,tblapprovalrequest.requestorName, tblapprovalrequest.requestorDepartment,  tblapprovalrequest.requestStatus, tblapprovalrequest.requestDate, tblapprovalrequest.approvDate FROM tblform_masterlist INNER JOIN tblapprovalrequest ON tblform_masterlist.formControlnum = tblapprovalrequest.formControlnum WHERE tblapprovalrequest.formControlnum = '" & formctrlnum & "' AND tblapprovalrequest.applicableSpecs = '" & applicablespecs & "'")
        command = New MySqlCommand(query, connection)

        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        reader.Read()

        Dim kuha As String
        kuha = GridView1.PageIndex.ToString

        filename = reader(2) 'getting the filename of the form

        ''open din pdf kaso napapatungan si system-----------------------------------------------------------------------------------------

        Dim path As String = "C:\Users\romer.legaspi\Desktop\pdf_files\pdf_file_for_approval\" + filename
        Dim client As New WebClient()
        Dim buffer As [Byte]() = client.DownloadData(path)

        If buffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", buffer.Length.ToString())
            Response.BinaryWrite(buffer)
            Response.End()

        End If

        reader.Close()
        connection.Close()

    End Sub

End Class