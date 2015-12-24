Imports MonitoringEventEngineWS.MonitoringDatabase
Public Class Thresholds

    Public db As New DBModel
    Public Property AThresholds As New List(Of AgentThresholds)
    Public Property GThresholds As New List(Of AgentThresholds)
    Public Property AList As New List(Of String)
    Public Property ThresholdEvents As New List(Of AgentEvents)
    Public Property FilteredEvents As New List(Of AgentEvents)


    Public Sub Load()

        Dim Q0 = From T In db.AgentSystem
                 Select T.AgentName
        For Each i In Q0
            AList.Add(i)
        Next

        'Add Agent Thresholds
        Dim Q1 = From T In db.AgentThresholds
                 Where T.Enabled = True
                 Select T
        For Each i In Q1
            AThresholds.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue})
        Next

        'Add Group Thresholds
        For Each i1 In AList
            Dim Q2 = From T In db.GlobalThresholds
                     Where T.Enabled = True
                     Select T
            For Each i2 In Q2
                GThresholds.Add(New AgentThresholds With {.AgentName = i1, .AgentClass = i2.AgentClass, .AgentProperty = i2.AgentProperty, .Comparison = i2.Comparison, .Severity = i2.Severity, .ThresholdTime = i2.ThresholdTime, .ThresholdValue = i2.ThresholdValue})
            Next
        Next

        'Combine Thresholds
        For Each i In GThresholds
            Dim Q3 = (From T In AThresholds
                      Where T.AgentName = i.AgentName And T.AgentClass = i.AgentClass And T.AgentProperty = i.AgentProperty And T.Severity = i.Severity
                      Select T).FirstOrDefault
            If Q3 Is Nothing Then
                AThresholds.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue})
            End If

        Next

    End Sub


    Public Sub RunThresholds(ByVal AClass As String, ByVal AProperty As String)

        Dim AThresholdsLocal As New List(Of AgentThresholds)

        Dim Q1 = Nothing
        If AClass = "Processor" Or AClass = "Memory" Then
            Q1 = From T In AThresholds
                 Where T.AgentClass = AClass And T.AgentProperty = AProperty
                 Select T
        ElseIf AClass = "Services" Then
            Q1 = From T In AThresholds
                 Where T.AgentClass = AClass
                 Select T
        ElseIf AClass = "Logical Disk" Then
            Q1 = From T In AThresholds
                 Where T.AgentClass.Contains(":)") And T.AgentProperty.Contains("Free")
                 Select T
        End If

        For Each i In Q1
            AThresholdsLocal.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdID = i.ThresholdID, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue})
        Next

        For Each i In AThresholdsLocal
            Dim ttime = Date.Now.AddMinutes(-i.ThresholdTime)

            Dim Q2 = Nothing

            If AClass = "Processor" Then
                Q2 = From T1 In AThresholdsLocal
                     Join T2 In db.AgentProcessor
                   On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                     Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName
                     Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue
            ElseIf AClass = "Memory" Then
                Q2 = From T1 In AThresholdsLocal
                     Join T2 In db.AgentMemory
                   On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                     Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName
                     Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue
            ElseIf AClass = "Logical Disk" Then
                Q2 = From T1 In AThresholdsLocal
                     Join T2 In db.AgentLogicalDisk
                   On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                     Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName
                     Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue
            ElseIf AClass = "Services" Then
                Q2 = From T1 In AThresholdsLocal
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

            If atotal = btotal And btotal IsNot Nothing Then
                ThresholdEvent(AName, AClass, AProperty, AThreshold, AComparison, AThresholdTime, ASeverity, True)
            ElseIf atotal <> btotal And btotal IsNot Nothing Then
                ThresholdEvent(AName, AClass, AProperty, AThreshold, AComparison, AThresholdTime, ASeverity, False)
            End If

        Next

    End Sub

    Public Sub ThresholdEvent(ByVal AName As String, ByVal AClass As String, ByVal AProperty As String, ByVal AThreshold As Integer, ByVal AComparison As String, ByVal AThresholdTime As Integer, ByVal ASeverity As Integer, ByVal AStatus As Boolean)

        Dim Subject As String = AName & " " & AClass & " is " & ASeverity
        Dim Message As String = "Agent exceeded threshold. " & AProperty & " " & AComparison & " " & AThreshold & " for " & AThresholdTime & " minutes."
        ThresholdEvents.Add(New AgentEvents With {.AgentName = AName, .AgentClass = AClass, .AgentProperty = AProperty, .AgentStatus = AStatus, .AgentSeverity = ASeverity, .AgentMessage = Message, .AgentComparison = AComparison, .AgentThreshold = AThreshold, .AgentTimeRange = AThresholdTime, .AgentEventDate = Date.Now})

    End Sub


    Public Sub SendEvents()

        For Each i In ThresholdEvents
            HandleEvents(i.AgentName, i.AgentMessage, i.AgentClass, i.AgentProperty, i.AgentThreshold, i.AgentComparison, i.AgentTimeRange, i.AgentSeverity, i.AgentStatus, i.AgentEventDate)
        Next

    End Sub


    Public Sub HandleEvents(ByVal AName As String, ByVal AMessage As String, ByVal AClass As String, ByVal AProperty As String, ByVal AThreshold As Integer, ByVal AComparison As String, ByVal AThresholdTime As Integer, ByVal ASeverity As Integer, ByVal AStatus As Boolean, ByVal AEventDate As Date)

        If AStatus = False Then


            Dim Q = (From T In db.AgentEvents
                     Where T.AgentName = AName And T.AgentClass = AClass And T.AgentProperty = AProperty And T.AgentStatus = True And T.AgentSeverity = ASeverity
                     Select T).FirstOrDefault

            If Not Q Is Nothing Then
                Q.AgentStatus = False
            End If

            db.SaveChanges()


        End If

        If AStatus = True Then


            Dim Q = (From T In db.AgentEvents
                     Where T.AgentName = AName And T.AgentClass = AClass And T.AgentProperty = AProperty And T.AgentStatus = True
                     Select T).FirstOrDefault


            If Not Q Is Nothing Then


                If ASeverity > Q.AgentSeverity Then
                    Q.AgentSeverity = ASeverity
                End If

                db.SaveChanges()

            Else
                db.AgentEvents.Add(New AgentEvents With {.AgentName = AName, .AgentClass = AClass, .AgentProperty = AProperty, .AgentStatus = AStatus, .AgentSeverity = ASeverity, .AgentMessage = AMessage, .AgentComparison = AComparison, .AgentThreshold = AThreshold, .AgentTimeRange = AThresholdTime, .AgentEventDate = AEventDate})

            End If
            db.SaveChanges()
        End If

    End Sub


End Class
