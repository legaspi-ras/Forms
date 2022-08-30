Imports System.Net



Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Protected Sub btnOpen_Click(sender As Object, e As EventArgs)
        Response.Redirect("calendar.pdf")
    End Sub
End Class