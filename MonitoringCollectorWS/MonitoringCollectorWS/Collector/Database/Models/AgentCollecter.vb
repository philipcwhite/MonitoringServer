Namespace MonitoringDatabase
    Public Class AgentCollector
        Public Property AgentID As Int32
        Public Property AgentName As String
        Public Property AgentClass As String
        Public Property AgentProperty As String
        Public Property AgentInstance As Int32?
        Public Property AgentValue As String
        Public Property AgentCollectDate As Date? = Nothing
        Public Property AgentDataMoved As Boolean
    End Class
End Namespace
