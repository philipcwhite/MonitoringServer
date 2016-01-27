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
                 Where T.EventStatus = True
                 Order By T.EventDate Descending
                 Select T).Take(1000)

        Dim Table As New LiteralControl("<table class='HoverTable'><thead><tr><th></th><th>Date</th><th>Severity</th><th>Hostname</th><th>Class</th><th>Message</th></tr></thead>")
        Dim Severity As String = Nothing
        EventPlaceHolder.Controls.Clear()
        EventPlaceHolder.Controls.Add(Table)

        Dim EventRows As String = Nothing

        If Q IsNot Nothing Then
            For Each i In Q
                Dim FormattedDate As Date = i.EventDate
                If i.EventSeverity = 2 Then
                    Severity = "Critical"
                    EventRows = EventRows & "<tr><td><div class='EventStatusCritical'></div></td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td><a href='../Devices/Device.aspx?hostname=" & i.EventHostname & "'>" & i.EventHostname & "</a></td><td>" & i.EventClass & "</td><td>" & i.EventMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>"
                ElseIf i.EventSeverity = 1 Then
                    Severity = "Warning"
                    EventRows = EventRows & "<tr><td><div class='EventStatusWarning'></div></td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td><a href='../Devices/Device.aspx?hostname=" & i.EventHostname & "'>" & i.EventHostname & "</a></td><td>" & i.EventClass & "</td><td>" & i.EventMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>"
                ElseIf i.EventSeverity = 0 Then
                    Severity = "Informational"
                    EventRows = EventRows & "<tr><td><div class='EventStatusInfo'></div></td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td><a href='../Devices/Device.aspx?hostname=" & i.EventHostname & "'>" & i.EventHostname & "</a></td><td>" & i.EventClass & "</td><td>" & i.EventMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>"
                End If
            Next
        End If
        If EventRows = "" Then
            EventRows = "<tr><td colspan='6' style='text-align:center'>No Events</td></tr>"
        End If

        Dim Row As New LiteralControl(EventRows)
        EventPlaceHolder.Controls.Add(Row)

        Dim EndTable As New LiteralControl("</Table>")
        EventPlaceHolder.Controls.Add(EndTable)
    End Sub

    Protected Sub EventsTimer_Tick(sender As Object, e As EventArgs) Handles EventsTimer.Tick
        BuildTable()
    End Sub
End Class
