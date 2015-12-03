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
        'Console.WriteLine("pause")
        'Console.ReadLine()

        For Each i In AgentCollectorLocal
            ' Console.WriteLine(i.AgentName & " " & i.AgentCollectDate)
            db.AgentData.Add(New AgentData With {.AgentClass = i.AgentClass, .AgentCollectDate = i.AgentCollectDate, .AgentInstance = i.AgentInstance, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue})
        Next
        ' Console.ReadLine()

        For Each i In AgentCollectorLocal

            Dim Q = (From T In db.AgentCollector
                     Where T.AgentID = i.AgentID
                     Select T).FirstOrDefault

            Q.AgentDataMoved = True

        Next
        db.SaveChanges()

    End Sub

End Class
