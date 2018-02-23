Imports MonitoringDatabase
Partial Class Device
    Inherits System.Web.UI.Page

    Private Property db As New DBModel
    Private Shared Property GraphList As New List(Of GraphData)
    Private Shared Property AgentList1 As New List(Of AgentGraphData)
    Private Shared Property AgentList2 As New List(Of AgentGraphData)

    Private Sub Device_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim QS As String = Nothing
            QS = Request.QueryString("hostname")
            HostNameLabel.Text = QS
            LoadPerformanceGraph(HostNameLabel.Text)
            LoadSystemPlaceholder(HostNameLabel.Text)
            LoadDiskPlaceHolder(HostNameLabel.Text)
            LoadNetworkPlaceHolder(HostNameLabel.Text)

        End If

    End Sub

    Private Sub LoadPerformanceGraph(ByVal AgentName As String)



        Dim yValue1 As Integer = Nothing
        Dim yValue2 As Integer = Nothing
        Dim yValue3 As Integer = Nothing
        Dim yValue4 As Integer = Nothing
        Dim xLine1 As String = Nothing
        Dim xLine2 As String = Nothing
        Dim xTime As Integer = 15
        Dim xTimeStart As Date = Date.Now.AddHours(-12)
        Dim xTimeEnd As Date = Date.Now
        Dim xTimeRunning As Date = Date.Now.AddHours(-12)
        Dim xTimeText As String = Nothing
        Dim xValue1 As Integer = 30
        Dim xValue2 As Integer = 34


        Dim datepart = xTimeRunning.Date
        Dim timepart = TimeSpan.FromMinutes(Math.Floor((xTimeRunning.TimeOfDay.TotalMinutes + 2.5) / 5.0) * 5.0)
        xTimeStart = datepart.Add(timepart)
        xTimeRunning = xTimeStart
        xTimeEnd = xTimeStart.AddHours(12)

        'Initialize DataList
        GraphList.Clear()
        AgentList1.Clear()
        AgentList2.Clear()


        'Retrieve data

        Dim qs1 = From T In db.AgentData
                  Where T.AgentName = AgentName And T.AgentClass = "Processor" And T.AgentProperty = "Total Util (%)"
                  Select T

        Dim qs2 = From T In db.AgentData
                  Where T.AgentName = AgentName And T.AgentClass = "Memory" And T.AgentProperty = "Total Util (%)"
                  Select T






        'Seed AgentList

        For i = 0 To 143
            GraphList.Add(New GraphData With {.AgentName = AgentName, .AgentTime = xTimeRunning, .AgentValue1 = 0, .AgentValue2 = 0})
            xTimeRunning = xTimeRunning.AddMinutes(5)
        Next

        For Each i In qs1
                AgentList1.Add(New AgentGraphData With {.AgentTime = i.AgentCollectDate, .Value = i.AgentValue})
            Next

            For Each i In qs2
                AgentList2.Add(New AgentGraphData With {.AgentTime = i.AgentCollectDate, .Value = i.AgentValue})
            Next

        'Graph if data exists
        If AgentList1.Count > 0 Or AgentList2.Count > 0 Then

            xTimeRunning = xTimeStart

            For Each i In GraphList
                Dim Q1 = (From T In AgentList1
                          Where T.AgentTime = xTimeRunning
                          Select T.Value).FirstOrDefault
                i.AgentValue1 = Q1
                Dim Q2 = (From T In AgentList2
                          Where T.AgentTime = xTimeRunning
                          Select T.Value).FirstOrDefault
                i.AgentValue3 = Q2
                xTimeRunning = xTimeRunning.AddMinutes(5)

            Next

            For i = 0 To GraphList.Count - 2
                GraphList.Item(i).AgentValue2 = GraphList.Item(i + 1).AgentValue1
                GraphList.Item(i).AgentValue4 = GraphList.Item(i + 1).AgentValue3
            Next

            'Draw Line

            For i = 0 To GraphList.Count - 2
                yValue1 = 120 - GraphList.Item(i).AgentValue1
                yValue2 = 120 - GraphList.Item(i).AgentValue2
                yValue3 = 120 - GraphList.Item(i).AgentValue3
                yValue4 = 120 - GraphList.Item(i).AgentValue4

                xLine1 = xLine1 & "<line x1=" & xValue1 & " y1=" & yValue1 & " x2=" & xValue2 & " y2=" & yValue2 & " style='stroke:#6BD5C3;stroke-width:1'/>"
                xLine2 = xLine2 & "<line x1=" & xValue1 & " y1=" & yValue3 & " x2=" & xValue2 & " y2=" & yValue4 & " style='stroke:#A9DC8E;stroke-width:1'/>"

                xValue1 = xValue1 + 4
                xValue2 = xValue2 + 4
            Next

            'Y Axis Text
            Dim SVGyAxisText As String = Nothing
            Dim SVGyAxisTextY As Integer = Nothing
            Dim SVGyAxisTextVal As Integer = Nothing

            SVGyAxisTextY = 25
            SVGyAxisTextVal = 100
            For i = 0 To 2
                SVGyAxisText = SVGyAxisText & "<text x='1' y='" & SVGyAxisTextY & "' fill='#7992BF' font-size='9' font-family='arial'>" & SVGyAxisTextVal & "</text>"
                SVGyAxisTextY += 50
                SVGyAxisTextVal -= 50
            Next

            'Build X Axis
            xTimeRunning = xTimeStart
            For i = 0 To 12
                xTimeText = xTimeText & "<text x=" & xTime & " y='140' fill='#7992BF' font-size='9' font-family='arial'>" & xTimeRunning.ToString("h:mmtt") & "</text>"
                xTimeRunning = xTimeRunning.AddMinutes(60)
                xTime = xTime + 48
            Next

            'Build Grid
            Dim SVGGridLine As String = Nothing
            Dim SVGGridTextY As Integer = 120
            For i = 0 To 2
                SVGGridLine = SVGGridLine & "<line x1 = '30' y1='" & SVGGridTextY & "' x2='606' y2='" & SVGGridTextY & "' style='stroke: #eeeeee;stroke-width:0.5' />"
                SVGGridTextY -= 50
            Next

            Dim SVGGridTextX As Integer = 30
            For i = 0 To 12
                SVGGridLine = SVGGridLine & "<line x1 = '" & SVGGridTextX & "' y1='120' x2='" & SVGGridTextX & "' y2='20' style='stroke:#eeeeee;stroke-width:0.5' />"
                SVGGridTextX += 48
            Next

            Dim SVGxLine1 As New LiteralControl(xLine1)
            Dim SVGxLine2 As New LiteralControl(xLine2)
            Dim SVGStart As New LiteralControl("<svg height='150' width='630'>")
            Dim SVGyAxis As New LiteralControl(SVGyAxisText)
            Dim SVGGrid As New LiteralControl(SVGGridLine)
            Dim SVGxTimeText As New LiteralControl(xTimeText)
            Dim SVGEnd As New LiteralControl("</svg>")

            Dim TableStart As New LiteralControl("<table class='StaticTable' style='width:100%'><thead><tr><th>" & AgentName & ": Performance" &
            "</th></tr></thead><tr><td style='width: 100%;padding-right:40px;padding-left:40px;text-align:center'><div style='width=100%;text-align:center'><table style='width:790px;margin:auto'><tr><td>")
            Dim TableEnd As New LiteralControl("</td></tr></table></div></td></tr></table>")
            Dim ContentInfoBox As New LiteralControl("</td><td><table style='width: 120px'><tr><td style='width:15px'><img src='../App_Themes/Monitoring/box-aqua.png' style='height:8px;width:8px;' /></td><td>" & GraphList.Item(143).AgentValue1.ToString & "% Processor</td></tr><tr>" &
    "<td style='width:15px'><img src='../App_Themes/Monitoring/box-green.png' style='height:8px;width:8px;' /></td><td>" & GraphList.Item(143).AgentValue3.ToString & "% Memory</td></tr>" &
    "</table>")

            PerformancePlaceHolder.Controls.Add(TableStart)
            PerformancePlaceHolder.Controls.Add(SVGStart)
            PerformancePlaceHolder.Controls.Add(SVGyAxis)
            PerformancePlaceHolder.Controls.Add(SVGGrid)
            PerformancePlaceHolder.Controls.Add(SVGxTimeText)
            PerformancePlaceHolder.Controls.Add(SVGxLine2)
            PerformancePlaceHolder.Controls.Add(SVGxLine1)
            PerformancePlaceHolder.Controls.Add(SVGEnd)
            PerformancePlaceHolder.Controls.Add(ContentInfoBox)
            PerformancePlaceHolder.Controls.Add(TableEnd)

        End If

    End Sub


    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadPerformanceGraph(HostNameLabel.Text)
        LoadSystemPlaceholder(HostNameLabel.Text)
        LoadDiskPlaceHolder(HostNameLabel.Text)
        LoadNetworkPlaceHolder(HostNameLabel.Text)
    End Sub

    Private Sub LoadSystemPlaceholder(ByVal AgentName As String)
        Try

            Dim AgentQ = (From T In db.AgentSystem
                      Where T.AgentName = AgentName
                      Select T).FirstOrDefault

        SystemPlaceHolder.Controls.Clear()

        Dim LayoutStart As String = "<table class='StaticTable' style='width:100%'><thead><tr><th>" & AgentName & ": System" &
            "</th></tr></thead><tr><td style='width:100%;padding-right:40px;padding-left:40px;text-align:center'><div style='width=100%;text-align:center'><table style='width:790px;margin:auto;'>"
        Dim LayoutEnd As String = "</table></td></tr></table>"

        Dim LayoutPanel As String = Nothing

        Dim Time As TimeSpan = TimeSpan.FromSeconds(AgentQ.AgentUptime)
        Dim Uptime = Time.ToString

        LayoutPanel = "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td style='width:110px'>Operating System:</td><td style='width:320px'>" & AgentQ.AgentOSName & " (" & AgentQ.AgentOSArchitecture & ")</td><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td style='width:100px'>Processors:</td><td style='width:100px'>" & AgentQ.AgentProcessors & "</td></tr>" &
                      "<tr><td><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>IPv4 Address:</td><td>" & AgentQ.AgentIP & "</td><td><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>Memory:</td><td>" & AgentQ.AgentMemory & " MB </td></tr>" &
                      "<tr><td><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>Domain:</td><td>" & AgentQ.AgentDomain & "</td><td><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>Uptime:</td><td>" & Uptime & "</td></tr>"

        Dim LC As New LiteralControl(LayoutStart & LayoutPanel & LayoutEnd)
        SystemPlaceHolder.Controls.Add(LC)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDiskPlaceHolder(ByVal AgentName As String)

        Dim PageFileQ = (From T In db.AgentData
                         Where T.AgentName = AgentName And T.AgentClass = "PageFile" And T.AgentProperty = "Total Util (%)"
                         Order By T.AgentCollectDate Descending
                         Select T).FirstOrDefault

        Dim LocalDiskQ1 = (From T In db.AgentData
                           Where T.AgentName = AgentName And T.AgentClass.Contains("Local Disk")
                           Order By T.AgentCollectDate Descending
                           Select T.AgentCollectDate).FirstOrDefault

        Dim LocalDiskList As New List(Of AgentLocalDisk)
        Dim LocalDiskTime As String = Nothing

        Try
            If Not LocalDiskQ1 Is Nothing Then
                LocalDiskTime = LocalDiskQ1
            End If

            Dim LocalDiskQ2 = From T In db.AgentData
                              Where T.AgentName = AgentName And T.AgentCollectDate = LocalDiskTime And T.AgentClass.Contains("Local Disk")
                              Order By T.AgentClass, T.AgentProperty Ascending
                              Select T


            For Each i In LocalDiskQ2
                LocalDiskList.Add(New AgentLocalDisk With {.AgentClass = i.AgentClass, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
            Next
        Catch ex As Exception
        End Try

        Dim LayoutStart As String = "<table class='StaticTable' style='width:100%'><thead><tr><th>" & AgentName & ": Disk" &
            "</th></tr></thead><tr><td style='width:100%;padding-right:40px;padding-left:40px;text-align:center'><div style='width=100%;text-align:center'><table style='width:790px;margin:auto;'>"
        Dim LayoutEnd As String = "</table></td></tr></table>"

        Dim LayoutPanel As String = Nothing

        Try
            LayoutPanel = LayoutPanel & "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td style='width:250px'>Windows Pagefile</td><td style='width:250px'>Pagefile Utilization</td><td style='text-align:center'>" & PageFileQ.AgentValue & "% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>"
        Catch
        End Try

        Try

            If LocalDiskList.Count > 0 Then
                For i = 0 To LocalDiskList.Count - 1 Step 2
                    LayoutPanel = LayoutPanel & "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td style='width:250px'>" & LocalDiskList.Item(i).AgentClass & "</td><td style='width:250px'>Active Disk Time</td><td style='text-align:center'>" & LocalDiskList.Item(i).AgentValue & "% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>"
                    LayoutPanel = LayoutPanel & "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td style='width:250px'>" & LocalDiskList.Item(i).AgentClass & "</td><td style='width:250px'>Total Free Space</td><td style='text-align:center'>" & LocalDiskList.Item(i + 1).AgentValue & "% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>"
                Next
                Dim LC As New LiteralControl(LayoutStart & LayoutPanel & LayoutEnd)
                DiskPlaceHolder.Controls.Add(LC)
            End If

        Catch ex As Exception
        End Try



    End Sub



    Private Sub LoadNetworkPlaceHolder(ByVal AgentName As String)

        Dim NetworkQ1 = (From T In db.AgentData
                             Where T.AgentName = AgentName And T.AgentClass.Contains("Network") And T.AgentProperty.Contains("Total KB/s Received")
                             Order By T.AgentCollectDate Descending
                             Select T).FirstOrDefault

        Dim NetworkQ2 = (From T In db.AgentData
                         Where T.AgentName = AgentName And T.AgentClass.Contains("Network") And T.AgentProperty.Contains("Total KB/s Sent")
                         Order By T.AgentCollectDate Descending
                         Select T).FirstOrDefault

        Dim LayoutStart As String = "<table class='StaticTable' style='width:100%'><thead><tr><th>" & AgentName & ": Network" &
                "</th></tr></thead><tr><td style='width:100%;padding-right:40px;padding-left:40px;text-align:center'><div style='width=100%;text-align:center'><table style='width:790px;margin:auto;'>"
            Dim LayoutEnd As String = "</table></td></tr></table>"

            Dim LayoutPanel As String = Nothing

        Try
            LayoutPanel = LayoutPanel & "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td style='width:250px'>Network Data</td><td style='width:250px'>" & NetworkQ1.AgentProperty & "</td><td style='text-align:center'>" & NetworkQ1.AgentValue & " KB &nbsp;&nbsp;</td></tr>"
            LayoutPanel = LayoutPanel & "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td style='width:250px'>Network Data</td><td style='width:250px'>" & NetworkQ2.AgentProperty & "</td><td style='text-align:center'>" & NetworkQ2.AgentValue & " KB &nbsp;&nbsp;</td></tr>"
            Dim LC As New LiteralControl(LayoutStart & LayoutPanel & LayoutEnd)
            NetworkPlaceHolder.Controls.Add(LC)
        Catch
        End Try



    End Sub




    Protected Sub ServicesButton_Click(sender As Object, e As EventArgs) Handles ServicesButton.Click
        Response.Redirect("Services.aspx?hostname=" & HostNameLabel.Text)
    End Sub
    Protected Sub ThresholdButton_Click(sender As Object, e As EventArgs) Handles ThresholdButton.Click
        Response.Redirect("~/Config/Thresholds/AgentThreshold.aspx?hostname=" & HostNameLabel.Text)
    End Sub

    Private Sub Device_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If User.IsInRole("Administrator") Then
            ThresholdButton.Visible = True
        End If
    End Sub




End Class


Public Class GraphData
    Public Property AgentName As String
    Public Property AgentTime As String
    Public Property AgentValue1 As Integer
    Public Property AgentValue2 As Integer
    Public Property AgentValue3 As Integer
    Public Property AgentValue4 As Integer
End Class

Public Class AgentGraphData
    Public Property AgentTime As String
    Public Property Value As Integer
End Class