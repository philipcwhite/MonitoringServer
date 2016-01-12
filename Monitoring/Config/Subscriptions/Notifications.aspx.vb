Imports MonitoringDatabase
Partial Class Config_Subscriptions_Default
    Inherits System.Web.UI.Page
    Private Property db As New DBModel

    Private Sub Config_Subscriptions_Default_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim QString1 = Nothing
            Dim QString2 = Nothing
            Dim SubscriptionID As Integer = Nothing
            Dim Notify As Boolean = False

            QString1 = Request.QueryString("SubscriptionID")
            QString2 = Request.QueryString("Notify")

            SubscriptionID = CInt(QString1)
            Notify = CBool(QString2)

        If QString1 <> "" And QString2 <> "" Then
            EditRecord(SubscriptionID, User.Identity.Name, Notify)
        End If

        If Not IsPostBack Then
            BuildTable()
        End If




    End Sub

    Private Sub BuildTable()

        PlaceHolder1.Controls.Clear()

        Dim Q = From T In db.Subscriptions
                Where T.UserName = User.Identity.Name
                Order By T.AgentName Ascending
                Select T

        Dim Table As New LiteralControl("<table class='HoverTable' style='width:250px'><thead><tr><th style='width:125px;'>My Devices</th><th style='width:125px;text-align:center'>Email Notifications</th></tr></thead>")
        PlaceHolder1.Controls.Clear()
        PlaceHolder1.Controls.Add(Table)

        For Each i In Q



            Dim EditButton As New Button
            EditButton.Text = i.Notify
            EditButton.CssClass = "Button"
            If i.Notify = False Then
                EditButton.PostBackUrl = "~/Config/Subscriptions/Notifications.aspx?SubscriptionID=" & i.SubscriptionID & "&Notify=True"
            Else
                EditButton.PostBackUrl = "~/Config/Subscriptions/Notifications.aspx?SubscriptionID=" & i.SubscriptionID & "&Notify=False"
            End If


            Dim RowStart As New LiteralControl("<tr><td>" & i.AgentName & "</td><td style='text-align:center'>")
            PlaceHolder1.Controls.Add(RowStart)
            PlaceHolder1.Controls.Add(EditButton)
            Dim RowEnd As New LiteralControl("</td></tr>")
            PlaceHolder1.Controls.Add(RowEnd)
        Next
        Dim EndTable As New LiteralControl("</Table>")
        PlaceHolder1.Controls.Add(EndTable)
    End Sub


    Private Sub EditRecord(ByVal SubscriptionID As Integer, ByVal UserName As String, ByVal Notify As Boolean)

        Dim Q = (From T In db.Subscriptions
                 Where T.UserName = UserName And T.SubscriptionID = SubscriptionID
                 Select T).FirstOrDefault

        Q.Notify = Notify
        db.SaveChanges()

        BuildTable()

    End Sub

End Class
