Imports MonitoringDatabase
Partial Class Devices_Services
    Inherits System.Web.UI.Page
    Private Property db As New DBModel

    Private Sub Devices_Services_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim QS As String = Nothing
            QS = Request.QueryString("hostname")
            HNHyperLink.NavigateUrl = "~/Devices/Device.aspx?hostname=" & QS
            HostNameLabel.Text = QS

            BuildTable()
        End If


    End Sub

    Private Sub BuildTable()
        Dim QS As String = Nothing
        QS = Request.QueryString("hostname")

        Try
            Dim QT As String = Nothing

            Dim Q1 = (From T In db.AgentSystem
                      Where T.AgentName = QS
                      Select T.AgentDate).FirstOrDefault
            QT = Q1

            Dim Q2 = From T In db.AgentService
                     Where T.AgentName = QS And T.AgentCollectDate = QT
                     Order By T.AgentValue Descending, T.AgentProperty Ascending
                     Select T

            Dim Table As New LiteralControl("<table class='HoverTable' style='width:100%'><thead><tr><th style='width:30px'></th><th>Service Name</th><th>Status</th><th>Collect Date</th></tr></thead>")



            Dim ServiceRows As String = Nothing

            For Each i In Q2
                If i.AgentValue = 1 Then
                    ServiceRows = ServiceRows & "<tr><td><div class='EventStatusOK'></div></td><td>" & i.AgentProperty & "</td><td>Running</td><td>" & i.AgentCollectDate & "</td></tr>"
                ElseIf i.AgentValue = 0 Then
                    ServiceRows = ServiceRows & "<tr><td><div class='EventStatusCritical'></div></td><td>" & i.AgentProperty & "</td><td>Stopped</td><td>" & i.AgentCollectDate & "</td></tr>"
                End If
            Next

            If ServiceRows = "" Then
                ServiceRows = "<tr><td colspan='4' style='text-align:center'>No Services</td></tr>"
            End If

            Dim ServiceRowsLC As New LiteralControl(ServiceRows)

            Dim EndTable As New LiteralControl("</Table>")

            ServicePlaceHolder.Controls.Clear()
            ServicePlaceHolder.Controls.Add(Table)
            ServicePlaceHolder.Controls.Add(ServiceRowsLC)
            ServicePlaceHolder.Controls.Add(EndTable)

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Dim QS As String = Nothing
        QS = Request.QueryString("hostname")
        Response.Redirect("~/Devices/Device.aspx?hostname=" & QS)
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BuildTable()
    End Sub
End Class
