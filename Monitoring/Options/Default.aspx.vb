
Partial Class Options_Default
    Inherits System.Web.UI.Page

    Private Sub Options_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If User.IsInRole("Administrator") Then
            AdminPanel.Visible = True
        End If
    End Sub

End Class
