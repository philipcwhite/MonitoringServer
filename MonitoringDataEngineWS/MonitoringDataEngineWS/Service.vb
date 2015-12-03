Imports System.Threading

Public Class Service

    Private DataEngineThread As Thread

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

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

        DataEngineThread = New Thread(AddressOf DataEngine)
        DataEngineThread.Start()


    End Sub

    Private Sub DataEngine()
        Try


            Dim MAgents As New MoveAgents
            MAgents.QueryDatabase()
            MAgents.InsertAgents()
            MAgents.UpdateAgents()

            Dim MAgentData As New MoveAgentData
            MAgentData.QueryDataBase()
            MAgentData.InsertAgentData()

            Dim CleanAgents As New CleanUp
            CleanAgents.PurgeData()

        Catch ex As Exception

        End Try
    End Sub



End Class
