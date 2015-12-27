
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub SearchImageButton_Click(sender As Object, e As ImageClickEventArgs) Handles SearchImageButton.Click
        Response.Redirect("~/Devices/Search.aspx?Search=" & SearchTextBox.Text)
    End Sub
End Class

