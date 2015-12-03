Imports MonitoringDataEngineWS.MonitoringDatabase
Public Class CleanUp

    Private db As New DBModel


    Public Sub PurgeData()

        Dim PurgeDate = Date.Now.AddDays(-1)
        Dim Q = From T In db.AgentCollector
                Where T.AgentDataMoved = True And T.AgentCollectDate < PurgeDate
                Select T

        For Each i In Q
            db.AgentCollector.Remove(i)
        Next
        db.SaveChanges()
    End Sub

End Class
