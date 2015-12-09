Imports MonitoringEventEngineWS.MonitoringDatabase
Public Class ManageEvents

    Private db As New DBModel
    Private Property AgentThresholdsCombined As New List(Of AgentThresholds)
    Private Property AgentThresholdsGroup As New List(Of AgentThresholds)

    Public Sub LoadThresholds()

        Dim Q1 = From T In db.AgentThresholds
                 Select T

        For Each i In Q1
            AgentThresholdsCombined.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue})
        Next

        Dim Q2 = From T1 In db.GroupThresholds
                 Join T2 In db.GroupMembers On T1.GroupName Equals T2.GroupName
                 Select T2.MemberName, T1.AgentClass, T1.AgentProperty, T1.Comparison, T1.Severity, T1.ThresholdTime, T1.ThresholdValue

        For Each i In Q2
            AgentThresholdsGroup.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.MemberName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue})
        Next

        For Each i In AgentThresholdsGroup
            Dim Q3 = (From T In AgentThresholdsCombined
                      Where T.AgentName = i.AgentName And T.AgentClass = i.AgentClass And T.AgentProperty = i.AgentProperty
                      Select T).FirstOrDefault

            If Q3 Is Nothing Then
                AgentThresholdsCombined.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue})
            End If

        Next

    End Sub



    Public Sub Thresholds(ByVal AClass As String, ByVal AProperty As String)

        Dim AgentThresholdsLocal As New List(Of AgentThresholds)

        Dim Q1 = Nothing
        If AClass = "Processor" Or AClass = "Memory" Then
            Q1 = From T In AgentThresholdsCombined
                 Where T.AgentClass = AClass And T.AgentProperty = AProperty
                 Select T
        ElseIf AClass = "Services" Then
            Q1 = From T In AgentThresholdsCombined
                 Where T.AgentClass = AClass
                 Select T
        ElseIf AClass = "Logical Disk" Then
            Q1 = From T In AgentThresholdsCombined
                 Where T.AgentClass.Contains(":)") And T.AgentProperty.Contains("Free")
                 Select T
        End If

        For Each i In Q1
            AgentThresholdsLocal.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdID = i.ThresholdID, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue})
        Next

        For Each i In AgentThresholdsLocal
            Dim ttime = Date.Now.AddMinutes(-i.ThresholdTime)

            Dim Q2 = Nothing

            If AClass = "Processor" Then
                Q2 = From T1 In AgentThresholdsLocal
                     Join T2 In db.AgentProcessor
                   On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                     Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName
                     Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue
            ElseIf AClass = "Memory" Then
                Q2 = From T1 In AgentThresholdsLocal
                     Join T2 In db.AgentMemory
                   On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                     Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName
                     Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue
            ElseIf AClass = "Logical Disk" Then
                Q2 = From T1 In AgentThresholdsLocal
                     Join T2 In db.AgentLogicalDisk
                   On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                     Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName
                     Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue
            ElseIf AClass = "Services" Then
                Q2 = From T1 In AgentThresholdsLocal
                     Join T2 In db.AgentService
                   On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                     Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName
                     Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue
            End If


            Dim atotal = Nothing
            Dim btotal = Nothing

            AProperty = i.AgentProperty
            Dim AComparison As String = i.Comparison
            Dim AName As String = i.AgentName
            Dim AThresholdTime As Integer = i.ThresholdTime
            Dim AThreshold As Integer = i.ThresholdValue
            Dim ASeverity As String = i.Severity
            Dim AValue As String = Nothing

            For Each i2 In Q2

                AValue = i2.AgentValue
                If AComparison = ">" Then

                    If AValue > AThreshold Then
                        atotal = atotal + 1
                        btotal = btotal + 1
                    Else
                        btotal = btotal + 1
                    End If

                End If

                If AComparison = "<" Then
                    If AValue < AThreshold Then
                        atotal = atotal + 1
                        btotal = btotal + 1
                    Else
                        btotal = btotal + 1
                    End If
                End If

                If AComparison = "=" Then
                    If AValue = AThreshold Then
                        atotal = atotal + 1
                        btotal = btotal + 1
                    Else
                        btotal = btotal + 1
                    End If
                End If

                If AComparison = ">=" Then
                    If AValue >= AThreshold Then
                        atotal = atotal + 1
                        btotal = btotal + 1
                    Else
                        btotal = btotal + 1
                    End If
                End If

                If AComparison = "<=" Then
                    If AValue <= AThreshold Then
                        atotal = atotal + 1
                        btotal = btotal + 1
                    Else
                        btotal = btotal + 1
                    End If
                End If

            Next

            If atotal = btotal Then
                CreateEvent(AName, AClass, AProperty, AThreshold, AComparison, AThresholdTime, ASeverity, True)
            Else
                CreateEvent(AName, AClass, AProperty, AThreshold, AComparison, AThresholdTime, ASeverity, False)
            End If

        Next

    End Sub


    Private Sub CreateEvent(ByVal AName As String, ByVal AClass As String, ByVal AProperty As String, ByVal AThreshold As Integer, ByVal AComparison As String, ByVal AThresholdTime As Integer, ByVal ASeverity As String, ByVal AStatus As Boolean)

        Dim Q1 = (From T In db.AgentEvents
                  Where T.AgentName = AName And T.AgentClass = AClass And T.AgentProperty = AProperty And T.AgentStatus = True
                  Select T.AgentName).FirstOrDefault


        If Q1 Is Nothing And AStatus = True Then
            Dim Subject As String = AName & " " & AClass & " is " & ASeverity
            Dim Message As String = "Agent exceeded threshold. " & AProperty & " " & AComparison & " " & AThreshold & " for " & AThresholdTime & " minutes."
            db.AgentEvents.Add(New AgentEvents With {.AgentName = AName, .AgentClass = AClass, .AgentProperty = AProperty, .AgentStatus = True, .AgentSeverity = ASeverity, .AgentSubject = Subject, .AgentMessage = Message, .AgentComparison = AComparison, .AgentThreshold = AThreshold, .AgentTimeRange = AThresholdTime, .AgentEventDate = Date.Now})
            db.SaveChanges()
        End If

        If Not Q1 Is Nothing And AStatus = False Then


            Dim Q2 = From T In db.AgentEvents
                     Where T.AgentName = AName And T.AgentClass = AClass And T.AgentProperty = AProperty And T.AgentStatus = True
                     Select T

            For Each i In Q2
                i.AgentStatus = False
            Next
            db.SaveChanges()

        End If

    End Sub




End Class


