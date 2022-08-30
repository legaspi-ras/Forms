Imports System.IO
Imports System.Net
Imports MySql.Data.MySqlClient

Public Class _Default
    Inherits Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ''call function Searchfile for loading data gridview

        If Not Me.IsPostBack Then
            Me.Searchfile()
        End If

    End Sub

    Private Sub Searchfile()
        ''function that loads all the file information in data gridview

        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        query = ("SELECT formControlnum, formTitle FROM tblform_masterlist")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()


        If reader.HasRows Then

            reader.Close()

            Using sda As New MySqlDataAdapter(command)
                Dim dt As New DataTable()
                sda.Fill(dt)
                gvfiles.DataSource = dt
                gvfiles.DataBind()
            End Using

        Else

            MsgBox("Sorry, I cant load the data because your database table named masterlist is empty.")

        End If

        reader.Close()
        connection.Close()

    End Sub

    Protected Sub OnPaging(sender As Object, e As GridViewPageEventArgs)
        '' displaying the other data in next page

        gvfiles.PageIndex = e.NewPageIndex
        Me.Searchfile()

    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

        '' search the file and display in datagridview based on the applicable specification 
        Dim query As String
        Dim frmsearch As String

        frmsearch = txtsearch.Value

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")


        query = ("SELECT * FROM tblform_masterlist WHERE formControlnum LIKE '" & frmsearch & "%' OR formTitle LIKE '" & frmsearch & "%' ")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then
            reader.Close()

            Using sda As New MySqlDataAdapter(command)
                Dim dt As New DataTable()
                sda.Fill(dt)
                gvfiles.DataSource = dt
                gvfiles.DataBind()
            End Using

        Else

            MsgBox("Sorry, the e-form that your looking for is not available.")

        End If

        reader.Close()
        connection.Close()

    End Sub

    Protected Sub gvfiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvfiles.SelectedIndexChanged

        ''getting the value of seleted index in grid view
        Dim formtitle As String = gvfiles.SelectedRow.Cells(1).Text
        Dim formcntrolnum As String = gvfiles.SelectedRow.Cells(0).Text

        Dim filename As String

        ''create a connection to database
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        'mysql query that select the file based on the formtitle and formctrlnum specifications
        Dim query As String
        query = ("select * from tblform_masterlist where  formTitle = '" & formtitle & "' and formControlnum = '" & formcntrolnum & "'")
        command = New MySqlCommand(query, connection)

        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then

            Dim bytes() As Byte

            bytes = DirectCast(reader(7), Byte())
            ContentType = reader(6).ToString()
            filename = reader(5).ToString()


            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ClearContent()
            Response.ClearHeaders()
            Response.ContentType = ContentType
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename)
            Response.TransmitFile("C:\Users\romer.legaspi\Desktop\pdf_files\pdf_forms\" + filename) 'ito yung pag download ng file 
            Response.BinaryWrite(bytes)
            Response.Flush()
            Response.Close()
            Response.End()

            connection.Close()

        Else

            MsgBox("Uh-oh, you got a missing pdf file.")

        End If

        reader.Close()
        connection.Close()

    End Sub

    'Protected Sub btnsearch1_Click(sender As Object, e As EventArgs) Handles btnsearch1.Click


    '    Dim query As String
    '    Dim empNum As String

    '    empNum = txtEmpnum.Value

    '    connection = New MySqlConnection
    '    connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

    '    query = ("SELECT EMP_NO, EMP_NAME, DEPARTMENT FROM emp_masterlist WHERE EMP_NO = '" & empNum & "'") '' REMINDER - BAGO MAG SAVE SA DATABASE IMPORTANTENG NAKA TRIM ANG MGA SPACES PARA WALANG PROBLEMA PAG NAG FETCH NA NG DATA FROM DATABASE

    '    command = New MySqlCommand(query, connection)
    '    connection.Open()

    '    Dim reader As MySqlDataReader
    '    reader = command.ExecuteReader()
    '    reader.Read()


    '    If reader.HasRows Then

    '        lblRequestor.Text = reader(1)
    '        lblRequestordept.Text = reader(2)


    '        reader.Close()
    '        connection.Close()

    '    Else
    '        MsgBox("Sorry, employee number doesn't exist.")
    '    End If

    'End Sub

    'Protected Sub btnDowload_Click(sender As Object, e As EventArgs) Handles btnDowload.Click

    '    '' save yung for approval na pdf sa for approval folder

    '    Dim savefilename As String
    '    '   savefilename = lblfilename.Text

    '    Dim directory As String
    '    Dim contentType As String
    '    '   contentType = lblContenttype.Text

    '    Dim pdfSavingStatus As String
    '    pdfSavingStatus = "failed"

    '    ' directory = "C:\Users\romer.legaspi\Desktop\sharing\pdf_files\" + savefilename '' gagawa ng validation para malaman kung tamang ang file name na kailangan i submit lalo na pag mga signatory na ang gagawa

    '    Dim copyFile As String
    '    Dim appspecs As String
    '    '  appspecs = txtasn.Value
    '    Dim filename As String
    '    filename = appspecs + ".pdf"
    '    '  copyFile = "C:\Users\romer.legaspi\Desktop\sharing\for_aproval\" + filename

    '    '  Label6.Text = directory for validation lang ito

    '    ' If contentType = "application/pdf" Then ''  <---- check kung PDF file ang document

    '    'If File.Exists(copyFile) Then '' <---- check kung may kapangalan ng file

    '    '' delete muna ang lumang file na guston paltan. --------------------------------

    '    '' File.Delete(copyFile)

    '    ''end of deleteing --------------------------------------------------------------

    '    '' start saving young edited file -----------------------------------------------

    '    ''  File.Copy(directory, copyFile)

    '    ''   Process.Start(copyFile)

    '    '   MsgBox("file already exist")
    '    pdfSavingStatus = "success"

    '    ' end -----  upload (saving) pdf file to mysql database

    '    '   Else ''  <---- if walang katulad na filename


    '    'File.Copy(directory, copyFile)

    '    ' MsgBox("New request has been posted.")
    '    '' Process.Start("C:\Users\romer.legaspi\Desktop\sharing\for_approval" + filename)
    '    System.Diagnostics.Process.Start("C:\Users\romer.legaspi\Desktop\sharing\pdf_files\" + "Employee Gate Pass.pdf")
    '    ''  Response.Redirect(Request.Url.AbsoluteUri)


    '    pdfSavingStatus = "success"

    '    '   End If

    '    ' save sa database tblapprovalrequest saka tblapprover -------------------------------------------------------------------------------

    '    'If pdfSavingStatus = "success" Then


    '    '        Dim deptarea As String
    '    '        Dim formctrlnum As String
    '    '        Dim frmtitle As String


    '    '        Dim requestor As String
    '    '        Dim reqdept As String
    '    '        Dim reqdate As String

    '    '        Dim approverstatus As String



    '    '        deptarea = lblDepartment.Text
    '    '        formctrlnum = lblFormctrlnum.Text
    '    '        frmtitle = lblFormtitle.Text
    '    '        appspecs = txtasn.Value

    '    '        If appspecs = "" Then

    '    '            appspecs = "NA"

    '    '        End If


    '    '        requestor = lblRequestor.Text
    '    '        reqdept = lblRequestordept.Text
    '    '        reqdate = Today.ToString("yyyy-MM-dd")
    '    '        approverstatus = "Pending"



    '    '        Dim query As String

    '    '        connection = New MySqlConnection
    '    '        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

    '    '        'tblapprovalrequest -------------------------------------------------------------------------------------------------------------

    '    '        query = ("INSERT INTO tblapprovalrequest (formControlnum, filename, applicableSpecs, requestorName, requestorDepartment, requestStatus, requestDate) VALUES ('" & formctrlnum & "', '" & filename & "', '" & appspecs & "', '" & requestor & "', '" & reqdept & "', '" & approverstatus & "', '" & reqdate & "')")

    '    '        command = New MySqlCommand(query, connection)

    '    '        Dim reader As MySqlDataReader
    '    '        connection.Open()

    '    '        reader = command.ExecuteReader()
    '    '        reader.Read()

    '    '        reader.Close()


    '    '    End If

    '    'Else
    '    '    '' git hub
    '    '    MsgBox("Please select the pdf file for upload.")

    '    'End If


    '    ' Response.Redirect(Request.Url.AbsoluteUri) '' refesh niya ang webform (ginamit ko para ma clear ang mga textboxes)
    '    '  connection.Close()

    'End Sub
End Class