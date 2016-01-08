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

        Dim StatusDate As Date = Date.Now.AddDays(-1)
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
        AltButton.PostBackUrl = "~/Config/Subscriptions/"
        Dim AltEnd As String = "</td></tr></table><br />"

        Dim TableStart As New LiteralControl("<table class='HoverTable'><thead><tr><th></th><th>Hostname</th><th>Domain</th><th>IP Address</th><th>Operating System</th></tr></thead>")
        Dim TableRows As New LiteralControl(Rows)
        Dim TableEnd As New LiteralControl("</Table>")

        Dim AltTableStart As New LiteralControl(AltStart)
        Dim AltTableEnd As New LiteralControl(AltEnd)


        If Rows <> "" Then
            HomePlaceHolder.Controls.Clear()
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

    Protected Sub HomeTimer_Tick(sender As Object, e As EventArgs) Handles HomeTimer.Tick
        BuildTable()
    End Sub

End Class
