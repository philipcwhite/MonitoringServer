Namespace MonitoringDatabase
    Public Class AgentEvents
        Public Property AgentEventID As Int64
        Public Property AgentName As String
        Public Property AgentMessage As String
        Public Property AgentStatus As Boolean
        Public Property AgentSeverity As Int32
        Public Property AgentClass As String
        Public Property AgentProperty As String
        Public Property AgentInstance As Int32
        Public Property AgentThreshold As Int32
        Public Property AgentComparison As String
        Public Property AgentTimeRange As Int32
        Public Property AgentEventDate As Date? = Nothing
    End Class
End Namespace