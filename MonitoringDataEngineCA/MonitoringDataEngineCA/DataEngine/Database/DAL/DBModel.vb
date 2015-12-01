Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions

Namespace MonitoringDatabase
    Public Class DBModel
        Inherits DbContext

        ' Your context has been configured to use a 'DBModel' connection string from your application's 
        ' configuration file (App.config or Web.config). By default, this connection string targets the 
        ' 'DBInstallerCA.DBModel' database on your LocalDb instance. 
        ' 
        ' If you wish to target a different database and/or database provider, modify the 'DBModel' 
        ' connection string in the application configuration file.

        Public Sub New()
            MyBase.New("name=Monitoring")
        End Sub

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

            modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()

            'Agent Table
            modelBuilder.Entity(Of Agent).HasKey(Function(t) t.AgentID)
            modelBuilder.Entity(Of Agent).Property(Function(t) t.AgentName).HasMaxLength(100)
            modelBuilder.Entity(Of Agent).Property(Function(t) t.AgentDomain).HasMaxLength(100)
            modelBuilder.Entity(Of Agent).Property(Function(t) t.AgentIP).HasMaxLength(15)
            modelBuilder.Entity(Of Agent).Property(Function(t) t.AgentOSName).HasMaxLength(150)
            modelBuilder.Entity(Of Agent).Property(Function(t) t.AgentOSBuild).HasMaxLength(100)
            modelBuilder.Entity(Of Agent).Property(Function(t) t.AgentOSArchitechture).HasMaxLength(100)

            'AgentData Table
            modelBuilder.Entity(Of AgentData).HasKey(Function(t) t.AgentID)
            modelBuilder.Entity(Of AgentData).Property(Function(t) t.AgentName).HasMaxLength(100)
            modelBuilder.Entity(Of AgentData).Property(Function(t) t.AgentClass).HasMaxLength(250)
            modelBuilder.Entity(Of AgentData).Property(Function(t) t.AgentProperty).HasMaxLength(100)

            'AgentCollector Table
            modelBuilder.Entity(Of AgentCollector).HasKey(Function(t) t.AgentID)
            modelBuilder.Entity(Of AgentCollector).Property(Function(t) t.AgentName).HasMaxLength(100)
            modelBuilder.Entity(Of AgentCollector).Property(Function(t) t.AgentClass).HasMaxLength(250)
            modelBuilder.Entity(Of AgentCollector).Property(Function(t) t.AgentProperty).HasMaxLength(100)

            'Policy Table
            modelBuilder.Entity(Of Policy).HasKey(Function(t) t.PolicyID)
            modelBuilder.Entity(Of Policy).Property(Function(t) t.PolicyName).HasMaxLength(100)
            modelBuilder.Entity(Of Policy).Property(Function(t) t.PolicyClass).HasMaxLength(50)
            modelBuilder.Entity(Of Policy).Property(Function(t) t.PolicyParameter).HasMaxLength(250)
            modelBuilder.Entity(Of Policy).Property(Function(t) t.PolicyValue).HasMaxLength(100)

        End Sub



        ' Add a DbSet for each entity type that you want to include in your model. For more information 
        ' on configuring and using a Code First model, see http:'go.microsoft.com/fwlink/?LinkId=390109.

        Public Overridable Property Agent As DbSet(Of Agent)
        Public Overridable Property AgentData As DbSet(Of AgentData)
        Public Overridable Property AgentCollector As DbSet(Of AgentCollector)
        Public Overridable Property Policy As DbSet(Of Policy)


    End Class
End Namespace




