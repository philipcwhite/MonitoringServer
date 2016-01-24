Imports MonitoringDatabase
Imports AuthClass
Imports System.Security.Principal


Partial Class _Default
    Inherits System.Web.UI.Page

    Private db As New DBModel

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.Redirect("~/Home/")
    End Sub

    Private Sub _Default_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad

        'Please comment out this sub after installation

        If db.Database.Exists = False Then
            db.Database.Create()
            db.SaveChanges()
        End If

        Try
            Dim Q2 = (From T In db.Users
                      Select T.UserName).FirstOrDefault

            If Q2 Is Nothing Then
                Try
                    'Add Admin User
                    db.Users.Add(New Users With {.UserName = "admin", .FirstName = "Admin", .LastName = "User", .Password = GetSHA512HashData("password"), .UserRole = "Administrator", .EmailAddress = "admin@localhost", .LastModified = Date.Now})
                    db.SaveChanges()
                    'Set defaults
                    Dim GTH As New GlobalThresholdData
                    GTH.AddThresholds()

                    Response.Redirect("~/Home/")
                Catch ex As Exception

                End Try
            End If
        Catch

            Response.Redirect("~/Home/")
        End Try

    End Sub
End Class



