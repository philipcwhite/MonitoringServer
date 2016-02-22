Imports MonitoringEventEngine.MonitoringDatabase
Public Class Thresholds

    Public Property db As New DBModel
    Public Property AThresholds As New List(Of AgentThresholds)
    Public Property GThresholds As New List(Of AgentThresholds)
    Public Property AList As New List(Of String)
    Public Property ThresholdEvents As New List(Of AgentEvents)
    Public Property FilteredEvents As New List(Of AgentEvents)


    Public Sub Load()

        AThresholds.Clear()
        GThresholds.Clear()
        AList.Clear()
        ThresholdEvents.Clear()
        FilteredEvents.Clear()

        Try
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
                    AThresholds.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue, .Enabled = True})
                End If
        Next
        Catch ex As Exception

        End Try



    End Sub


    Public Sub RunThresholds()

        Dim AThresholdsLocal As New List(Of AgentThresholds)
        Try
            Dim Q = From T In AThresholds
                    Where T.AgentClass <> "Agent"
                    Select T

            For Each i In Q
                AThresholdsLocal.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdID = i.ThresholdID, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue})
            Next
        Catch ex As Exception

        End Try

        Try

            For Each i In AThresholdsLocal
                Dim ttime = Date.Now.AddMinutes(-i.ThresholdTime)
                Dim AClass = i.AgentClass
                Dim Q = Nothing

                If AClass.Contains("Processor") Then
                    Q = From T1 In AThresholdsLocal
                        Join T2 In db.AgentProcessor
                       On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                        Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName And T2.AgentClass = AClass
                        Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue, T2.AgentCollectDate Distinct
                ElseIf AClass.Contains("Memory") Then
                    Q = From T1 In AThresholdsLocal
                        Join T2 In db.AgentMemory
                       On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                        Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName And T2.AgentClass = AClass
                        Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue, T2.AgentCollectDate Distinct
                ElseIf AClass.Contains("Local Disk") Then
                    Q = From T1 In AThresholdsLocal
                        Join T2 In db.AgentLocalDisk
                       On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                        Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName And T2.AgentClass = AClass
                        Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue, T2.AgentCollectDate Distinct
                ElseIf AClass.Contains("Services") Then
                    Q = From T1 In AThresholdsLocal
                        Join T2 In db.AgentService
                       On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                        Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName And T2.AgentClass = AClass
                        Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue, T2.AgentCollectDate Distinct
                ElseIf AClass.Contains("PageFile") Then
                    Q = From T1 In AThresholdsLocal
                        Join T2 In db.AgentPageFile
                       On T1.AgentName Equals T2.AgentName And T1.AgentClass Equals T2.AgentClass And T1.AgentProperty Equals T2.AgentProperty
                        Where T2.AgentCollectDate >= ttime And T1.AgentName = i.AgentName And T2.AgentClass = AClass
                        Select T2.AgentName, T2.AgentClass, T2.AgentProperty, T2.AgentValue, T2.AgentCollectDate Distinct
                End If

                Dim Atotal = Nothing
                Dim Btotal = Nothing
                Dim AProperty = Nothing
                Dim AComparison As String = i.Comparison
                Dim AName As String = i.AgentName
                Dim AThresholdTime As Integer = i.ThresholdTime
                Dim AThreshold As Integer = i.ThresholdValue
                Dim ASeverity As String = i.Severity
                Dim AValue As String = Nothing

                For Each i2 In Q

                    AValue = i2.AgentValue
                    AClass = i2.AgentClass
                    AProperty = i2.AgentProperty

                    If AComparison = ">" Then
                        If AValue > AThreshold Then
                            Atotal = Atotal + 1
                            Btotal = Btotal + 1
                        Else
                            Btotal = Btotal + 1
                        End If
                    End If

                    If AComparison = "<" Then
                        If AValue < AThreshold Then
                            Atotal = Atotal + 1
                            Btotal = Btotal + 1
                        Else
                            Btotal = Btotal + 1
                        End If
                    End If

                    If AComparison = "=" Then
                        If AValue = AThreshold Then
                            Atotal = Atotal + 1
                            Btotal = Btotal + 1
                        Else
                            Btotal = Btotal + 1
                        End If
                    End If

                    If AComparison = ">=" Then
                        If AValue >= AThreshold Then
                            Atotal = Atotal + 1
                            Btotal = Btotal + 1
                        Else
                            Btotal = Btotal + 1
                        End If
                    End If

                    If AComparison = "<=" Then
                        If AValue <= AThreshold Then
                            Atotal = Atotal + 1
                            Btotal = Btotal + 1
                        Else
                            Btotal = Btotal + 1
                        End If
                    End If

                Next

                If Atotal = Btotal And Btotal IsNot Nothing Then
                    ThresholdEvent(AName, AClass, AProperty, AThreshold, AComparison, AThresholdTime, ASeverity, True)
                ElseIf Atotal <> Btotal And Btotal IsNot Nothing Then
                    ThresholdEvent(AName, AClass, AProperty, AThreshold, AComparison, AThresholdTime, ASeverity, False)
                End If

            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ThresholdEvent(ByVal AName As String, ByVal AClass As String, ByVal AProperty As String, ByVal AThreshold As Integer, ByVal AComparison As String, ByVal AThresholdTime As Integer, ByVal ASeverity As Integer, ByVal AStatus As Boolean)
        Try
            If AClass <> "Agent" Then
                Dim Subject As String = AName & " " & AClass & " is " & ASeverity
                Dim Message As String = "Server exceeded threshold. " & AProperty & " " & AComparison & " " & AThreshold & " for " & AThresholdTime & " minutes."
                ThresholdEvents.Add(New AgentEvents With {.EventHostname = AName, .EventClass = AClass, .EventProperty = AProperty, .EventStatus = AStatus, .EventSeverity = ASeverity, .EventMessage = Message, .EventComparison = AComparison, .EventThreshold = AThreshold, .EventTimeRange = AThresholdTime, .EventDate = Date.Now.ToString("MM/dd/yyyy HH:mm")})
            Else
                Dim Subject As String = AName & " " & AClass & " is " & ASeverity
                Dim Message As String = "Agent has not reported for over " & AThresholdTime & " minutes."
                ThresholdEvents.Add(New AgentEvents With {.EventHostname = AName, .EventClass = AClass, .EventProperty = AProperty, .EventStatus = AStatus, .EventSeverity = ASeverity, .EventMessage = Message, .EventComparison = AComparison, .EventThreshold = AThreshold, .EventTimeRange = AThresholdTime, .EventDate = Date.Now.ToString("MM/dd/yyyy HH:mm")})
            End If

        Catch ex As Exception

        End Try
    End Sub


    Public Sub SendEvents()
        Try
            For Each i In ThresholdEvents
                HandleEvents(i.EventHostname, i.EventMessage, i.EventClass, i.EventProperty, i.EventThreshold, i.EventComparison, i.EventTimeRange, i.EventSeverity, i.EventStatus, i.EventDate)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub HandleEvents(ByVal AName As String, ByVal AMessage As String, ByVal AClass As String, ByVal AProperty As String, ByVal AThreshold As Integer, ByVal AComparison As String, ByVal AThresholdTime As Integer, ByVal ASeverity As Integer, ByVal AStatus As Boolean, ByVal AEventDate As Date)
        Try
            If AStatus = False Then
                Dim Q = (From T In db.AgentEvents
                         Where T.EventHostname = AName And T.EventClass = AClass And T.EventProperty = AProperty And T.EventStatus = True And T.EventSeverity = ASeverity
                         Select T).FirstOrDefault

                If Not Q Is Nothing Then
                    Q.EventStatus = False
                End If
                db.SaveChanges()
            End If
        Catch ex As Exception

        End Try

        Try
            If AStatus = True Then
                Dim Q = (From T In db.AgentEvents
                         Where T.EventHostname = AName And T.EventClass = AClass And T.EventProperty = AProperty And T.EventStatus = True
                         Select T).FirstOrDefault

                If Not Q Is Nothing Then
                    If ASeverity > Q.EventSeverity Then
                        Q.EventMessage = AMessage
                        Q.EventSeverity = ASeverity
                        Q.EventComparison = AComparison
                        Q.EventClass = AClass
                        Q.EventProperty = AProperty
                        Q.EventThreshold = AThreshold
                        Q.EventTimeRange = AThresholdTime

                        Try
                            Dim Notify As New Notifications
                            Notify.RouteNotification(AName, AEventDate, AMessage, ASeverity, AClass, AProperty, AComparison)
                        Catch
                        End Try

                    End If
                    db.SaveChanges()

                Else
                    db.AgentEvents.Add(New AgentEvents With {.EventHostname = AName, .EventClass = AClass, .EventProperty = AProperty, .EventStatus = AStatus, .EventSeverity = ASeverity, .EventMessage = AMessage, .EventComparison = AComparison, .EventThreshold = AThreshold, .EventTimeRange = AThresholdTime, .EventDate = AEventDate})
                    db.SaveChanges()

                    Try
                        Dim Notify As New Notifications
                        Notify.RouteNotification(AName, AEventDate, AMessage, ASeverity, AClass, AProperty, AComparison)
                    Catch
                    End Try

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgentStatus()

        Dim AThresholdsLocal As New List(Of AgentThresholds)
        Try
            Dim Q = From T In AThresholds
                    Where T.AgentClass = "Agent" And T.Enabled = True
                    Select T

            For Each i In Q
                AThresholdsLocal.Add(New AgentThresholds With {.AgentClass = i.AgentClass, .AgentName = i.AgentName, .AgentProperty = i.AgentProperty, .Comparison = i.Comparison, .Severity = i.Severity, .ThresholdID = i.ThresholdID, .ThresholdTime = i.ThresholdTime, .ThresholdValue = i.ThresholdValue})
            Next
        Catch ex As Exception

        End Try

        Try
            For Each i In AThresholdsLocal
                Dim Q = (From T In db.AgentSystem
                         Where T.AgentName = i.AgentName
                         Select T).FirstOrDefault

                Dim DateDiff As Date = Date.Now
                If Q.AgentDate < DateDiff.AddMinutes(-i.ThresholdTime) Then
                    ThresholdEvent(i.AgentName, i.AgentClass, i.AgentProperty, i.ThresholdValue, i.Comparison, i.ThresholdTime, i.Severity, True)
                Else
                    ThresholdEvent(i.AgentName, i.AgentClass, i.AgentProperty, i.ThresholdValue, i.Comparison, i.ThresholdTime, i.Severity, False)
                End If

            Next
        Catch ex As Exception

        End Try


    End Sub



End Class
