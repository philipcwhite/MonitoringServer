Imports System.Threading

Module Module1

    Sub Main()

        'Dim db As DBModel = New DBModel
        'db.Agent.Add(New Agent With {.AgentName = "Test"})
        'db.SaveChanges()

        Dim ReceiveTCP As New ReceiveTCP
        Dim t As New Thread(AddressOf ReceiveTCP.StartListener)
        t.Start()

    End Sub

End Module
