Imports Microsoft.EntityFrameworkCore
Imports Mirage.Core.Database.Types

Namespace DbContexts
    Public MustInherit Class MirageDbContext
        Inherits DbContext

        Public ReadOnly Property Characters As DbSet(Of Character)
    End Class
End Namespace