
Imports DBInstallerCA.MonitoringDatabase


Module Module1

    Sub Main()


        Dim db As DBModel = New DBModel




        'db.Policy.Add(New Policy With {.PolicyName = "Windows_Default"})



        'Policy1 Agent
        db.Policy.Add(New Policy With {.PolicyName = "Agent Version", .PolicyClass = "agent", .PolicyParameter = "version", .PolicyValue = "1.0", .PolicyDate = Date.Now})
        db.Policy.Add(New Policy With {.PolicyName = "Agent Server", .PolicyClass = "agent", .PolicyParameter = "server", .PolicyValue = "localhost", .PolicyDate = Date.Now})
        db.Policy.Add(New Policy With {.PolicyName = "Agent TCP Listen Port", .PolicyClass = "agent", .PolicyParameter = "tcp_listen", .PolicyValue = "10000", .PolicyDate = Date.Now})
        db.Policy.Add(New Policy With {.PolicyName = "Agent TCP Send Port", .PolicyClass = "agent", .PolicyParameter = "tcp_send", .PolicyValue = "10000", .PolicyDate = Date.Now})
        db.Policy.Add(New Policy With {.PolicyName = "Agent Agent Poll Period", .PolicyClass = "agent", .PolicyParameter = "poll_period", .PolicyValue = "3", .PolicyDate = Date.Now})

        'Policy2  WMI
        db.Policy.Add(New Policy With {.PolicyName = "Windows OS Name", .PolicyClass = "wmi", .PolicyParameter = "root\CIMV2\Win32_OperatingSystem", .PolicyValue = "Caption", .PolicyDate = Date.Now})
        db.Policy.Add(New Policy With {.PolicyName = "Windows OS Build Number", .PolicyClass = "wmi", .PolicyParameter = "root\CIMV2\Win32_OperatingSystem", .PolicyValue = "BuildNumber", .PolicyDate = Date.Now})
        db.Policy.Add(New Policy With {.PolicyName = "Windows OS Architechture", .PolicyClass = "wmi", .PolicyParameter = "root\CIMV2\Win32_OperatingSystem", .PolicyValue = "OSArchitechture", .PolicyDate = Date.Now})


        db.SaveChanges()

    End Sub

End Module
