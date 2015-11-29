Imports System.Threading

Public Class ServerListener
    Public Sub Listen()
        Dim nReceive As New ReceiveTCP
        Dim t As Thread
        t = New Thread(AddressOf nReceive.StartListener)
        t.Start()
    End Sub
End Class
