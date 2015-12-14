
Partial Class User_Default
    Inherits System.Web.UI.Page

    Private Sub User_Default_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' UserManager.AddToRole(User.Identity.Name, "Administrators")
        'Roles.AddUserToRole(User.Identity.Name, "Administrators")

        'If User.IsInRole("Administrators") Then
        '    Label1.Text = True
        'End If
    End Sub
End Class
