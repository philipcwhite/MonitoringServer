'MonitoringDataEngine  
'Copyright 2016 Phil White, wcpSoft
'This software is released under the Apache 2.0 License
'Maintained at http://github.com/philipcwhite

Imports System.Threading

Public Class Service

    Private DataEngineThread As Thread

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        DataEngineThread = New Thread(AddressOf DataEngine)
        DataEngineThread.Start()

        Dim LaunchTimer As New Timers.Timer
        AddHandler LaunchTimer.Elapsed, AddressOf Tick
        LaunchTimer.Interval = 60000
        LaunchTimer.Enabled = True
        LaunchTimer.Start()

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.

        If DataEngineThread.IsAlive = True Then
            DataEngineThread.Abort()
        End If

    End Sub


    Private Sub Tick(sender As System.Object, e As System.EventArgs)
        If DataEngineThread.IsAlive = False Then
            DataEngineThread = New Thread(AddressOf DataEngine)
            DataEngineThread.Start()
        End If

    End Sub

    Private Sub DataEngine()
        ' Try

        Dim Archive As New ArchiveAgentData
            Archive.Archive()

            Dim CleanAgents As New CleanUp
            CleanAgents.PurgeData()

        'Catch ex As Exception

        'End Try

        DataEngineThread.Abort()

    End Sub



End Class
