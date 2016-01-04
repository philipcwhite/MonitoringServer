Imports MonitoringDatabase
Imports Microsoft.VisualBasic

Public Class GlobalThresholdData

    Private Property db As New DBModel

    Public Sub AddThresholds()

        'Purge Old Data

        Dim Q = From T In db.GlobalThresholds
                Select T
        For Each i In Q
            db.GlobalThresholds.Remove(i)
        Next
        db.SaveChanges()

        'Add Defaults

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Processor", .AgentProperty = "Total Util (%)", .Comparison = ">=", .ThresholdValue = "70", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Processor", .AgentProperty = "Total Util (%)", .Comparison = ">=", .ThresholdValue = "80", .ThresholdTime = "30", .Severity = 2, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Processor", .AgentProperty = "Total Util (%)", .Comparison = ">=", .ThresholdValue = "90", .ThresholdTime = "30", .Severity = 3, .Enabled = True})

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Memory", .AgentProperty = "Total Util (%)", .Comparison = ">=", .ThresholdValue = "70", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Memory", .AgentProperty = "Total Util (%)", .Comparison = ">=", .ThresholdValue = "80", .ThresholdTime = "30", .Severity = 2, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Memory", .AgentProperty = "Total Util (%)", .Comparison = ">=", .ThresholdValue = "90", .ThresholdTime = "30", .Severity = 3, .Enabled = True})

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "PageFile", .AgentProperty = "Total Util (%)", .Comparison = ">=", .ThresholdValue = "70", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "PageFile", .AgentProperty = "Total Util (%)", .Comparison = ">=", .ThresholdValue = "80", .ThresholdTime = "30", .Severity = 2, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "PageFile", .AgentProperty = "Total Util (%)", .Comparison = ">=", .ThresholdValue = "90", .ThresholdTime = "30", .Severity = 3, .Enabled = True})

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (C:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "30", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (C:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "20", .ThresholdTime = "30", .Severity = 2, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (C:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "10", .ThresholdTime = "30", .Severity = 3, .Enabled = True})

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (C:)", .AgentProperty = "Active Time (%)", .Comparison = "<=", .ThresholdValue = "70", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (C:)", .AgentProperty = "Active Time (%)", .Comparison = "<=", .ThresholdValue = "80", .ThresholdTime = "30", .Severity = 2, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (C:)", .AgentProperty = "Active Time (%)", .Comparison = "<=", .ThresholdValue = "90", .ThresholdTime = "30", .Severity = 3, .Enabled = True})

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (D:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "30", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (D:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "20", .ThresholdTime = "30", .Severity = 2, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (D:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "10", .ThresholdTime = "30", .Severity = 3, .Enabled = True})

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (D:)", .AgentProperty = "Active Time (%)", .Comparison = "<=", .ThresholdValue = "70", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (D:)", .AgentProperty = "Active Time (%)", .Comparison = "<=", .ThresholdValue = "80", .ThresholdTime = "30", .Severity = 2, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (D:)", .AgentProperty = "Active Time (%)", .Comparison = "<=", .ThresholdValue = "90", .ThresholdTime = "30", .Severity = 3, .Enabled = True})

        Dim ServiceList As New List(Of String)
        ServiceList.Add("Application Host Helper Service")
        ServiceList.Add("Background Tasks Infrastructure Service")
        ServiceList.Add("Base Filtering Engine")
        ServiceList.Add("COM+ Event System")
        ServiceList.Add("Cryptographic Services")
        ServiceList.Add("DCOM Server Process Launcher")
        ServiceList.Add("DHCP Client")
        ServiceList.Add("Diagnostic Policy Service")
        ServiceList.Add("Diagnostics Tracking Service")
        ServiceList.Add("Distributed Link Tracking Client")
        ServiceList.Add("IP Helper")
        ServiceList.Add("Local Session Manager")
        ServiceList.Add("Network Location Awareness")
        ServiceList.Add("Network Store Interface Service")
        ServiceList.Add("Power")
        ServiceList.Add("Print Spooler")
        ServiceList.Add("Program Compatibility Assistant Service")
        ServiceList.Add("Remote Procedure Call (RPC)")
        ServiceList.Add("RPC Endpoint Mapper")
        ServiceList.Add("Security Accounts Manager")
        ServiceList.Add("Server")
        ServiceList.Add("Shell Hardware Detection")
        ServiceList.Add("Superfetch")
        ServiceList.Add("System Event Notification Service")
        ServiceList.Add("Task Scheduler")
        ServiceList.Add("Themes")
        ServiceList.Add("User Profile Service")
        ServiceList.Add("Windows Audio")
        ServiceList.Add("Windows Defender Service")
        ServiceList.Add("Windows Event Log")
        ServiceList.Add("Windows Firewall")
        ServiceList.Add("Windows Font Cache Service")
        ServiceList.Add("Windows Management Instrumentation")
        ServiceList.Add("Workstation")

        For Each i In ServiceList
            db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Services", .AgentProperty = i, .Comparison = "=", .ThresholdValue = "0", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        Next



        db.SaveChanges()


    End Sub

End Class
