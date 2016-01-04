Imports MonitoringDataEngine.MonitoringDatabase
Public Class ArchiveAgentData

    Private db As New DBModel

    Public Sub Archive()

        Dim PurgeDate = Date.Now.AddDays(-1)

        Dim Q1 = From T In db.AgentProcessor
                 Where T.AgentCollectDate < PurgeDate
                 Select T.AgentName, T.AgentClass, T.AgentProperty, T.AgentValue, T.AgentCollectDate


        For Each i In Q1
            db.AgentProcessorArchive.Add(New AgentProcessorArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next


        Dim Q2 = From T In db.AgentMemory
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q2
            db.AgentMemoryArchive.Add(New AgentMemoryArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next

        db.SaveChanges()

        Dim Q3 = From T In db.AgentPageFile
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q3
            db.AgentPageFileArchive.Add(New AgentPageFileArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next

        db.SaveChanges()

        Dim Q4 = From T In db.AgentLocalDisk
                 Where T.AgentCollectDate < PurgeDate
                 Select T


        For Each i In Q4
            db.AgentLocalDiskArchive.Add(New AgentLocalDiskArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next

        db.SaveChanges()

        Dim Q5 = From T In db.AgentService
                 Where T.AgentCollectDate < PurgeDate
                 Select T

        For Each i In Q5
            db.AgentServiceArchive.Add(New AgentServiceArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next

        db.SaveChanges()



    End Sub




End Class
