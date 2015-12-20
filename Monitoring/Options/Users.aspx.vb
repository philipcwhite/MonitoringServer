Imports MonitoringDatabase
Partial Class Options_Users
    Inherits System.Web.UI.Page

    Private Property db As New DBModel

    Private Sub Options_Users_Load(sender As Object, e As EventArgs) Handles Me.Load
        BuildTable()
    End Sub

    Private Sub BuildTable()

        'Add Paging for past 1000 Events

        Dim Q = From T In db.Users
                Order By T.LastName Ascending
                Select T

        Dim Table As New LiteralControl("<table class='HoverTable'><thead><tr><th>Last Name</th><th>First Name</th><th>User Name</th><th>Email Address</th><th>User Role</th><th></th></tr></thead>")
        UsersPlaceHolder.Controls.Clear()
        UsersPlaceHolder.Controls.Add(Table)

        For Each i In Q
            Dim EditButton As New Button
            EditButton.Text = "Edit"
            EditButton.CssClass = "Button"
            EditButton.ID = i.UserID
            EditButton.PostBackUrl = "~/Options/UpdateUser.aspx?UserName=" & i.UserName

            Dim DeleteButton As New Button
            DeleteButton.Text = "Delete"
            DeleteButton.CssClass = "Button"
            DeleteButton.ID = i.UserID
            DeleteButton.PostBackUrl = "~/Options/DeleteConfirm.aspx?UserName=" & i.UserName

            Dim Blank As New LiteralControl(" ")

            Dim Row As New LiteralControl("<tr><td>" & i.LastName & "</td><td>" & i.FirstName & "</td><td>" & i.UserName & "</td><td>" & i.EmailAddress & "</td><td>" & i.UserRole & "</td><td style='text-align:center'>")

            UsersPlaceHolder.Controls.Add(Row)
            UsersPlaceHolder.Controls.Add(EditButton)
            UsersPlaceHolder.Controls.Add(Blank)
            UsersPlaceHolder.Controls.Add(DeleteButton)
            Dim Row2 As New LiteralControl("</td></tr>")
            UsersPlaceHolder.Controls.Add(Row2)
        Next
        Dim EndTable As New LiteralControl("</Table>")
        UsersPlaceHolder.Controls.Add(EndTable)
    End Sub


    Protected Sub UsersTimer_Tick(sender As Object, e As EventArgs) Handles UsersTimer.Tick
        BuildTable()
    End Sub

    Private Sub Options_Users_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        If Not User.IsInRole("Administrator") Then
            Response.Redirect("~/Options")
        End If
    End Sub
End Class
