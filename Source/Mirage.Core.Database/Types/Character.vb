Imports Microsoft.EntityFrameworkCore
Imports Mirage.Core.Database.Types.Components
Imports Mirage.Core.Database.Types.Enumerations

Namespace Types
    Public Class Character
        Public Property CharacterId As Integer
        Public Property AccountId As Integer
        Public Property Name As String
        Public Property Sex As Sex
        Public Property JobId As Integer
        Public Property SpriteId As Integer
        Public Property Level As Leveling
        Public Property Vitals As Vitals
        Public Property Location As Location

        Public Sub New()
            Me.CharacterId = 0
            Me.AccountId = 0
            Me.Name = String.Empty
            Me.Sex = Sex.None
            Me.JobId = 0
            Me.SpriteId = 0
            Me.Level = New Leveling()
            Me.Vitals = New Vitals()
            Me.Location = New Location()
        End Sub

        Public Shared Sub RegisterComplexTypes(ByVal modelBuilder As ModelBuilder)
            Call modelBuilder.Entity(Of Character).OwnsOne(Function(e) e.Level)
            Call modelBuilder.Entity(Of Character).OwnsOne(Function(e) e.Vitals)
            Call modelBuilder.Entity(Of Character).OwnsOne(Function(e) e.Location)
        End Sub
    End Class
End Namespace