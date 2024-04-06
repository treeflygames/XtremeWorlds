Namespace DbContexts.Attributes
    <AttributeUsage(AttributeTargets.Property)>
    Public Class MaxLengthAttribute
        Inherits Attribute

        Public Property Length As Integer

        Public Sub New(length As Integer)
            Me.Length = length
        End Sub
    End Class
End Namespace