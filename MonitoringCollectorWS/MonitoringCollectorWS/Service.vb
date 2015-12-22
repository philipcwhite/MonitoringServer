Imports System.Threading

Public Class Service

    'Private Property ListenThread As Thread

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.



        Dim SLoad As New ServerLoad
        SLoad.LoadParameters()

        Dim SListener As New ServerListener
        SListener.Listen()

        'Dim ReceiveTCP As New ReceiveTCP
        'ListenThread = New Thread(AddressOf ReceiveTCP.StartListener)
        'ListenThread.Start()

        'Dim LaunchTimer As New Timers.Timer
        'AddHandler LaunchTimer.Elapsed, AddressOf Tick
        'LaunchTimer.Interval = 60000
        'LaunchTimer.Enabled = True
        'LaunchTimer.AutoReset = False
        'LaunchTimer.Start()

    End Sub

    'Private Sub Tick(sender As System.Object, e As System.EventArgs)

    '    If ListenThread.IsAlive = False Then
    '        Dim ReceiveTCP As New ReceiveTCP
    '        ListenThread = New Thread(AddressOf ReceiveTCP.StartListener)
    '        ListenThread.Start()
    '    End If

    'End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        'If ListenThread.IsAlive = True Then
        '    ListenThread.Abort()
        'End If
    End Sub

End Class
