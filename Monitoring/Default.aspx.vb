Imports MonitoringDatabase
Imports AuthClass
Imports System.Security.Principal


Partial Class _Default
    Inherits System.Web.UI.Page

    Private db As New DBModel

    Private Sub _Default_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        Try
            Dim Q1 = (From T In db.Users
                      Select T.UserName).FirstOrDefault

        Catch ex As Exception

        End Try

        Dim Q2 = (From T In db.Users
                  Select T.UserName).FirstOrDefault

        If Q2 Is Nothing Then
            Try
                'Add Admin User
                db.Users.Add(New Users With {.UserName = "admin", .FirstName = "Admin", .LastName = "User", .Password = GetSHA512HashData("password"), .UserRole = "Administrator", .LastModified = Date.Now})
                db.SaveChanges()
                'Set defaults
                Dim GTH As New GlobalThresholdData
                GTH.AddThresholds()

                Response.Redirect("~/Options/")
            Catch ex As Exception

            End Try
        End If

        Response.Redirect("~/Events/")

    End Sub
End Class



