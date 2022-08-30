Imports System.IO
Imports System.Net
Imports MySql.Data.MySqlClient

Public Class About
    Inherits Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        txtFormctrlnum.Attributes.Add("placeholder", "i.e. MIS-04")
        txtFormtitle.Attributes.Add("placeholder", "i.e. Computer/Laptop Peripherals Issuance Slip")

    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

        'Dim sampletext As String

        'sampletext = "*A"

        'Label6.Text = sampletext.Replace("*", "0")

        Dim deptarea As String
        Dim formctrlnum As String
        Dim frmtitle As String
        Dim revnum As String
        Dim pdfbytes() As Byte


        Dim filename As String
        filename = Path.GetFileName(FileUpload1.FileName)

        Dim directory As String
        Dim contentType As String
        contentType = FileUpload1.PostedFile.ContentType
        directory = Server.MapPath("~/pdf_files/" + filename) '' babaguhin ang path

        '  Label6.Text = directory for validation lang ito
        If contentType = "application/pdf" Then

            If File.Exists(directory) Then

                MsgBox("Oops! I'm sorry. The form your trying to add is already available. ")

            ElseIf (FileUpload1.HasFile) Then

                ' start -----  upload (save) pdf file to mysql database


                Using fs As Stream = FileUpload1.PostedFile.InputStream

                    Using br As New BinaryReader(fs)

                        deptarea = ddlDepartment.SelectedItem.Text
                        formctrlnum = txtFormctrlnum.Text.Trim().ToUpper()
                        frmtitle = txtFormtitle.Text
                        revnum = txtRevnum.Text
                        pdfbytes = br.ReadBytes(fs.Length)

                        Dim query As String

                        connection = New MySqlConnection
                        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

                        query = ("INSERT INTO tblform_masterlist (departmentArea, formControlnum, formTitle, revisionNum, pdfFilename, contentType, pdfData) VALUES ('" & deptarea & "', '" & formctrlnum & "', '" & frmtitle & "', '" & revnum & "', '" & filename & "', '" & contentType & "', '" & pdfbytes(0) & "')")

                        command = New MySqlCommand(query, connection)

                        Dim reader As MySqlDataReader
                        connection.Open()
                        reader = command.ExecuteReader()
                        reader.Read()

                        FileUpload1.SaveAs(Server.MapPath("~/pdf_files/" + filename))

                        reader.Close()
                        connection.Close()
                    End Using
                End Using


                MsgBox(frmtitle + " succesfully uploaded from the system.")

                Response.Redirect(Request.Url.AbsoluteUri)

                ' end -----  upload (save) pdf file to mysql database

            Else

                MsgBox("Please select the PDF file for upload.")

            End If

        Else

            MsgBox("Please select the PDF file for upload.")

        End If



    End Sub

    Protected Sub ddlDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDepartment.SelectedIndexChanged


    End Sub
End Class