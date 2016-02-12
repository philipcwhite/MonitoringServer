Imports MonitoringDatabase
Partial Class Events_Default
    Inherits System.Web.UI.Page

    Private Property db As New DBModel

    Private Property EventSeverity As Integer
    Private Property EventStatus As Boolean


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        BuildTable()

    End Sub


    Private Sub BuildTable()

        EventSeverity = 3
        EventStatus = True

        Dim QString1 = Nothing
        Dim QString2 = Nothing
        Try
            QString1 = Request.QueryString("Severity")
            QString2 = Request.QueryString("Status")
        Catch
        End Try

        Try
            If Not QString1 Is Nothing Then
                EventSeverity = QString1
            End If
        Catch
        End Try

        Try
            If Not QString2 Is Nothing Then
                EventStatus = QString2
            End If
        Catch
        End Try

        If EventStatus = True Then
            OpenLinkButton.CssClass = "LegendText"
        ElseIf EventStatus = False Then
            ClosedLinkButton.CssClass = "LegendText"
        End If

        If EventSeverity = 0 Then
            InfoLinkButton.CssClass = "LegendText"
        ElseIf EventSeverity = 1 Then
            WarningLinkButton.CssClass = "LegendText"
        ElseIf EventSeverity = 2 Then
            CriticalLinkButton.CssClass = "LegendText"
        ElseIf EventSeverity = 3 Then
            AllLinkButton.CssClass = "LegendText"
        End If

        'Add Paging for past 2500 Events
        Dim Q = Nothing
        If EventSeverity = 3 Then
            Q = (From T In db.AgentEvents
                 Where T.EventStatus = EventStatus
                 Order By T.EventDate Descending
                 Select T).Take(2500)
        Else
            Q = (From T In db.AgentEvents
                 Where T.EventStatus = EventStatus And T.EventSeverity = EventSeverity
                 Order By T.EventDate Descending
                 Select T).Take(2500)
        End If

        Dim Table As New LiteralControl("<table class='HoverTable'><thead><tr><th></th><th>Date</th><th>Severity</th><th>Hostname</th><th>Class</th><th>Message</th><th style='width:35px'></th></tr></thead>")
        Dim Severity As String = Nothing
        EventPlaceHolder.Controls.Clear()
        EventPlaceHolder.Controls.Add(Table)

        Dim EventRows As String = Nothing

        If Q IsNot Nothing Then
            For Each i In Q
                Dim FormattedDate As Date = i.EventDate
                If i.EventSeverity = 2 Then
                    Severity = "Critical"
                    EventRows = "<tr><td><div class='EventStatusCritical'></div></td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td><a href='../Devices/Device.aspx?hostname=" & i.EventHostname & "'>" & i.EventHostname & "</a></td><td>" & i.EventClass & "</td><td>" & i.EventMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td><td>"
                ElseIf i.EventSeverity = 1 Then
                    Severity = "Warning"
                    EventRows = "<tr><td><div class='EventStatusWarning'></div></td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td><a href='../Devices/Device.aspx?hostname=" & i.EventHostname & "'>" & i.EventHostname & "</a></td><td>" & i.EventClass & "</td><td>" & i.EventMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td><td>"
                ElseIf i.EventSeverity = 0 Then
                    Severity = "Informational"
                    EventRows = "<tr><td><div class='EventStatusInfo'></div></td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td><a href='../Devices/Device.aspx?hostname=" & i.EventHostname & "'>" & i.EventHostname & "</a></td><td>" & i.EventClass & "</td><td>" & i.EventMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td><td>"
                End If

                Dim Row As New LiteralControl(EventRows)
                EventPlaceHolder.Controls.Add(Row)

                Dim StatusText As String = Nothing
                If EventStatus = True Then
                    StatusText = "Close"
                Else
                    StatusText = "Open"
                End If

                If User.IsInRole("Administrator") Then
                    Dim StatusButton As New Button
                    StatusButton.Text = StatusText
                    StatusButton.CssClass = "EventButton"
                    StatusButton.ID = i.EventID
                    StatusButton.CommandArgument = i.EventID
                    AddHandler StatusButton.Click, AddressOf EventButton
                    EventPlaceHolder.Controls.Add(StatusButton)
                End If



                Dim EndRow As New LiteralControl("</td></tr>")
                EventPlaceHolder.Controls.Add(EndRow)

            Next
        End If
        If EventRows = "" Then
            EventRows = "<tr><td colspan='7' style='text-align:center'>No Events</td></tr>"
            Dim NoRows As New LiteralControl(EventRows)
            EventPlaceHolder.Controls.Add(NoRows)
        End If

        Dim EndTable As New LiteralControl("</Table>")
        EventPlaceHolder.Controls.Add(EndTable)
    End Sub

    Protected Sub EventsTimer_Tick(sender As Object, e As EventArgs) Handles EventsTimer.Tick
        BuildTable()
    End Sub




    Private Sub EventButton(ByVal sender As Object, ByVal e As EventArgs)

        Dim cButton As Button = CType(sender, Button)

        Dim Q = (From T In db.AgentEvents
                 Where T.EventID = cButton.CommandArgument
                 Select T).FirstOrDefault

        If EventStatus = True Then
            Q.EventStatus = False
            db.SaveChanges()
        Else
            Q.EventStatus = True
            db.SaveChanges()
        End If
        ApplyFilter()


    End Sub


    Protected Sub OpenLinkButton_Click(sender As Object, e As EventArgs) Handles OpenLinkButton.Click
        EventStatus = True
        ApplyFilter()
    End Sub

    Protected Sub ClosedLinkButton_Click(sender As Object, e As EventArgs) Handles ClosedLinkButton.Click
        EventStatus = False
        ApplyFilter()
    End Sub



    Protected Sub AllLinkButton_Click(sender As Object, e As EventArgs) Handles AllLinkButton.Click
        EventSeverity = 3
        ApplyFilter()
    End Sub

    Protected Sub CriticalLinkButton_Click(sender As Object, e As EventArgs) Handles CriticalLinkButton.Click
        EventSeverity = 2
        ApplyFilter()
    End Sub

    Protected Sub WarningLinkButton_Click(sender As Object, e As EventArgs) Handles WarningLinkButton.Click
        EventSeverity = 1
        ApplyFilter()
    End Sub

    Protected Sub InfoLinkButton_Click(sender As Object, e As EventArgs) Handles InfoLinkButton.Click
        EventSeverity = 0
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Response.Redirect("~/Events/Default.aspx?Status=" & EventStatus & "&Severity=" & EventSeverity)
    End Sub


End Class
