Imports MonitoringCollectorWS.ServerParameters
Imports MonitoringCollectorWS.MonitoringDatabase
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
        Dim Message As String = Nothing
        Dim Reader As New StreamReader(NStream)
        While Reader.Peek > -1
            Message = Message + Convert.ToChar(Reader.Read)
        End While
        Dim Encryption As New Encryption
        Message = Encryption.DecryptData(Message)
        Dim ResponseString As String = "Data received by server"
        Dim ResponseBytes As Byte() = Encoding.ASCII.GetBytes(ResponseString)
        Dim ReturnStream As NetworkStream = tcpClient.GetStream
        ReturnStream.Write(ResponseBytes, 0, ResponseBytes.Length)

        TranslateXML(Message)

        tcpClient.Close()
        NStream.Close()
        tcpClientConnected.Set()
    End Sub


    Public Sub TranslateXML(ByVal xmlMessage As String)



        Try
            If xmlMessage.Contains("agent-data") Then


                Dim xelement As XElement = XElement.Parse(xmlMessage)
                Dim wobjects As IEnumerable(Of XElement) = xelement.Elements("object")

                Dim db As New DBModel

                For Each i In wobjects
                    db.AgentCollector.Add(New AgentCollector With {.AgentName = i.Attribute("name").Value, .AgentCollectDate = i.Attribute("date").Value, .AgentClass = i.Attribute("class").Value, .AgentProperty = i.Attribute("property").Value, .AgentInstance = i.Attribute("instance").Value, .AgentValue = i.Attribute("value"), .AgentDataMoved = False})
                    db.SaveChanges()
                Next



            End If

        Catch ex As Exception

        End Try

    End Sub



End Class
