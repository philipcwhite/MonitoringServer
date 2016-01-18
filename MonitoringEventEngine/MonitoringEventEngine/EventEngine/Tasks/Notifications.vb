Imports MonitoringEventEngine.MonitoringDatabase
Imports System.Net.Mail

Public Class Notifications
    Private Property db As New DBModel

    Public Sub Send(ByVal AName As String, AMessage As String, ASeverity As Integer, AClass As String, AProperty As String, AComparison As String)

        Dim MailServer As String = Nothing
        Dim MailAdmin As String = Nothing

        Try

            Dim QMailServer = (From T In db.ServerConfiguration
                               Where T.Name = "Mail_Server"
                               Select T.Value).FirstOrDefault
            If QMailServer <> "" Then
                MailServer = QMailServer
            End If

            Dim QMailAdmin = (From T In db.ServerConfiguration
                              Where T.Name = "Mail_Admin"
                              Select T.Value).FirstOrDefault
            If QMailAdmin <> "" Then
                MailAdmin = QMailAdmin
            End If

        Catch ex As Exception
        End Try

        If MailServer <> Nothing Or MailAdmin <> Nothing Then

            Try

                Dim QRecipients = (From T1 In db.Subscriptions
                                   Join T2 In db.Users On T1.UserName Equals T2.UserName
                                   Where T1.AgentName = AName
                                   Select T2.EmailAddress).Distinct

                Dim SmtpServer As New SmtpClient()
                Dim Mail As New MailMessage()
                'SmtpServer.Credentials = New Net.NetworkCredential("username@domain.com", "password")
                SmtpServer.Port = 587
                SmtpServer.Host = MailServer
                Mail = New MailMessage()
                Mail.From = New MailAddress(MailAdmin)
                For Each i In QRecipients
                    Mail.To.Add(i)
                Next
                Dim MSeverity As String = Nothing
                If ASeverity = 0 Then
                    MSeverity = "Informational"
                ElseIf ASeverity = 1 Then
                    MSeverity = "Warning"
                ElseIf ASeverity = 2 Then
                    MSeverity = "Critical"
                End If
                Mail.Subject = AName & ": " & AProperty & " is " & MSeverity
                Mail.Body = AMessage
                SmtpServer.Send(Mail)
            Catch ex As Exception

            End Try

        End If

    End Sub

End Class
