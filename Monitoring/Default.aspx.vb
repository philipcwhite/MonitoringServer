
Imports System.Security.Principal

Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub

    Private Sub _Default_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        Response.Redirect("~/Events/")
    End Sub
End Class
