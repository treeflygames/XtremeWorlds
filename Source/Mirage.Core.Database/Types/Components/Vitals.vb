Imports Mirage.Core.Database.Types.Enumerations

Namespace Types.Components
    Public Class Vitals
        Public Property Health As Integer
        Public Property Mana As Integer
        Public Property Stamina As Integer

        Public Sub New()
            Me.Health = 0
            Me.Mana = 0
            Me.Stamina = 0
        End Sub

        Public Sub New(health As Integer, mana As Integer, stamina As Integer)
            Me.Health = health
            Me.Mana = mana
            Me.Stamina = stamina
        End Sub

        Public Function GetVital(ByVal vital As Vital) As Integer
            Select Case vital
                Case Vital.Health
                    Return Me.Health
                Case Vital.Mana
                    Return Me.Mana
                Case Vital.Stamina
                    Return Me.Stamina
                Case Vital.All
                    Return Me.Health + Me.Mana + Me.Stamina
                Case Else
                    Return 0
            End Select
        End Function

        Public Sub SetVital(ByVal vital As Vital, ByVal value As Integer)
            Select Case vital
                Case Vital.Health
                    Me.Health = value
                Case Vital.Mana
                    Me.Mana = value
                Case Vital.Stamina
                    Me.Stamina = value
                Case Vital.All
                    Me.Health = value
                    Me.Mana = value
                    Me.Stamina = value
            End Select
        End Sub
    End Class
End Namespace