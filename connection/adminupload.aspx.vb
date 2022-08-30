Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Net

Public Class adminupload
    Inherits System.Web.UI.Page
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblRequestor.Text = HttpContext.Current.Session(“requestor”)
        lblRequestordept.Text = HttpContext.Current.Session("formdepartment")
        lblFormctrlnum.Text = HttpContext.Current.Session(“formctrlnum”)
        lblFormtitle.Text = HttpContext.Current.Session(“formtitle”)
        lblAppsspecs.Text = HttpContext.Current.Session(“appspecs”)
        lblFormdept.Text = HttpContext.Current.Session(“formdepartment”)

        ' btnupdate.Enabled = False

    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub btnview_Click(sender As Object, e As EventArgs) Handles btnview.Click

        Dim filename As String
        filename = HttpContext.Current.Session(“empname”)

        ''create a connection to database
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")


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
        Response.TransmitFile("C:\Users\romer.legaspi\Desktop\pdf_files\pdf_file_for_approval\" + filename)
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

            directory = ("C:\Users\romer.legaspi\Desktop\pdf_files\pdf_file_for_approval\" + savefilename) ' gagawa ng validation para malaman kung tamang ang file name na kailangan i submit lalo na pag mga signatory na ang gagawa


            If contentType = "application/pdf" Then '  <---- check kung PDF file ang document

                If File.Exists(directory) Then ' <---- check yung file

                    ' delete muna ang lumang file na guston paltan. --------------------------------

                    File.Delete(directory)

                    'end of deleteing --------------------------------------------------------------

                    ' start saving young edited file -----------------------------------------------

                    Using fs As Stream = FileUpload1.PostedFile.InputStream

                        ' save niya sa folder na for approval 
                        FileUpload1.SaveAs("C:\Users\romer.legaspi\Desktop\pdf_files\pdf_file_for_approval\" + savefilename)

                    End Using

                    ' end -----  

                    ' Transferring file to each department folder

                    Dim deptarea As String
                    deptarea = DropDownList1.SelectedItem.Value

                    Select Case deptarea
                        Case "MIS"

                            FileUpload1.SaveAs("C:\Users\romer.legaspi\Desktop\pdf_files\MIS\" + savefilename)

                        Case "Security"

                            FileUpload1.SaveAs("C:\Users\romer.legaspi\Desktop\pdf_files\Security\" + savefilename)

                        Case Else

                    End Select

                End If

            End If
            ' save sa database tblapprovalrequest saka tblapprover -------------------------------------------------------------------------------

        End If

    End Sub
End Class