Imports MonitoringDataEngine.MonitoringDatabase
Imports MonitoringDataEngine.ServerParameters
Public Class CleanUp

    Private db As New DBModel


    Public Sub PurgeData()

        Try

            Dim PurgeDate = ServerTime.AddDays(-1)
            'Dim PurgeDate = ServerTime.AddHours(-24)

            db.AgentData.RemoveRange(db.AgentData.Where(Function(o) o.AgentCollectDate < PurgeDate))
            db.SaveChanges()

            'Cleanup Archive
            PurgeDate = Date.Now.AddDays(-14)

            db.AgentDataArchive.RemoveRange(db.AgentDataArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
            db.SaveChanges()

            'Cleanup Broken links

            Dim excludeList = db.AgentSystem.Cast(Of AgentSystem).Select(Function(x) x.AgentName).ToArray()
            Dim results = db.Subscriptions.Where(Function(x) Not excludeList.Contains(x.AgentName))

            For Each i In results
                db.Subscriptions.Remove(i)
            Next
            db.SaveChanges()

        Catch ex As Exception

        End Try

    End Sub


End Class
