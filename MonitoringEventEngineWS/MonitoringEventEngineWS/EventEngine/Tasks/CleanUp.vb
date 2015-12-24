Imports MonitoringEventEngineWS.MonitoringDatabase
Public Class CleanUp
    Private db As New DBModel

    Public Sub PurgeRecords()
        Dim PurgeDate = Date.Now.AddDays(-7)

        db.AgentEvents.RemoveRange(db.AgentEvents.Where(Function(o) o.AgentStatus = False And o.AgentEventDate < PurgeDate))
        db.SaveChanges()

    End Sub


End Class
