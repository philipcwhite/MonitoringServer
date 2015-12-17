Imports MonitoringDataEngineWS.MonitoringDatabase
Public Class CleanUp

    Private db As New DBModel


    Public Sub PurgeData()

        'Purge Collector Data
        Dim PurgeDate = Date.Now.AddDays(-1)
        Dim Q1 = From T In db.AgentCollector
                 Where T.AgentDataMoved = True And T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q1
            db.AgentCollector.Remove(i)
        Next
        db.SaveChanges()



        Dim Q2 = From T In db.AgentProcessor
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q2
            db.AgentProcessor.Remove(i)
        Next
        db.SaveChanges()



        Dim Q3 = From T In db.AgentMemory
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q3
            db.AgentMemory.Remove(i)
        Next
        db.SaveChanges()

        Dim Q4 = From T In db.AgentLogicalDisk
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q4
            db.AgentLogicalDisk.Remove(i)
        Next
        db.SaveChanges()

        Dim Q5 = From T In db.AgentService
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q5
            db.AgentService.Remove(i)
        Next
        db.SaveChanges()




        PurgeDate = Date.Now.AddDays(-30)




        Dim Q6 = From T In db.AgentProcessorArchive
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q6
            db.AgentProcessorArchive.Remove(i)
        Next
        db.SaveChanges()


        Dim Q7 = From T In db.AgentMemoryArchive
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q7
            db.AgentMemoryArchive.Remove(i)
        Next
        db.SaveChanges()

        Dim Q8 = From T In db.AgentLogicalDiskArchive
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q8
            db.AgentLogicalDiskArchive.Remove(i)
        Next
        db.SaveChanges()

        Dim Q9 = From T In db.AgentServiceArchive
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q9
            db.AgentServiceArchive.Remove(i)
        Next
        db.SaveChanges()







    End Sub


End Class
