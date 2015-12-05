﻿Namespace MonitoringDatabase
    Public Class AgentData
        Public Property AgentID As Int32
        Public Property AgentName As String
        Public Property AgentClass As String
        Public Property AgentProperty As String
        Public Property AgentInstance As Int32?
        Public Property AgentValue As String
        Public Property AgentNumericValue As Double
        Public Property AgentCollectDate As Date? = Nothing
    End Class
End Namespace