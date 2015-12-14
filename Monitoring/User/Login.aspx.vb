Imports AuthClass
Partial Class User_Login
    Inherits System.Web.UI.Page

    Protected Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        AuthenticateUser(UserNameTextBox.Text, PasswordTextBox.Text)
    End Sub
End Class