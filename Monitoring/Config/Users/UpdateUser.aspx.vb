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
            Response = UpdateUser(UserNameTextBox.Text, ChangePassword, NewPasswordTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text, EmailAddressTextBox.Text, RoleDropDownList.SelectedValue)
        ElseIf NewPasswordTextBox.Enabled = False And NewPasswordTextBox.Text = "" Then
            Response = UpdateUser(UserNameTextBox.Text, ChangePassword, NewPasswordTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text, EmailAddressTextBox.Text, RoleDropDownList.SelectedValue)
        End If

        If Response = True Then
            StatusLabel.Text = "Account Updated"
        Else
            StatusLabel.Text = "Update Failed"
        End If

    End Sub

    Private Sub Options_UpdateProfile_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then


            Dim UserString As String = Nothing
            UserString = Request.QueryString("UserName")

            UserNameTextBox.Text = UserString




            If User.IsInRole("Administrator") Then
                RoleDropDownList.Enabled = True
            End If



            Dim Q = (From T In db.Users
                     Where T.UserName = UserString
                     Select T).FirstOrDefault

            If Not Q Is Nothing Then
                FirstNameTextBox.Text = Q.FirstName
                LastNameTextBox.Text = Q.LastName
                EmailAddressTextBox.Text = Q.EmailAddress
                If Q.UserRole = "Administrator" Then
                    RoleDropDownList.SelectedValue = "Administrator"
                ElseIf Q.UserRole = "Operator" Then
                    RoleDropDownList.SelectedValue = "Operator"
                ElseIf Q.UserRole = "User" Then
                    RoleDropDownList.SelectedValue = "User"
                Else
                    RoleDropDownList.SelectedValue = "Pending"
                End If
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

    Private Sub Options_UpdateProfile_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not User.IsInRole("Administrator") Then
            Response.Redirect("~/Config")
        End If
    End Sub

    Protected Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        Response.Redirect("~/Config/DeleteConfirm.aspx?UserName=" & UserNameTextBox.Text)
    End Sub

End Class
