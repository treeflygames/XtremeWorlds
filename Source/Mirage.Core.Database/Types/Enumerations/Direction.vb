Namespace Types.Enumerations
    <Flags>
    Public Enum Direction As Byte
        None = 0

        Up = 1 << 0
        Down = 1 << 1
        Left = 1 << 2
        Right = 1 << 3

        All = Up Or Down Or Left Or Right
    End Enum
End Namespace
