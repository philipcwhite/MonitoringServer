Imports MonitoringDatabase
Partial Class Config_Thresholds_AgentConfirmation
    Inherits System.Web.UI.Page
    Private db As New DBModel

    Private Sub Config_Thresholds_AgentConfirmation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim QString1 As String = Nothing
        If Not IsPostBack Then

            QString1 = Request.QueryString("ThresholdID")
            ValueLabel.Text = QString1

        End If

    End Sub

    Private Sub Config_Thresholds_AgentConfirmation_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not User.IsInRole("Administrator") Then
            Response.Redirect("~/Config")
        End If
    End Sub
    Protected Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        Dim ThresholdID As Integer = Nothing
            ThresholdID = CInt(ValueLabel.Text)


        db.AgentThresholds.Remove(db.AgentThresholds.Find(ThresholdID))


        db.SaveChanges()

        Response.Redirect("~/Config/")


    End Sub
End Class
