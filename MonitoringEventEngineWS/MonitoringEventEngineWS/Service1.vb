Imports System.Threading

Public Class Service

    Private EventEngineThread As Thread

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        Dim LaunchTimer As New Timers.Timer
        AddHandler LaunchTimer.Elapsed, AddressOf Tick
        LaunchTimer.Interval = 60000
        LaunchTimer.Enabled = True
        LaunchTimer.Start()

    End Sub

    Private Sub Tick(sender As System.Object, e As System.EventArgs)

        EventEngineThread = New Thread(AddressOf EventEngine)
        EventEngineThread.Start()


    End Sub

    Private Sub EventEngine()

        Dim MEvents As New ManageEvents
        MEvents.Thresholds("Processor", "Total Util (%)")
        MEvents.Thresholds("Memory", "Total Util (%)")
        MEvents.Thresholds("Logical Disk", "")
        MEvents.Thresholds("Services", "")


    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        If EventEngineThread.IsAlive = True Then
            EventEngineThread.Abort()
        End If

    End Sub

End Class
