Imports MonitoringDataEngine.MonitoringDatabase
Imports MonitoringDataEngine.ServerParameters
Public Class CleanUp

    Private db As New DBModel


    Public Sub PurgeData()

        Try

            Dim PurgeDate = ServerTime.AddDays(-1)

        db.AgentProcessor.RemoveRange(db.AgentProcessor.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentMemory.RemoveRange(db.AgentMemory.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentPageFile.RemoveRange(db.AgentPageFile.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentLocalDisk.RemoveRange(db.AgentLocalDisk.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentService.RemoveRange(db.AgentService.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()


        'Cleanup Archive
        PurgeDate = Date.Now.AddDays(-30)

        db.AgentProcessorArchive.RemoveRange(db.AgentProcessorArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentMemoryArchive.RemoveRange(db.AgentMemoryArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentPageFile.RemoveRange(db.AgentPageFile.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentLocalDiskArchive.RemoveRange(db.AgentLocalDiskArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentServiceArchive.RemoveRange(db.AgentServiceArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentSystem.RemoveRange(db.AgentServiceArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
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
