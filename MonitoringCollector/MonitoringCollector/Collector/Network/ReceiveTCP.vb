Imports MonitoringCollector.ServerParameters
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports System.IO

Public Class ReceiveTCP

    Public ListenPort As Integer = TCPListenPort
    Public ListenAddress As IPAddress = IPAddress.Any
    Public tcpListener As TcpListener = New TcpListener(ListenAddress, ListenPort)

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

        Dim tcpListener As TcpListener = CType(ar.AsyncState, TcpListener)
        Dim tcpClient As TcpClient = tcpListener.EndAcceptTcpClient(ar)

        Dim NStream As NetworkStream = tcpClient.GetStream

        NStream.ReadTimeout = 1000
        NStream.WriteTimeout = 1000
        Dim Message As String = Nothing

        Try

            Dim Reader As New StreamReader(NStream)
            While Reader.Peek > -1
                Message = Message + Convert.ToChar(Reader.Read)
            End While

            Dim ResponseString As String = "Data received by server"
            Dim ResponseBytes As Byte() = Encoding.ASCII.GetBytes(ResponseString)

            NStream.Write(ResponseBytes, 0, ResponseBytes.Length)

        Catch ex As Exception
            Dim NLog As New NetworkLog
            NLog.WriteToLog(ex.ToString)
        End Try
        NStream.Close()

        Dim Compression As New Compression
        Dim DL As New DataLoad
        DL.TranslateXML(Compression.DecompressData(Message))

        tcpClientConnected.Set()

    End Sub




End Class
