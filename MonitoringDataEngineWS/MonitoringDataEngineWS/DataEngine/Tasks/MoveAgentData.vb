Imports MonitoringDataEngineWS.MonitoringDatabase
Public Class MoveAgentData


    Private db As New DBModel
    Private AgentCollectorLocal As New List(Of AgentCollector)


    Public Sub QueryDataBase()

        Dim Q = From T In db.AgentCollector
                Where T.AgentClass <> "System" And T.AgentDataMoved = False
                Select T

        For Each i In Q
            AgentCollectorLocal.Add(New AgentCollector With {.AgentID = i.AgentID, .AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentInstance = i.AgentInstance, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})

        Next
        db.SaveChanges()


    End Sub


    Public Sub InsertAgentData()

        Dim Q1 = From T In AgentCollectorLocal
                 Where T.AgentClass = "Processor"
                 Select T

        For Each i In Q1
            db.AgentProcessor.Add(New AgentProcessor With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next

        Dim Q2 = From T In AgentCollectorLocal
                 Where T.AgentClass = "Memory"
                 Select T

        For Each i In Q2
            db.AgentMemory.Add(New AgentMemory With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next

        Dim Q3 = From T In AgentCollectorLocal
                 Where T.AgentClass.Contains(":)") And T.AgentProperty.Contains("Free Space")
                 Select T

        For Each i In Q3
            db.AgentLogicalDisk.Add(New AgentLogicalDisk With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue, .AgentInstance = i.AgentInstance})
        Next

        Dim Q4 = From T In AgentCollectorLocal
                 Where T.AgentClass = "Services"
                 Select T

        For Each i In Q4
            db.AgentService.Add(New AgentService With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next


        For Each i In AgentCollectorLocal

            Dim Q5 = (From T In db.AgentCollector
                      Where T.AgentID = i.AgentID
                      Select T).FirstOrDefault

            Q5.AgentDataMoved = True

        Next
        db.SaveChanges()


    End Sub




End Class
