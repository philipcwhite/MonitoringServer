Imports MonitoringDataEngineWS.MonitoringDatabase
Public Class CleanUp

    Private db As New DBModel


    Public Sub PurgeData()

        'Purge Collector Data
        Dim PurgeDate = Date.Now.AddDays(-1)


        db.AgentCollector.RemoveRange(db.AgentCollector.Where(Function(o) o.AgentDataMoved = True And o.AgentCollectDate < PurgeDate))
        db.SaveChanges()


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

        'Dim Q6 = From T In db.AgentProcessorArchive
        '         Where T.AgentCollectDate < PurgeDate
        '         Select T

        'For Each i In Q6
        '    db.AgentProcessorArchive.Remove(i)
        'Next
        'db.SaveChanges()


        'Dim Q7 = From T In db.AgentMemoryArchive
        '         Where T.AgentCollectDate < PurgeDate
        '         Select T

        'For Each i In Q7
        '    db.AgentMemoryArchive.Remove(i)
        'Next
        'db.SaveChanges()

        'Dim Q8 = From T In db.AgentLogicalDiskArchive
        '         Where T.AgentCollectDate < PurgeDate
        '         Select T

        'For Each i In Q8
        '    db.AgentLogicalDiskArchive.Remove(i)
        'Next
        'db.SaveChanges()

        'Dim Q9 = From T In db.AgentServiceArchive
        '         Where T.AgentCollectDate < PurgeDate
        '         Select T

        'For Each i In Q9
        '    db.AgentServiceArchive.Remove(i)
        'Next
        'db.SaveChanges()







    End Sub


End Class
