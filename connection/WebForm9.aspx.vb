Imports System.IO

Public Class WebForm9
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Dim P As New ProcessStartInfo
        'P.FileName = "C:\Program Files (x86)\Foxit Software\Foxit PDF Reader\FoxitPDFReader.exe"

        'P.UseShellExecute = True
        'P.WindowStyle = ProcessWindowStyle.Normal
        'P.Verb = "runas"

        'Dim pro As Process = Process.Start(P)
        Label1.Text = "resume.pdf" ''pinaltan ko lang file name ng ecn 

        Process.Start("C:\Users\romer.legaspi\source\repos\connection\connection\pdf_files\" + Label1.Text)



    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim SourcePath As String
        SourcePath = "C:\Users\romer.legaspi\Desktop\pdf_file_for_approval\TFP04-005.pdf"
        Dim filename As String
        filename = Path.GetFileName(SourcePath)
        Dim MoveLocation As String
        MoveLocation = "C:\Users\romer.legaspi\Desktop\pdf_transfer\myfilename.pdf"

        Dim destinationPath As String = Path.Combine(MoveLocation, filename)

        If File.Exists(SourcePath) Then

            If File.Exists(destinationPath) Then
                File.Delete(destinationPath)
            End If
            File.Copy("C:\Users\romer.legaspi\Desktop\pdf_file_for_approval\TFP04-005.pdf", "C:\Users\romer.legaspi\Desktop\pdf_transfer\myfilename.pdf")
            MsgBox("File Downloaded")
            Process.Start("C:\Users\romer.legaspi\Desktop\pdf_transfer\myfilename.pdf")
        Else
            MsgBox("File Not move")
        End If


    End Sub
End Class