Imports MonitoringDataEngine.MonitoringDatabase
Public Class ArchiveAgentData

    Private db As New DBModel

    Public Sub Archive()

        Dim PurgeDate = Date.Now.AddDays(-1)

        Dim Q1 = (From T In db.AgentProcessor
                  Where T.AgentCollectDate < PurgeDate
                  Select T).AsParallel

        Parallel.ForEach(Q1, Sub(i)
                                 ' For Each i In Q1
                                 db.AgentProcessorArchive.Add(New AgentProcessorArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
                                 ' Next

                             End Sub)
        db.SaveChanges()


        Dim Q2 = (From T In db.AgentMemory
                  Where T.AgentCollectDate < PurgeDate
                  Select T).AsParallel

        Parallel.ForEach(Q2, Sub(i)
                                 'For Each i In Q2
                                 db.AgentMemoryArchive.Add(New AgentMemoryArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
                                 ' Next
                             End Sub)
        db.SaveChanges()

        Dim Q3 = (From T In db.AgentLogicalDisk
                  Where T.AgentCollectDate < PurgeDate
                  Select T).AsParallel

        Parallel.ForEach(Q3, Sub(i)
                                 '        For Each i In Q3
                                 db.AgentLogicalDiskArchive.Add(New AgentLocalDiskArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue, .AgentInstance = i.AgentInstance})
                                 '                         Next
                             End Sub)
        db.SaveChanges()

        Dim Q4 = (From T In db.AgentService
                  Where T.AgentCollectDate < PurgeDate
                  Select T).AsParallel

        Parallel.ForEach(Q4, Sub(i)
                                 'For Each i In Q4
                                 db.AgentServiceArchive.Add(New AgentServiceArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
                                 'Next
                             End Sub)
        db.SaveChanges()




                            End Sub




End Class
