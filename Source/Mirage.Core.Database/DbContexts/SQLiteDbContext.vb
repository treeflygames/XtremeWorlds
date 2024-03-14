Imports System.IO
Imports Microsoft.EntityFrameworkCore

Namespace DbContexts
    Public Class SQLiteDbContext
        Inherits MirageDbContext

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            Dim folder As Environment.SpecialFolder = Environment.SpecialFolder.LocalApplicationData
            Dim path As String = Environment.GetFolderPath(folder)

            If Not Directory.Exists(IO.Path.Join(path, "MirageWorlds")) Then
                Directory.CreateDirectory(IO.Path.Join(path, "MirageWorlds"))
            End If

            Dim unused = optionsBuilder.UseSqlite($"Data Source={IO.Path.Join(path, "MirageWorlds\Database.db")}")

            MyBase.OnConfiguring(optionsBuilder)
        End Sub
    End Class
End Namespace