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


            If User.IsInRole("Administrator") Then
                ThresholdButton.Visible = True
            End If

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

        Dim PageFileQ = (From T In db.AgentPageFile
                         Where T.AgentName = AgentName
                         Order By T.AgentCollectDate Descending
                         Select T).FirstOrDefault

        Dim LocalDiskTime As String = Nothing

        LocalDiskTime = AgentQ.AgentDate
        Dim CurrentDate As Date = AgentQ.AgentDate


        Dim LocalDiskQ = From T In db.AgentLocalDisk
                         Where T.AgentName = AgentName And T.AgentCollectDate = LocalDiskTime
                         Order By T.AgentClass, T.AgentProperty Ascending
                         Select T

        Dim LocalDiskList As New List(Of AgentLocalDisk)
        For Each i In LocalDiskQ
            LocalDiskList.Add(New AgentLocalDisk With {.AgentClass = i.AgentClass, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next

        Dim EventQ = (From T In db.AgentEvents
                      Where T.EventHostname = AgentName And T.EventStatus = True
                      Order By T.EventDate Descending
                      Select T).Take(50)

        DevicePlaceHolder.Controls.Clear()

        Dim Layout1 As String = "<table style='width: 100%'>" &
                                "<tr><td style='padding-right:10px;padding-bottom:20px;vertical-align:top;width:50%;'>" &
                                "<table class='StaticTable' style='width: 100%'>" &
                                "<thead><tr><th>Device</th></tr></thead>" &
                                "<tr><td style='height:160px;vertical-align:top'><table>"
        Dim LayoutPanelLeft As String = Nothing
        Dim Layout2 As String = "</table></td><td style='padding-left: 10px;padding-bottom:20px;vertical-align:top;width:50%;'>" &
                                "<table class='StaticTable' style='width: 100%'>" &
                                "<thead><tr><th>Monitors</th></tr></thead>" &
                                "<tr><td style='height:160px;vertical-align:top'><table>"
        Dim LayoutPanelRight As String = Nothing
        Dim Layout3 As String = "</table><br/></td></tr></table></td></tr>" &
                                "<tr><td style='padding:0px' colspan='2'>" &
                                "<table class='HoverTable'>" &
                                "<thead><tr><th></th><th>Date</th><th>Severity</th><th>Hostname</th><th>Class</th><th>Message</th></tr></thead>"
        Dim LayoutPanelBottom As String = Nothing
        Dim Layout4 As String = "</table></td><td></td></tr></table>"


        LayoutPanelLeft = "<tr><td style='width:10px'><div class='DivBullet'/></td><td>Hostname:</td><td>" & AgentQ.AgentName & "</td></tr>" &
                          "<tr><td><div class='DivBullet'/></td><td>Domain:</td><td>" & AgentQ.AgentDomain & "</td></tr>" &
                          "<tr><td><div class='DivBullet'/></td><td>IP Address:</td><td>" & AgentQ.AgentIP & "</td></tr>" &
                          "<tr><td><div class='DivBullet'/></td><td>Operating System:</td><td>" & AgentQ.AgentOSName & " (" & AgentQ.AgentOSArchitecture & ")</td></tr>" &
                          "<tr><td><div class='DivBullet'/></td><td>Processors:</td><td>" & AgentQ.AgentProcessors & "</td></tr>" &
                          "<tr><td><div class='DivBullet'/></td><td>Memory:</td><td>" & AgentQ.AgentMemory & " MB </td></tr>" &
                          "<tr><td><div class='DivBullet'/></td><td>Last Updated:</td><td>" & CurrentDate.ToString("M/dd/yyyy h:mm tt") & "</td></tr></table>"

        Try
            LayoutPanelRight = "<tr><td style='width:10px'><div class='DivBullet'/></td><td>Processor</td><td><a href='Graph.aspx?hostname=" & AgentQ.AgentName & "&class=" & ProcessorQ.AgentClass & "'>Total Utilization</a></td><td style='text-align:center'>" & ProcessorQ.AgentValue & "%</td></tr>"
        Catch
            LayoutPanelRight = "<tr><td style='width:10px'><div class='DivBullet'/></td><td>Processor</td><td colspan=2>No Data</td></tr>"
        End Try

        Try
            LayoutPanelRight = LayoutPanelRight & "<tr><td><div class='DivBullet'/></td><td>Memory</td><td><a href='Graph.aspx?hostname=" & AgentQ.AgentName & "&class=" & MemoryQ.AgentClass & "'>Total Utilization</a></td><td style='text-align:center'>" & MemoryQ.AgentValue & "%</td></tr>"
        Catch
            LayoutPanelRight = LayoutPanelRight & "<tr><td style='width:10px'><div class='DivBullet'/></td><td>Memory</td><td colspan=2>No Data</td></tr>"
        End Try

        Try
            LayoutPanelRight = LayoutPanelRight & "<tr><td><div class='DivBullet'/></td><td>Pagefile</td><td><a href='Graph.aspx?hostname=" & AgentQ.AgentName & "&class=" & PageFileQ.AgentClass & "'>Total Utilization</a></td><td style='text-align:center'>" & PageFileQ.AgentValue & "%</td></tr>"
        Catch
            LayoutPanelRight = LayoutPanelRight & "<tr><td style='width:10px'><div class='DivBullet'/></td><td>Pagefile</td><td colspan=2>No Data</td></tr>"
        End Try

        Try
            For i = 0 To LocalDiskList.Count - 1 Step 2
                LayoutPanelRight = LayoutPanelRight & "<tr><td><div class='DivBullet'/></td><td>" & LocalDiskList.Item(i).AgentClass & "</td><td><a href='Graph.aspx?hostname=" & AgentQ.AgentName & "&class=" & LocalDiskList.Item(i).AgentClass & ";" & LocalDiskList.Item(i).AgentProperty & "'>Active Time</a> | <a href='Graph.aspx?hostname=" & AgentQ.AgentName & "&class=" & LocalDiskList.Item(i).AgentClass & ";" & LocalDiskList.Item(i + 1).AgentProperty & "'>Free Space</a></td><td style='text-align:center'>" & LocalDiskList.Item(i).AgentValue & "% | " & LocalDiskList.Item(i + 1).AgentValue & "%</td></tr>"
            Next
        Catch
        End Try

        Dim Severity As String = Nothing

        If EventQ IsNot Nothing Then
            For Each i In EventQ
                Dim FormattedDate As Date = i.EventDate
                If i.EventSeverity = 2 Then
                    Severity = "Critical"
                    LayoutPanelBottom = LayoutPanelBottom & "<tr><td><div class='EventStatusCritical'></div></td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td>" & i.EventHostname & "</td><td>" & i.EventClass & "</td><td>" & i.EventMessage.Replace(">", "&gt; ").Replace("<", " &lt;") & "</td></tr>"
                ElseIf i.EventSeverity = 1 Then
                    Severity = "Warning"
                    LayoutPanelBottom = LayoutPanelBottom & "<tr><td><div class='EventStatusWarning'></div></td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td>" & i.EventHostname & "</td><td>" & i.EventClass & "</td><td>" & i.EventMessage.Replace(">", "&gt; ").Replace("<", " &lt;") & "</td></tr>"
                ElseIf i.EventSeverity = 0 Then
                    Severity = "Informational"
                    LayoutPanelBottom = LayoutPanelBottom & "<tr><td><div class='EventStatusInfo'></div></td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td>" & i.EventHostname & "</td><td>" & i.EventClass & "</td><td>" & i.EventMessage.Replace(">", "&gt; ").Replace("<", " &lt;") & "</td></tr>"

                ElseIf EventQ Is Nothing Then
                    LayoutPanelBottom = "<tr><td colspan='6' style='text-align:center'>No Events</td></tr>"

                End If
            Next
        End If

        If LayoutPanelBottom = "" Then
            LayoutPanelBottom = "<tr><td colspan='6' style='text-align:center'>No Events</td></tr>"
        End If

        Dim LC As New LiteralControl(Layout1 & LayoutPanelLeft & Layout2 & LayoutPanelRight & Layout3 & LayoutPanelBottom & Layout4)
        DevicePlaceHolder.Controls.Add(LC)

    End Sub

    Protected Sub DeviceTimer_Tick(sender As Object, e As EventArgs) Handles DeviceTimer.Tick
        Try
            QS = Request.QueryString("hostname")
            BuildTables(QS)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ThresholdButton_Click(sender As Object, e As EventArgs) Handles ThresholdButton.Click
        QS = Request.QueryString("hostname")
        Response.Redirect("~/Config/Thresholds/AgentThreshold.aspx?hostname=" & QS)
    End Sub

    Protected Sub ServicesButton_Click(sender As Object, e As EventArgs) Handles ServicesButton.Click
        QS = Request.QueryString("hostname")
        Response.Redirect("~/Devices/Services.aspx?hostname=" & QS)
    End Sub

End Class
