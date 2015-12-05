Namespace MonitoringDatabase
    Public Class AgentEvents
        Public Property AgentEventID As Int32
        Public Property AgentName As String
        Public Property AgentEventSubject As String
        Public Property AgentEventMessage As String
        Public Property AgentEventStatus As String
        Public Property AgentEventSeverity As String
        Public Property AgentEventDate As Date? = Nothing
    End Class
End Namespace