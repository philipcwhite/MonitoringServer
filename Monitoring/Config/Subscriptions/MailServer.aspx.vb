Imports MonitoringDatabase
Partial Class Config_Subscriptions_MailServer
    Inherits System.Web.UI.Page
    Private Property db As New DBModel

    Protected Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        Dim QServer = (From T In db.ServerConfiguration
                       Where T.Name = "Mail_Server"
                       Select T.Value).FirstOrDefault
        Dim QAdmin = (From T In db.ServerConfiguration
                      Where T.Name = "Mail_Admin"
                      Select T.Value).FirstOrDefault

        If QAdmin IsNot Nothing And QServer IsNot Nothing Then
            QServer = HostNameTextBox.Text
            QAdmin = AdminTextBox.Text
            db.SaveChanges()
        Else
            db.ServerConfiguration.Add(New ServerConfiguration With {.Name = "Mail_Server", .Value = HostNameTextBox.Text})
            db.ServerConfiguration.Add(New ServerConfiguration With {.Name = "Mail_Admin", .Value = AdminTextBox.Text})
            db.SaveChanges()
        End If

        Response.Redirect("~/Config")
    End Sub

    Private Sub Config_Subscriptions_MailServer_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim Q = From T In db.ServerConfiguration
                    Select T

            For Each i In Q
                If i.Name = "Mail_Server" Then
                    HostNameTextBox.Text = i.Value
                ElseIf i.Name = "Mail_Admin" Then
                    AdminTextBox.Text = i.Value
                End If
            Next

        End If
    End Sub

    Private Sub Config_Subscriptions_MailServer_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not User.IsInRole("Administrator") Then
            Response.Redirect("~/Config")
        End If
    End Sub
End Class
