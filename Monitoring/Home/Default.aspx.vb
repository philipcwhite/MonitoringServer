Imports MonitoringDatabase
Partial Class Main_Default
    Inherits System.Web.UI.Page
    Private Property db As New DBModel

    Private Sub Main_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            BuildTable()

        End If
    End Sub


    Private Sub BuildTable()


        Dim Q = From T1 In db.AgentSystem
                Join T2 In db.Subscriptions On T1.AgentName Equals T2.AgentName
                Where T2.UserName = User.Identity.Name
                Order By T1.AgentName Ascending
                Select T1

        Dim Rows As String = Nothing

        Dim StatusDate As Date = Date.Now.AddMinutes(-10)
        For Each i In Q

            If i.AgentDate < StatusDate Then
                Rows = Rows & "<tr><td><div class='EventStatusCritical'></div></td><td><a href='../Devices/Device.aspx?hostname=" & i.AgentName & "'>" & i.AgentName & "</a></td><td>" & i.AgentDomain & "</td><td>" & i.AgentIP & "</td><td>" & i.AgentOSName & "</td></tr>"
            Else
                Rows = Rows & "<tr><td><div class='EventStatusOK'></div></td><td><a href='../Devices/Device.aspx?hostname=" & i.AgentName & "'>" & i.AgentName & "</a></td><td>" & i.AgentDomain & "</td><td>" & i.AgentIP & "</td><td>" & i.AgentOSName & "</td></tr>"
            End If

        Next

        Dim AltStart As String = "<table class='StaticTable'><thead><tr><th>Welcome</th></tr>" &
                                "<tr><td style='text-align:center'>Welcome to the Monitoring Server.  Please select the devices you would like to watch on your home page by clicking on the button below.<br /><br />"
        Dim AltButton As New Button
        AltButton.CssClass = "Button"
        AltButton.Text = "Click Here"
        AltButton.PostBackUrl = "~/Config/Subscriptions/MyDevices.aspx"
        Dim AltEnd As String = "</td></tr></table><br />"

        Dim LayoutStart As New LiteralControl("<table style='width:100%'><tr><td style='padding-right:7px;width:50%'>")
        Dim Layout1 As New LiteralControl("</td><td style='padding-left:7px;width:50%'>")
        Dim Layout2 As New LiteralControl("</td></tr></table> <br />")
        Dim TableStart As New LiteralControl("<table class='HoverTable'><thead><tr><th></th><th>Hostname</th><th>Domain</th><th>IP Address</th><th>Operating System</th></tr></thead>")
        Dim TableRows As New LiteralControl(Rows)
        Dim TableEnd As New LiteralControl("</Table>")

        Dim AltTableStart As New LiteralControl(AltStart)
        Dim AltTableEnd As New LiteralControl(AltEnd)


        If Rows <> "" Then
            HomePlaceHolder.Controls.Clear()
            HomePlaceHolder.Controls.Add(LayoutStart)
            LeftChart()
            HomePlaceHolder.Controls.Add(Layout1)
            RightChart()
            HomePlaceHolder.Controls.Add(Layout2)
            HomePlaceHolder.Controls.Add(TableStart)
            HomePlaceHolder.Controls.Add(TableRows)
            HomePlaceHolder.Controls.Add(TableEnd)
        Else
            HomePlaceHolder.Controls.Clear()
            HomePlaceHolder.Controls.Add(AltTableStart)
            HomePlaceHolder.Controls.Add(AltButton)
            HomePlaceHolder.Controls.Add(AltTableEnd)
        End If


    End Sub



    Public Sub LeftChart()

        Dim Q = From T1 In db.AgentEvents
                Join T2 In db.Subscriptions On T1.EventHostname Equals T2.AgentName
                Where T2.UserName = User.Identity.Name And T1.EventStatus = True
                Order By T1.EventHostname Ascending
                Select T1.EventSeverity

        Dim InfoAlert As Integer = 0
        Dim WarnAlert As Integer = 0
        Dim CritAlert As Integer = 0
        Dim TotalAlerts As Integer = 0


        For Each i In Q
            If i = 0 Then
                InfoAlert = InfoAlert + 1
            ElseIf i = 1 Then
                WarnAlert = WarnAlert + 1
            ElseIf i = 2 Then
                CritAlert = CritAlert + 1
            End If
        Next

        TotalAlerts = InfoAlert + WarnAlert + CritAlert

        Dim StatusList As New List(Of Status)
        If InfoAlert > 0 Then
            StatusList.Add(New Status With {.Category = "Info", .Count = InfoAlert})
        End If
        If WarnAlert > 0 Then
            StatusList.Add(New Status With {.Category = "Warn", .Count = WarnAlert})
        End If
        If CritAlert > 0 Then
            StatusList.Add(New Status With {.Category = "Crit", .Count = CritAlert})
        End If

        Dim StartAngle As Double = 0
        Dim radius As Double = 50
        Dim SVGPath As String = Nothing
        Dim Color As String = Nothing
        Dim PercentTotal As Double = Nothing

        For Each i In StatusList

            PercentTotal = PercentTotal + i.Count

            Dim percentage As Double = (PercentTotal / TotalAlerts) * 100

            Dim size = 100

            Dim cy As Double = size / 2
            Dim cx As Double = size / 2

            Dim unit = (Math.PI * 2) / 100
            Dim EndAngle = percentage * unit - 0.001

            EndAngle = percentage * unit - 0.001
            Dim x1 = (size / 2) + (size / 2) * Math.Sin(StartAngle)
            Dim y1 = (size / 2) - (size / 2) * Math.Cos(StartAngle)
            Dim x2 = (size / 2) + (size / 2) * Math.Sin(EndAngle)
            Dim y2 = (size / 2) - (size / 2) * Math.Cos(EndAngle)

            Dim big = 0
            If EndAngle - StartAngle > Math.PI Then
                big = 1
            End If

            Dim d As String = "M " & (size / 2) & "," & (size / 2) &
        " L " & x1 & "," & y1 &
        " A " & (size / 2) & "," & (size / 2) &
        " 0 " & big & " 1 " &
        x2 & "," & y2 &
        " Z"


            If i.Category = "Info" Then
                Color = "#6BD5C3"
            ElseIf i.Category = "Warn" Then
                Color = "#ECD48B"
            ElseIf i.Category = "Crit" Then
                Color = "#ED848F"
            End If

            SVGPath = SVGPath & "<g><path fill = '" & Color & "' stroke-width='0' ' d='" & d & " ' /></g>"

            StartAngle = EndAngle


        Next


        Dim SVGStart As String = "<svg style = 'overflow: hidden;'  width='100' height='100'>"
        Dim SVGItems As String = SVGPath
        Dim SVGEnd As String = "<circle fill = '#ffffff' stroke='none' stroke-width='0' cx='50' cy='50' r='35' /></svg>"




        Dim SVGLiteral As New LiteralControl(SVGStart & SVGItems & SVGEnd)


        Dim TableStart As New LiteralControl("<table class='StaticTable'><thead><tr><th style='text-align:left'>Event Summary</th></tr></thead><tr><td><table><tr><td>")



        Dim ContentInfoBox As String = "</td><td><table><tr><td style='width:15px'><div class='EventStatusCritical' /></td><td>" & CritAlert & " Critical Events</td></tr>" &
            "<tr><td><div class='EventStatusWarning' /></td><td>" & WarnAlert & " Warning Events</td></tr>" &
            "<tr><td><div class='EventStatusInfo' /></td><td>" & InfoAlert & " Info Events</td></tr></table></td></tr></table>"
        Dim InfoBoxControl As New LiteralControl(ContentInfoBox)

        Dim TableEnd As New LiteralControl("</td></tr></table>")

        HomePlaceHolder.Controls.Add(TableStart)
        HomePlaceHolder.Controls.Add(SVGLiteral)
        HomePlaceHolder.Controls.Add(InfoBoxControl)
        HomePlaceHolder.Controls.Add(TableEnd)
    End Sub

    Public Sub RightChart()



        Dim Q = From T1 In db.AgentSystem
                Join T2 In db.Subscriptions On T1.AgentName Equals T2.AgentName
                Where T2.UserName = User.Identity.Name
                Order By T1.AgentName Ascending
                Select T1

        Dim Ok As Integer = 0
        Dim Down As Integer = 0
        Dim TotalAlerts As Integer = 0
        Dim StatusDate As Date = Date.Now.AddMinutes(-15)

        For Each i In Q
            If i.AgentDate < StatusDate Then
                Down = Down + 1
            Else
                Ok = Ok + 1
            End If
        Next

        TotalAlerts = Ok + Down

        Dim DataList As New List(Of Double)

        If Ok > 0 Then
            DataList.Add(Ok)
        End If
        If Down > 0 Then
            DataList.Add(Down)
        End If

        Dim StartAngle As Double = 0
        Dim radius As Double = 50
        Dim SVGPath As String = Nothing
        Dim colorInt As Integer = 0
        Dim Color As String = Nothing
        Dim PercentTotal As Double = Nothing

        For Each i In DataList

            PercentTotal = PercentTotal + i

            Dim percentage As Double = (PercentTotal / TotalAlerts) * 100

            Dim size = 100

            Dim cy As Double = size / 2
            Dim cx As Double = size / 2

            Dim unit = (Math.PI * 2) / 100
            Dim EndAngle = percentage * unit - 0.001



            EndAngle = percentage * unit - 0.001
            Dim x1 = (size / 2) + (size / 2) * Math.Sin(StartAngle)
            Dim y1 = (size / 2) - (size / 2) * Math.Cos(StartAngle)
            Dim x2 = (size / 2) + (size / 2) * Math.Sin(EndAngle)
            Dim y2 = (size / 2) - (size / 2) * Math.Cos(EndAngle)



            Dim big = 0
            If EndAngle - StartAngle > Math.PI Then
                big = 1
            End If

            Dim d As String = "M " & (size / 2) & "," & (size / 2) &
        " L " & x1 & "," & y1 &
        " A " & (size / 2) & "," & (size / 2) &
        " 0 " & big & " 1 " &
        x2 & "," & y2 &
        " Z"

            If Ok = 0 And Down > 0 Then
                Color = "#ED848F"
            ElseIf Ok > 0 And Down = 0 Then
                Color = "#A9DC8E"
            ElseIf Ok > 0 And Down > 0 Then
                If colorInt = 0 Then
                    Color = "#A9DC8E"
                ElseIf colorInt = 1 Then
                    Color = "#ED848F"
                End If
            End If



            SVGPath = SVGPath & "<g><path fill = '" & Color & "' stroke-width='0' ' d='" & d & " ' /></g>"

            StartAngle = EndAngle
            colorInt = colorInt + 1

        Next


        Dim SVGStart As String = "<svg style = 'overflow: hidden;'  width='100' height='100'>"
        Dim SVGItems As String = SVGPath
        Dim SVGEnd As String = "<circle fill = '#ffffff' stroke='none' stroke-width='0' cx='50' cy='50' r='35' /></svg>"




        Dim SVGLiteral As New LiteralControl(SVGStart & SVGItems & SVGEnd)


        Dim TableStart As New LiteralControl("<table class='StaticTable'><thead><tr><th style='text-align:left'>Device Summary</th></tr></thead><tr><td><table><tr><td>")


        Dim ContentInfoBox As String = "</td><td><table><tr><td style='width:15px'><div class='EventStatusOK' /></td><td>" & Ok & " Devices Ok</td></tr>" &
            "<tr><td><div class='EventStatusCritical' /></td><td>" & Down & " Devices Down</td></tr>" &
            "<tr><td></td><td></td></tr></table></td></tr></table>"
        Dim InfoBoxControl As New LiteralControl(ContentInfoBox)

        Dim TableEnd As New LiteralControl("</td></tr></Table>")

        HomePlaceHolder.Controls.Add(TableStart)
        HomePlaceHolder.Controls.Add(SVGLiteral)
        HomePlaceHolder.Controls.Add(InfoBoxControl)
        HomePlaceHolder.Controls.Add(TableEnd)

    End Sub





    Protected Sub HomeTimer_Tick(sender As Object, e As EventArgs) Handles HomeTimer.Tick
        BuildTable()
    End Sub

End Class

Public Class Status
    Public Property Category As String
    Public Property Count As Integer
End Class