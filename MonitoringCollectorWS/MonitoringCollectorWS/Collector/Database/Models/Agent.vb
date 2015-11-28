Namespace MonitoringDatabase
    Public Class Agent
        Public Property AgentID As Int32
        Public Property AgentName As String
        Public Property AgentDomain As String
        Public Property AgentIP As String
        Public Property AgentOSName As String
        Public Property AgentOSVersion As String
        Public Property AgentStatus As Boolean = True
        Public Property AgentDate As Date? = Nothing
    End Class
End Namespace