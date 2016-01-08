
Partial Class Options_Default
    Inherits System.Web.UI.Page

    Private Sub Options_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If User.IsInRole("Administrator") Then
            AdminPanel1.Visible = True
            AdminPanel2.Visible = True
        End If
    End Sub

    'Protected Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
    '    FormsAuthentication.SignOut()
    '    Response.Redirect("~/")
    'End Sub

End Class
