﻿Imports Microsoft.EntityFrameworkCore
Imports Mirage.Core.Database.Types.Components
Imports Mirage.Core.Database.Types.Enumerations

Namespace Types
    <PrimaryKey(NameOf(Character.Name))>
    Public Class Character
        Public Property Name As String
        Public Property Sex As Sex
        Public Property Location As Location

        Public Sub New()
            Me.Name = String.Empty
            Me.Sex = Sex.None
            Me.Location = New Location()
        End Sub

        Public Shared Sub RegisterComplexTypes(ByVal modelBuilder As ModelBuilder)
            Call modelBuilder.Entity(Of Character).OwnsOne(Function(e) e.Location)
        End Sub
    End Class
End Namespace