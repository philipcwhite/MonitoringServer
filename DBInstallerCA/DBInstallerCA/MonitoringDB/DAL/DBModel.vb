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

            'AgentSystem Table
            modelBuilder.Entity(Of AgentSystem).HasKey(Function(t) t.AgentID)
            modelBuilder.Entity(Of AgentSystem).Property(Function(t) t.AgentName).HasMaxLength(100)
            modelBuilder.Entity(Of AgentSystem).Property(Function(t) t.AgentDomain).HasMaxLength(100)
            modelBuilder.Entity(Of AgentSystem).Property(Function(t) t.AgentIP).HasMaxLength(15)
            modelBuilder.Entity(Of AgentSystem).Property(Function(t) t.AgentOSName).HasMaxLength(100)
            modelBuilder.Entity(Of AgentSystem).Property(Function(t) t.AgentOSBuild).HasMaxLength(25)
            modelBuilder.Entity(Of AgentSystem).Property(Function(t) t.AgentOSArchitechture).HasMaxLength(25)

            'AgentProcessor Table
            modelBuilder.Entity(Of AgentProcessor).HasKey(Function(t) t.AgentID)
            modelBuilder.Entity(Of AgentProcessor).Property(Function(t) t.AgentName).HasMaxLength(100)
            modelBuilder.Entity(Of AgentProcessor).Property(Function(t) t.AgentClass).HasMaxLength(100)
            modelBuilder.Entity(Of AgentProcessor).Property(Function(t) t.AgentProperty).HasMaxLength(100)

            'AgentMemory Table
            modelBuilder.Entity(Of AgentMemory).HasKey(Function(t) t.AgentID)
            modelBuilder.Entity(Of AgentMemory).Property(Function(t) t.AgentName).HasMaxLength(100)
            modelBuilder.Entity(Of AgentMemory).Property(Function(t) t.AgentClass).HasMaxLength(100)
            modelBuilder.Entity(Of AgentMemory).Property(Function(t) t.AgentProperty).HasMaxLength(100)

            'AgentLogicalDisk Table
            modelBuilder.Entity(Of AgentLogicalDisk).HasKey(Function(t) t.AgentID)
            modelBuilder.Entity(Of AgentLogicalDisk).Property(Function(t) t.AgentName).HasMaxLength(100)
            modelBuilder.Entity(Of AgentLogicalDisk).Property(Function(t) t.AgentClass).HasMaxLength(100)
            modelBuilder.Entity(Of AgentLogicalDisk).Property(Function(t) t.AgentProperty).HasMaxLength(100)

            'AgentServices Table
            modelBuilder.Entity(Of AgentService).HasKey(Function(t) t.AgentID)
            modelBuilder.Entity(Of AgentService).Property(Function(t) t.AgentName).HasMaxLength(100)
            modelBuilder.Entity(Of AgentService).Property(Function(t) t.AgentClass).HasMaxLength(100)
            modelBuilder.Entity(Of AgentService).Property(Function(t) t.AgentProperty).HasMaxLength(100)

            'AgentCollector Table
            modelBuilder.Entity(Of AgentCollector).HasKey(Function(t) t.AgentID)
            modelBuilder.Entity(Of AgentCollector).Property(Function(t) t.AgentName).HasMaxLength(100)
            modelBuilder.Entity(Of AgentCollector).Property(Function(t) t.AgentClass).HasMaxLength(100)
            modelBuilder.Entity(Of AgentCollector).Property(Function(t) t.AgentProperty).HasMaxLength(100)

            'GroupName Table
            modelBuilder.Entity(Of GroupNames).HasKey(Function(t) t.GroupID)
            modelBuilder.Entity(Of GroupNames).Property(Function(t) t.GroupName).HasMaxLength(150)
            modelBuilder.Entity(Of GroupNames).Property(Function(t) t.GroupType).HasMaxLength(150)
            modelBuilder.Entity(Of GroupNames).Property(Function(t) t.GroupDescription).HasMaxLength(1000)

            'GroupMembers Table
            modelBuilder.Entity(Of GroupMembers).HasKey(Function(t) t.MemberID)
            modelBuilder.Entity(Of GroupMembers).Property(Function(t) t.GroupName).HasMaxLength(150)
            modelBuilder.Entity(Of GroupMembers).Property(Function(t) t.MemberName).HasMaxLength(100)


            'Policy Table
            modelBuilder.Entity(Of Policy).HasKey(Function(t) t.PolicyID)
            modelBuilder.Entity(Of Policy).Property(Function(t) t.PolicyName).HasMaxLength(100)
            modelBuilder.Entity(Of Policy).Property(Function(t) t.PolicyClass).HasMaxLength(50)
            modelBuilder.Entity(Of Policy).Property(Function(t) t.PolicyParameter).HasMaxLength(250)
            modelBuilder.Entity(Of Policy).Property(Function(t) t.PolicyValue).HasMaxLength(100)

        End Sub



        ' Add a DbSet for each entity type that you want to include in your model. For more information 
        ' on configuring and using a Code First model, see http:'go.microsoft.com/fwlink/?LinkId=390109.

        Public Overridable Property Agent As DbSet(Of AgentSystem)
        Public Overridable Property AgentProcessor As DbSet(Of AgentProcessor)
        Public Overridable Property AgentMemory As DbSet(Of AgentMemory)
        Public Overridable Property AgentLogicalDisk As DbSet(Of AgentLogicalDisk)
        Public Overridable Property AgentService As DbSet(Of AgentService)
        Public Overridable Property AgentCollector As DbSet(Of AgentCollector)
        Public Overridable Property GroupNames As DbSet(Of GroupNames)
        Public Overridable Property GroupMembers As DbSet(Of GroupMembers)
        Public Overridable Property Policy As DbSet(Of Policy)


    End Class
End Namespace




