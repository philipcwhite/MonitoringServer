Imports MonitoringEventEngineWS.MonitoringDatabase
Public Class CleanUp
    Private db As New DBModel

    Public Sub PurgeRecords()
        Dim PurgeDate = Date.Now.AddDays(-7)
        Dim Q = From T In db.AgentEvents
                Where T.AgentStatus = False And T.AgentEventDate < PurgeDate
                Select T

        For Each i In Q
            db.AgentEvents.Remove(i)
        Next
        db.SaveChanges()

    End Sub


End Class
