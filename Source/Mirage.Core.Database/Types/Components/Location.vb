Imports Mirage.Core.Database.Types.Enumerations

Namespace Types.Components
    Public Class Location
        Public Property Map As Integer
        Public Property X As Byte
        Public Property Y As Byte
        Public Property Direction As Direction

        Public Sub New()
            Me.Map = 1
            Me.X = 0
            Me.Y = 0
            Me.Direction = Direction.Down
        End Sub

        Public Sub New(map As Integer, x As Byte, y As Byte, direction As Direction)
            Me.Map = map
            Me.X = x
            Me.Y = y
            Me.Direction = direction
        End Sub
    End Class
End Namespace