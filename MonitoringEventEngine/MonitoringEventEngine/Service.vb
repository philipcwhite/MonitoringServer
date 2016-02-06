'MonitoringEventEngine  
'Copyright 2016 Phil White, pcwSoft
'This software is released under the Apache 2.0 License
'Maintained at http://github.com/philipcwhite

Imports System.Threading

Public Class Service

    Private EventEngineThread As Thread

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        System.Data.Entity.Database.SetInitializer(Of MonitoringDatabase.DBModel)(Nothing)


        EventEngineThread = New Thread(AddressOf EventEngine)
        EventEngineThread.Start()

        Dim LaunchTimer As New Timers.Timer
        AddHandler LaunchTimer.Elapsed, AddressOf Tick
        LaunchTimer.Interval = 60000
        LaunchTimer.Enabled = True
        LaunchTimer.Start()

    End Sub

    Private Sub Tick(sender As System.Object, e As System.EventArgs)

        If EventEngineThread.IsAlive = False Then
            EventEngineThread = New Thread(AddressOf EventEngine)
            EventEngineThread.Start()
        End If

    End Sub

    Private Sub EventEngine()

        Dim TH As New Thresholds
        TH.Load()
        TH.RunThresholds()
        TH.AgentStatus()
        TH.SendEvents()

        Dim PEvents As New CleanUp
        PEvents.PurgeRecords()

        EventEngineThread.Abort()

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Try
            If EventEngineThread.IsAlive = True Then
                EventEngineThread.Abort()
            End If
        Catch
        End Try

    End Sub

End Class
