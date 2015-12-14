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

        Dim LogicalDiskQ1 = (From T In db.AgentLogicalDisk
                             Where T.AgentName = AgentName
                             Order By T.AgentCollectDate Descending
                             Select T.AgentCollectDate).FirstOrDefault

        Dim LogicalDiskTime As String = LogicalDiskQ1

        Dim LogicalDiskQ2 = From T In db.AgentLogicalDisk
                            Where T.AgentName = AgentName And T.AgentCollectDate = LogicalDiskTime
                            Select T

        Dim EventQ = (From T In db.AgentEvents
                      Where T.AgentStatus = True And T.AgentName = AgentName
                      Order By T.AgentEventDate Descending
                      Select T).Take(50)




        DevicePlaceHolder.Controls.Clear()






        Dim Break As New LiteralControl(" ")

        Dim Table1 As New LiteralControl("<table style='width: 100%'><tr><td style='padding:10px;vertical-align:top'>")
        DevicePlaceHolder.Controls.Add(Table1)

        Dim Table2 As New LiteralControl("<table class='DeviceTable' style='width: 100%'><thead><tr><th>Device</th></tr></thead><tr><td>")
        DevicePlaceHolder.Controls.Add(Table2)

        Dim Table2Item1 As New LiteralControl("Hostname: " & AgentQ.AgentName & "<br />")
        DevicePlaceHolder.Controls.Add(Table2Item1)

        Dim Table2Item2 As New LiteralControl("Domain: " & AgentQ.AgentDomain & "<br />")
        DevicePlaceHolder.Controls.Add(Table2Item2)

        Dim Table2Item3 As New LiteralControl("IP Address: " & AgentQ.AgentIP & "<br />")
        DevicePlaceHolder.Controls.Add(Table2Item3)

        Dim Table2Item4 As New LiteralControl("OS: " & AgentQ.AgentOSName & "<br />")
        DevicePlaceHolder.Controls.Add(Table2Item4)

        Dim Table2Item5 As New LiteralControl("Build: " & AgentQ.AgentOSBuild & "<br />")
        DevicePlaceHolder.Controls.Add(Table2Item5)

        Dim Table2Item6 As New LiteralControl("Architecture: " & AgentQ.AgentOSArchitechture & "<br />")
        DevicePlaceHolder.Controls.Add(Table2Item6)

        Dim Table2Item7 As New LiteralControl("Processors: " & AgentQ.AgentProcessors & "<br />")
        DevicePlaceHolder.Controls.Add(Table2Item7)

        Dim Table2Item8 As New LiteralControl("Memory: " & AgentQ.AgentMemory & " MB <br />")
        DevicePlaceHolder.Controls.Add(Table2Item8)

        Dim Table2Item9 As New LiteralControl("Last Updated: " & AgentQ.AgentDate & "<br />")
        DevicePlaceHolder.Controls.Add(Table2Item9)

        Dim Table2End As New LiteralControl("</td></tr></table></td><td style='padding: 10px;vertical-align:top'>")
        DevicePlaceHolder.Controls.Add(Table2End)

        Dim Table3 As New LiteralControl("<table class='DeviceTable' style='width: 100%'><thead><tr><th>Monitors</th></tr></thead><tr><td>")
        DevicePlaceHolder.Controls.Add(Table3)

        Dim Table3Item1 As New LiteralControl(ProcessorQ.AgentClass & " " & ProcessorQ.AgentProperty & " " & ProcessorQ.AgentValue & " <img alt='Graph' src='../App_Themes/Monitoring/GraphIcon.png' height='12' width='21' /><br />")
        DevicePlaceHolder.Controls.Add(Table3Item1)

        Dim Table3Item2 As New LiteralControl(MemoryQ.AgentClass & " " & MemoryQ.AgentProperty & " " & MemoryQ.AgentValue & " <img alt='Graph' src='../App_Themes/Monitoring/GraphIcon.png' height='12' width='21' /><br />")
        DevicePlaceHolder.Controls.Add(Table3Item2)

        For Each i In LogicalDiskQ2
            Dim Table3ItemX As New LiteralControl(i.AgentClass & " " & i.AgentProperty & " " & i.AgentValue & " <img alt='Graph' src='../App_Themes/Monitoring/GraphIcon.png' height='12' width='21' /><br />")
            DevicePlaceHolder.Controls.Add(Table3ItemX)
        Next

        Dim Table3Item3 As New LiteralControl("Windows Service Status")
        DevicePlaceHolder.Controls.Add(Table3Item3)


        Dim Table3End As New LiteralControl("</td></tr></table></td></tr><tr><td style='padding:10px' colspan='2'>")
        DevicePlaceHolder.Controls.Add(Table3End)


        Dim Table4 As New LiteralControl("<Table class='EventTable'><thead><tr><th></th><th>Date</th><th>Severity</th><th>Hostname</th><th>Class</th><th>Message</th></tr></thead>")

        DevicePlaceHolder.Controls.Add(Table4)

        For Each i In EventQ
            If i.AgentSeverity = "Critical" Then
                Dim Row As New LiteralControl("<tr><td><div class='EventStatusCritical'></div></td><td>" & i.AgentEventDate & "</td><td>" & i.AgentSeverity & "</td><td>" & i.AgentName & "</td><td>" & i.AgentClass & "</td><td>" & i.AgentMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>")
                DevicePlaceHolder.Controls.Add(Row)
            ElseIf i.AgentSeverity = "Major"
                Dim Row As New LiteralControl("<tr><td><div class='EventStatusMajor'></div></td><td>" & i.AgentEventDate & "</td><td>" & i.AgentSeverity & "</td><td>" & i.AgentName & "</td><td>" & i.AgentClass & "</td><td>" & i.AgentMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>")
                DevicePlaceHolder.Controls.Add(Row)
            ElseIf i.AgentSeverity = "Minor"
                Dim Row As New LiteralControl("<tr><td><div class='EventStatusMinor'></div></td><td>" & i.AgentEventDate & "</td><td>" & i.AgentSeverity & "</td><td>" & i.AgentName & "</td><td>" & i.AgentClass & "</td><td>" & i.AgentMessage.Replace(">", "&gt; ").Replace("<", "&lt;") & "</td></tr>")
                DevicePlaceHolder.Controls.Add(Row)
            End If
        Next
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
