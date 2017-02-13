Imports MonitoringDatabase
Partial Class Device
    Inherits System.Web.UI.Page

    Private Property db As New DBModel
    Private Shared Property DataList1 As New List(Of AgentData)
    Private Shared Property DataList2 As New List(Of AgentData)

    Private Sub Device_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim QS As String = Nothing
            QS = Request.QueryString("hostname")
            HostNameLabel.Text = QS
            LoadPerformanceGraph(HostNameLabel.Text)
            LoadSystemPlaceholder(HostNameLabel.Text)
            LoadDiskPlaceHolder(HostNameLabel.Text)

        End If

    End Sub

    Private Sub LoadPerformanceGraph(ByVal AgentName As String)

        Dim Duration As Integer = 60
        Dim StartTime As Date = Date.Now
        Dim yValue1 As Integer = Nothing
        Dim yValue2 As Integer = Nothing
        Dim SVGxLine1 As String = Nothing
        Dim SVGxLine2 As String = Nothing
        Dim xTime As Integer = 35
        Dim xTimeStart As Date = Nothing
        Dim xDateTimeStart As Date = Nothing
        Dim xTimeIncrement As Integer = 1
        Dim SVGxTimeText As String = Nothing
        Dim xValue1 As Integer = 50
        Dim xValue2 As Integer = 60

        'Initialize DataList
        DataList1.Clear()
        DataList2.Clear()

        xTimeStart = RoundTime1Min(StartTime.AddMinutes(-Duration))
        xDateTimeStart = RoundTime1Min(StartTime.AddMinutes(-Duration))

        For i = 0 To 12
            SVGxTimeText = SVGxTimeText & "<text x=" & xTime & " y='130' fill='#95A8CC' font-size='9' font-family='arial'>" & xDateTimeStart.ToString("h:mmtt") & "</text>"
            xDateTimeStart = xDateTimeStart.AddMinutes(5)
            xTime = xTime + 50
        Next

        For i = 0 To 60
            DataList1.Add(New AgentData With {.AgentName = AgentName, .AgentTime = xTimeStart, .AgentValue1 = 0, .AgentValue2 = 0})
            DataList2.Add(New AgentData With {.AgentName = AgentName, .AgentTime = xTimeStart, .AgentValue1 = 0, .AgentValue2 = 0})
            xTimeStart = xTimeStart.AddMinutes(xTimeIncrement)
        Next

        For Each i In DataList1
            Dim Q = (From T In db.AgentProcessor
                     Where T.AgentCollectDate = i.AgentTime And T.AgentName = i.AgentName
                     Select T).FirstOrDefault
            If Q IsNot Nothing Then
                i.AgentValue1 = Q.AgentValue
            End If
        Next
        For i = 0 To DataList1.Count - 2
            DataList1.Item(i).AgentValue2 = DataList1.Item(i + 1).AgentValue1
        Next

        For Each i In DataList2
            Dim Q = (From T In db.AgentMemory
                     Where T.AgentCollectDate = i.AgentTime And T.AgentName = i.AgentName
                     Select T).FirstOrDefault
            If Q IsNot Nothing Then
                i.AgentValue1 = Q.AgentValue
            End If
        Next
        For i = 0 To DataList2.Count - 2
            DataList2.Item(i).AgentValue2 = DataList2.Item(i + 1).AgentValue1
        Next

        For i = 0 To DataList1.Count - 2
            yValue1 = 110 - DataList1.Item(i).AgentValue1
            yValue2 = 110 - DataList1.Item(i).AgentValue2
            SVGxLine1 = SVGxLine1 & "<line x1=" & xValue1 & " y1=" & yValue1 & " x2=" & xValue2 & " y2=" & yValue2 & " style='stroke:#6BD5C3;stroke-width:2'/>"
            xValue1 = xValue1 + 10
            xValue2 = xValue2 + 10
        Next

        xValue1 = 50
        xValue2 = 60

        For i = 0 To DataList2.Count - 2
            yValue1 = 110 - DataList2.Item(i).AgentValue1
            yValue2 = 110 - DataList2.Item(i).AgentValue2
            SVGxLine2 = SVGxLine2 & "<line x1=" & xValue1 & " y1=" & yValue1 & " x2=" & xValue2 & " y2=" & yValue2 & " style='stroke:#A9DC8E;stroke-width:2'/>"
            xValue1 = xValue1 + 10
            xValue2 = xValue2 + 10
        Next

        Dim SVGStart As String = "<svg height='150' width='670'>"
        Dim SVGyAxis As String = "<line x1='50' y1='10' x2='50' y2='115' style='stroke:#7992BF;stroke-width:1' />" &
            "<line x1 ='45' y1='10' x2='50' y2='10' style='stroke:#7992BF;stroke-width:1' />" &
            "<line x1='45' y1='35' x2='50' y2='35' style='stroke:#7992BF;stroke-width:1'/>" &
            "<line x1='45' y1='60' x2='50' y2='60' style='stroke:#7992BF;stroke-width:1'/>" &
            "<line x1='45' y1='85' x2='50' y2='85' style='stroke:#7992BF;stroke-width:1'/>" &
            "<text x='20' y='13' fill='#95A8CC' font-size='9' font-family='arial'>100</text>" &
            "<text x='25' y='38' fill='#95A8CC' font-size='9' font-family='arial'>75</text>" &
            "<text x='25' y='63' fill='#95A8CC' font-size='9' font-family='arial'>50</text>" &
            "<text x='25' y='88' fill='#95A8CC' font-size='9' font-family='arial'>25</text>" &
            "<text x='30' y='113' fill='#95A8CC' font-size='9' font-family='arial'>0</text>"
        Dim SVGxAxis As String = "<line x1 = '45' y1='110' x2='650' y2='110' style='stroke:#7992BF;stroke-width:1' />" &
            "<line x1 = '100' y1='110' x2='100' y2='115' style='stroke:#7992BF;stroke-width:1'/>" &
            "<line x1 = '150' y1='110' x2='150' y2='115' style='stroke:#7992BF;stroke-width:1'/>" &
            "<line x1 = '200' y1='110' x2='200' y2='115' style='stroke:#7992BF;stroke-width:1' />" &
            "<line x1 = '250' y1='110' x2='250' y2='115' style='stroke:#7992BF;stroke-width:1'/>" &
            "<line x1 = '300' y1='110' x2='300' y2='115' style='stroke:#7992BF;stroke-width:1' />" &
            "<line x1 = '350' y1='110' x2='350' y2='115' style='stroke:#7992BF;stroke-width:1'/>" &
            "<line x1 = '400' y1='110' x2='400' y2='115' style='stroke:#7992BF;stroke-width:1' />" &
            "<line x1 = '450' y1='110' x2='450' y2='115' style='stroke:#7992BF;stroke-width:1'/>" &
            "<line x1 = '500' y1='110' x2='500' y2='115' style='stroke:#7992BF;stroke-width:1' />" &
            "<line x1 = '550' y1='110' x2='550' y2='115' style='stroke:#7992BF;stroke-width:1'/>" &
            "<line x1 = '600' y1='110' x2='600' y2='115' style='stroke:#7992BF;stroke-width:1' />" &
            "<line x1 = '650' y1='110' x2='650' y2='115' style='stroke:#7992BF;stroke-width:1' />"
        Dim SVGGrid As String = "<line x1 = '50' y1='10' x2='650' y2='10' style='stroke: #eeeeee;stroke-width:1' />" &
            "<line x1 = '50' y1='35' x2='650' y2='35' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '50' y1='60' x2='650' y2='60' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '50' y1='85' x2='650' y2='85' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '100' y1='10' x2='100' y2='110' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '150' y1='10' x2='150' y2='110' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '200' y1='10' x2='200' y2='110' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '250' y1='10' x2='250' y2='110' style='stroke:#eeeeee;stroke-width:1'/>" &
            "<line x1 = '300' y1='10' x2='300' y2='110' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '350' y1='10' x2='350' y2='110' style='stroke:#eeeeee;stroke-width:1'/>" &
            "<line x1 = '400' y1='10' x2='400' y2='110' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '450' y1='10' x2='450' y2='110' style='stroke:#eeeeee;stroke-width:1'/>" &
            "<line x1 = '500' y1='10' x2='500' y2='110' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '550' y1='10' x2='550' y2='110' style='stroke:#eeeeee;stroke-width:1'/>" &
            "<line x1 = '600' y1='10' x2='600' y2='110' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '650' y1='10' x2='650' y2='110' style='stroke:#eeeeee;stroke-width:1' />"

        Dim SVGEnd As String = "</svg>"

        Dim TableStart As String = "<table class='StaticTable' style='width:100%'><thead><tr><th>" & AgentName & ": Performance" &
            "</th></tr></thead><tr><td style='width: 100%;padding-right:40px;padding-left:40px;text-align:center'><div style='width=100%;text-align:center'><table style='width:790px;margin:auto'><tr><td>"
        Dim TableEnd As String = "</td></tr></table></div></td></tr></table>"
        Dim ContentInfoBox As String = "</td><td><table style='width: 120px'><tr><td style='width:15px'><img src='../App_Themes/Monitoring/box-aqua.png' style='height:8px;width:8px;' /></td><td>" & DataList1.Item(60).AgentValue1.ToString & "% Processor</td></tr><tr>" &
    "<td style='width:15px'><img src='../App_Themes/Monitoring/box-green.png' style='height:8px;width:8px;' /></td><td>" & DataList2.Item(60).AgentValue1.ToString & "% Memory</td></tr>" &
    "</table>"

        Dim LC As New LiteralControl(TableStart & SVGStart & SVGxAxis & SVGyAxis & SVGGrid & SVGxTimeText & SVGxLine2 & SVGxLine1 & SVGEnd & ContentInfoBox & TableEnd)
        PerformancePlaceHolder.Controls.Add(LC)

    End Sub

    Private Function RoundTime1Min(ByVal StartTime As Date) As Date
        Dim MyDateTime = StartTime
        Dim DatePart = MyDateTime.Date
        Dim TimePart = MyDateTime.TimeOfDay
        TimePart = TimeSpan.FromMinutes(Math.Floor(TimePart.TotalMinutes))
        Dim NewTime = DatePart.Add(TimePart)
        Return NewTime
    End Function

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadPerformanceGraph(HostNameLabel.Text)
        LoadSystemPlaceholder(HostNameLabel.Text)
        LoadDiskPlaceHolder(HostNameLabel.Text)
    End Sub

    Private Sub LoadSystemPlaceholder(ByVal AgentName As String)

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
                      "<tr><td><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>Domain</td><td>" & AgentQ.AgentDomain & "</td><td><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>Uptime:</td><td>" & Uptime & "</td></tr>"

        Dim LC As New LiteralControl(LayoutStart & LayoutPanel & LayoutEnd)
        SystemPlaceHolder.Controls.Add(LC)

    End Sub

    Private Sub LoadDiskPlaceHolder(ByVal AgentName As String)

        Dim PageFileQ = (From T In db.AgentPageFile
                         Where T.AgentName = AgentName
                         Order By T.AgentCollectDate Descending
                         Select T).FirstOrDefault

        Dim LocalDiskQ1 = (From T In db.AgentLocalDisk
                           Where T.AgentName = AgentName
                           Order By T.AgentCollectDate Descending
                           Select T).FirstOrDefault

        Dim LocalDiskTime As String = Nothing
        LocalDiskTime = LocalDiskQ1.AgentCollectDate

        Dim LocalDiskQ2 = From T In db.AgentLocalDisk
                          Where T.AgentName = AgentName And T.AgentCollectDate = LocalDiskTime
                          Order By T.AgentClass, T.AgentProperty Ascending
                          Select T

        Dim LocalDiskList As New List(Of AgentLocalDisk)
        For Each i In LocalDiskQ2
            LocalDiskList.Add(New AgentLocalDisk With {.AgentClass = i.AgentClass, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next

        Dim LayoutStart As String = "<table class='StaticTable' style='width:100%'><thead><tr><th>" & AgentName & ": Disk" &
            "</th></tr></thead><tr><td style='width:100%;padding-right:40px;padding-left:40px;text-align:center'><div style='width=100%;text-align:center'><table style='width:790px;margin:auto;'>"
        Dim LayoutEnd As String = "</table></td></tr></table>"

        Dim LayoutPanel As String = Nothing

        Try
            LayoutPanel = LayoutPanel & "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>Windows Pagefile</td><td>Pagefile Utilization</td><td style='text-align:center'>" & PageFileQ.AgentValue & "% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>"
        Catch
            LayoutPanel = LayoutPanel & "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>Windows Pagefile</td><td colspan=2>No Data</td></tr>"
        End Try

        Try
            For i = 0 To LocalDiskList.Count - 1 Step 2
                LayoutPanel = LayoutPanel & "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>" & LocalDiskList.Item(i).AgentClass & "</td><td>Active Disk Time</td><td style='text-align:center'>" & LocalDiskList.Item(i).AgentValue & "% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>"
                LayoutPanel = LayoutPanel & "<tr><td style='width:10px'><img src='../App_Themes/Monitoring/box-gray.png' style='height:8px;width:8px;' /></td><td>" & LocalDiskList.Item(i).AgentClass & "</td><td>Total Free Space</td><td style='text-align:center'>" & LocalDiskList.Item(i + 1).AgentValue & "% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>"
            Next
        Catch
        End Try

        Dim LC As New LiteralControl(LayoutStart & LayoutPanel & LayoutEnd)
        DiskPlaceHolder.Controls.Add(LC)

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


Public Class AgentData
    Public Property AgentName As String
    Public Property AgentTime As String
    Public Property AgentValue1 As Integer
    Public Property AgentValue2 As Integer
End Class