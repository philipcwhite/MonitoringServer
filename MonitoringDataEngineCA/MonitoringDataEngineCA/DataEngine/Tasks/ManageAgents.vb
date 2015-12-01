Imports MonitoringDataEngineCA.MonitoringDatabase

Public Class ManageAgents

    Private db As New DBModel
    Private AgentCollectorLocal As New List(Of AgentCollector)
    Private AgentLocal As New List(Of Agent)
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

        Dim Q1 = From s In db.AgentCollector
                 Where s.AgentClass = "System"
                 Order By s.AgentName, s.AgentProperty, s.AgentValue
                 Group By AgentName = s.AgentName, AgentProperty = s.AgentProperty, AgentValue = s.AgentValue
                Into g = Group
                 Select New With {
                .AgentName = AgentName,
                .AgentProperty = AgentProperty,
                .AgentValue = AgentValue,
                .AgentMaxDate = g.Max(Function(T1) T1.AgentCollectDate)
                }

        For Each i In Q1
            AgentCollectorLocal.Add(New AgentCollector With {.AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .AgentValue = i.AgentValue, .AgentCollectDate = i.AgentMaxDate})
        Next

        Dim Q2 = (From T In AgentCollectorLocal
                  Select T.AgentName).Distinct

        For Each i In Q2
            AgentList1.Add(i)
        Next

        Dim Q3 = From T In db.Agent
                 Select T.AgentName

        For Each i In Q3
            AgentList2.Add(i)
        Next

        Dim Q4 = (From T In db.AgentCollector
                  Where Not AgentList2.Contains(T.AgentName)
                  Select T.AgentName).Distinct

        For Each i In Q4
            AgentList3.Add(i)
        Next

        For Each i In AgentList1

            Dim Q = From T In AgentCollectorLocal
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

            AgentLocal.Add(New Agent With {.AgentName = AgentLocalName, .AgentDate = AgentLocalDate, .AgentDomain = AAgentLocalDomain, .AgentIP = AgentLocalIPAddress, .AgentMemory = AgentLocalMemory, .AgentOSArchitechture = AgentLocalArchitecture, .AgentOSBuild = AgentLocalBuild, .AgentOSName = AgentLocalOSVersion, .AgentProcessors = AgentLocalProcessors})
        Next

    End Sub


    Public Sub InsertAgents()

        Dim Q = From T1 In AgentLocal
                Join T2 In AgentList3 On T1.AgentName Equals T2
                Select T1

        For Each i In Q
            db.Agent.Add(New Agent With {.AgentName = i.AgentName, .AgentDate = i.AgentDate, .AgentDomain = i.AgentDomain, .AgentIP = i.AgentIP, .AgentMemory = i.AgentMemory, .AgentOSArchitechture = i.AgentOSArchitechture, .AgentOSBuild = i.AgentOSBuild, .AgentOSName = i.AgentOSName, .AgentProcessors = i.AgentProcessors})
            db.SaveChanges()
        Next

    End Sub


    Public Sub UpdateAgents()






        For Each i In AgentLocal


            'Console.WriteLine(i.AgentName & " " & i.AgentDate & " " & i.AgentOSName)
            'Console.ReadLine()
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

            db.SaveChanges()
        Next

        ' Console.ReadLine()




    End Sub


    Public Sub PurgeAgents()

    End Sub

End Class
