Imports AuthClass

Partial Class Options_DeleleConfirm
    Inherits System.Web.UI.Page

    Private Sub Options_DeleleConfirm_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not User.IsInRole("Administrator") Then
            Response.Redirect("~/Config")
        End If
    End Sub

    Protected Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
        DeleteUser(UserLabel.Text)
        Response.Redirect("~/Config/Default.aspx")
    End Sub

    Private Sub Options_DeleleConfirm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim UserString = Nothing
        UserString = Request.QueryString("UserName")
        UserLabel.Text = UserString
    End Sub
End Class
