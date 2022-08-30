Imports System.IO
Imports System.Net
Imports MySql.Data.MySqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page

    Dim connection As MySqlConnection
    Dim command As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            BindGrid()
        End If

    End Sub
    Private Sub BindGrid()

        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        'Using con As New SqlConnection(constr)
        '    Using cmd As New SqlCommand()
        '        cmd.CommandText = "SELECT Id, Name FROM tblFiles"
        '        cmd.Connection = con
        '        con.Open()
        '        GridView1.DataSource = cmd.ExecuteReader()
        '        GridView1.DataBind()
        '        con.Close()
        '    End Using
        'End Using

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        Dim query As String
        query = ("select * from tblpdfdata")
        command = New MySqlCommand(query, connection)

        connection.Open()

        GridView2.DataSource = command.ExecuteReader()
        GridView2.DataBind()

        connection.Close()



    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = "hello"

        Label2.Text = Today.ToString("yyyy-mm-dd")


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

    End Sub

    Protected Sub Upload(sender As Object, e As EventArgs) Handles btnUpload.Click, btnUpload.Click


        Dim filename As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
        Dim contentType As String = FileUpload1.PostedFile.ContentType
        Using fs As Stream = FileUpload1.PostedFile.InputStream

            Label3.Text = filename + " " + contentType

            Using br As New BinaryReader(fs)

                Dim bytes As Byte() = br.ReadBytes(fs.Length)

                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

                Dim query As String
                'query = ("INSERT INTO tbl_pdf_data(filename, specsNumber, revNumber, dateUpload, pdfFileName) VALUES('ECN', 'TF01-001', 'REV E', '2022-08-01', 'calendar.pdf')")

                query = ("INSERT INTO tblpdfdata (filename, specsNumber, revNumber, dateUpload, pdfFileName) VALUES('" & TextBox1.Text & "', '" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & filename & "')")

                command = New MySqlCommand(query, connection)

                Dim reader As MySqlDataReader
                connection.Open()
                reader = command.ExecuteReader()
                reader.Read()


                'command.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename
                'command.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contentType
                'command.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes

            End Using
        End Using

        Response.Redirect(Request.Url.AbsoluteUri)


    End Sub

    Protected Sub Button2_Click1(sender As Object, e As EventArgs) Handles Button2.Click

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        Dim query As String
        query = ("select * from tblpdfdata")
        command = New MySqlCommand(query, connection)

        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        reader.Read()

        Label1.Text = reader(0)
        Label2.Text = reader(1)

        reader.Close()

        connection.Close()

    End Sub

    Protected Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click

        Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""500px"" height=""300px"">"
        embed += "If you are unable to view file, you can download from <a href = ""{0}"">here</a>"
        embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
        embed += "</object>"
        HyperLink1.Text = String.Format(embed, ResolveUrl("~/pdf_files/calendar.pdf"))

    End Sub

    Protected Sub btnpdf_Click(sender As Object, e As EventArgs) Handles btnpdf.Click




        Dim path As String = Server.MapPath("~/pdf_files/calendar.pdf")
        Dim client As New WebClient()
        Dim buffer As [Byte]() = client.DownloadData(path)

        If buffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", buffer.Length.ToString())
            Response.BinaryWrite(buffer)

        End If


    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click

        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        Dim query As String
        query = ("select * from tblpdfdata")
        command = New MySqlCommand(query, connection)

        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        reader.Read()

        Label1.Text = reader(0)
        Label2.Text = reader(1)


        Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""500px"" height=""300px"">"
        embed += "If you are unable to view file, you can download from <a href = ""{0}"">here</a>"
        embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
        embed += "</object>"
        HyperLink1.Text = String.Format(embed, ResolveUrl("~/pdf_files/" + reader(5) + ""))

        reader.Close()

        connection.Close()


    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged


        '    <System.Web.Services.WebMethod()>
        'Public Shared Function GetPDF(ByVal fileId As Integer) As Object
        '    Dim bytes As Byte()
        '    Dim fileName As String, contentType As String
        '    Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        '    Using con As New SqlConnection(constr)
        '        Using cmd As New SqlCommand()
        '            cmd.CommandText = "SELECT Name, Data, ContentType FROM tblFiles WHERE Id = @Id"
        '            cmd.Parameters.AddWithValue("@Id", fileId)
        '            cmd.Connection = con
        '            con.Open()
        '            Using sdr As SqlDataReader = cmd.ExecuteReader()
        '                sdr.Read()
        '                bytes = DirectCast(sdr("Data"), Byte())
        '                contentType = sdr("ContentType").ToString()
        '                fileName = sdr("Name").ToString()
        '            End Using
        '            con.Close()
        '        End Using
        '    End Using

        '    Return New With {.FileName = fileName, .ContentType = contentType, .Data = bytes}
        'End Function

        'Dim name As String = GridView2.SelectedRow.Cells(2).Text
        'Dim filename As String

        'connection = New MySqlConnection
        'connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        'Dim query As String
        'query = ("select * from tblpdfdata where pdfName ='" & name & "'")
        'command = New MySqlCommand(query, connection)

        'Dim reader As MySqlDataReader
        'connection.Open()
        'reader = command.ExecuteReader()
        'reader.Read()

        'filename = reader(7)

        'Dim path As String = Server.MapPath("~/pdf_files/" + filename + "")
        'Dim client As New WebClient()
        'Dim buffer As [Byte]() = client.DownloadData(path)

        'If buffer IsNot Nothing Then
        '    Response.ContentType = "application/pdf"
        '    Response.AddHeader("content-length", buffer.Length.ToString())
        '    Response.BinaryWrite(buffer)

        'End If

        'reader.Close()

        'connection.Close()


    End Sub

    Protected Sub GridView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView3.SelectedIndexChanged

        'Dim id As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        'Dim bytes As Byte()
        'Dim fileName As String, contentType As String
        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        'Using con As New SqlConnection(constr)
        '    Using cmd As New SqlCommand()
        '        cmd.CommandText = "select Name, Data, ContentType from tblFiles where Id=@Id"
        '        cmd.Parameters.AddWithValue("@Id", id)
        '        cmd.Connection = con
        '        con.Open()
        '        Using sdr As SqlDataReader = cmd.ExecuteReader()
        '            sdr.Read()
        '            bytes = DirectCast(sdr("Data"), Byte())
        '            contentType = sdr("ContentType").ToString()
        '            fileName = sdr("Name").ToString()
        '        End Using
        '        con.Close()
        '    End Using
        'End Using
        'Response.Clear()
        'Response.Buffer = True
        'Response.Charset = ""
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.ContentType = contentType
        'Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName)
        'Response.BinaryWrite(bytes)
        'Response.Flush()
        'Response.End()


        'Dim pdfname As String = GridView3.SelectedRow.Cells(1).Text

        'Dim pdfbytes As Byte()
        'Dim fileName As String
        'Dim contentType As String


        'connection = New MySqlConnection
        'connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

        'Dim query As String
        'query = ("select * from tblpdfdata where pdfName ='" & pdfname & "'")
        'command = New MySqlCommand(query, connection)

        'Dim reader As MySqlDataReader
        'connection.Open()
        'reader = command.ExecuteReader()
        'reader.Read()

        'fileName = Server.MapPath("~/pdf_files/" + reader(7) + "")
        'contentType = reader(5)
        ''' pdfbytes = reader(6)

        'pdfbytes = DirectCast(reader("pdfData"), Byte())

        'reader.Close()

        'connection.Close()


        'Response.Clear()
        'Response.Buffer = True
        'Response.Charset = ""
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.ContentType = contentType
        'Response.AddHeader("content-length", fileName.Length.ToString())
        'Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName)
        'Response.BinaryWrite(pdfbytes)
        'Response.Flush()
        'Response.End()

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim filename As String = Path.GetFileName(FileUpload2.PostedFile.FileName)
        Dim contentType As String = FileUpload2.PostedFile.ContentType
        Using fs As Stream = FileUpload2.PostedFile.InputStream

            Using br As New BinaryReader(fs)

                Dim pdfbytes() As Byte

                pdfbytes = br.ReadBytes(fs.Length)

                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost'; port='3306'; username='root'; password='powerhouse'; database='eforms'")

                Dim query As String

                '' query = ("INSERT INTO tblpdfdata (pdfName, specsNumber, revNumber, dateUpload, contentType, pdfData, pdfFilename) VALUES('" & txtFilename.Text & "', '" & txtSpecsnumber.Text & "','" & txtRevnumber.Text & "','" & dateUpload & "','" & contentType & "','" & pdfbytes(0) & "','" & filename & "')")

                query = ("UPDATE tblpdfdata SET contentType = '" & contentType & "'," & "pdfData = '" & pdfbytes(0) & "', " & "pdfFilename = '" & filename & "' WHERE pdfName = 'FVI'")
                command = New MySqlCommand(query, connection)

                Dim reader As MySqlDataReader
                connection.Open()
                reader = command.ExecuteReader()
                reader.Read()

            End Using
        End Using

        Response.Redirect(Request.Url.AbsoluteUri)

    End Sub
End Class