Imports Microsoft.EntityFrameworkCore

Namespace DbContexts
    Public Class PostgreSQLDbContext
        Inherits MirageDbContext

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            Dim unused = optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Username=postgres;Password=mirage;Database=mirage")

            MyBase.OnConfiguring(optionsBuilder)
        End Sub
    End Class
End Namespace