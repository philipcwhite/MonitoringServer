Imports MonitoringDataEngine.MonitoringDatabase
Public Class CleanUp

    Private db As New DBModel


    Public Sub PurgeData()


        Dim PurgeDate = Date.Now.AddDays(-1)

        db.AgentProcessor.RemoveRange(db.AgentProcessor.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentMemory.RemoveRange(db.AgentMemory.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentLogicalDisk.RemoveRange(db.AgentLogicalDisk.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentService.RemoveRange(db.AgentService.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()


        PurgeDate = Date.Now.AddDays(-30)


        db.AgentProcessorArchive.RemoveRange(db.AgentProcessorArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentMemoryArchive.RemoveRange(db.AgentMemoryArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentLogicalDiskArchive.RemoveRange(db.AgentLogicalDiskArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()

        db.AgentServiceArchive.RemoveRange(db.AgentServiceArchive.Where(Function(o) o.AgentCollectDate < PurgeDate))
        db.SaveChanges()


    End Sub


End Class
