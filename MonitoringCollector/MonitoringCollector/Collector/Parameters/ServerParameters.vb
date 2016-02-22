Public Class ServerParameters

    'Server Parameters
    Public Shared ServerName As String = Net.Dns.GetHostName
    Public Shared ServerPath As String = Reflection.Assembly.GetEntryAssembly.Location.Replace("bin\MonitoringCollector.exe", "")
    Public Shared TCPListenPort As String = 10000
    Public Shared SSLEnabled As Boolean = False
    Public Shared CertificatePassword As String = Nothing

    'Logging
    Public Shared ServerNetLog As String = Nothing



End Class

