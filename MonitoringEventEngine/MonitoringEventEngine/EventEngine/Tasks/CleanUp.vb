Imports MonitoringEventEngine.MonitoringDatabase
Public Class CleanUp
    Private db As New DBModel

    Public Sub PurgeRecords()
        Dim PurgeDate = Date.Now.AddHours(-12)
        Try
            db.AgentEvents.RemoveRange(db.AgentEvents.Where(Function(o) o.EventStatus = False And o.EventDate < PurgeDate))
            db.SaveChanges()
        Catch ex As Exception

        End Try
    End Sub


End Class
