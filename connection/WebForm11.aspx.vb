Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Net
Public Class WebForm11
    Inherits System.Web.UI.Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        ' start restriction-----------------------------------------------------------------------

        'Dim query As String
        'Dim empid As String
        'Dim appspecs As String
        'Dim pdffilename As String
        'Dim docstatus As String


        'appspecs = HttpContext.Current.Session(“appspecs”)
        'empid = HttpContext.Current.Session(“empid”)

        'connection = New MySqlConnection
        'connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

        'query = ("SELECT * FROM tblloginhistory WHERE empId = '" & empid & "' AND logstatus = 'Login'")

        'command = New MySqlCommand(query, connection)
        'connection.Open()

        'Dim reader As MySqlDataReader
        'reader = command.ExecuteReader()
        'reader.Read()

        'pdffilename = reader(5)
        'docstatus = reader(2)

        'If reader.HasRows Then

        '    reader.Close()
        '    connection.Close()

        '    If docstatus = "Login" And pdffilename = appspecs Then

        '        Response.Write("<script> alert(" & "sorry someone is using the file" & ")")
        '        Response.Redirect("WebForm10.aspx")

        '    Else
        '        Response.Write("<script> alert(" & "sorry someone is using the file" & ") <script>")
        '        'update loginhistory - status -------------------------------------
        '        query = ("UPDATE tblloginhistory SET applicableSpecs = '" & HttpContext.Current.Session(“appspecs”) & "', formControlnum = '" & HttpContext.Current.Session(“formctrlnum”) & "' WHERE empId = '" & HttpContext.Current.Session(“empId”) & "' AND logStatus = 'Login'")

        '        command = New MySqlCommand(query, connection)
        '        connection.Open()

        '        reader = command.ExecuteReader()
        '        reader.Read()

        '        reader.Close()
        '        connection.Close()
        '        ' end update --------------------------------------------------------

        lblRequestor.Text = HttpContext.Current.Session(“requestor”)
        lblFormctrlnum.Text = HttpContext.Current.Session(“formctrlnum”)
        lblFormtitle.Text = HttpContext.Current.Session(“formtitle”)
        lblAppsspecs.Text = HttpContext.Current.Session(“appspecs”)
        lblFormdept.Text = HttpContext.Current.Session(“formdepartment”)

        '    End If
        '    '    'update loginhistory - status -------------------------------------
        '    '    query = ("UPDATE tblloginhistory SET applicableSpecs = '" & HttpContext.Current.Session(“appspecs”) & "', formControlnum = '" & HttpContext.Current.Session(“formctrlnum”) & "' WHERE empId = '" & HttpContext.Current.Session(“empId”) & "' AND logStatus = 'Login'")

        '    '    command = New MySqlCommand(query, connection)
        '    '    connection.Open()

        '    '    reader = command.ExecuteReader()
        '    '    reader.Read()

        '    '    reader.Close()
        '    '    connection.Close()
        '    '    ' end update --------------------------------------------------------

        '    '    lblRequestor.Text = HttpContext.Current.Session(“requestor”)
        '    '    lblFormctrlnum.Text = HttpContext.Current.Session(“formctrlnum”)
        '    '    lblFormtitle.Text = HttpContext.Current.Session(“formtitle”)
        '    '    lblAppsspecs.Text = HttpContext.Current.Session(“appspecs”)
        '    '    lblFormdept.Text = HttpContext.Current.Session(“formdepartment”)
        'Else
        '    reader.Close()
        '    connection.Close()
        '    Response.Redirect("WebForm10.aspx")

        'End If

        'reader.Close()
        'connection.Close()

        ' end restriction ------------------------------

        'If HttpContext.Current.Session("documentStatus") = "Active" Then

        '    ' MsgBox("Sorry. The document is currently updating by the other approver. Try again later.")
        '    Response.Redirect("WebForm10.aspx")

        'Else
        '    HttpContext.Current.Session("documentStatus") = "Active"

        '    'Dim query As String
        '    'Dim search As String

        '    'search = lblRequestor.Text

        '    'connection = New MySqlConnection
        '    'connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")


        '    'query = ("SELECT EMP_NAME, DEPARTMENT FROM emp_masterlist WHERE EMP_NO = '" & HttpContext.Current.Session(“empId”) & "'") '' approver side na tayo kaya yung yung empId ay kay approver

        '    'command = New MySqlCommand(query, connection)
        '    'connection.Open()

        '    'Dim reader As MySqlDataReader
        '    'reader = command.ExecuteReader()
        '    'reader.Read()

        '    'Dim empdept As String

        '    'empdept = reader(1)

        '    'reader.Close()
        '    'connection.Close()

        '    lblRequestor.Text = HttpContext.Current.Session(“requestor”)
        '    'lblRequestordept.Text = empdept 'baka tanggalin na to dahil hindi naman kailangan
        '    lblFormctrlnum.Text = HttpContext.Current.Session(“formctrlnum”)
        '    lblFormtitle.Text = HttpContext.Current.Session(“formtitle”)
        '    lblAppsspecs.Text = HttpContext.Current.Session(“appspecs”)
        '    lblFormdept.Text = HttpContext.Current.Session(“formdepartment”)

        '    ' btnupdate.Enabled = False


        'End If


    End Sub

    Protected Sub btndownload_Click(sender As Object, e As EventArgs) Handles btndownload.Click

        btnupdate.Enabled = True

        Dim filename As String

        filename = HttpContext.Current.Session(“filename”)

        ContentType = "application/pdf"

        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ClearContent()
        Response.ClearHeaders()
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename)
        Response.TransmitFile("D:\Forms\Approval\" + filename)
        Response.Flush()
        Response.Close()
        Response.End()


    End Sub

    Protected Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click


        If FileUpload1.HasFile Then
            HttpContext.Current.Session("documentStatus") = "Inactive"
            ' update/replace yung file sa approval folder
            Dim savefilename As String
            savefilename = Path.GetFileName(FileUpload1.FileName)

            Dim directory As String
            Dim contentType As String
            contentType = FileUpload1.PostedFile.ContentType

            Dim pdfSavingStatus As String
            pdfSavingStatus = "failed"

            directory = ("D:\Forms\Approval\" + savefilename) ' gagawa ng validation para malaman kung tamang ang file name na kailangan i submit lalo na pag mga signatory na ang gagawa


            If contentType = "application/pdf" Then '  <---- check kung PDF file ang document

                If File.Exists(directory) Then ' <---- check yung file

                    ' delete muna ang lumang file na guston paltan. --------------------------------

                    File.Delete(directory)

                    'end of deleteing --------------------------------------------------------------

                    ' start saving young edited file -----------------------------------------------

                    Using fs As Stream = FileUpload1.PostedFile.InputStream

                        ' save niya sa folder na for approval 
                        FileUpload1.SaveAs("D:\Forms\Approval\" + savefilename)

                    End Using

                    Dim query As String

                    connection = New MySqlConnection
                    connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

                    query = ("UPDATE tblapprovalrequest SET requestStatus = '" & DropDownList1.SelectedItem.Value & "' WHERE applicableSpecs = '" & lblAppsspecs.Text & "'")

                    command = New MySqlCommand(query, connection)
                    connection.Open()

                    Dim reader As MySqlDataReader
                    reader = command.ExecuteReader()
                    reader.Read()

                    reader.Close()
                    connection.Close()

                    lblalert.Visible = True
                    '' condition kapag nag approve ang value ni dropdownlsit

                    If DropDownList1.SelectedItem.Value = "Approve" Then

                        Dim approvdate As String
                        approvdate = Today.ToString("yyyy-MM-dd")

                        connection = New MySqlConnection
                        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

                        query = ("UPDATE tblapprovalrequest SET requestStatus = '" & DropDownList1.SelectedItem.Value & "', approvDate = '" & approvdate & "' WHERE applicableSpecs = '" & lblAppsspecs.Text & "'")

                        command = New MySqlCommand(query, connection)
                        connection.Open()

                        reader = command.ExecuteReader()
                        reader.Read()

                        reader.Close()
                        connection.Close()

                    End If

                    ' end -----  upload (saving) pdf file to mysql database

                End If

            End If
            ' save sa database tblapprovalrequest saka tblapprover -------------------------------------------------------------------------------
        Else
            'pwede tong function na to pag hindi na sila mag susubmit ng changes. kung baga reject na agad.

            HttpContext.Current.Session("documentStatus") = "Inactive"

            Dim query As String

            connection = New MySqlConnection
            connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

            query = ("UPDATE tblapprovalrequest SET requestStatus = '" & DropDownList1.SelectedItem.Value & "' WHERE applicableSpecs = '" & lblAppsspecs.Text & "'")

            command = New MySqlCommand(query, connection)
            connection.Open()

            Dim reader As MySqlDataReader
            reader = command.ExecuteReader()
            reader.Read()

            reader.Close()
            connection.Close()


        End If


    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        Dim query As String
        Dim logstatus As String
        Dim usernow As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

        query = ("SELECT * FROM tblloginhistory ORDER BY id DESC LIMIT 1")

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


        query = ("UPDATE tblloginhistory SET logstatus = 'Logout', applicableSpecs = '" & HttpContext.Current.Session(“appspecs”) & "', formControlnum = '" & HttpContext.Current.Session(“formctrlnum”) & "' , logoutDatentime = '" & logoutdatentime & "', docStatus = 'Inactive' WHERE empId = '" & HttpContext.Current.Session(“empId”) & "' AND logStatus = 'Login'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        reader = command.ExecuteReader()
        reader.Read()

        reader.Close()
        connection.Close()

        HttpContext.Current.Session("documentStatus") = ""
        Response.Redirect("Login.aspx")

    End Sub


    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click

        Dim filename As String
        filename = HttpContext.Current.Session(“empname”)

        ''create a connection to database
        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")


        ''MySql query that select the file based on the formtitle And applicable specifications
        Dim query As String
        query = ("SELECT tblform_masterlist.formTitle, tblapprovalrequest.formControlnum, tblapprovalrequest.filename, tblapprovalrequest.applicableSpecs ,tblapprovalrequest.requestorName, tblapprovalrequest.requestorDepartment,  tblapprovalrequest.requestStatus, tblapprovalrequest.requestDate FROM tblform_masterlist INNER JOIN tblapprovalrequest ON tblform_masterlist.formControlnum = tblapprovalrequest.formControlnum WHERE tblapprovalrequest.formControlnum = '" & HttpContext.Current.Session(“formctrlnum”) & "'")
        command = New MySqlCommand(query, connection)

        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        reader.Read()

        filename = reader(2) 'getting the filename of the form

        ''open din pdf kaso napapatungan si system kaya nag lagay ng javascript para ma open sa nex window-----------------------------------------------------------------------------------------

        Dim path As String = "D:\Forms\Approval\" + filename
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