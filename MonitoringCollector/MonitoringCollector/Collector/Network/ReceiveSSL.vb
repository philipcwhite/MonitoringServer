Imports MonitoringCollector.ServerParameters
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security
Imports System.Security.Authentication

Public Class ReceiveSSL

    Public ListenPort As Integer = TCPListenPort
    Public ListenAddress As IPAddress = IPAddress.Any
    Public tcpListener As TcpListener = New TcpListener(ListenAddress, ListenPort)
    Public Shared serverCertificate As New X509Certificate2(ServerPath & "config\certificate.pfx", CertificatePassword)

    Public Sub StartListener()
        tcpListener.Start()
        While True
            DoBeginAcceptTcpClient(tcpListener)
        End While
    End Sub

    Public tcpClientConnected As New ManualResetEvent(False)

    Public Sub DoBeginAcceptTcpClient(tcpListener As TcpListener)
        tcpClientConnected.Reset()
        ' Accept the connection. 
        tcpListener.BeginAcceptTcpClient(New AsyncCallback(AddressOf DoAcceptTcpClientCallback), tcpListener)
        tcpClientConnected.WaitOne()
    End Sub

    Public Sub DoAcceptTcpClientCallback(ar As IAsyncResult)
        ' Get the listener that handles the client request.

        Try
            Dim tcpListener As TcpListener = CType(ar.AsyncState, TcpListener)
            Dim tcpClient As TcpClient = tcpListener.EndAcceptTcpClient(ar)

            Dim sslStream As New SslStream(tcpClient.GetStream)
            sslStream.AuthenticateAsServer(serverCertificate, False, SslProtocols.Tls12, False)
            sslStream.ReadTimeout = 15000
            sslStream.WriteTimeout = 15000

            Dim Message As String = Nothing

            Dim Reader As New StreamReader(sslStream)
            While Reader.Peek > -1
                Message = Message + Convert.ToChar(Reader.Read)
            End While

            Dim ResponseString As String = "Data received by server"
            Dim ResponseBytes As Byte() = Encoding.UTF8.GetBytes(ResponseString)

            sslStream.Write(ResponseBytes, 0, ResponseBytes.Length)
            sslStream.Close()
            Dim Compression As New Compression
            Dim DL As New DataLoad
            DL.TranslateXML(Compression.DecompressData(Message))

        Catch ex As Exception

        Finally
            tcpClientConnected.Set()
        End Try


    End Sub


End Class
