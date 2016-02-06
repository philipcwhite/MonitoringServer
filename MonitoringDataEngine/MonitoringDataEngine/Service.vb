'MonitoringDataEngine  
'Copyright 2016 Phil White, pcwSoft
'This software is released under the Apache 2.0 License
'Maintained at http://github.com/philipcwhite

Imports MonitoringDataEngine.ServerParameters
Imports System.Threading

Public Class Service

    Private DataEngineThread As Thread

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.



        Dim LaunchTimer As New Timers.Timer
        AddHandler LaunchTimer.Elapsed, AddressOf Tick
        LaunchTimer.Interval = 1000
        LaunchTimer.Enabled = True
        LaunchTimer.Start()

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Try
            If DataEngineThread.IsAlive = True Then
                DataEngineThread.Abort()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Tick(sender As System.Object, e As System.EventArgs)

        ServerTime = Date.Now
        Dim TimeString As String = ServerTime.ToString("mm:ss").Substring(0, 5)
        If TimeString = "00:00" Then
            DataEngineThread = New Thread(AddressOf DataEngine)
            DataEngineThread.IsBackground = True
            DataEngineThread.Start()
        End If

    End Sub

    Private Sub DataEngine()

        Dim Archive As New ArchiveAgentData
        Archive.Archive()
        Dim CleanAgents As New CleanUp
        CleanAgents.PurgeData()
        DataEngineThread.Abort()

    End Sub



End Class
