Imports Microsoft.VisualBasic
Imports MonitoringDatabase
Imports System.Security.Cryptography

Public Class AuthClass

    Public Shared db As New DBModel

    Public Shared Sub AuthenticateUser(ByVal UserName As String, ByVal Password As String)

        If ValidateUser(UserName, Password) Then

            Dim Q = (From T In db.Users
                     Where T.UserName = UserName
                     Select T).FirstOrDefault



            Dim userData As String = Nothing

            userData = Q.UserRole

            Dim isPersistent As Boolean = False

            Dim ticket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1,
             UserName,
             Date.Now,
             Date.Now.AddMinutes(30),
             isPersistent,
             userData,
             FormsAuthentication.FormsCookiePath)

            ' Encrypt the ticket.
            Dim encTicket As String = FormsAuthentication.Encrypt(ticket)

            ' Create the cookie.
            HttpContext.Current.Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, encTicket))

            ' Redirect back to original URL.
            HttpContext.Current.Response.Redirect(FormsAuthentication.GetRedirectUrl(UserName, isPersistent))
        Else

        End If

    End Sub


    Public Shared Function ValidateUser(ByVal UserName As String, ByVal Password As String) As Boolean
        Dim x = False
        Password = GetSHA512HashData(Password)

        Dim Q = (From T In db.Users
                 Where T.UserName = UserName And T.Password = Password
                 Select T).FirstOrDefault

        If Not Q Is Nothing Then
            x = True
        End If
        Return x
    End Function

    Public Shared Function GetSHA512HashData(ByVal Data As String) As String
        Dim SHA512 As New SHA512CryptoServiceProvider
        Dim HashBytes As Byte() = SHA512.ComputeHash(Encoding.UTF8.GetBytes(Data))
        Return Convert.ToBase64String(HashBytes)
    End Function



    Public Shared Function AddUser(ByVal UserName As String, ByVal Password As String, ByVal FirstName As String, ByVal LastName As String, ByVal Email As String) As String
        Dim Message As String = Nothing

        Dim Q = (From T In db.Users
                 Where T.UserName = UserName
                 Select T).FirstOrDefault

        If Q Is Nothing Then
            Dim EncryptPassword As String = GetSHA512HashData(Password)
            db.Users.Add(New Users With {.UserName = UserName, .Password = EncryptPassword, .FirstName = FirstName, .LastName = LastName, .EmailAddress = Email, .UserRole = "Pending"})
            db.SaveChanges()
            Message = "Successfuly created user account!"
            HttpContext.Current.Response.Redirect("~/User/RegisterStatus.aspx")
        Else
            Message = "User name already exists!"
        End If

        Return Message
    End Function


    Public Shared Function UpdateUser(ByVal UserName As String, ByVal ChangePassword As Boolean, ByVal Password As String, ByVal FirstName As String, ByVal LastName As String, ByVal EmailAddress As String, ByVal UserRole As String) As Boolean
        Dim Message = False

        Dim Q = (From T In db.Users
                 Where T.UserName = UserName
                 Select T).FirstOrDefault

        If ChangePassword = True Then
            Q.Password = GetSHA512HashData(Password)
        End If

        Q.FirstName = FirstName
        Q.LastName = LastName
        Q.EmailAddress = EmailAddress
        If Not UserRole Is Nothing Then
            Q.UserRole = UserRole
        End If
        Q.LastModified = Date.Now
        db.SaveChanges()
        Message = True

        Return Message
    End Function

    Public Shared Sub DeleteUser(ByVal UserName As String)

        Dim Q1 = db.Subscriptions.RemoveRange(db.Subscriptions.Where(Function(x) x.UserName = UserName))
        db.SaveChanges()

        Dim Q2 = db.Users.Where(Function(x) x.UserName = UserName).FirstOrDefault
        db.Users.Remove(Q2)
        db.SaveChanges()

    End Sub

End Class
