Imports AuthClass
Partial Class User_Register
    Inherits System.Web.UI.Page
    Protected Sub RegisterButton_Click(sender As Object, e As EventArgs) Handles RegisterButton.Click
        Dim Message = AddUser(UserNameTextBox.Text, PasswordTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text, EmailTextBox.Text)

        ResultLabel.ForeColor = Drawing.Color.Red
        ResultLabel.Text = Message.ToString

    End Sub
End Class
