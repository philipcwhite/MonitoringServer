Namespace MonitoringDatabase
    Public Class AgentEvents
        Public Property EventID As Int64
        Public Property EventDate As Date? = Nothing
        Public Property EventHostname As String
        Public Property EventMessage As String
        Public Property EventStatus As Boolean
        Public Property EventSeverity As Int32
        Public Property EventClass As String
        Public Property EventProperty As String
        Public Property EventThreshold As Int32
        Public Property EventComparison As String
        Public Property EventTimeRange As Int32
    End Class
End Namespace