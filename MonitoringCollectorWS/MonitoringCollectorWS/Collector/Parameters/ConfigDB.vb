Public Class ServerConfigDB
    Public Shared ServerConfigurationList As New List(Of ServerConfiguration)
End Class

Public Class ServerConfiguration
        Public Property ServerClass As String
        Public Property ServerParameter As String
        Public Property ServerValue As String
    End Class

