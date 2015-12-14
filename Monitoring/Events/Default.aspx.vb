Imports MonitoringDatabase
Partial Class Events_Default
    Inherits System.Web.UI.Page

    Private Property db As New DBModel

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        BuildTable()

    End Sub


    Private Sub BuildTable()

        'Add Paging for past 1000 Events

        Dim Q = (From T In db.AgentEvents
                 Where T.AgentStatus = True
                 Order By T.AgentEventDate Descending
                 Select T).Take(1000)

        Dim Table As New LiteralControl("<table class='EventTable'><thead><tr><th></th><th>Date</th><th>Severity</th><th>Hostname</th><th>Class</th><th>Message</th></tr></thead>")
        EventPlaceHolder.Controls.Clear()
        EventPlaceHolder.Controls.Add(Table)

        For Each i In Q
            If i.AgentSeverity = "Critical" Then
                Dim Row As New LiteralControl("<tr><td><div class='EventStatusCritical'></div></td><td>" & i.AgentEventDate & "</td><td>" & i.AgentSeverity & "</td><td><a href='Device.aspx?hostname=" & i.AgentName & "'>" & i.AgentName & "</a></td><td>" & i.AgentClass & "</td><td>" & i.AgentMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>")
                EventPlaceHolder.Controls.Add(Row)
            ElseIf i.AgentSeverity = "Major"
                Dim Row As New LiteralControl("<tr><td><div class='EventStatusMajor'></div></td><td>" & i.AgentEventDate & "</td><td>" & i.AgentSeverity & "</td><td><a href='Device.aspx?hostname=" & i.AgentName & "'>" & i.AgentName & "</a></td><td>" & i.AgentClass & "</td><td>" & i.AgentMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>")
                EventPlaceHolder.Controls.Add(Row)
            ElseIf i.AgentSeverity = "Minor"
                Dim Row As New LiteralControl("<tr><td><div class='EventStatusMinor'></div></td><td>" & i.AgentEventDate & "</td><td>" & i.AgentSeverity & "</td><td><a href='Device.aspx?hostname=" & i.AgentName & "'>" & i.AgentName & "</a></td><td>" & i.AgentClass & "</td><td>" & i.AgentMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>")
                EventPlaceHolder.Controls.Add(Row)
            End If
        Next
        Dim EndTable As New LiteralControl("</Table>")
        EventPlaceHolder.Controls.Add(EndTable)
    End Sub

    Protected Sub EventsTimer_Tick(sender As Object, e As EventArgs) Handles EventsTimer.Tick
        BuildTable()
    End Sub
End Class
