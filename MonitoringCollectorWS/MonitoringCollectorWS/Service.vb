Imports System.Threading

Public Class Service



    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        Dim ReceiveTCP As New ReceiveTCP
        Dim t As New Thread(AddressOf ReceiveTCP.StartListener)
        t.Start()


    End Sub



    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

End Class
