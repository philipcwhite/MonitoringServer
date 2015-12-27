Imports MonitoringDatabase
Imports System.Math
Partial Class Options_AddThreshold
    Inherits System.Web.UI.Page
    Private db As New DBModel

    Private Sub Options_EditThreshold_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If ClassDropDownList.SelectedValue = "Processor" Then
                PropertyDropDownList.Items.Add("Total Util (%)")
                ServicesTextBox.Visible = False
            End If

        End If
    End Sub

    Private Sub Options_EditThreshold_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not User.IsInRole("Administrator") Then
            Response.Redirect("~/Options")
        End If
    End Sub

    Protected Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click

        Dim ThresholdValue As Integer = Nothing
        Dim ThresholdDuration As Integer = Nothing
        Dim AgentClass As String = Nothing
        Dim AgentProperty As String = Nothing
        Dim Compare As String = Nothing
        Dim Severity As Integer = Nothing
        Dim Enabled As Boolean = False

        ThresholdValue = CInt(Ceiling(CDbl(ThresholdTextBox.Text)))
        ThresholdDuration = CInt(Ceiling(CDbl(DurationTextBox.Text)))

        If ThresholdDuration <= 1440 Then

            If ClassDropDownList.SelectedValue = "Processor" Then
                AgentClass = "Processor"
                AgentProperty = PropertyDropDownList.SelectedValue
                Compare = OperatorDropDownList.SelectedValue
                ThresholdValue = ThresholdTextBox.Text
                ThresholdDuration = DurationTextBox.Text
                Severity = SeverityDropDownList.SelectedValue
            End If

            If ClassDropDownList.SelectedValue = "Memory" Then
                AgentClass = "Memory"
                AgentProperty = PropertyDropDownList.SelectedValue
                Compare = OperatorDropDownList.SelectedValue
                ThresholdValue = ThresholdTextBox.Text
                ThresholdDuration = DurationTextBox.Text
                Severity = SeverityDropDownList.SelectedValue
            End If

            If ClassDropDownList.SelectedValue = "Local Disk" Then
                AgentClass = "Local Disk (" & LDDropDownList.SelectedValue & ":)"
                AgentProperty = PropertyDropDownList.SelectedValue
                Compare = OperatorDropDownList.SelectedValue
                ThresholdValue = ThresholdTextBox.Text
                ThresholdDuration = DurationTextBox.Text
                Severity = SeverityDropDownList.SelectedValue
            End If

            If ClassDropDownList.SelectedValue = "Services" Then
                AgentClass = "Services"
                AgentProperty = ServicesTextBox.Text
                Compare = OperatorDropDownList.SelectedValue
                ThresholdValue = ThresholdTextBox.Text
                ThresholdDuration = DurationTextBox.Text
                Severity = SeverityDropDownList.SelectedValue
            End If

            Enabled = EnabledRadioButtonList.SelectedValue

            db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = AgentClass, .AgentProperty = AgentProperty, .Comparison = Compare, .ThresholdValue = ThresholdValue, .ThresholdTime = ThresholdDuration, .Severity = Severity, .Enabled = Enabled})
            db.SaveChanges()

            ValidatorLabel.Text = "Added Successfully"
        Else
            ValidatorLabel.Text = "Please enter a duration less than 1440 minutes."
        End If


    End Sub

    Protected Sub ClassDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClassDropDownList.SelectedIndexChanged

        PropertyDropDownList.Items.Clear()
        PropertyDropDownList.Visible = True

        If ClassDropDownList.SelectedValue = "Local Disk" Then
            LDDropDownList.Visible = True
            PropertyDropDownList.Items.Add("Free Space (%)")
            PropertyDropDownList.Items.Add("Free Space (MB)")
            ServicesTextBox.Visible = False
        Else
            LDDropDownList.Visible = False
        End If

        If ClassDropDownList.SelectedValue = "Memory" Then
            PropertyDropDownList.Items.Add("Total Util (%)")
            ServicesTextBox.Visible = False
        End If

        If ClassDropDownList.SelectedValue = "Processor" Then
            PropertyDropDownList.Items.Add("Total Util (%)")
            ServicesTextBox.Visible = False
        End If

        If ClassDropDownList.SelectedValue = "Services" Then
            PropertyDropDownList.Visible = False
            ServicesTextBox.Visible = True
        End If

    End Sub

End Class
