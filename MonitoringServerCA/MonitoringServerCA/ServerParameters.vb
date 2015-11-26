Namespace Server
    Public Class ServerParameters

        'Server Parameters
        Public Shared ServerName As String = Net.Dns.GetHostName
        Public Shared ServerPath As String = Reflection.Assembly.GetEntryAssembly.Location.Replace("MonitoringWS.exe", "")
        Public Shared TCPListenPort As String = 10000
        Public Shared TCPSendPort As String = Nothing

        'Logging
        Public Shared ServerNetLog As String = Nothing

        'Cryptography
        Public Shared Key As Byte() = Text.Encoding.ASCII.GetBytes("abcdefghijklmnop")
        Public Shared IV As Byte() = Text.Encoding.ASCII.GetBytes("abcdefghijklmnop")

    End Class

End Namespace
