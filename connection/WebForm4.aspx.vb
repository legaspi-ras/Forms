Imports System.IO
Imports System.Net
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class WebForm4
    Inherits System.Web.UI.Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' pag nag search tapos nag select nabalik sa umpisa
        'Dim query As String

        'connection = New MySqlConnection
        'connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        'query = ("SELECT * FROM tblmasterlist")

        'command = New MySqlCommand(query, connection)
        'connection.Open()

        'Using sda As New MySqlDataAdapter(command)
        '    Dim dt As New DataTable()
        '    sda.Fill(dt)
        '    gvCustomers.DataSource = dt
        '    gvCustomers.DataBind()
        'End Using

        'connection.Close()

        If Not Me.IsPostBack Then
            Me.Searchfile()
        End If

    End Sub

    Private Sub Searchfile()

        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        query = ("SELECT * FROM tblmasterlist")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Using sda As New MySqlDataAdapter(command)
            Dim dt As New DataTable()
            sda.Fill(dt)
            gvCustomers.DataSource = dt
            gvCustomers.DataBind()
        End Using

        connection.Close()

    End Sub

    Protected Sub OnPaging(sender As Object, e As GridViewPageEventArgs)
        gvCustomers.PageIndex = e.NewPageIndex
        Me.Searchfile()
    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        '' revisionNum field ginamit kong reference dahil mali yung sa add ko sa database saka ko nalang babaguhin pag ok na dami kasing type aahahahahaha
        query = ("SELECT * FROM tblmasterlist WHERE revisionNum LIKE '" & txtsearch.Text & "%'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Using sda As New MySqlDataAdapter(command)
            Dim dt As New DataTable()
            sda.Fill(dt)
            gvCustomers.DataSource = dt
            gvCustomers.DataBind()
        End Using

        connection.Close()
    End Sub

    Protected Sub gvCustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCustomers.SelectedIndexChanged


        Dim formtitle As String = gvCustomers.SelectedRow.Cells(2).Text           'getting the value of seleted index in grid view
        Dim applicablespecs As String = gvCustomers.SelectedRow.Cells(4).Text       ' mali din display nito ha aadjust naman pag new entries na ulit dapat cell(3) 

        Dim filename As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        Dim query As String 'getting the full details of the selected form
        query = ("select * from tblmasterlist where  formTitle = '" & formtitle & "' and revisionNum = '" & applicablespecs & "'") '' yung revisionNum papalitan din ng applicableSpecs dahil mali lang yung sa add ko kanina 
        command = New MySqlCommand(query, connection)

        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        reader.Read()

        Dim kuha As String
        kuha = gvCustomers.PageIndex.ToString

        Label1.Text = formtitle + " " + applicablespecs
        Label2.Text = kuha
        ''  CustomersGridView.PageIndex = pageList.SelectedIndex

        filename = reader(7) 'getting the filename of the form

        'open pdf in same page ------------------------------------------------------------------------------------------------------------
        Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""700px"" height=""700px""> </object>"
        HyperLink1.Text = String.Format(embed, ResolveUrl("~/pdf_files/" + filename + ""))

        reader.Close()
        connection.Close()

    End Sub
End Class