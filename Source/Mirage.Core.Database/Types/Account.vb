Imports System.ComponentModel.DataAnnotations.Schema
Imports Microsoft.EntityFrameworkCore

Namespace Types
    Public Class Account
        Public Property AccountId As Integer
        Public Property Login As String
        Public Property Password As String
        Public Property Banned As Integer

        Public Sub New()
            Me.AccountId = 0
            Me.Login = String.Empty
            Me.Password = String.Empty
            Me.Banned = 0
        End Sub
    End Class
End Namespace