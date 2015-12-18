Imports AuthClass
Imports MonitoringDatabase
Partial Class Options_UpdateProfile
    Inherits System.Web.UI.Page

    Private db As New DBModel

    Protected Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        Dim Response As Boolean = UpdateUser(UserNameLabel.Text, PasswordTextBox.Text, NewPasswordTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text, EmailAddressTextBox.Text)

        If Response = True Then
            StatusLabel.Text = "Account Updated"
        Else
            StatusLabel.Text = "Update Failed"
        End If

    End Sub

    Private Sub Options_UpdateProfile_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim UserName As String = User.Identity.Name
        UserNameLabel.Text = UserName

        Dim Q = (From T In db.Users
                     Where T.UserName = UserName
                     Select T).FirstOrDefault


        FirstNameTextBox.Text = Q.FirstName
            LastNameTextBox.Text = Q.LastName
            EmailAddressTextBox.Text = Q.UserEmail


    End Sub

    Protected Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Response.Redirect("~/Options/")
    End Sub
End Class
