Imports MonitoringEventEngine.MonitoringDatabase
Imports System.Net.Mail
Imports System.IO
Imports System.Xml
Imports System.Text

Public Class Notifications
    Private Property db As New DBModel


    Public Sub RouteNotification(ByVal AName As String, ADate As String, AMessage As String, ASeverity As Integer, AClass As String, AProperty As String, AComparison As String)

        Dim Q = (From T In db.ServerConfiguration
                 Where T.Name = "Event_Route"
                 Select T.Value).FirstOrDefault

        If Q IsNot Nothing Then
            If Q = "Text" Then
                ExportEvent(AName, ADate, AMessage, ASeverity, AClass, AProperty, AComparison)
            ElseIf Q = "Email" Then
                SendMail(AName, ADate, AMessage, ASeverity, AClass, AProperty, AComparison)
            End If
        End If

    End Sub


    Public Sub SendMail(ByVal AName As String, ADate As String, AMessage As String, ASeverity As Integer, AClass As String, AProperty As String, AComparison As String)

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

                If QRecipients IsNot Nothing Then
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
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub

    Public Sub ExportEvent(ByVal AName As String, ADate As String, AMessage As String, ASeverity As Integer, AClass As String, AProperty As String, AComparison As String)
        Dim Path As String = Reflection.Assembly.GetEntryAssembly.Location.Replace("bin\MonitoringEventEngine.exe", "export\")
        Dim NGUID As String = Guid.NewGuid.ToString

        Dim QRecipients = (From T1 In db.Subscriptions
                           Join T2 In db.Users On T1.UserName Equals T2.UserName
                           Where T1.AgentName = AName
                           Select T2.EmailAddress).Distinct

        Dim ARecipients As String = Nothing
        For Each i In QRecipients
            ARecipients = ARecipients & i & ","
        Next

        ARecipients = ARecipients.Substring(0, ARecipients.Length - 1)

        AMessage = filterXML(AMessage)
        AComparison = filterXML(AComparison)


        If Not File.Exists(Path & NGUID & ".xml") Then
            Dim Settings As XmlWriterSettings = New XmlWriterSettings()
            Settings.Indent = True
            Settings.NewLineOnAttributes = False
            Settings.OmitXmlDeclaration = True
            Dim SB As New StringBuilder()

            Using SW As New StringWriter(SB)
                Using writer = XmlWriter.Create(SW, Settings)
                    writer.WriteStartDocument()
                    writer.WriteStartElement("Event")

                    'Default Values
                    writer.WriteStartElement("Contents")
                    writer.WriteElementString("Name", AName)
                    writer.WriteElementString("Date", ADate)
                    writer.WriteElementString("Message", AMessage)
                    writer.WriteElementString("Severity", ASeverity)
                    writer.WriteElementString("Class", AClass)
                    writer.WriteElementString("Property", AProperty)
                    writer.WriteElementString("Comparison", AComparison)
                    writer.WriteElementString("Recipients", ARecipients)
                    writer.WriteEndElement()

                    writer.WriteEndElement()
                    writer.WriteEndDocument()
                End Using
            End Using

            File.WriteAllText(Path & NGUID & ".xml", SB.ToString)

        End If

    End Sub


    Public Function filterXML(ByVal input As String)
        Dim output As String = Nothing

        input = input.Replace(">", "&gt;")
        input = input.Replace("<", "&lt;")
        output = input

        Return output
    End Function

End Class
