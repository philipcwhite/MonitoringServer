Imports MonitoringDatabase

Partial Class Options_GlobalThresholds
    Inherits System.Web.UI.Page

    Private Property db As New DBModel

    Private Sub Options_GlobalThresholds_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BuildTable()
        End If


    End Sub

    Private Sub BuildTable()

        Dim Q = From T In db.GlobalThresholds
                Order By T.AgentClass, T.AgentProperty, T.Severity Ascending
                Select T

        Dim Table As New LiteralControl("<table class='HoverTable'><thead><tr><th>Class</th><th>Property</th><th>Operator</th><th>Value</th><th>Time (Min)</th><th>Severity</th><th>Enabled</th><th></th></tr></thead>")
        ThresholdPlaceHolder.Controls.Clear()
        ThresholdPlaceHolder.Controls.Add(Table)

        For Each i In Q
            Dim EditButton As New Button
            EditButton.Text = "Edit"
            EditButton.CssClass = "Button"
            EditButton.ID = i.ThresholdID
            EditButton.PostBackUrl = "~/Options/UpdateThreshold.aspx?ThresholdID=" & i.ThresholdID

            Dim Row As New LiteralControl("<tr><td>" & i.AgentClass & "</td><td>" & i.AgentProperty & "</td><td>" & i.Comparison & "</td><td>" & i.ThresholdValue & "</td><td>" & i.ThresholdTime & "</td><td>" & i.Severity & "</td><td>" & i.Enabled & "</td><td style='text-align:center'>")

            ThresholdPlaceHolder.Controls.Add(Row)
            ThresholdPlaceHolder.Controls.Add(EditButton)
            Dim Row2 As New LiteralControl("</td></tr>")
            ThresholdPlaceHolder.Controls.Add(Row2)
        Next
        Dim EndTable As New LiteralControl("</Table>")
        ThresholdPlaceHolder.Controls.Add(EndTable)


    End Sub


    Private Sub Options_GlobalThresholds_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not User.IsInRole("Administrator") Then
            Response.Redirect("~/Options")
        End If
    End Sub


    Protected Sub RestoreButton_Click(sender As Object, e As EventArgs) Handles RestoreButton.Click

        Dim GTH As New GlobalThresholdData

        GTH.AddThresholds()
        Response.Redirect("GlobalThresholds.aspx")

    End Sub

End Class
