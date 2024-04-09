Namespace Types.Enumerations
    <Flags>
    Public Enum Stat As Byte
        None = 0

        Strength = 1 << 0
        Vitality = 1 << 1
        Luck = 1 << 2
        Intelligence = 1 << 3
        Spirit = 1 << 4

        All = Strength Or Vitality Or Luck Or Intelligence Or Spirit
    End Enum
End Namespace
