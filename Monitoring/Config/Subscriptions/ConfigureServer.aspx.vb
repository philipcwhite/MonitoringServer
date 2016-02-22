Imports MonitoringDatabase
Partial Class Config_Subscriptions_ConfigureServer
    Inherits System.Web.UI.Page
    Private Property db As New DBModel

    Protected Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        Dim Q = From T In db.ServerConfiguration
                Select T.Name, T.Value

        Dim Exist As Integer = 0

        For Each i In Q
            If i.Name = "Event_Route" Then
                Exist = Exist + 1
            ElseIf i.Name = "Mail_Server" Then
                Exist = Exist + 1
            ElseIf i.Name = "Mail_Admin" Then
                Exist = Exist + 1
            End If
        Next



        If Exist = 3 Then
            Dim Q1 = (From T In db.ServerConfiguration
                      Where T.Name = "Event_Route"
                      Select T).FirstOrDefault

            Q1.Value = RouteDropDownList.SelectedValue
            db.SaveChanges()

            Dim Q2 = (From T In db.ServerConfiguration
                      Where T.Name = "Mail_Server"
                      Select T).FirstOrDefault

            Q2.Value = HostNameTextBox.Text
            db.SaveChanges()

            Dim Q3 = (From T In db.ServerConfiguration
                      Where T.Name = "Mail_Admin"
                      Select T).FirstOrDefault

            Q3.Value = AdminTextBox.Text
            db.SaveChanges()

        Else
            db.ServerConfiguration.Add(New ServerConfiguration With {.Name = "Event_Route", .Value = RouteDropDownList.SelectedValue})
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
                If i.Name = "Event_Route" Then
                    RouteDropDownList.SelectedValue = i.Value
                ElseIf i.Name = "Mail_Server" Then
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
