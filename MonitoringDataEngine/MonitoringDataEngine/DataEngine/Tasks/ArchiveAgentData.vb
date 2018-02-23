Imports MonitoringDataEngine.MonitoringDatabase
Imports MonitoringDataEngine.ServerParameters
Public Class ArchiveAgentData

    Private db As New DBModel

    Public Sub Archive()


        Dim CurrentTime As Date = ServerTime.ToString("MM/dd/yyyy HH:mm")
        Dim ArchiveTime As Date = CurrentTime.AddDays(-1)
        'Dim ArchiveTime As Date = CurrentTime.AddHours(-24)


        Try
            Dim Q = From T In db.AgentData
                    Where T.AgentCollectDate < ArchiveTime
                    Group By T = New With {Key .AgentName = T.AgentName, Key .AgentClass = T.AgentClass, Key .AgentProperty = T.AgentProperty}
                     Into G = Group
                    Select New With {.AgentName = T.AgentName, .AgentClass = T.AgentClass, .AgentProperty = T.AgentProperty, .AgentValue = G.Average(Function(i) i.AgentValue)}

            For Each i In Q
                db.AgentDataArchive.Add(New AgentDataArchive With {.AgentClass = i.AgentClass, .AgentCollectDate = ArchiveTime, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = Math.Round(i.AgentValue, 0)})
            Next

            db.SaveChanges()

        Catch
        End Try




    End Sub




End Class
