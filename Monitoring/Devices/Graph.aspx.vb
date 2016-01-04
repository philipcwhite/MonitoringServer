Imports MonitoringDatabase
Partial Class Devices_Graph
    Inherits System.Web.UI.Page

    Private Property db As New DBModel

    Private Sub Devices_Default4_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim QString1 As String = Nothing
            Dim QString2 As String = Nothing

            QString1 = Request.QueryString("hostname")
            QString2 = Request.QueryString("class")

            HostNameLabel.Text = QString1
            DeviceHyperLink.NavigateUrl = "~/Devices/Device.aspx?hostname=" & QString1


            If QString2.Contains("Local Disk") Then
                GraphLabel.Text = QString2.Replace(";", " ")
            Else
                GraphLabel.Text = QString2
            End If



            LoadGraph(QString1, QString2, Date.Now, 60)

        End If

    End Sub

    Private Sub LoadGraph(ByVal AgentName As String, ByVal AgentClass As String, ByVal StartTime As Date, ByVal Duration As Integer)

        Dim GraphTitle As String = Nothing
        Dim DataPoints As Integer = Nothing
        Dim TimeMeasure As String = Nothing
        Dim ySpace As Integer = 50
        Dim yValue1 As Integer = Nothing
        Dim yValue2 As Integer = Nothing
        Dim xSpace As Integer = 50
        Dim xCircle As String = Nothing
        Dim xLine As String = Nothing
        Dim xTime As Integer = 85
        Dim xTimeStart = RoundTime(StartTime.AddMinutes(-Duration))
        Dim xTimeValue As Date = Nothing
        Dim xTimeText As String = Nothing
        Dim xValue1 As Integer = 100
        Dim xValue2 As Integer = 150
        Dim DataList As New List(Of AgentData)

        For i = 0 To 12
            xTimeText = xTimeText & "<text x=" & xTime & " y='320' fill='black' font-size='9' font-family='arial'>" & xTimeStart.ToString("h:mmtt") & "</text>"
            DataList.Add(New AgentData With {.AgentName = AgentName, .AgentTime = xTimeStart, .AgentValue1 = 0, .AgentValue2 = 0})
            xTimeStart = xTimeStart.AddMinutes(5)
            xTime = xTime + 50
        Next

        If AgentClass = "Processor" Then
            For Each i In DataList
                Dim Q = (From T In db.AgentProcessor
                         Where T.AgentCollectDate = i.AgentTime And T.AgentName = i.AgentName
                         Select T).FirstOrDefault
                If Q IsNot Nothing Then
                    i.AgentValue1 = Q.AgentValue
                End If
            Next
            For i = 0 To DataList.Count - 2
                DataList.Item(i).AgentValue2 = DataList.Item(i + 1).AgentValue1
            Next
            GraphTitle = "<text x = '300' y='40' fill='#485385' font-size='16' font-family='arial' font-weight='bold'>Processor Total Utilization (%)</text>"
        End If

        If AgentClass = "Memory" Then
            For Each i In DataList
                Dim Q = (From T In db.AgentMemory
                         Where T.AgentCollectDate = i.AgentTime And T.AgentName = i.AgentName
                         Select T).FirstOrDefault
                If Q IsNot Nothing Then
                    i.AgentValue1 = Q.AgentValue
                End If
            Next
            For i = 0 To DataList.Count - 2
                DataList.Item(i).AgentValue2 = DataList.Item(i + 1).AgentValue1
            Next
            GraphTitle = "<text x = '300' y='40' fill='#485385' font-size='16' font-family='arial' font-weight='bold'>Memory Total Utilization (%)</text>"
        End If

        If AgentClass = "PageFile" Then
            For Each i In DataList
                Dim Q = (From T In db.AgentPageFile
                         Where T.AgentCollectDate = i.AgentTime And T.AgentName = i.AgentName
                         Select T).FirstOrDefault
                If Q IsNot Nothing Then
                    i.AgentValue1 = Q.AgentValue
                End If
            Next
            For i = 0 To DataList.Count - 2
                DataList.Item(i).AgentValue2 = DataList.Item(i + 1).AgentValue1
            Next
            GraphTitle = "<text x = '300' y='40' fill='#485385' font-size='16' font-family='arial' font-weight='bold'>Pagefile Total Utilization (%)</text>"
        End If

        If AgentClass.Contains("Local Disk") Then
            Dim LDClass As String = AgentClass.Split(";")(0)
            Dim LDProperty = AgentClass.Split(";")(1)
            For Each i In DataList
                Dim Q = (From T In db.AgentLocalDisk
                         Where T.AgentCollectDate = i.AgentTime And T.AgentName = i.AgentName And T.AgentClass = LDClass And T.AgentProperty = LDProperty
                         Select T).FirstOrDefault
                If Q IsNot Nothing Then
                    i.AgentValue1 = Q.AgentValue
                End If
            Next
            For i = 0 To DataList.Count - 2
                DataList.Item(i).AgentValue2 = DataList.Item(i + 1).AgentValue1
            Next
            GraphTitle = "<text x = '300' y='40' fill='#485385' font-size='16' font-family='arial' font-weight='bold'>" & AgentClass.Replace(";", " ") & "</text>"
        End If

        For i = 0 To DataList.Count - 2
            yValue1 = 300 - DataList.Item(i).AgentValue1 * 2
            yValue2 = 300 - DataList.Item(i).AgentValue2 * 2
            xLine = xLine & "<line x1=" & xValue1 & " y1=" & yValue1 & " x2=" & xValue2 & " y2=" & yValue2 & " style='stroke:#485385;stroke-width:2'/>"
            xValue1 = xValue1 + 50
            xValue2 = xValue2 + 50
        Next

        xValue1 = 100
        For i = 0 To DataList.Count - 1
            yValue1 = 300 - DataList.Item(i).AgentValue1 * 2
            xCircle = xCircle & "<circle cx=" & xValue1 & " cy=" & yValue1 & " r='3' stroke='#485385' stroke-width='1' fill='#485385' onmouseover=""evt.target.setAttribute('stroke-width','4');"" onmouseout=""evt.target.setAttribute('stroke-width', '1');"" />"
            xValue1 = xValue1 + 50
        Next


        Dim SVGxCircle As New LiteralControl(xCircle)
        Dim SVGxLine As New LiteralControl(xLine)



        Dim SVGStart As New LiteralControl("<svg height='350' width='850'>")

        Dim SVGTitle As New LiteralControl(GraphTitle)

        Dim SVGyAxis As New LiteralControl("<line x1='100' y1='100' x2='100' y2='305' style='stroke:#444444;stroke-width:1' />" &
            "<line x1 ='95' y1='100' x2='100' y2='100' style='stroke:#444444;stroke-width:1' />" &
            "<line x1='95' y1='150' x2='100' y2='150' style='stroke:#444444;stroke-width:1'/>" &
            "<line x1='95' y1='200' x2='100' y2='200' style='stroke:#444444;stroke-width:1'/>" &
            "<line x1='95' y1='250' x2='100' y2='250' style='stroke:#444444;stroke-width:1'/>" &
            "<line x1 ='95' y1='300' x2='100' y2='300' style='stroke:#444444;stroke-width:1' />" &
            "<text x = '70' y='105' fill='black' font-size='9' font-family='arial'>100</text>" &
            "<text x='75' y='155' fill='black' font-size='9' font-family='arial'>75</text>" &
            "<text x = '75' y='205' fill='black' font-size='9' font-family='arial'>50</text>" &
            "<text x='75' y='255' fill='black' font-size='9' font-family='arial'>25</text>" &
            "<text x = '80' y='305' fill='black' font-size='9' font-family='arial'>0</text>")
        Dim SVGxAxis As New LiteralControl("<line x1 = '95' y1='300' x2='700' y2='300' style='stroke:#444444;stroke-width:1' />" &
            "<line x1 = '150' y1='300' x2='150' y2='305' style='stroke:#444444;stroke-width:1'/>" &
            "<line x1 = '200' y1='300' x2='200' y2='305' style='stroke:#444444;stroke-width:1' />" &
            "<line x1 = '250' y1='300' x2='250' y2='305' style='stroke:#444444;stroke-width:1'/>" &
            "<line x1 = '300' y1='300' x2='300' y2='305' style='stroke:#444444;stroke-width:1' />" &
            "<line x1 = '350' y1='300' x2='350' y2='305' style='stroke:#444444;stroke-width:1'/>" &
            "<line x1 = '400' y1='300' x2='400' y2='305' style='stroke:#444444;stroke-width:1' />" &
            "<line x1 = '450' y1='300' x2='450' y2='305' style='stroke:#444444;stroke-width:1'/>" &
            "<line x1 = '500' y1='300' x2='500' y2='305' style='stroke:#444444;stroke-width:1' />" &
            "<line x1 = '550' y1='300' x2='550' y2='305' style='stroke:#444444;stroke-width:1'/>" &
            "<line x1 = '600' y1='300' x2='600' y2='305' style='stroke:#444444;stroke-width:1' />" &
            "<line x1 = '650' y1='300' x2='650' y2='305' style='stroke:#444444;stroke-width:1' />" &
            "<line x1 = '700' y1='300' x2='700' y2='305' style='stroke:#444444;stroke-width:1' />")
        Dim SVGGrid As New LiteralControl("<line x1 = '100' y1='250' x2='700' y2='250' style='stroke: #eeeeee;stroke-width:1' />" &
            "<line x1 = '100' y1='200' x2='700' y2='200' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '100' y1='150' x2='700' y2='150' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '100' y1='100' x2='700' y2='100' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '150' y1='300' x2='150' y2='100' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '200' y1='300' x2='200' y2='100' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '250' y1='300' x2='250' y2='100' style='stroke:#eeeeee;stroke-width:1'/>" &
            "<line x1 = '300' y1='300' x2='300' y2='100' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '350' y1='300' x2='350' y2='100' style='stroke:#eeeeee;stroke-width:1'/>" &
            "<line x1 = '400' y1='300' x2='400' y2='100' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '450' y1='300' x2='450' y2='100' style='stroke:#eeeeee;stroke-width:1'/>" &
            "<line x1 = '500' y1='300' x2='500' y2='100' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '550' y1='300' x2='550' y2='100' style='stroke:#eeeeee;stroke-width:1'/>" &
            "<line x1 = '600' y1='300' x2='600' y2='100' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '650' y1='300' x2='650' y2='100' style='stroke:#eeeeee;stroke-width:1' />" &
            "<line x1 = '700' y1='300' x2='700' y2='100' style='stroke:#eeeeee;stroke-width:1' />")


        Dim SVGxTimeText As New LiteralControl(xTimeText)
        Dim SVGEnd As New LiteralControl("</svg>")

        GraphPlaceHolder.Controls.Add(SVGStart)
        GraphPlaceHolder.Controls.Add(SVGTitle)
        GraphPlaceHolder.Controls.Add(SVGxAxis)
        GraphPlaceHolder.Controls.Add(SVGyAxis)
        GraphPlaceHolder.Controls.Add(SVGGrid)
        GraphPlaceHolder.Controls.Add(SVGxTimeText)
        GraphPlaceHolder.Controls.Add(SVGxCircle)
        GraphPlaceHolder.Controls.Add(SVGxLine)
        GraphPlaceHolder.Controls.Add(SVGEnd)

    End Sub

    Private Function RoundTime(ByVal StartTime As Date) As Date

        Dim MyDateTime = StartTime
        Dim DatePart = MyDateTime.Date
        Dim TimePart = MyDateTime.TimeOfDay
        TimePart = TimeSpan.FromMinutes(Math.Floor((TimePart.TotalMinutes + 2.5) / 5.0) * 5.0)
        Dim NewTime = DatePart.Add(TimePart)

        Return NewTime
    End Function


    Protected Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

    End Sub

End Class

Public Class AgentData
    Public Property AgentName As String
    Public Property AgentTime As String
    Public Property AgentValue1 As Integer
    Public Property AgentValue2 As Integer
End Class