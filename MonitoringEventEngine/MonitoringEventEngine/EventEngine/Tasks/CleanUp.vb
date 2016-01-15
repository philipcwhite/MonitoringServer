Imports MonitoringEventEngine.MonitoringDatabase
Public Class CleanUp
    Private db As New DBModel

    Public Sub PurgeRecords()
        Dim PurgeDate = Date.Now.AddDays(-7)
        Try
            db.AgentEvents.RemoveRange(db.AgentEvents.Where(Function(o) o.AgentStatus = False And o.AgentEventDate < PurgeDate))
            db.SaveChanges()
        Catch ex As Exception

        End Try
    End Sub


End Class
