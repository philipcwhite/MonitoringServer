
Partial Class User_Default
    Inherits System.Web.UI.Page

    Private Sub User_Default_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        Response.Redirect("~/User/Login.aspx")
    End Sub
End Class
