Imports MonitoringDatabase
Partial Class Options_Subscriptions_Default
    Inherits System.Web.UI.Page
    Private Property db As New DBModel

    Private Sub Options_Subscriptions_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            UsernameLabel.Text = User.Identity.Name
            GetData()


        End If
    End Sub

    Private Sub GetData()
        Dim UserName = UsernameLabel.Text
        DevicesListBox.Items.Clear()
        MyDevicesListBox.Items.Clear()


        Dim DeviceList As New List(Of String)


        Dim Q1 = From T In db.AgentSystem
                 Order By T.AgentName Ascending
                 Select T.AgentName

        For Each i In Q1
            DeviceList.Add(i)
        Next

        For Each i In DeviceList
            Dim Q = (From T In db.Subscriptions
                     Where T.AgentName = i And T.UserName = UserName
                     Select T).FirstOrDefault
            If Q Is Nothing Then
                DevicesListBox.Items.Add(i)
            End If
        Next

        Dim Q2 = From T In db.Subscriptions
                 Where T.UserName = UserName
                 Order By T.AgentName Ascending
                 Select T.AgentName

        For Each i In Q2
            MyDevicesListBox.Items.Add(i)
        Next



    End Sub


    Protected Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click

        Dim UserName = UsernameLabel.Text

        For i = 0 To DevicesListBox.Items.Count - 1

            If DevicesListBox.Items(i).Selected = True Then
                Dim AgentName As String = DevicesListBox.Items(i).Text.ToString
                Dim Q = (From T In db.Subscriptions
                         Where T.UserName = UserName And T.AgentName = AgentName
                         Select T).FirstOrDefault

                If Q Is Nothing Then
                    db.Subscriptions.Add(New Subscriptions With {.AgentName = AgentName, .UserName = UserName, .Notify = False})
                    db.SaveChanges()
                End If

            End If


        Next


        GetData()

    End Sub

    Protected Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click

        Dim UserName = UsernameLabel.Text

        For i = 0 To MyDevicesListBox.Items.Count - 1

            If MyDevicesListBox.Items(i).Selected = True Then
                Dim AgentName As String = MyDevicesListBox.Items(i).Text.ToString
                Dim Q = (From T In db.Subscriptions
                         Where T.UserName = UserName And T.AgentName = AgentName
                         Select T).FirstOrDefault

                If Q IsNot Nothing Then
                    db.Subscriptions.Remove(Q)
                    db.SaveChanges()
                End If

            End If


        Next

        GetData()

    End Sub
End Class
