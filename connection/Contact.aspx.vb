Imports System.IO
Imports MySql.Data.MySqlClient
Public Class Contact
    Inherits Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If HttpContext.Current.Session("empid") <> "" Then
            If HttpContext.Current.Session("logstatus") = "Login" And HttpContext.Current.Session(“usertype”) = "admin" Then

            Else

                Response.Redirect("Login.aspx")
            End If
        Else
            Response.Redirect("Login.aspx")
        End If


    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click


        '' dislpaying existing data ------------------------------------------------------------
        Dim query As String

        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

        query = ("SELECT * FROM tblform_masterlist WHERE formControlnum = '" & txtSearch.Text & "'")

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()

        If reader.FieldCount > 0 Then

            txtDeptarea.Enabled = True
            txtFormctrlnum.Enabled = True
            txtFormtitle.Enabled = True
            txtRevisionnum.Enabled = True
            FileUpload1.Enabled = True
            btnUpdate.Enabled = True

            txtDeptarea.Text = reader(1)
            txtFormctrlnum.Text = reader(2)
            txtFormtitle.Text = reader(3)
            txtRevisionnum.Text = reader(4)
            lblFilename.Text = reader(5)

        Else

            ' MsgBox("Sorry. File unavailable.")

        End If
        connection.Close()
        ''---------------------------------------------------------------------------------------


    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim filename As String
        filename = Path.GetFileName(FileUpload1.FileName)

        Dim directory As String
        Dim contentType As String
        contentType = FileUpload1.PostedFile.ContentType
        directory = "D:\Forms\Template/" + filename

        If contentType = "application/pdf" Then

            If File.Exists(directory) Then

                '' delete muna ang lumang file na guston paltan. --------------------------------
                '' MsgBox(" ok proceed" + directory)

                File.Delete(directory)

                ''end of deleteing --------------------------------------------------------------

                '' start saving young edited file -----------------------------------------------


                Using fs As Stream = FileUpload1.PostedFile.InputStream

                    Using br As New BinaryReader(fs)

                        Dim deptarea As String
                        Dim formctrlnum As String
                        Dim frmtitle As String
                        ' Dim revdate = calDateupload.SelectedDate.ToString("yyyy-MM-dd")
                        '' Dim pdfname As String
                        Dim revnum As String
                        Dim pdfbytes() As Byte


                        deptarea = txtDeptarea.Text
                        formctrlnum = txtFormctrlnum.Text
                        frmtitle = txtFormtitle.Text

                        ''pdfname = txtFormtitle.Text
                        '' revnum = txtRevisionnum.Text.Replace("*", "0")
                        revnum = txtRevisionnum.Text
                        pdfbytes = br.ReadBytes(fs.Length)

                        Dim query As String

                        connection = New MySqlConnection
                        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

                        query = ("UPDATE tblform_masterlist SET pdfFilename = '" & filename & "', contentType = '" & contentType & "', pdfData = '" & pdfbytes(0) & "' WHERE  formControlNum = '" & formctrlnum & "'")
                        command = New MySqlCommand(query, connection)

                        Dim reader As MySqlDataReader
                        connection.Open()
                        reader = command.ExecuteReader()
                        reader.Read()

                        FileUpload1.SaveAs("D:\Forms\Template" + filename)

                    End Using
                End Using


                ' MsgBox("File succesfully updated from the system.")

                Response.Redirect(Request.Url.AbsoluteUri)

                ' end -----  upload (save) pdf file to mysql database

            Else

                ' MsgBox("Please select a PDF file for upload! ")

            End If

        Else

            'MsgBox("Please select a PDF file for upload! ")

        End If


    End Sub
End Class