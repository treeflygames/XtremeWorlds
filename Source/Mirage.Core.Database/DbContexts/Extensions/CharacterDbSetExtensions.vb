Imports System.Runtime.CompilerServices
Imports Microsoft.EntityFrameworkCore
Imports Mirage.Core.Database.Types

Namespace DbContexts.Extensions
    Module CharacterDbSetExtensions
        <Extension()>
        Public Function Add(ByVal dbset As DbSet(Of Character), ByVal name As String) As Boolean
            If String.IsNullOrWhiteSpace(name) Then
                Throw New ArgumentException($"'{NameOf(name)}' cannot be null or whitespace.", NameOf(name))
            End If

            If Not dbset.Exists(name) Then
                Dim character As New Character With {
                    .Name = name
                }

                If character IsNot Nothing Then
                    Dim unused = dbset.Add(character)
                    Return True
                End If
            End If

            Return False
        End Function

        <Extension()>
        Public Function Exists(ByVal dbset As DbSet(Of Character), ByVal name As String) As Boolean
            If String.IsNullOrWhiteSpace(name) Then
                Throw New ArgumentException($"'{NameOf(name)}' cannot be null or whitespace.", NameOf(name))
            End If

            Return (From c In dbset
                    Where Trim(c.Name.ToLower()) = Trim$(name.ToLower())
                    Select c).FirstOrDefault() IsNot Nothing
        End Function

        <Extension()>
        Public Function Remove(ByVal dbset As DbSet(Of Character), ByVal name As String) As Boolean
            If String.IsNullOrWhiteSpace(name) Then
                Throw New ArgumentException($"'{NameOf(name)}' cannot be null or whitespace.", NameOf(name))
            End If

            If dbset.Exists(name) Then
                Dim character As Character = (From c In dbset
                                              Where Trim(c.Name.ToLower()) = Trim$(name.ToLower())
                                              Select c).FirstOrDefault()

                If character IsNot Nothing Then
                    Dim unused = dbset.Remove(character)
                    Return True
                End If
            End If

            Return False
        End Function
    End Module
End Namespace