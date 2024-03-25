Imports Microsoft.EntityFrameworkCore

Namespace Types
    <PrimaryKey(NameOf(Character.Name))>
    Public Class Character
        Public Property Name As String

        Public Sub New()
            Me.Name = String.Empty
        End Sub
    End Class
End Namespace