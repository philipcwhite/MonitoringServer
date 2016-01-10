Imports MonitoringDatabase
Imports System.Math
Partial Class Options_EditThreshold
    Inherits System.Web.UI.Page
    Private db As New DBModel
    Private Sub Options_EditThreshold_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim QString As String = Nothing

        If Not IsPostBack Then
            QString = Request.QueryString("ThresholdID")

            Dim Q = (From T In db.GlobalThresholds
                     Where T.ThresholdID = QString
                     Select T).FirstOrDefault

            IDLabel.Text = Q.ThresholdID
            ClassTextBox.Text = Q.AgentClass
            PropertyTextBox.Text = Q.AgentProperty
            OperatorDropDownList.SelectedValue = Q.Comparison
            ThresholdTextBox.Text = Q.ThresholdValue
            DurationTextBox.Text = Q.ThresholdTime
            SeverityDropDownList.SelectedValue = Q.Severity
            EnabledRadioButtonList.SelectedValue = Q.Enabled

        End If

    End Sub

    Private Sub Options_EditThreshold_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not User.IsInRole("Administrator") Then
            Response.Redirect("~/Config")
        End If
    End Sub

    Protected Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click

        Dim ThresholdValue As Integer = Nothing
        Dim ThresholdDuration As Integer = Nothing

        ThresholdValue = CInt(Ceiling(CDbl(ThresholdTextBox.Text)))
        ThresholdDuration = CInt(Ceiling(CDbl(DurationTextBox.Text)))

        If ThresholdDuration <= 1440 Then


            Dim Q = (From T In db.GlobalThresholds
                     Where T.ThresholdID = IDLabel.Text
                     Select T).FirstOrDefault

            Q.Comparison = OperatorDropDownList.SelectedValue
            Q.ThresholdValue = ThresholdTextBox.Text
            Q.ThresholdTime = DurationTextBox.Text
            Q.Severity = SeverityDropDownList.SelectedValue
            Q.Enabled = EnabledRadioButtonList.SelectedValue
            db.SaveChanges()
            ValidatorLabel.Text = "Updated Successfully"
        Else
            ValidatorLabel.Text = "Please enter a duration less than 1440 minutes."
        End If


    End Sub

End Class
