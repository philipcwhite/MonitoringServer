Imports AuthClass
Imports MonitoringDatabase
Partial Class Options_UpdateProfile
    Inherits System.Web.UI.Page

    Private db As New DBModel

    Protected Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        Dim ChangePassword As Boolean = False

        If PasswordRadioButtonList.SelectedValue = "Yes" Then
            ChangePassword = True
        Else
            ChangePassword = False
        End If

        Dim Response As Boolean = False

        If NewPasswordTextBox.Enabled = True And NewPasswordTextBox.Text <> "" Then
            Response = UpdateUser(UserNameTextBox.Text, ChangePassword, NewPasswordTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text, EmailAddressTextBox.Text, Nothing)
        ElseIf NewPasswordTextBox.Enabled = False And NewPasswordTextBox.Text = "" Then
            Response = UpdateUser(UserNameTextBox.Text, ChangePassword, NewPasswordTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text, EmailAddressTextBox.Text, Nothing)
        End If

        If Response = True Then
            StatusLabel.Text = "Account Updated"
        Else
            StatusLabel.Text = "Update Failed"
        End If

    End Sub

    Private Sub Options_UpdateProfile_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim UserName As String = User.Identity.Name
            UserNameTextBox.Text = UserName








            Dim Q = (From T In db.Users
                     Where T.UserName = UserName
                     Select T).FirstOrDefault

            If Not Q Is Nothing Then
                FirstNameTextBox.Text = Q.FirstName
                LastNameTextBox.Text = Q.LastName
                EmailAddressTextBox.Text = Q.EmailAddress
            End If


        End If


    End Sub

    Protected Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Response.Redirect("~/Config/")
    End Sub




    Protected Sub PasswordRadioButtonList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PasswordRadioButtonList.SelectedIndexChanged
        If PasswordRadioButtonList.SelectedValue = "Yes" Then
            NewPasswordTextBox.Enabled = True
            NewPasswordTextBox.BackColor = Drawing.Color.White
        ElseIf PasswordRadioButtonList.SelectedValue = "No" Then
            NewPasswordTextBox.Enabled = False
            NewPasswordTextBox.BackColor = Drawing.ColorTranslator.FromHtml("#efefef")
        End If
    End Sub

End Class
