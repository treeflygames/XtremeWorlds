Imports Microsoft.EntityFrameworkCore

Namespace Types
    <PrimaryKey(NameOf(Character.Name))>
    Public Class Character
        Public Property Name As String
    End Class
End Namespace