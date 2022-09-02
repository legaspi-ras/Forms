Imports System.Net.Mail
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class WebForm6
    Inherits System.Web.UI.Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles btnUploadnSend.Click

        ' save yung for approval na pdf sa for approval folder
        Dim savefilename As String
        savefilename = Path.GetFileName(FileUpload1.FileName)

        Dim directory As String
        Dim contentType As String
        contentType = FileUpload1.PostedFile.ContentType

        Dim pdfSavingStatus As String
        pdfSavingStatus = "failed"

        directory = ("D:\Forms\Approval\" + savefilename) ' gagawa ng validation para malaman kung tamang ang file name na kailangan i submit lalo na pag mga signatory na ang gagawa

        If lblRequestor.Text <> "-" Then

            lblalert4.Visible = False

            If contentType = "application/pdf" Then '  <---- check kung PDF file ang document
                lblalert3.Visible = False

                If File.Exists(directory) Then ' <---- check kung may kapangalan ng file

                    ' delete muna ang lumang file na guston paltan. --------------------------------
                    ' MsgBox("Request already exist. Replacing file.....")

                    File.Delete(directory)

                    'end of deleteing --------------------------------------------------------------

                    ' start saving young edited file -----------------------------------------------

                    Using fs As Stream = FileUpload1.PostedFile.InputStream

                        ' save niya sa folder na for approval 
                        FileUpload1.SaveAs("D:\Forms\Approval\" + savefilename)

                    End Using

                    pdfSavingStatus = "success"

                    ' end -----  upload (saving) pdf file to mysql database

                Else ' <---- walang katulad na filename

                    Using fs As Stream = FileUpload1.PostedFile.InputStream


                        FileUpload1.SaveAs("D:\Forms\Approval\" + savefilename)


                    End Using

                    ' MsgBox("New request has been posted.")
                    pdfSavingStatus = "success"

                End If

                ' save sa database tblapprovalrequest saka tblapprover -------------------------------------------------------------------------------

                If pdfSavingStatus = "success" Then

                    Dim filename As String
                    Dim deptarea As String
                    Dim formctrlnum As String
                    Dim frmtitle As String
                    Dim appspecs As String

                    Dim requestor As String
                    Dim reqdept As String
                    Dim reqdate As String
                    Dim approverstatus As String

                    deptarea = lblDepartment.Text
                    formctrlnum = lblFormctrlnum.Text
                    frmtitle = lblFormtitle.Text
                    appspecs = txtasn.Text

                    If appspecs = "" Then

                        appspecs = "NA"

                    End If

                    filename = Path.GetFileName(FileUpload1.FileName)
                    requestor = lblRequestor.Text
                    reqdept = lblRequestordept.Text
                    reqdate = Today.ToString("yyyy-MM-dd")
                    approverstatus = "Pending"

                    Dim query As String

                    connection = New MySqlConnection
                    connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

                    'tblapprovalrequest -------------------------------------------------------------------------------------------------------------

                    query = ("INSERT INTO tblapprovalrequest (formControlnum, filename, applicableSpecs, requestorName, requestorDepartment, requestStatus, requestDate) VALUES ('" & formctrlnum & "', '" & savefilename & "', '" & appspecs & "', '" & requestor & "', '" & reqdept & "', '" & approverstatus & "', '" & reqdate & "')")

                    command = New MySqlCommand(query, connection)

                    Dim reader As MySqlDataReader
                    connection.Open()

                    reader = command.ExecuteReader()
                    reader.Read()
                    reader.Close()

                    connection.Close()

                    lblalert2.Visible = True

                    txtEmpnum.Value = ""
                    txtSearch.Value = ""
                    txtasn.Text = ""
                    FileUpload1.PostedFile.InputStream.Dispose()

                End If

            Else
                ' MsgBox("Please select the pdf file for upload.")
                lblalert3.Visible = True
                lblalert2.Visible = False
            End If

        Else

            lblalert4.Visible = True

        End If

        ' Response.Redirect(Request.Url.AbsoluteUri) '' refesh niya ang webform (ginamit ko para ma clear ang mga textboxes)

    End Sub


    Protected Sub btnsearch1_Click(sender As Object, e As EventArgs) Handles btnsearch1.Click

        Dim query As String
        Dim empNum As String

        empNum = txtEmpnum.Value

        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

        query = ("SELECT EMP_NO, EMP_NAME, DEPARTMENT FROM emp_masterlist WHERE EMP_NO = '" & empNum & "'") '' REMINDER - BAGO MAG SAVE SA DATABASE IMPORTANTENG NAKA TRIM ANG MGA SPACES PARA WALANG PROBLEMA PAG NAG FETCH NA NG DATA FROM DATABASE

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()


        If reader.HasRows Then

            lblRequestor.Text = reader(1)
            lblRequestordept.Text = reader(2)

            reader.Close()
            connection.Close()

            lblalert.Visible = False
            lblalert4.Visible = False

        Else
            lblalert.Visible = True
        End If

    End Sub

    Protected Sub btnsearch2_Click(sender As Object, e As EventArgs) Handles btnsearch2.Click

        '' display nya yung galing sa search data ------------------------------------------------------------
        Dim query As String
        Dim frmctrnum As String

        frmctrnum = txtSearch.Value

        connection = New MySqlConnection
        connection.ConnectionString = ("server='127.0.0.1'; port='3306'; username='root'; password='POWERHOUSE'; database='eforms'")

        query = ("SELECT * FROM tblform_masterlist WHERE formControlnum = '" & frmctrnum & "'") '' REMINDER - BAGO MAG SAVE SA DATABASE IMPORTANTENG NAKA TRIM ANG MGA SPACES PARA WALANG PROBLEMA PAG NAG FETCH NA NG DATA FROM DATABASE

        command = New MySqlCommand(query, connection)
        connection.Open()

        Dim reader As MySqlDataReader
        reader = command.ExecuteReader()
        reader.Read()

        If reader.HasRows Then

            lblDepartment.Text = reader(1)
            lblFormctrlnum.Text = reader(2)
            lblFormtitle.Text = reader(3)

            btnUploadnSend.Enabled = True

            reader.Close()
            connection.Close()

            txtasn.Enabled = True
            FileUpload1.Enabled = True
            lblalert1.Visible = False
        Else
            '  MsgBox("Sorry, the e-form that your looking for is not available.")
            lblalert1.Visible = True
        End If

    End Sub
End Class

