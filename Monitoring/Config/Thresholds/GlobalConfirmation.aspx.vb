Imports MonitoringDatabase
Partial Class Options_Thresholds_Confirmation
    Inherits System.Web.UI.Page

    Private db As New DBModel

    Protected Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        If MessageLabel.Text = "Are you sure you want to reset thresholds?" And ValueLabel.Text = "True" Then
            Dim GTH As New GlobalThresholdData
            GTH.AddThresholds()
            Response.Redirect("~/Config/Thresholds/GlobalThresholds.aspx")
        ElseIf MessageLabel.Text = "Are you sure you want to delete this threshold?" Then
            Dim ThresholdID As Integer = Nothing
            ThresholdID = CInt(ValueLabel.Text)


            db.GlobalThresholds.Remove(db.GlobalThresholds.Find(ThresholdID))


            db.SaveChanges()

            Response.Redirect("~/Config/Thresholds/GlobalThresholds.aspx")

        End If



    End Sub

    Private Sub Options_Thresholds_Confirmation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim QString1 As String = Nothing
        Dim QString2 As String = Nothing
        If Not IsPostBack Then

            QString1 = Request.QueryString("ResetThresholds")
            QString2 = Request.QueryString("ThresholdID")

            If QString1 IsNot Nothing Then
                MessageLabel.Text = "Are you sure you want to reset thresholds?"
                ValueLabel.Text = QString1

            ElseIf QString2 IsNot Nothing Then

                MessageLabel.Text = "Are you sure you want to delete this threshold?"
                ValueLabel.Text = QString2
            Else
                Response.Redirect("~/Config/")

            End If



        End If

    End Sub

    Private Sub Options_Thresholds_Confirmation_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not User.IsInRole("Administrator") Then
            Response.Redirect("~/Config")
        End If
    End Sub

End Class
