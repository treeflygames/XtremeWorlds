Imports System.IO
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Mirage.Core.Database.Types

Namespace DbContexts
    Public Class MirageDbContext
        Inherits DbContext

        Private dbType As String
        Private connectionString As String
        Private ReadOnly configuration As IConfigurationRoot

        Public Property Characters As DbSet(Of Character)

        Public Sub New()
            MyBase.New()

            Dim builder As IConfigurationBuilder = New ConfigurationBuilder() _
                .SetBasePath(AppContext.BaseDirectory) _
                .AddJsonFile("appsettings.database.json", optional:=False, reloadOnChange:=True) _
                .AddJsonFile($"appsettings.database.{If(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Production")}.json", optional:=True, reloadOnChange:=True) _
                .AddUserSecrets(Of MirageDbContext)([optional]:=True, reloadOnChange:=True) _
                .AddEnvironmentVariables()

            Me.configuration = builder.Build()

            If String.IsNullOrWhiteSpace(Me.dbType) Then
                Me.dbType = Me.configuration("Database:Type")

                If String.IsNullOrWhiteSpace(Me.dbType) Then
                    Me.dbType = "Sqlite"
                End If
            End If

            If String.IsNullOrWhiteSpace(Me.connectionString) Then
                Me.connectionString = Me.configuration("Database:ConnectionString")

                If String.IsNullOrWhiteSpace(Me.connectionString) Then
                    Me.connectionString = "Data Source=Database/Mirage.db"
                End If
            End If

            If Me.connectionString.Contains("Filename=") OrElse Me.connectionString.Contains("Data Source=") Then
                Dim dbdir As String = Path.GetDirectoryName(Me.connectionString.Replace("Filename=", "").Replace("Data Source=", ""))

                If Not String.IsNullOrWhiteSpace(dbdir) AndAlso Not Directory.Exists(dbdir) Then
                    Dim unused = Directory.CreateDirectory(dbdir)
                End If
            End If
        End Sub

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            Select Case Trim$(Me.dbType.ToLower())
                Case "sqlite"
                    optionsBuilder = optionsBuilder.UseSqlite(Me.connectionString)
                Case "postgresql"
                    optionsBuilder = optionsBuilder.UseNpgsql(Me.connectionString)
                Case Else
                    Throw New NotSupportedException($"Database type '{Me.dbType}' is not supported.")
            End Select

            Console.WriteLine($"Database type '{Me.dbType}' has been configured.")
            MyBase.OnConfiguring(optionsBuilder)
        End Sub

        Public Function UseConnectionString(ByVal connectionString As String) As MirageDbContext
            If String.IsNullOrWhiteSpace(connectionString) Then
                Throw New ArgumentException($"'{NameOf(connectionString)}' cannot be null or whitespace.", NameOf(connectionString))
            End If

            If Me.connectionString.Contains("Filename=") OrElse Me.connectionString.Contains("Data Source=") Then
                Dim dbdir As String = Path.GetDirectoryName(Me.connectionString.Replace("Filename=", "").Replace("Data Source=", ""))

                If Not String.IsNullOrWhiteSpace(dbdir) AndAlso Not Directory.Exists(dbdir) Then
                    Dim unused = Directory.CreateDirectory(dbdir)
                End If
            End If

            Me.connectionString = connectionString

            Return Me
        End Function

        Public Function UseDatabaseType(ByVal dbtype As String) As MirageDbContext
            If String.IsNullOrWhiteSpace(dbtype) Then
                Throw New ArgumentException($"'{NameOf(dbtype)}' cannot be null or whitespace.", NameOf(dbtype))
            End If

            Me.dbType = dbtype

            Return Me
        End Function
    End Class
End Namespace