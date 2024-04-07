Namespace Types.Enumerations
    <Flags>
    Public Enum Sex As Byte
        None = 0

        Male = 1 << 0
        Female = 1 << 1

        All = Male Or Female
    End Enum
End Namespace
