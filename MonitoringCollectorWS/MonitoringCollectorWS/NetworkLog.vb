Imports MonitoringCollectorWS.ServerParameters
Imports System.IO

Public Class NetworkLog


    Public Sub InitializeLog()
        ServerNetLog = "Initializing Log..." & vbCrLf
        SyncLock (Lock)
            File.WriteAllText(ServerPath & "ServerNetLog.log", ServerNetLog)
        End SyncLock
    End Sub

    Public Sub WriteToLog(ByVal Message As String)
        If Not ServerNetLog Is Nothing Then
            If ServerNetLog.Length > 10000 Then
                ServerNetLog = Nothing
            End If
        End If
        ServerNetLog = ServerNetLog & Date.Now & " [SERVER] " & Message & vbCrLf
        SyncLock (Lock)
            File.WriteAllText(ServerPath & "ServerNetLog.log", ServerNetLog)
        End SyncLock
    End Sub

    Private Lock As New Object

End Class
