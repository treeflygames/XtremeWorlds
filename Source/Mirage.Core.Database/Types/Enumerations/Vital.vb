Namespace Types.Enumerations
    <Flags>
    Public Enum Vital As Byte
        None = 0

        Health = 1 << 0
        Mana = 1 << 1
        Stamina = 1 << 2

        All = Health Or Mana Or Stamina
    End Enum
End Namespace
