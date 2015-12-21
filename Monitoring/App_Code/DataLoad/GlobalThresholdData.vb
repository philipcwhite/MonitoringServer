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

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (C:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "30", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (C:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "20", .ThresholdTime = "30", .Severity = 2, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (C:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "10", .ThresholdTime = "30", .Severity = 3, .Enabled = True})

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (D:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "30", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (D:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "20", .ThresholdTime = "30", .Severity = 2, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Logical Disk (D:)", .AgentProperty = "Free Space (%)", .Comparison = "<=", .ThresholdValue = "10", .ThresholdTime = "30", .Severity = 3, .Enabled = True})

        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Services", .AgentProperty = "Server", .Comparison = "=", .ThresholdValue = "0", .ThresholdTime = "30", .Severity = 1, .Enabled = True})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Services", .AgentProperty = "Server", .Comparison = "=", .ThresholdValue = "0", .ThresholdTime = "30", .Severity = 2, .Enabled = False})
        db.GlobalThresholds.Add(New GlobalThresholds With {.AgentClass = "Services", .AgentProperty = "Server", .Comparison = "=", .ThresholdValue = "0", .ThresholdTime = "30", .Severity = 3, .Enabled = False})

        db.SaveChanges()


    End Sub

End Class
