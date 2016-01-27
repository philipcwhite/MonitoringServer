Imports MonitoringDataEngine.MonitoringDatabase
Imports MonitoringDataEngine.ServerParameters
Public Class ArchiveAgentData

    Private db As New DBModel

    Public Sub Archive()


        Dim CurrentTime As Date = ServerTime.ToString("MM/dd/yyyy HH:mm")
        Dim ArchiveTime As Date = CurrentTime.AddDays(-1)

        Try
            Dim Q1 = From T In db.AgentProcessor
                     Where T.AgentCollectDate < ArchiveTime
                     Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                     Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}


            For Each i In Q1
                db.AgentProcessorArchive.Add(New AgentProcessorArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = ArchiveTime, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 0)})
            Next

            db.SaveChanges()

        Catch
        End Try

        Try
            Dim Q2 = From T In db.AgentMemory
                     Where T.AgentCollectDate < ArchiveTime
                     Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                     Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}


            For Each i In Q2
                db.AgentMemoryArchive.Add(New AgentMemoryArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = ArchiveTime, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 0)})
            Next

            db.SaveChanges()
        Catch
        End Try

        Try
            Dim Q3 = From T In db.AgentPageFile
                     Where T.AgentCollectDate < ArchiveTime
                     Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                     Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}


            For Each i In Q3
                db.AgentPageFileArchive.Add(New AgentPageFileArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = ArchiveTime, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 0)})
            Next

            db.SaveChanges()

        Catch
        End Try

        Try
            Dim Q4 = From T In db.AgentLocalDisk
                     Where T.AgentCollectDate < ArchiveTime
                     Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                     Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}


            For Each i In Q4
                db.AgentLocalDiskArchive.Add(New AgentLocalDiskArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = ArchiveTime, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 0)})
            Next

            db.SaveChanges()
        Catch
        End Try

        Try
            Dim Q5 = From T In db.AgentService
                     Where T.AgentCollectDate < ArchiveTime
                     Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                     Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}


            For Each i In Q5
                db.AgentServiceArchive.Add(New AgentServiceArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = ArchiveTime, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 2)})
            Next

            db.SaveChanges()

        Catch
        End Try

    End Sub




End Class
