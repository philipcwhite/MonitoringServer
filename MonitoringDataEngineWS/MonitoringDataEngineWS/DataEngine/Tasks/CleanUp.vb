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

        PurgeDate = Date.Now.AddDays(-7)


        'Purge Agent Data

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





    End Sub

    Public Sub Archive()

    End Sub

End Class
