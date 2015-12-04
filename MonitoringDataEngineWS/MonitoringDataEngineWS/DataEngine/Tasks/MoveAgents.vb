Imports MonitoringDataEngineWS.MonitoringDatabase

Public Class MoveAgents

    Private db As New DBModel
    Private AgentCollectorLocalFull As New List(Of AgentCollector)
    Private AgentCollectorLocalFiltered As New List(Of AgentCollector)
    Private AgentLocal As New List(Of AgentSystem)
    Private AgentList1 As New List(Of String)
    Private AgentList2 As New List(Of String)
    Private AgentList3 As New List(Of String)
    Private AgentLocalName = Nothing
    Private AgentLocalDate = Nothing
    Private AAgentLocalDomain = Nothing
    Private AgentLocalOSVersion = Nothing
    Private AgentLocalBuild = Nothing
    Private AgentLocalArchitecture = Nothing
    Private AgentLocalProcessors = Nothing
    Private AgentLocalMemory = Nothing
    Private AgentLocalIPAddress = Nothing

    Public Sub QueryDatabase()

        Dim Q0 = From T In db.AgentCollector
                 Where T.AgentClass = "System" And T.AgentDataMoved = False
                 Select T

        For Each i In Q0
            AgentCollectorLocalFull.Add(New AgentCollector With {.AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue, .AgentCollectDate = i.AgentCollectDate, .AgentID = i.AgentID, .AgentClass = i.AgentClass, .AgentDataMoved = i.AgentDataMoved})
        Next

        Dim Q1 = From T In AgentCollectorLocalFull
                 Where T.AgentClass = "System"
                 Order By T.AgentName, T.AgentProperty, T.AgentValue
                 Group By AgentName = T.AgentName, AgentProperty = T.AgentProperty, AgentValue = T.AgentValue
                Into G = Group
                 Select New With {
                .AgentName = AgentName,
                .AgentProperty = AgentProperty,
                .AgentValue = AgentValue,
                .AgentMaxDate = G.Max(Function(T1) T1.AgentCollectDate)
                }

        For Each i In Q1
            AgentCollectorLocalFiltered.Add(New AgentCollector With {.AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue, .AgentCollectDate = i.AgentMaxDate})
        Next

        Dim Q2 = (From T In AgentCollectorLocalFiltered
                  Select T.AgentName).Distinct

        For Each i In Q2
            AgentList1.Add(i)
        Next

        Dim Q3 = From T In db.Agent
                 Select T.AgentName

        For Each i In Q3
            AgentList2.Add(i)
        Next

        Dim Q4 = (From T In AgentCollectorLocalFull
                  Where Not AgentList2.Contains(T.AgentName)
                  Select T.AgentName).Distinct

        For Each i In Q4
            AgentList3.Add(i)
        Next

        For Each i In AgentList1

            Dim Q = From T In AgentCollectorLocalFiltered
                    Where T.AgentName = i
                    Select T
            AgentLocalName = i

            For Each i2 In Q
                If i2.AgentProperty = "Domain" Then
                    AgentLocalDate = i2.AgentCollectDate
                    AAgentLocalDomain = i2.AgentValue
                ElseIf i2.AgentProperty = "IP Address" Then
                    AgentLocalIPAddress = i2.AgentValue
                ElseIf i2.AgentProperty = "Version" Then
                    AgentLocalOSVersion = i2.AgentValue
                ElseIf i2.AgentProperty = "Build Number" Then
                    AgentLocalBuild = i2.AgentValue
                ElseIf i2.AgentProperty = "OS Architecture" Then
                    AgentLocalArchitecture = i2.AgentValue
                ElseIf i2.AgentProperty = "Processors" Then
                    AgentLocalProcessors = i2.AgentValue
                ElseIf i2.AgentProperty = "Total Memory (MB)" Then
                    AgentLocalMemory = i2.AgentValue
                End If
            Next

            AgentLocal.Add(New AgentSystem With {.AgentName = AgentLocalName, .AgentDate = AgentLocalDate, .AgentDomain = AAgentLocalDomain, .AgentIP = AgentLocalIPAddress, .AgentMemory = AgentLocalMemory, .AgentOSArchitechture = AgentLocalArchitecture, .AgentOSBuild = AgentLocalBuild, .AgentOSName = AgentLocalOSVersion, .AgentProcessors = AgentLocalProcessors})
        Next


        For Each i In AgentCollectorLocalFull
            Dim Q = (From T In db.AgentCollector
                     Where T.AgentID = i.AgentID
                     Select T).FirstOrDefault

            Q.AgentDataMoved = True

        Next
        db.SaveChanges()

    End Sub


    Public Sub InsertAgents()

        Dim Q = From T1 In AgentLocal
                Join T2 In AgentList3 On T1.AgentName Equals T2
                Select T1

        For Each i In Q
            db.Agent.Add(New AgentSystem With {.AgentName = i.AgentName, .AgentDate = i.AgentDate, .AgentDomain = i.AgentDomain, .AgentIP = i.AgentIP, .AgentMemory = i.AgentMemory, .AgentOSArchitechture = i.AgentOSArchitechture, .AgentOSBuild = i.AgentOSBuild, .AgentOSName = i.AgentOSName, .AgentProcessors = i.AgentProcessors})
        Next
        db.SaveChanges()

    End Sub


    Public Sub UpdateAgents()


        For Each i In AgentLocal

            Dim Q = (From T In db.Agent
                     Where T.AgentName = i.AgentName
                     Select T).FirstOrDefault

            Q.AgentDate = i.AgentDate
            Q.AgentDomain = i.AgentDomain
            Q.AgentIP = i.AgentIP
            Q.AgentOSArchitechture = i.AgentOSArchitechture
            Q.AgentOSBuild = i.AgentOSBuild
            Q.AgentOSName = i.AgentOSName
            Q.AgentMemory = i.AgentMemory
            Q.AgentProcessors = i.AgentProcessors


        Next
        db.SaveChanges()

    End Sub




End Class
