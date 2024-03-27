Imports Microsoft.EntityFrameworkCore

Namespace Types
    <PrimaryKey(NameOf(Account.Login))>
    Public Class Account
        Public Property Login As String
        Public Property Password As String
        Public Property Banned As Integer

        Public Sub New()
            Me.Login = String.Empty
            Me.Password = String.Empty
            Me.Banned = 0
        End Sub
    End Class
End Namespace