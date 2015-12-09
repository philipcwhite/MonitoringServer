
Imports DBInstallerCA.MonitoringDatabase


Module Module1

    Sub Main()


        Dim db As DBModel = New DBModel



        db.AgentThresholds.Add(New AgentThresholds With {.AgentName = "MNWVSDEV", .AgentClass = "Processor", .AgentProperty = "Total Util (%)", .Comparison = ">", .Severity = "Critical", .ThresholdTime = 60, .ThresholdValue = 0})

        'Policy1 Agent
        'db.GroupPolicy.Add(New GroupPolicy With {.GroupName = "Infrastructure", .PolicyName = "Agent Version", .PolicyClass = "agent", .PolicyParameter = "version", .PolicyValue = "1.0", .PolicyDate = Date.Now})
        'db.GroupPolicy.Add(New GroupPolicy With {.GroupName = "Infrastructure", .PolicyName = "Agent Server", .PolicyClass = "agent", .PolicyParameter = "server", .PolicyValue = "localhost", .PolicyDate = Date.Now})
        'db.GroupPolicy.Add(New GroupPolicy With {.GroupName = "Infrastructure", .PolicyName = "Agent TCP Listen Port", .PolicyClass = "agent", .PolicyParameter = "tcp_listen", .PolicyValue = "10000", .PolicyDate = Date.Now})
        'db.GroupPolicy.Add(New GroupPolicy With {.GroupName = "Infrastructure", .PolicyName = "Agent TCP Send Port", .PolicyClass = "agent", .PolicyParameter = "tcp_send", .PolicyValue = "10000", .PolicyDate = Date.Now})
        'db.GroupPolicy.Add(New GroupPolicy With {.GroupName = "Infrastructure", .PolicyName = "Agent Agent Poll Period", .PolicyClass = "agent", .PolicyParameter = "poll_period", .PolicyValue = "3", .PolicyDate = Date.Now})

        ''Policy2  WMI
        'db.GroupPolicy.Add(New GroupPolicy With {.GroupName = "Infrastructure", .PolicyName = "Windows OS Name", .PolicyClass = "wmi", .PolicyParameter = "root\CIMV2\Win32_OperatingSystem", .PolicyValue = "Caption", .PolicyDate = Date.Now})
        'db.GroupPolicy.Add(New GroupPolicy With {.GroupName = "Infrastructure", .PolicyName = "Windows OS Build Number", .PolicyClass = "wmi", .PolicyParameter = "root\CIMV2\Win32_OperatingSystem", .PolicyValue = "BuildNumber", .PolicyDate = Date.Now})
        'db.GroupPolicy.Add(New GroupPolicy With {.GroupName = "Infrastructure", .PolicyName = "Windows OS Architechture", .PolicyClass = "wmi", .PolicyParameter = "root\CIMV2\Win32_OperatingSystem", .PolicyValue = "OSArchitechture", .PolicyDate = Date.Now})


        db.SaveChanges()

    End Sub

End Module
