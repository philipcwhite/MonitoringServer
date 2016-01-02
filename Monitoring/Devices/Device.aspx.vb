Imports MonitoringDatabase
Partial Class Devices_Device
    Inherits System.Web.UI.Page
    Private Property db As New DBModel
    Private Property QS As String = Nothing

    Private Sub Devices_Device_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Try
                QS = Request.QueryString("hostname")
                BuildTables(QS)
                HostNameLabel.Text = QS
            Catch ex As Exception

            End Try

        End If

    End Sub


    Private Sub BuildTables(ByVal AgentName As String)

        Dim AgentQ = (From T In db.AgentSystem
                      Where T.AgentName = AgentName
                      Select T).FirstOrDefault

        Dim ProcessorQ = (From T In db.AgentProcessor
                          Where T.AgentName = AgentName
                          Order By T.AgentCollectDate Descending
                          Select T).FirstOrDefault

        Dim MemoryQ = (From T In db.AgentMemory
                       Where T.AgentName = AgentName
                       Order By T.AgentCollectDate Descending
                       Select T).FirstOrDefault

        Dim LocalDiskTime As String = Nothing

        LocalDiskTime = AgentQ.AgentDate

        Dim LocalDiskQ = From T In db.AgentLocalDisk
                         Where T.AgentName = AgentName And T.AgentCollectDate = LocalDiskTime And T.AgentProperty = "Free Space (%)"
                         Select T

        Dim EventQ = (From T In db.AgentEvents
                      Where T.AgentStatus = True And T.AgentName = AgentName
                      Order By T.AgentEventDate Descending
                      Select T).Take(50)




        DevicePlaceHolder.Controls.Clear()



        Dim Break As New LiteralControl(" ")

        Dim Table1 As New LiteralControl("<table style='width: 100%'><tr><td style='padding-right:10px;padding-bottom:20px;vertical-align:top;width:50%;'>")
        DevicePlaceHolder.Controls.Add(Table1)

        Dim Table2 As New LiteralControl("<table class='StaticTable' style='width: 100%'><thead><tr><th>Device<img alt='Windows' src='../App_Themes/Monitoring/Windows.png' height='12' width='12' style='float:right;box-shadow: 1px 1px 1px #888888;' /></th></tr></thead><tr><td style='height:180px;vertical-align:top'><table>")
        DevicePlaceHolder.Controls.Add(Table2)

        Dim Table2Item1 As New LiteralControl("<tr><td style='width:10px'><div class='DivBullet' /></td><td>Hostname: " & AgentQ.AgentName & "</td></tr>")
        DevicePlaceHolder.Controls.Add(Table2Item1)

        Dim Table2Item2 As New LiteralControl("<tr><td><div class='DivBullet' /></td><td>Domain: " & AgentQ.AgentDomain & "</td></tr>")
        DevicePlaceHolder.Controls.Add(Table2Item2)

        Dim Table2Item3 As New LiteralControl("<tr><td><div class='DivBullet' /></td><td>IP Address: " & AgentQ.AgentIP & "</td></tr>")
        DevicePlaceHolder.Controls.Add(Table2Item3)

        Dim Table2Item4 As New LiteralControl("<tr><td><div class='DivBullet' /></td><td>OS: " & AgentQ.AgentOSName & " (" & AgentQ.AgentOSArchitechture & ")</td></tr>")
        DevicePlaceHolder.Controls.Add(Table2Item4)

        'Dim Table2Item5 As New LiteralControl("Build: " & AgentQ.AgentOSBuild & "<br />")
        'DevicePlaceHolder.Controls.Add(Table2Item5)

        'Dim Table2Item6 As New LiteralControl("<tr><td><div class='DivBullet' /></td><td>Architecture: " & AgentQ.AgentOSArchitechture & "</td></tr>")
        'DevicePlaceHolder.Controls.Add(Table2Item6)

        Dim Table2Item7 As New LiteralControl("<tr><td><div class='DivBullet' /></td><td>Processors: " & AgentQ.AgentProcessors & "</td></tr>")
        DevicePlaceHolder.Controls.Add(Table2Item7)

        Dim Table2Item8 As New LiteralControl("<tr><td><div class='DivBullet' /></td><td>Memory: " & AgentQ.AgentMemory & " MB </td></tr>")
        DevicePlaceHolder.Controls.Add(Table2Item8)

        Dim Table2Item9 As New LiteralControl("<tr><td><div class='DivBullet' /></td><td>Last Updated: " & AgentQ.AgentDate & "</td></tr></table>")
        DevicePlaceHolder.Controls.Add(Table2Item9)

        Dim Table2End As New LiteralControl("</td></tr></table></td><td style='padding-left: 10px;padding-bottom:20px;vertical-align:top;width:50%;'>")
        DevicePlaceHolder.Controls.Add(Table2End)

        Dim Table3 As New LiteralControl("<table class='StaticTable' style='width: 100%'><thead><tr><th>Monitors<img alt='Monitoring' src='../App_Themes/Monitoring/Graph.png' height='12' width='12' style='float:right;box-shadow: 1px 1px 1px #888888;' /></th></tr></thead><tr><td style='height:180px;vertical-align:top'>")
        DevicePlaceHolder.Controls.Add(Table3)

        Dim Table3Item1 As New LiteralControl("<table><tr><td style='width:10px'><div class='DivBullet' /></td><td><a href='Graph.aspx?hostname=" & AgentQ.AgentName & "&class=" & ProcessorQ.AgentClass & "'>Processor Total Utilization:  " & ProcessorQ.AgentValue & "%</a></td></tr>")
        DevicePlaceHolder.Controls.Add(Table3Item1)

        Dim Table3Item2 As New LiteralControl("<tr><td><div class='DivBullet' /></td><td><a href='Graph.aspx?hostname=" & AgentQ.AgentName & "&class=" & MemoryQ.AgentClass & "'>Memory Total Utilization: " & MemoryQ.AgentValue & "%</a></td></tr>")
        DevicePlaceHolder.Controls.Add(Table3Item2)

        For Each i In LocalDiskQ
            Dim Table3ItemX As New LiteralControl("<tr><td><div class='DivBullet' /></td><td><a href='Graph.aspx?hostname=" & AgentQ.AgentName & "&class=" & i.AgentClass & "'>" & i.AgentClass & " Free Space: " & i.AgentValue & "%</a></td></tr>")
            DevicePlaceHolder.Controls.Add(Table3ItemX)
        Next

        Dim Table3Item3 As New LiteralControl("<tr><td><div class='DivBullet' /></td><td>Windows Service Status</td></tr></table><br />")
        DevicePlaceHolder.Controls.Add(Table3Item3)


        Dim Table3End As New LiteralControl("</td></tr></table></td></tr><tr><td style='padding:0px' colspan='2'>")
        DevicePlaceHolder.Controls.Add(Table3End)


        Dim Table4 As New LiteralControl("<Table class='HoverTable'><thead><tr><th></th><th>Date</th><th>Severity</th><th>Hostname</th><th>Class</th><th>Message<img alt='Events' src='../App_Themes/Monitoring/Warning.png' height='12' width='12' style='float:right;box-shadow: 1px 1px 1px #888888;' /></th></tr></thead>")

        DevicePlaceHolder.Controls.Add(Table4)
        Dim Severity As String = Nothing
        If EventQ IsNot Nothing Then
            For Each i In EventQ
                If i.AgentSeverity = 3 Then
                    Severity = "Critical"
                    Dim Row As New LiteralControl("<tr><td><div class='EventStatusCritical'></div></td><td>" & i.AgentEventDate & "</td><td>" & Severity & "</td><td>" & i.AgentName & "</td><td>" & i.AgentClass & "</td><td>" & i.AgentMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>")
                    DevicePlaceHolder.Controls.Add(Row)
                ElseIf i.AgentSeverity = 2 Then
                    Severity = "Major"
                    Dim Row As New LiteralControl("<tr><td><div class='EventStatusMajor'></div></td><td>" & i.AgentEventDate & "</td><td>" & Severity & "</td><td>" & i.AgentName & "</td><td>" & i.AgentClass & "</td><td>" & i.AgentMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>")
                    DevicePlaceHolder.Controls.Add(Row)
                ElseIf i.AgentSeverity = 1 Then
                    Severity = "Minor"
                    Dim Row As New LiteralControl("<tr><td><div class='EventStatusMinor'></div></td><td>" & i.AgentEventDate & "</td><td>" & Severity & "</td><td>" & i.AgentName & "</td><td>" & i.AgentClass & "</td><td>" & i.AgentMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>")
                    DevicePlaceHolder.Controls.Add(Row)
                End If
            Next
        Else
            Dim Row As New LiteralControl("<tr><td colspan='6' style='text-align:center'>No Events</td></tr>")
            DevicePlaceHolder.Controls.Add(Row)
        End If

        Dim EndTable As New LiteralControl("</table></td><td></td></tr></table>")
        DevicePlaceHolder.Controls.Add(EndTable)
    End Sub

    Protected Sub DeviceTimer_Tick(sender As Object, e As EventArgs) Handles DeviceTimer.Tick
        Try
            QS = Request.QueryString("hostname")
            BuildTables(QS)
        Catch ex As Exception

        End Try
    End Sub
End Class
