Imports Microsoft.EntityFrameworkCore
Imports Mirage.Core.Database.Types

Namespace DbContexts
    Public Class MirageDbContext
        Inherits DbContext

        Private dbType As String
        Private connectionString As String

        Public Property Characters As DbSet(Of Character)

        Public Sub New()
            MyBase.New()

            ' TODO -> Implement configuration loading.
            ' TODO -> Load connection string.
            ' TODO -> Check for file path on connection string.
            ' TODO -> Check for database directory if required.

            Me.dbType = "Sqlite"
            Me.connectionString = $"Data Source=Database\GameData.db"
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

            MyBase.OnConfiguring(optionsBuilder)
        End Sub

        Public Function UseConnectionString(ByVal connectionString As String) As MirageDbContext
            If String.IsNullOrWhiteSpace(connectionString) Then
                Throw New ArgumentException($"'{NameOf(connectionString)}' cannot be null or whitespace.", NameOf(connectionString))
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