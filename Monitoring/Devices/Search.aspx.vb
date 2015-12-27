Imports MonitoringDatabase
Partial Class Devices_Search
    Inherits System.Web.UI.Page

    Private Property db As New DBModel

    Private Sub Devices_Search_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim SearchTerm As String = Nothing
        SearchTerm = Request.QueryString("Search")
        SearchLabel.Text = SearchTerm

        Dim Q = From T In db.AgentSystem
                Where T.AgentName.Contains(SearchTerm) Or T.AgentIP.Contains(SearchTerm)
                Select T

        For Each i In Q

            Dim SearchLink As New HyperLink
            SearchLink.Text = i.AgentName
            SearchLink.NavigateUrl = "~/Devices/Device.aspx?hostname=" & i.AgentName
            SearchLink.Font.Bold = True

            Dim SearchResult As New LiteralControl(" Domain: " & i.AgentDomain & " IP Address: " & i.AgentIP & "<br />")
            ResultsPlaceHolder.Controls.Add(SearchLink)
            ResultsPlaceHolder.Controls.Add(SearchResult)
        Next


    End Sub

End Class
