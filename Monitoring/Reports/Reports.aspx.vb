Imports MonitoringDatabase
Partial Class Reports_Reports
    Inherits System.Web.UI.Page
    Private db As New DBModel

    Private Sub Reports_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim ReportID As String = Nothing
            ReportID = Request.QueryString("ReportID")
            Dim ReportType As String = Nothing
            ReportType = Request.QueryString("Type")

            If ReportID = 1 Then
                ReportAgentDevice(ReportType)
            ElseIf ReportID = 2 Then
                ReportAgentEvent(ReportType)
            ElseIf ReportID = 3 Then
                ReportAgentPerformance(ReportType)
            End If

        End If
    End Sub

    Private Sub ReportAgentDevice(ByVal ReportType As String)
        ReportLabel.Text = "Agent Device Report"

        Dim Q = From T In db.AgentSystem
                Order By T.AgentName Ascending
                Select T

        If ReportType = "web" Then

            Dim TableStart As String = "<table class='HoverTable'><thead><tr><th>Hostname</th><th>Domain</th><th>IP Address</th><th>Operating System</th><th>Architechture</th><th>Processors</th><th>Memory (MB)</th><th>Last Updated</th></tr></thead>"
            Dim Rows As String = Nothing
            For Each i In Q
                Dim FormattedDate As Date = i.AgentDate
                Rows = Rows & "<tr style='font-size:9px'><td>" & i.AgentName & "</td><td>" & i.AgentDomain & "</td><td>" & i.AgentIP & "</td><td>" & i.AgentOSName & "</td><td>" & i.AgentOSArchitechture & "</td><td>" & i.AgentProcessors & "</td><td>" & i.AgentMemory & "</td><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td></tr>"
            Next
            Dim TableEnd As String = "</table>"

            Dim LC1 As New LiteralControl(TableStart)
            Dim LC2 As New LiteralControl(Rows)
            Dim LC3 As New LiteralControl(TableEnd)

            ReportPlaceHolder.Controls.Add(LC1)
            ReportPlaceHolder.Controls.Add(LC2)
            ReportPlaceHolder.Controls.Add(LC3)

        ElseIf ReportType = "csv" Then

            Dim CSVString As String = """Hostname"",""Domain"",""IP Address"",""Operating System"",""Architechture"",""Processors"",""Memory (MB)"",""Last Updated"""

            For Each i In Q
                Dim FormattedDate As Date = i.AgentDate
                CSVString = CSVString & vbCrLf & """" & i.AgentName & """,""" & i.AgentDomain & """,""" & i.AgentIP & """,""" & i.AgentOSName & """,""" & i.AgentOSArchitechture & """,""" & i.AgentProcessors & """,""" & i.AgentMemory & """,""" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & """"
            Next

            Response.Clear()
            Response.ContentType = "text/csv"
            Response.AddHeader("content-disposition", "attachment;filename=AgentDeviceReport.csv")
            Response.Write(CSVString)
            Response.End()

        End If

    End Sub

    Private Sub ReportAgentEvent(ByVal ReportType As String)
        ReportLabel.Text = "Agent Event Report"

        Dim Q = From T In db.AgentEvents
                Order By T.EventDate Descending
                Where T.EventStatus = True
                Select T

        If ReportType = "web" Then

            Dim TableStart As String = "<table class='HoverTable'><thead><tr><th>Event Date</th><th>Severity</th><th>Hostname</th><th>Class</th><th>Message</th></tr></thead>"
            Dim Rows As String = Nothing
            For Each i In Q
                Dim Severity As String = Nothing
                If i.EventSeverity = 0 Then
                    Severity = "Informational"
                ElseIf i.EventSeverity = 1 Then
                    Severity = "Warning"
                ElseIf i.EventSeverity = 2 Then
                    Severity = "Critical"
                End If
                Dim FormattedDate As Date = i.EventDate
                Rows = Rows & "<tr style='font-size:9px'><td>" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & "</td><td>" & Severity & "</td><td>" & i.EventHostname & "</td><td>" & i.EventClass & "</td><td>" & i.EventMessage & "</td></tr>"
            Next
            Dim TableEnd As String = "</table>"

            Dim LC1 As New LiteralControl(TableStart)
            Dim LC2 As New LiteralControl(Rows)
            Dim LC3 As New LiteralControl(TableEnd)

            ReportPlaceHolder.Controls.Add(LC1)
            ReportPlaceHolder.Controls.Add(LC2)
            ReportPlaceHolder.Controls.Add(LC3)

        ElseIf ReportType = "csv" Then

            Dim CSVString As String = """Event Date"",""Severity"",""Hostname"",""Event Class"",""Message"""

            For Each i In Q
                Dim Severity As String = Nothing
                If i.EventSeverity = 0 Then
                    Severity = "Informational"
                ElseIf i.EventSeverity = 1 Then
                    Severity = "Warning"
                ElseIf i.EventSeverity = 2 Then
                    Severity = "Critical"
                End If
                Dim FormattedDate As Date = i.EventDate
                CSVString = CSVString & vbCrLf & """" & FormattedDate.ToString("M/dd/yyyy h:mm tt") & """,""" & Severity & """,""" & i.EventHostname & """,""" & i.EventClass & """,""" & i.EventMessage & """"
            Next

            Response.Clear()
            Response.ContentType = "text/csv"
            Response.AddHeader("content-disposition", "attachment;filename=AgentEventReport.csv")
            Response.Write(CSVString)
            Response.End()

        End If
    End Sub

    Private Sub ReportAgentPerformance(ByVal ReportType As String)
        ReportLabel.Text = "Agent Performance Report"

        Dim PerformanceList As New List(Of AgentProcessor)

        Dim LastHour As Date = Date.Now.AddHours(-1)


        Dim Q1 = From T In db.AgentProcessor
                     Where T.AgentCollectDate > LastHour
                     Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                     Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}


            For Each i In Q1
            PerformanceList.Add(New AgentProcessor With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 0)})
        Next



        Dim Q2 = From T In db.AgentMemory
                     Where T.AgentCollectDate > LastHour
                     Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                     Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}


            For Each i In Q2
            PerformanceList.Add(New AgentProcessor With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 0)})
        Next


        Dim Q3 = From T In db.AgentPageFile
                     Where T.AgentCollectDate > LastHour
                     Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                     Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}


            For Each i In Q3
            PerformanceList.Add(New AgentProcessor With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 0)})
        Next


        Dim Q4 = From T In db.AgentLocalDisk
                     Where T.AgentCollectDate > LastHour
                     Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                     Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}


            For Each i In Q4
            PerformanceList.Add(New AgentProcessor With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 0)})
        Next

        Dim Q = From T In PerformanceList
                Order By T.AgentName, T.AgentClass, T.AgentProperty
                Select T

        If ReportType = "web" Then

            Dim TableStart As String = "<table class='HoverTable'><thead><tr><th>Hostname</th><th>Class</th><th>Property</th><th>Value</th></tr></thead>"
            Dim Rows As String = Nothing
            For Each i In Q
                Rows = Rows & "<tr style='font-size:9px'><td>" & i.AgentName & "</td><td>" & i.AgentClass & "</td><td>" & i.AgentProperty & "</td><td>" & i.AgentValue & "</td></tr>"
            Next
            Dim TableEnd As String = "</table>"

            Dim LC1 As New LiteralControl(TableStart)
            Dim LC2 As New LiteralControl(Rows)
            Dim LC3 As New LiteralControl(TableEnd)

            ReportPlaceHolder.Controls.Add(LC1)
            ReportPlaceHolder.Controls.Add(LC2)
            ReportPlaceHolder.Controls.Add(LC3)

        ElseIf ReportType = "csv" Then

            Dim CSVString As String = """Hostname"",""Class"",""Property"",""Value"""

            For Each i In Q
                CSVString = CSVString & vbCrLf & """" & i.AgentName & """,""" & i.AgentClass & """,""" & i.AgentProperty & """,""" & i.AgentValue & """"
            Next

            Response.Clear()
            Response.ContentType = "text/csv"
            Response.AddHeader("content-disposition", "attachment;filename=AgentPerformanceReport.csv")
            Response.Write(CSVString)
            Response.End()

        End If


    End Sub

End Class
