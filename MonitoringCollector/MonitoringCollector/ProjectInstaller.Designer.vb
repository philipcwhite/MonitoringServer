<System.ComponentModel.RunInstaller(True)> Partial Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MonitoringServiceProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.MCollectorServiceInstaller = New System.ServiceProcess.ServiceInstaller()
        '
        'MonitoringServiceProcessInstaller
        '
        Me.MonitoringServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.MonitoringServiceProcessInstaller.Password = Nothing
        Me.MonitoringServiceProcessInstaller.Username = Nothing
        '
        'MCollectorServiceInstaller
        '
        Me.MCollectorServiceInstaller.Description = "Monitoring Collector"
        Me.MCollectorServiceInstaller.DisplayName = "Monitoring Collector"
        Me.MCollectorServiceInstaller.ServiceName = "MCollector"
        Me.MCollectorServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.MonitoringServiceProcessInstaller, Me.MCollectorServiceInstaller})

    End Sub

    Friend WithEvents MonitoringServiceProcessInstaller As ServiceProcess.ServiceProcessInstaller
    Friend WithEvents MCollectorServiceInstaller As ServiceProcess.ServiceInstaller
End Class
