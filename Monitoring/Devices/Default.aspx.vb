Imports MonitoringDatabase
Partial Class Devices_Default
    Inherits System.Web.UI.Page

    Private Property db As New DBModel


    Private Sub Devices_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        BuildTable()
    End Sub


    Private Sub BuildTable()

        Dim Q = From T In db.AgentSystem
                Order By T.AgentName Ascending
                Select T



        Dim Table As New LiteralControl("<table class='HoverTable'><thead><tr><th></th><th>Hostname</th><th>Domain</th><th>IP Address</th><th>Operating System</th></tr></thead>")
        DevicesPlaceHolder.Controls.Clear()
        DevicesPlaceHolder.Controls.Add(Table)

        Dim StatusDate As Date = Date.Now.AddHours(-1)

        Dim DeviceRows As String = Nothing
        For Each i In Q

            If i.AgentDate < StatusDate Then
                DeviceRows = DeviceRows & "<tr><td><div class='EventStatusCritical'></div></td><td><a href='Device.aspx?hostname=" & i.AgentName & "'>" & i.AgentName & "</a></td><td>" & i.AgentDomain & "</td><td>" & i.AgentIP & "</td><td>" & i.AgentOSName & "</td></tr>"
            Else
                DeviceRows = DeviceRows & "<tr><td><div class='EventStatusOK'></div></td><td><a href='Device.aspx?hostname=" & i.AgentName & "'>" & i.AgentName & "</a></td><td>" & i.AgentDomain & "</td><td>" & i.AgentIP & "</td><td>" & i.AgentOSName & "</td></tr>"
            End If
        Next
        If DeviceRows = "" Then
            DeviceRows = "<tr><td colspan='5' style='text-align:center'>No Events</td></tr>"
        End If

        Dim Row As New LiteralControl(DeviceRows)
        DevicesPlaceHolder.Controls.Add(Row)

        Dim EndTable As New LiteralControl("</Table>")
        DevicesPlaceHolder.Controls.Add(EndTable)

    End Sub


    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BuildTable()
    End Sub

End Class
